using HealthDiaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthDiaryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEntryPage : ContentPage
    {
        public AddEntryPage()
        {
            InitializeComponent();
        }
        async void Save_Clicked(object sender, EventArgs e) // логика при сохранении данных
        {
            var entry = new HealthEntry
            {
                Date = DateTime.Now, // дата
                Steps = int.Parse(steps.Text), // шаги
                SleepHours = double.Parse(sleep.Text), // сон
                Calories = int.Parse(calories.Text), // калории
                Pulse = int.Parse(pulse.Text), // пульс
                Pressure = int.Parse(pressure.Text), // давление
                Weight = double.Parse(weight.Text) // вес
            };

            await App.Database.SaveEntryAsync(entry);

            await Navigation.PopAsync();
        }
    }
}