using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using KhaledControlLibrary1;
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using static MoneyMindManagerGlobal.clsDataColumns.clsReportClassess;

namespace MoneyMindManager_Presentation.OverView.Controls
{
    public partial class ctrlTopDebtorsRanking : UserControl
    {
        public ctrlTopDebtorsRanking()
        {
            InitializeComponent();
        }

        //List<clsTopDebtorsRanking> _chartData;

        void _EmptyChart()
        {
            CartesianChart1.Series.Clear();
            CartesianChart1.AxisX.Clear();
            CartesianChart1.AxisY.Clear();
        }

        //void LoadChart()
        //{
        //    _EmptyChart();
        //    LoadChartColumn(_chartData);
        //}

        public async Task LoadData()
        {
            bool isLending = false;

            if (gcbDebtType.Text == "الدائنون لي")
                isLending = false;
            else if (gcbDebtType.Text == "المدينون لي")
                isLending = true;
            else
            {
                clsGlobalMessageBoxs.ShowErrorMessage("خطأ في تحديد نوع الدين !");
                return;
            }

           var chartData = await clsReport.GetTopDebtorsRanking(isLending, Convert.ToInt16(clsGlobal_UI.CurrentUser.AccountID));

            //LoadChart();
            _EmptyChart();
            LoadChartColumn(chartData);
        }


        void LoadChartColumn(List<clsTopDebtorsRanking> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;


            string[] labels = chartData.Select(x => x.PersonOrder.ToString()).ToArray();

            CartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "القيمة",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.PersonRemaining)),
                    Fill = System.Windows.Media.Brushes.SlateBlue,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },
            };

            CartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Labels = labels,
                Title = "الترتيب",
                Separator = new Separator { Step = 1 },

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 15,
            });


            string currency = clsGlobal_UI.CurrentUser?.AccountInfo?.DefaultCurrencyInfo?.CurrencySymbol;

            CartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = $"القيمة ({currency})",
                LabelFormatter = value => value.ToString("N0") + $" {currency}",

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 15
            });

            CartesianChart1.Update();
        }

        private string GetMonthName(byte? monthNumber, short? year)
        {
            if (monthNumber == null || year == null)
                return "السابق";

            return new DateTime(Convert.ToInt32(year), Convert.ToInt32(monthNumber), 1).ToString("MMM - yyyy");
        }

        private void ctrlMonthlyFlow_Load(object sender, EventArgs e)
        {
            CartesianChart1.LegendLocation = LegendLocation.Top;
        }

        private async void gcbDebtType_SelectedIndexChanged(object sender, EventArgs e)
        {
          await  LoadData();
        }
    }
}
