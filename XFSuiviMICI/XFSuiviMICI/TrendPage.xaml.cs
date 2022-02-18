using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSuiviMICI.Models;

namespace XFSuiviMICI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrendPage : ContentPage
    {
        PlotModel GraphPlot = new PlotModel();
        
        public TrendPage()
        {
            InitializeComponent();

        }

        private void buttonTrend_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var labWorkTable = conn.Table<LabWork>().ToList();
                
                //countTest.Text = labWorkTable.Select(s => s.TestName).Distinct().Count().ToString();
                //Distinct().Count().ToString();

                var labWorkDates = conn.Table<LabWork>().ToList().Select(s => s.DateLabWork);
                var labWorkValues = conn.Table<LabWork>().ToList().Select(s => s.TestValue);
                var labWorkCoordinates = conn.Table<LabWork>().ToList().Select(s => new { s.DateLabWork, s.TestValue });

                float min = 1000;
                foreach (var val in labWorkCoordinates)
                { 
                    if (val.TestValue < min)
                    {
                        min = val.TestValue;
                        var x = val.DateLabWork;
                        var y = val.TestValue;
                    }
                };

               

                PlotModel GraphModel = new PlotModel
                {
                    Title = "Test"
                };

                BindingContext = GraphModel;

                GraphModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
                GraphModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });

                var series1 = new LineSeries
                {
                    Title = "Data",
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 4,
                    MarkerStroke = OxyColors.White
                };

                //Add data point
                series1.Points.Add(new DataPoint(0.0, 6.0));
                series1.Points.Add(new DataPoint(1.4, 2.1));
                series1.Points.Add(new DataPoint(2.0, 4.2));
                series1.Points.Add(new DataPoint(3.3, 2.3));
                series1.Points.Add(new DataPoint(4.7, 7.4));
                series1.Points.Add(new DataPoint(6.0, 6.2));
                series1.Points.Add(new DataPoint(8.9, 8.9));

                //Add data column
                GraphModel.Series.Add(series1);

                
            }
        }

        public class OxyData
        {
            public PlotModel PlotModel { get; set; }

            public OxyData()
            {
                PlotModel = CreatePlotModel();
            }
            public PlotModel CreatePlotModel()
            {
                var plotModel = new PlotModel
                {
                    Title = "Test Oxyplot"
                };

                //Add Axis
                plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
                plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });

                //Create data column
                var series1 = new LineSeries
                {
                    Title = "Data",
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 4,
                    MarkerStroke = OxyColors.White
                };

                //Add data point
                series1.Points.Add(new DataPoint(0.0, 6.0));
                series1.Points.Add(new DataPoint(1.4, 2.1));
                series1.Points.Add(new DataPoint(2.0, 4.2));
                series1.Points.Add(new DataPoint(3.3, 2.3));
                series1.Points.Add(new DataPoint(4.7, 7.4));
                series1.Points.Add(new DataPoint(6.0, 6.2));
                series1.Points.Add(new DataPoint(8.9, 8.9));

                //Add data column
                plotModel.Series.Add(series1);

                return plotModel;
            }
        }
    }
}