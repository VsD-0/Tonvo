using ReactiveUI.Fody.Helpers;
using Tonvo.Core;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tonvo.MVVM.Models;

namespace Tonvo.Models
{
    internal class Vacancy : ObservableObject, IModel
    {
        //TODO: Добавить свойства и валидацию данных в класс
        [Reactive]
        public int Id { get; set; }
        [Reactive]
        public string VacancyName { get; set; }
        [Reactive]
        public string VacancySalary { get; set; }
        [Reactive]
        public string CompanyName { get; set; }
    }
}
