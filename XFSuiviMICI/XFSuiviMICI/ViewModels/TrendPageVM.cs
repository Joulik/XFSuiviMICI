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
                var dailyreports = conn.Table<DailyReport>().Select(s => s);

                foreach (var dailyreport in dailyreports)
                {
                    barSeries.Items.Add(new ColumnItem
                    {
                        Value = Convert.ToDouble(dailyreport.Weight)
                    });
                }

                model.Series.Add(barSeries);
                String[] xValues = new String[] { "0","1","2","3","4","5"}; 

                model.Axes.Add(new CategoryAxis
                {
                    Position = AxisPosition.Bottom,
                    Key = "Sample Data",
                    ItemsSource = xValues,
                    IsPanEnabled = false,
                    IsZoomEnabled = false,
                    Selectable = false,
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
