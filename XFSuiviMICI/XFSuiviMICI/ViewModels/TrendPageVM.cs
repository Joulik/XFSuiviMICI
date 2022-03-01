using OxyPlot;
using OxyPlot.Series;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using System.Text;
using XFSuiviMICI.Models;
using OxyPlot.Axes;

namespace XFSuiviMICI.ViewModels
{
    public class TrendPageVM : INotifyPropertyChanged
    {
        private PlotModel graphModel;
        public PlotModel GraphModel 
        { 
            get
            { return graphModel; }
            set 
            { graphModel = value; }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public TrendPageVM()
        {
            GraphModel = new PlotModel();
        }

        public void LoadGraph()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                GraphModel = null;
                OnPropertyChanged("GraphModel");

                var model = new PlotModel { Title = "Test" };
                var barSeries = new ColumnSeries { };
                var dailyreports = conn.Table<LabWork>().Select(s => s).OrderBy(s => s.DateLabWork);
                int nn = dailyreports.Count();
                List<string> datesList = new List<string>();

                foreach (var dailyreport in dailyreports)
                {
                    barSeries.Items.Add(new ColumnItem
                    {
                        Value = Convert.ToDouble(dailyreport.TestValue)
                    });
                    datesList.Add(dailyreport.DateLabWork.ToString("dd/MM/yyyy"));
                }

                model.Series.Add(barSeries);
                
                model.Axes.Add(new CategoryAxis
                {
                    Position = AxisPosition.Bottom,
                    Key = "Sample Data",
                    ItemsSource = datesList,
                    IsPanEnabled = false,
                    IsZoomEnabled = false,
                    Selectable = false,
                    Angle = 90,
                });

                GraphModel = model;
                OnPropertyChanged("GraphModel");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
