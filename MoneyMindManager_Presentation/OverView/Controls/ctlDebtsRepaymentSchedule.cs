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
using LiveCharts.Wpf;
using MoneyMindManager_Business;
using MoneyMindManager_Presentation.Global;
using static MoneyMindManagerGlobal.clsDataColumns.clsReportClassess;

namespace MoneyMindManager_Presentation.OverView.Controls
{
    public partial class ctlDebtsRepaymentSchedule : UserControl
    {
        public ctlDebtsRepaymentSchedule()
        {
            InitializeComponent();
        }

        List<clsDebtRepaymentSchedule> _chartData;

        void _EmptyChart()
        {
            CartesianChart1.Series.Clear();
            CartesianChart1.AxisX.Clear();
            CartesianChart1.AxisY.Clear();
        }

        void LoadChart()
        {
            _EmptyChart();

            if (grbColumnsShape.Checked)
                LoadChartColumn(_chartData);
            else if (grbLinerShape.Checked)
                LoadChartLiner(_chartData);
        }

        public async Task LoadData()
        {

            _chartData = await clsReport.GetDebtsRepaymentSchedule(Convert.ToInt16(clsGlobal_UI.CurrentUser.AccountID));

            LoadChart();
        }

        void LoadChartColumn(List<clsDebtRepaymentSchedule> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;


            string[] labels = chartData.Select(x => GetMonthName(x.mon, x.Year)).ToArray();

            CartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "المستحقات لك",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.Receivable)),
                    Fill = System.Windows.Media.Brushes.SeaGreen,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new ColumnSeries
                {
                    Title = "المستحقات عليك",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.Payables)),
                    Fill = System.Windows.Media.Brushes.Crimson,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new LineSeries // <--- تحويل إلى خط
                {
                    Title = "صافي التدفق النقدي",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.NetCashFlow)),

                    Stroke = System.Windows.Media.Brushes.CornflowerBlue,
                    StrokeThickness = 3,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    LineSmoothness = 0.8,
                    PointGeometry = LiveCharts.Wpf.DefaultGeometries.Circle,
                    PointGeometrySize = 12,

                    DataLabels = false,
                    LabelPoint = point => point.Y.ToString("N0")
                }

            };

            CartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Labels = labels,
                Title = "الشهر",
                Separator = new Separator { Step = 1 },

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 15,
            });


            string currency = clsGlobal_UI.CurrentUser?.AccountInfo?.DefaultCurrencyInfo?.CurrencySymbol;

            CartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = $"القيمة ({currency})",
                LabelFormatter = value => value.ToString("N0"),
                
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

        void LoadChartLiner(List<clsDebtRepaymentSchedule> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;

            string[] labels = chartData.Select(x => GetMonthName(x.mon, x.Year)).ToArray();

            CartesianChart1.Series = new SeriesCollection
            {
                new LineSeries 
                {
                    Title = "المستحقات لك",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.Receivable)),

                    Fill = System.Windows.Media.Brushes.Transparent,
                    LineSmoothness = 0.8,

                    Stroke = System.Windows.Media.Brushes.DarkGreen,
                    StrokeThickness = 2.5,

                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,

                    DataLabels = false,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new LineSeries
                {
                   Title = "المستحقات عليك",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.Payables)),
                    
                    Fill = System.Windows.Media.Brushes.Transparent,
                    LineSmoothness = 0.8,
                    StrokeThickness = 2.5,
                    Stroke = System.Windows.Media.Brushes.DarkRed,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,

                    DataLabels = false,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                 new LineSeries
                {
                    Title = "صافي التدفق النقدي",
                    LineSmoothness = 0.8,
                    Values = new ChartValues<decimal>(chartData.Select(x => x.NetCashFlow)),
                    Stroke = System.Windows.Media.Brushes.CornflowerBlue,
                    StrokeThickness = 3,

                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(120, 100, 149, 237)),
                    PointGeometry = LiveCharts.Wpf.DefaultGeometries.Circle,
                    PointGeometrySize = 12,

                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                }

            };

            string currency = clsGlobal_UI.CurrentUser?.AccountInfo?.DefaultCurrencyInfo?.CurrencySymbol;

            CartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Labels = labels,
                Title = "الشهر",
                Separator = new Separator { Step = 1 },

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 14
            });

            CartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = $"القيمة ({currency})",
                LabelFormatter = value => value.ToString("N0"),

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 14
            });

            CartesianChart1.Update();
        }

        private void grbColumnsShape_CheckedChanged(object sender, EventArgs e)
        {
            LoadChart();
        }

        private void ctrlMonthlyFlow_Load(object sender, EventArgs e)
        {
            CartesianChart1.LegendLocation = LegendLocation.Top;
            CartesianChart1.DefaultLegend.FontSize = 15;
            CartesianChart1.DataTooltip.FontSize = 14;
        }
    }
}
