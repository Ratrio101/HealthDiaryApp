using HealthDiaryApp.Database;
using HealthDiaryApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace HealthDiaryApp
{
    public partial class App : Application
    {

        static HealthDatabase database;

        public static HealthDatabase Database
        {
            get
            {
                if (database == null)
                {
                    var path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "health.db3");

                    database = new HealthDatabase(path);
                }

                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new TabbedPage
            {
                Children =
    {
        new NavigationPage(new MainPage()) { Title = "Дневник" },
        new NavigationPage(new ChartPage()) { Title = "Графики" }
    }
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
