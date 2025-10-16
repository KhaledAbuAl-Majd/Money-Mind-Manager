using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Drawing;
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
    public partial class ctrlDebtsMonthlyFlow : UserControl
    {
        public ctrlDebtsMonthlyFlow()
        {
            InitializeComponent();
        }

        List<clsDebtsMonthlyFlow> _chartData;

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
            if (!ValidateChildren())
            {
                _EmptyChart();
                return;
            }

            DateTime startDate = Convert.ToDateTime(kgtxtFromData.ValidatedText);
            DateTime endDate = Convert.ToDateTime(kgtxtToDate.ValidatedText);


            _chartData = await clsReport.GetDebtsMonthlyFlow(startDate, endDate, Convert.ToInt16(clsGlobal_UI.CurrentUser.AccountID));

            LoadChart();
        }

        public Brush GetBrush(string hexColor)
        {
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(hexColor));
        }
        void LoadChartColumn(List<clsDebtsMonthlyFlow> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;


            string[] labels = chartData.Select(x => GetMonthName(x.mon, x.Year)).ToArray();

            CartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "الإقراض",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.LendingDebtsSum)),
                    Fill = GetBrush("#0077B6"),
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new ColumnSeries
                {
                    Title = "الإقتراض",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.BorrowingDebtsSum)),
                  Fill = GetBrush("#6099B6"),
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                 new ColumnSeries
                {
                    Title = "سداد الإقراض",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.LendingPaymentsSum)),
                   Fill = GetBrush("#C74BFF"),
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                  new ColumnSeries
                {
                    Title = "سداد الإقتراض",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.BorrowingPaymentsSum)),
                    Fill =  GetBrush("#D99478"),
                    DataLabels = true,
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

        void LoadChartLiner(List<clsDebtsMonthlyFlow> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;

            // 1. تنظيف وإعداد التسميات

            // نستخدم Select لإنشاء تسميات المحور X (نحول الأرقام إلى نص)
            string[] labels = chartData.Select(x => GetMonthName(x.mon, x.Year)).ToArray();

            // 2. ربط السلاسل
            //    CartesianChart1.Series = new SeriesCollection
            //    {
            //// === السلسلة 1: الإيرادات (Income) - LineSeries/AreaSeries ===
            //        new LineSeries // <--- التعديل هنا لجعله خطي
            //        {
            //            Title = "الإقراض",
            //            Values = new ChartValues<decimal>(chartData.Select(x => x.LendingDebtsSum)),

            //            Fill = System.Windows.Media.Brushes.Transparent, 

            //            // Stroke: لون الخط نفسه
            //            Stroke = System.Windows.Media.Brushes.DarkCyan, 

            //            // Point Geometry: لإظهار النقاط على الخط (مثل الدوائر في الصورة)
            //            PointGeometry = DefaultGeometries.Circle,
            //            PointGeometrySize = 8,

            //            // يمكنك إزالة DataLabels هنا لتجنب الازدحام
            //            DataLabels = false,
            //            LabelPoint = point => point.Y.ToString("N0")
            //        },

            //        new LineSeries
            //        {
            //             Title = "الإقتراض",
            //            Values = new ChartValues<decimal>(chartData.Select(x => x.BorrowingDebtsSum)),

            //            Fill = System.Windows.Media.Brushes.Transparent,
            //            Stroke = System.Windows.Media.Brushes.Orange,
            //            PointGeometry = DefaultGeometries.Circle,
            //            PointGeometrySize = 8,

            //            DataLabels = false,
            //            LabelPoint = point => point.Y.ToString("N0")
            //        },

            //         new LineSeries
            //        {
            //             Title = "سداد الإقراض",
            //             Values = new ChartValues<decimal>(chartData.Select(x => x.LendingPaymentsSum)),

            //            Fill = System.Windows.Media.Brushes.Transparent,
            //            Stroke = System.Windows.Media.Brushes.Orange,
            //            PointGeometry = DefaultGeometries.Circle,
            //            PointGeometrySize = 8,

            //            DataLabels = false,
            //            LabelPoint = point => point.Y.ToString("N0")
            //        },

            //          new LineSeries
            //        {
            //             Title = "سداد الإقتراض",
            //              Values = new ChartValues<decimal>(chartData.Select(x => x.BorrowingPaymentsSum)),

            //            Fill = System.Windows.Media.Brushes.Transparent,
            //            Stroke = System.Windows.Media.Brushes.LightSkyBlue,
            //            PointGeometry = DefaultGeometries.Circle,
            //            PointGeometrySize = 8,

            //            DataLabels = false,
            //            LabelPoint = point => point.Y.ToString("N0")
            //        }


            //    };

            // استخدم هذه الدالة لتحويل الألوان (كما اتفقنا سابقاً)
            // public Brush GetBrush(string hexColor) => new SolidColorBrush((Color)ColorConverter.ConvertFromString(hexColor));

            CartesianChart1.Series = new SeriesCollection
            {
                // === 1. الإقراض (القيمة الأساسية - خط متصل وسميك) ===
                new LineSeries
                {
                    Title = "الإقراض",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.LendingDebtsSum)),
                    Fill = System.Windows.Media.Brushes.Transparent,
                   Stroke = GetBrush("#0A4C75"),
                    PointForeground = GetBrush("#0A4C75"), // الأزرق الأطلسي
                    StrokeThickness = 3, // جعل الخط أسمك
        
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10, // تكبير النقطة قليلاً

                    // (DataLabels = false, LabelPoint = ...)
                },

                // === 2. الاقتراض (القيمة الأساسية - خط متصل وسميك) ===
                new LineSeries
                {
                    Title = "الإقتراض",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.BorrowingDebtsSum)),
                    Fill = System.Windows.Media.Brushes.Transparent,
                  Stroke = GetBrush("#6099B6"),
        PointForeground = GetBrush("#6099B6"),
                    StrokeThickness = 3,

                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                },

                // === 3. سداد الإقراض (السداد - خط متقطع ورقيق) ===
                new LineSeries
                {
                    Title = "سداد الإقراض",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.LendingPaymentsSum)),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = GetBrush("#C74BFF"), // البنفسجي المشرق
                    StrokeThickness = 2, // خط أرق
                    StrokeDashArray = new DoubleCollection { 4, 4 }, // إضافة تنقيط (Dash) لتمييز السداد

                    PointGeometry = DefaultGeometries.Diamond, // تغيير شكل النقطة للتمييز
                    PointGeometrySize = 7,
                    PointForeground = GetBrush("#C74BFF")
                },

                // === 4. سداد الاقتراض (السداد - خط متقطع ورقيق) ===
                new LineSeries
                {
                    Title = "سداد الإقتراض",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.BorrowingPaymentsSum)),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = GetBrush("#D99478"),
        PointForeground = GetBrush("#D99478"),
                    StrokeThickness = 2,
                    StrokeDashArray = new DoubleCollection { 4, 4 }, // إضافة تنقيط

                    PointGeometry = DefaultGeometries.Diamond, // تغيير شكل النقطة للتمييز
                    PointGeometrySize = 7,
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
            LoadChart();
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
            if (_IsSkipNumberOfMonths(Convert.ToDateTime(kgtxtFromData.Text), Convert.ToDateTime(kgtxtToDate.Text), 4))
            {
                KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
                e.Cancel = true;
                errorProvider1.SetError(kgtxt, "أقصى عدد من الشهور هو 4 شهرا مختلفين !");
            }
            else
            {
                kgtxt_OnValidationSuccess(sender, e);
            }
        }
        private void ctrlMonthlyFlow_Load(object sender, EventArgs e)
        {
            DateTime bofore12Month = DateTime.Today.AddMonths(-3);
            kgtxtToDate.RefreshNumber_DateTimeFormattedText(DateTime.Today.ToString());
            kgtxtFromData.RefreshNumber_DateTimeFormattedText(new DateTime(bofore12Month.Year,bofore12Month.Month,1).ToString());

            CartesianChart1.LegendLocation = LegendLocation.Top;
        }

        private async void gibtnFindPerson_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void kgtxtFromData_TextChanged(object sender, EventArgs e)
        {

        }

        private void kgtxtToDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void ctrlInfoIcon1_Load(object sender, EventArgs e)
        {

        }
    }
}
