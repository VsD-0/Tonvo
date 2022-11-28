using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tonvo.Core;

namespace Tonvo.MVVM.ViewModels
{
    class ControlButtonsViewModel
    {
        public GlobalViewModel Global { get; } = GlobalViewModel.Instance;
        public ControlButtonsViewModel()
        {
        }
    }
}
