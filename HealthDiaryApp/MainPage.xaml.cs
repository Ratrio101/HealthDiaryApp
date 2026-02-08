using HealthDiaryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDiaryApp
{
    public partial class MainPage : ContentPage
    {
        MainViewModel vm;

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

        async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.AddEntryPage());
        }
        void StartReminderTimer()
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