using System;
using Tonvo.MVVM.Models;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace Tonvo.Services
{
    internal static class DataStorage
    {
        // TODO: Оптимизировать
        private const string _vacancyDSNameFile = "\\VacancyDataStorage.json";
        private const string _companyDSNameFile = "\\CompanyDataStorage.json";
        private const string _applicantDSNameFile = "\\ApplicantDataStorage.json";

        private static string _pathToSaveApplicant;
        private static string _pathToSaveCompany;
        private static string _pathToSaveVacancy;
        private static string _currentPath;

        private static ObservableCollection<Applicant> readedApplicant;
        private static ObservableCollection<Vacancy> readedVacancy;
        private static ObservableCollection<Company> readedCompany;

        // Путь к файлу
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().Location;
                UriBuilder uri = new(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }


        public static string CurrentPath(IModel acc)
        {
            try
            {
                return acc.GetType().ToString() switch
                {
                    "Tonvo.MVVM.Models.Applicant" => _currentPath = _pathToSaveApplicant,
                    "Tonvo.MVVM.Models.Company" => _currentPath = _pathToSaveCompany,
                    "Tonvo.MVVM.Models.Vacancy" => _currentPath = _pathToSaveVacancy,
                    _ => throw new Exception("Некоректный тип входных данных"),
                };
            }
            catch { return null; }
        }

        // Создание файла dataStorage.json
        public static void Init()
        {
            _pathToSaveApplicant = AssemblyDirectory + _applicantDSNameFile;
            if (!File.Exists(_pathToSaveApplicant)) File.WriteAllText(_pathToSaveApplicant, "[]");

            _pathToSaveCompany = AssemblyDirectory + _companyDSNameFile;
            if (!File.Exists(_pathToSaveCompany)) File.WriteAllText(_pathToSaveCompany, "[]");

            _pathToSaveVacancy = AssemblyDirectory + _vacancyDSNameFile;
            if (!File.Exists(_pathToSaveVacancy)) File.WriteAllText(_pathToSaveVacancy, "[]");
        }

        // команда добавления нового объекта
        public static void AddApplicant(Applicant acc)
        {
            try
            {
                CurrentPath(acc);
                if (_currentPath == _pathToSaveApplicant)
                {
                    readedApplicant = ReadApplicantsJson();
                    readedApplicant.Insert(0, acc);
                    SaveDataList(readedApplicant);
                }
            }
            catch (Exception ex) { System.Windows.MessageBox.Show("Ошибка чтения данных, очистите файл dataStorage.json\n" + ex.Message + "\n" + ex.StackTrace); }
        }
        public static void AddVacancy(Vacancy acc)
        {
            try
            {
                CurrentPath(acc);
                if (_currentPath == _pathToSaveVacancy)
                {
                    readedVacancy = ReadVacancyJson();
                    readedVacancy.Insert(0, acc);
                    SaveDataList(readedVacancy);
                }
            }
            catch (Exception ex) { System.Windows.MessageBox.Show("Ошибка чтения данных, очистите файл dataStorage.json\n" + ex.Message + "\n" + ex.StackTrace); }
        }
        public static void AddCompany(Company acc)
        {
            try
            {
                CurrentPath(acc);
                if (_currentPath == _pathToSaveCompany)
                {
                    readedCompany = ReadCompanyJson();
                    readedCompany.Insert(0, acc);
                    SaveDataList(readedCompany);
                }
            }
            catch (Exception ex) { System.Windows.MessageBox.Show("Ошибка чтения данных, очистите файл dataStorage.json\n" + ex.Message + "\n" + ex.StackTrace); }
        }

        // Команда удаления
        public static void Remove(IModel acc)
        {
            CurrentPath(acc);
            if (_currentPath == _pathToSaveApplicant)
            {
                readedApplicant = ReadApplicantsJson();
                foreach (var item in readedApplicant)
                {
                    if (acc.Id.Equals(item.Id)) readedApplicant.Remove(item);
                }
                SaveDataList(readedApplicant);// TODO: Доделать
            }
            else if (_currentPath == _pathToSaveCompany)
            {
                readedCompany = ReadCompanyJson();
                return;
            }
            else if (_currentPath == _pathToSaveVacancy)
            {
                readedVacancy = ReadVacancyJson();
                return;
            }
        }
        
        // Чтение файла
        public static void ReadJson(IModel acc)
        {
            CurrentPath(acc);
            if(_currentPath == _pathToSaveApplicant)
            {
                readedApplicant = ReadApplicantsJson();
                return;
            }
            else if(_currentPath == _pathToSaveCompany)
            {
                readedCompany = ReadCompanyJson();
                return;
            }
            else if(_currentPath == _pathToSaveVacancy)
            {
                readedVacancy = ReadVacancyJson();
                return;
            }
        }

        public static ObservableCollection<Applicant> ReadApplicantsJson()
        {
            return JsonConvert.DeserializeObject<ObservableCollection<Applicant>>(File.ReadAllText(AssemblyDirectory + _applicantDSNameFile));
        }
        public static ObservableCollection<Vacancy> ReadVacancyJson()
        {
            return JsonConvert.DeserializeObject<ObservableCollection<Vacancy>>(File.ReadAllText(AssemblyDirectory + _vacancyDSNameFile));
        }
        public static ObservableCollection<Company> ReadCompanyJson()
        {
            return JsonConvert.DeserializeObject<ObservableCollection<Company>>(File.ReadAllText(AssemblyDirectory + _companyDSNameFile));
        }

        // Конвертация списка
        public static ObservableCollection<IModel> ConvertListFromFile<T>(ObservableCollection<T> jsonlist)
        {
            ObservableCollection<IModel> convertedList = new();
            foreach (var item in jsonlist)
            {
                IModel obj = (IModel)item;
                convertedList.Add(obj);
            }
            return convertedList;
        }

        // Сохранение данных
        public static void SaveDataList<T>(T accs)
        {
            File.WriteAllText(_currentPath, JsonConvert.SerializeObject(accs, Formatting.Indented));
        }

        // Изменение объекта
        public static bool AccountChange(IModel replace)
        {
            int i = -1;
            CurrentPath(replace);
            ObservableCollection<IModel> readed = ConvertListFromFile(JsonConvert.DeserializeObject<ObservableCollection<Applicant>>(File.ReadAllText(_currentPath)));
            foreach (var item in readed) 
            {
                if(item.Id.Equals(replace.Id))
                {
                    i = readed.IndexOf(item);
                }
            }
            if (i == -1)
                return false;
            readed[i] = replace;
            SaveDataList(readed);
            return true;
        }
    }
}
