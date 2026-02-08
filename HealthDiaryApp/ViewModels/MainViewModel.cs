using HealthDiaryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HealthDiaryApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<HealthEntry> Entries { get; set; }

        public ICommand LoadCommand { get; }

        public MainViewModel()
        {
            Entries = new ObservableCollection<HealthEntry>();

            LoadCommand = new Command(async () => await LoadData());
        }

        async Task LoadData()
        {
            var list = await App.Database.GetEntriesAsync();

            Entries.Clear();

            foreach (var item in list)
                Entries.Add(item);
        }
    }
}
