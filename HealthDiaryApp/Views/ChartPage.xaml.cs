using HealthDiaryApp.Models;
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
        List<HealthEntry> entries;

        public ChartPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            entries = await App.Database.GetEntriesAsync();

            ShowWeightChart();
        }
        void ShowWeightChart()
        {
            chart.Chart = new LineChart
            {
                Entries = entries.Select(x =>
                    new ChartEntry((float)x.Weight)
                    {
                        Label = x.Date.ToShortDateString(),
                        ValueLabel = x.Weight.ToString(),
                        Color = SKColor.Parse("#3498db")
                    })
            };
        }

        void ShowSleepChart()
        {
            chart.Chart = new LineChart
            {
                Entries = entries.Select(x =>
                    new ChartEntry((float)x.SleepHours)
                    {
                        Label = x.Date.ToShortDateString(),
                        ValueLabel = x.SleepHours.ToString(),
                        Color = SKColor.Parse("#9b59b6")
                    })
            };
        }

        void ShowStepsChart()
        {
            chart.Chart = new LineChart
            {
                Entries = entries.Select(x =>
                    new ChartEntry((float)x.Steps)
                    {
                        Label = x.Date.ToShortDateString(),
                        ValueLabel = x.Steps.ToString(),
                        Color = SKColor.Parse("#2ecc71")
                    })
            };
        }

        void ShowPulseChart()
        {
            chart.Chart = new LineChart
            {
                Entries = entries.Select(x =>
                    new ChartEntry((float)x.Pulse)
                    {
                        Label = x.Date.ToShortDateString(),
                        ValueLabel = x.Pulse.ToString(),
                        Color = SKColor.Parse("#e74c3c")
                    })
            };
        }

        void Weight_Clicked(object sender, EventArgs e) => ShowWeightChart();
        void Sleep_Clicked(object sender, EventArgs e) => ShowSleepChart();
        void Steps_Clicked(object sender, EventArgs e) => ShowStepsChart();
        void Pulse_Clicked(object sender, EventArgs e) => ShowPulseChart();
    }
}