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
        async void Save_Clicked(object sender, EventArgs e)
        {
            var entry = new HealthEntry
            {
                Date = DateTime.Now,
                Steps = int.Parse(steps.Text),
                SleepHours = double.Parse(sleep.Text),
                Calories = int.Parse(calories.Text),
                Pulse = int.Parse(pulse.Text),
                Pressure = int.Parse(pressure.Text),
                Weight = double.Parse(weight.Text)
            };

            await App.Database.SaveEntryAsync(entry);

            await Navigation.PopAsync();
        }
    }
}