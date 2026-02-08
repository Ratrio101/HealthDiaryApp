using HealthDiaryApp.ViewModels;
using HealthDiaryApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.IO;

namespace HealthDiaryApp
{
    public partial class MainPage : ContentPage
    {
        MainViewModel vm; // VM

        public MainPage()
        {
            InitializeComponent();
            vm = new MainViewModel();
            BindingContext = vm;
            StartReminderTimer();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.LoadCommand.Execute(null);
        }

        async void Add_Clicked(object sender, EventArgs e) // нажатие на кнопку добавления
        {
            await Navigation.PushAsync(new AddEntryPage());
        }
        async void Charts_Clicked(object sender, EventArgs e) // нажатие на кнопку "Графики"
        {
            await Navigation.PushAsync(new ChartPage());
        }
        void StartReminderTimer() // логика работы таймера (в перспективе)
        {
            Device.StartTimer(TimeSpan.FromHours(3), () =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Напоминалочка!", "Введите данные здоровья", "OK");
                });

                return true; // повторять
            });
        }
    }
}