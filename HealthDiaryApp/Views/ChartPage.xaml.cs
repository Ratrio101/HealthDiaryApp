using Microcharts;
using SkiaSharp;
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
    public partial class ChartPage : ContentPage
    {
        public ChartPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var entries = await App.Database.GetEntriesAsync();

            var chartEntries = entries.Select(x =>
                new ChartEntry((float)x.Weight)
                {
                    Label = x.Date.ToShortDateString(),
                    ValueLabel = x.Weight.ToString(),
                    Color = SKColor.Parse("#2ecc71")
                }).ToList();

            chart.Chart = new LineChart
            {
                Entries = chartEntries
            };
        }
    }
}