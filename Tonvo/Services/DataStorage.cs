using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tonvo.Models;
using Newtonsoft.Json;
using System.IO;
using Tonvo.MVVM.Models;
using Microsoft.VisualBasic;
using System.CodeDom;
using System.Collections.ObjectModel;
using DynamicData;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Tonvo.Services
{
    internal static class DataStorage
    {
        //TODO: Оптимизировать
        private const string _vacancyDSNameFile = "\\VacancyDataStorage.json";
        private const string _companyDSNameFile = "\\CompanyDataStorage.json";
        private const string _applicantDSNameFile = "\\ApplicantDataStorage.json";

        private static string _pathToSaveApplicant;
        private static string _pathToSaveCompany;
        private static string _pathToSaveVacancy;
        private static string _currentPath;

        // Путь к файлу
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
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
                    "Tonvo.Models.Applicant" => _currentPath = _pathToSaveApplicant,
                    "Tonvo.Models.Company" => _currentPath = _pathToSaveCompany,
                    "Tonvo.Models.Vacancy" => _currentPath = _pathToSaveVacancy,
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
        public static void Add(IModel acc)
        {
            try
            {
                ObservableCollection<IModel> readed = ReadJson(acc);
                readed.Insert(0, acc);
                SaveDataList(readed);
            }
            catch (Exception ex) { System.Windows.MessageBox.Show("Ошибка чтения данных, очистите файл dataStorage.json\n" + ex.Message + "\n" + ex.StackTrace); }
        }

        // Команда удаления
        public static void Remove(IModel acc)
        {
            var readed = ReadJson(acc);
            readed.Remove(acc);
        }
        
        // Чтение файла
        public static ObservableCollection<IModel> ReadJson(IModel acc)
        {
            CurrentPath(acc);
            return ConvertListFromFile(JsonConvert.DeserializeObject<ObservableCollection<Applicant>>(File.ReadAllText(_currentPath)));
        }

        public static ObservableCollection<Applicant> ReadApplicantsJson()
        {
            return JsonConvert.DeserializeObject<ObservableCollection<Applicant>>(File.ReadAllText(AssemblyDirectory + _applicantDSNameFile));
        }
        public static ObservableCollection<Vacancy> ReadVacancyJson()
        {
            return JsonConvert.DeserializeObject<ObservableCollection<Vacancy>>(File.ReadAllText(AssemblyDirectory + _vacancyDSNameFile));
        }

        // Конвертация списка
        public static ObservableCollection<IModel> ConvertListFromFile<T>(ObservableCollection<T> jsonlist)
        {
            ObservableCollection<IModel> convertedList = new ObservableCollection<IModel>();
            foreach (var item in jsonlist)
            {
                IModel obj = (IModel)item;
                convertedList.Add(obj);
            }
            return convertedList;
        }

        // Сохранение данных
        public static void SaveDataList(ObservableCollection<IModel> accs)
        {
            CurrentPath(accs[0]);
            File.WriteAllText(_currentPath, JsonConvert.SerializeObject(accs, Formatting.Indented));
        }

        // Изменение объекта
        public static bool AccountChange(IModel replace, IModel toreplace)
        {
            ObservableCollection<IModel> readed = ReadJson(replace);
            int i = readed.IndexOf(toreplace);
            if (i == -1)
                return false;
            readed[i] = replace;
            SaveDataList(readed);
            return true;
        }
    }
}
