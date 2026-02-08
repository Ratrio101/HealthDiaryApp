using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HealthDiaryApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged // базовая VM
    {
        public event PropertyChangedEventHandler PropertyChanged; //автообновление интерфейса

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}