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
    public partial class ctrlMonthlyFlow : UserControl
    {
        public ctrlMonthlyFlow()
        {
            InitializeComponent();
        }

        List<clsMonthlyFlow> _chartData;

        void _EmptyChart()
        {
            CartesianChart1.Series.Clear();
            CartesianChart1.AxisX.Clear();
            CartesianChart1.AxisY.Clear();
        }
        void LoadMonthlyChart()
        {
            _EmptyChart();

            if (grbColumnsShape.Checked)
                LoadMonthlyChartColumn(_chartData);
            else if (grbLinerShape.Checked)
                LoadMonthlyChartLiner(_chartData);
        }

        public async Task LoadData()
        {
            if (!ValidateChildren())
            {
                _EmptyChart();
                return;
            }

            DateTime startDate = Convert.ToDateTime(kgtxtFromData.ValidatedText);
            DateTime endDate = Convert.ToDateTime(kgtxtToDate.ValidatedText);


            _chartData = await clsReport.GetMonthlyFlow(startDate, endDate, Convert.ToInt16(clsGlobal_UI.CurrentUser.AccountID));

            LoadMonthlyChart();
        }

        void LoadMonthlyChartColumn(List<clsMonthlyFlow> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;


            string[] labels = chartData.Select(x => GetMonthName(x.mon, x.Year)).ToArray();

            CartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "الإيرادات",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.Income)),
                    Fill = System.Windows.Media.Brushes.SeaGreen,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new ColumnSeries
                {
                    Title = "صافي المصروفات",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.NetExpense)),
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
                LabelFormatter = value => value.ToString("N0") + $" {currency}",
                
                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 15
            });

            CartesianChart1.Update();
        }

        private string GetMonthName(byte monthNumber, short year)
        {
            return new DateTime(year, monthNumber, 1).ToString("MMM - yyyy");
        }

        void LoadMonthlyChartLiner(List<clsMonthlyFlow> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;

            // 1. تنظيف وإعداد التسميات

            // نستخدم Select لإنشاء تسميات المحور X (نحول الأرقام إلى نص)
            string[] labels = chartData.Select(x => GetMonthName(x.mon, x.Year)).ToArray();

            // 2. ربط السلاسل
            CartesianChart1.Series = new SeriesCollection
            {
        // === السلسلة 1: الإيرادات (Income) - LineSeries/AreaSeries ===
                new LineSeries // <--- التعديل هنا لجعله خطي
                {
                    Title = "الإيرادات",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.Income)),

                    Fill = System.Windows.Media.Brushes.Transparent, 
            
                    // Stroke: لون الخط نفسه
                    Stroke = System.Windows.Media.Brushes.DarkGreen,
                    StrokeThickness = 2,
            
                    // Point Geometry: لإظهار النقاط على الخط (مثل الدوائر في الصورة)
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,

                    // يمكنك إزالة DataLabels هنا لتجنب الازدحام
                    DataLabels = false,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new LineSeries
                {
                    Title = "صافي المصروفات",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.NetExpense)),
                    
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.DarkRed,
                    StrokeThickness = 2,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,

                    DataLabels = false,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new LineSeries
                {
                    Title = "صافي التدفق النقدي",
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
                LabelFormatter = value => value.ToString("N0") + $" {currency}",

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 14
            });


            // 4. تحديث الكنترول
            CartesianChart1.Update();
        }

        private void grbColumnsShape_CheckedChanged(object sender, EventArgs e)
        {
            LoadMonthlyChart();
        }
        private void kgtxt_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsUtils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }

        bool _IsSkipNumberOfMonths(DateTime startDate,DateTime endDate,byte numOfMonths)
        {
            int months = Math.Abs((12 * (startDate.Year - endDate.Year)) + (startDate.Month - endDate.Month));

            months++;

            return months > numOfMonths;
        }

        private void kgtxtToDate_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            if (_IsSkipNumberOfMonths(Convert.ToDateTime(kgtxtFromData.Text), Convert.ToDateTime(kgtxtToDate.Text), 12))
            {
                KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
                e.Cancel = true;
                errorProvider1.SetError(kgtxt, "أقصى عدد من الشهور هو 12 شهرا مختلفين !");
            }
            else
            {
                kgtxt_OnValidationSuccess(sender, e);
            }
        }
        private void ctrlMonthlyFlow_Load(object sender, EventArgs e)
        {
            DateTime bofore12Month = DateTime.Today.AddMonths(-11);
            kgtxtToDate.RefreshNumber_DateTimeFormattedText(DateTime.Today.ToString());
            kgtxtFromData.RefreshNumber_DateTimeFormattedText(new DateTime(bofore12Month.Year,bofore12Month.Month,1).ToString());

            CartesianChart1.LegendLocation = LegendLocation.Top;
        }

        private async void gibtnFindPerson_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

    }
}
