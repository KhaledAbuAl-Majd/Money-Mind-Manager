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
using LiveCharts;
using LiveCharts.Wpf;
using MoneyMindManager_Business;
using static MoneyMindManagerGlobal.clsDataColumns.clsReportClassess;

namespace MoneyMindManager_Presentation.OverView.Controls
{
    public partial class ctrlMonthlyFlow : UserControl
    {
        public ctrlMonthlyFlow()
        {
            InitializeComponent();
        }

        async Task LoadMonthlyChart()
        {
            List<clsMonthlyFlow> chartData = await clsReport.GetMonthlyFlow(Convert.ToInt32(clsGlobal_UI.CurrentUser.AccountID));

            LoadMonthlyChartColumn(chartData);
            //LoadMonthlyChartLiner(chartData);
        }

        public async Task LoadData()
        {
            await LoadMonthlyChart();
        }

        void LoadMonthlyChartColumn(List<clsMonthlyFlow> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;

            // 1. تنظيف وإعداد التسميات
            CartesianChart1.Series.Clear();
            CartesianChart1.AxisX.Clear();
            CartesianChart1.AxisY.Clear();

            // نستخدم Select لإنشاء تسميات المحور X (نحول الأرقام إلى نص)
            string[] labels = chartData.Select(x => GetMonthName(x.mon)).ToArray();

            // 2. ربط السلاسل
            CartesianChart1.Series = new SeriesCollection
            {
        // السلسلة 1: الإيرادات (Income)
                new ColumnSeries
                {
                    Title = "الإيرادات",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.Income)),
                    Fill = System.Windows.Media.Brushes.Green,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                // السلسلة 2: المصروفات الصافية (NetExpense)
                new ColumnSeries
                {
                    Title = "صافي المصروفات",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.NetExpense)),
                    Fill = System.Windows.Media.Brushes.Red,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                // السلسلة 2: المصروفات الصافية (NetCashFlow)
                //new ColumnSeries
                //{
                //    Title = "صافي التدفق النقدي",
                //    Values = new ChartValues<decimal>(chartData.Select(x => x.NetCashFlow)),
                //    Fill = System.Windows.Media.Brushes.CornflowerBlue,
                //    DataLabels = true,
                //    LabelPoint = point => point.Y.ToString("N0")
                //}

                new LineSeries // <--- تحويل إلى خط
                {
                    Title = "صافي التدفق النقدي",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.NetCashFlow)),
        
                    // لون الخط نفسه
                    Stroke = System.Windows.Media.Brushes.CornflowerBlue,
                    StrokeThickness = 3,
        
                    // لا نريد تعبئة Area، لذا نجعل Fill شفاف
                    Fill = System.Windows.Media.Brushes.Transparent, 
        
                    // إظهار النقاط على الخط (لتحسين التمييز)
                    PointGeometry = LiveCharts.Wpf.DefaultGeometries.Circle,
                    PointGeometrySize = 10,

                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                }
            };

            // 3. إعداد المحاور
            CartesianChart1.AxisX.Add(new Axis
            {
                Labels = labels,
                Title = "الشهر",
                Separator = new Separator { Step = 1 },

                Foreground = System.Windows.Media.Brushes.Black, // اللون الأبيض
                FontSize = 15
            });

            
            string currency = clsGlobal_UI.CurrentUser?.AccountInfo?.DefaultCurrencyInfo?.CurrencySymbol;

            CartesianChart1.AxisY.Add(new Axis
            {
                Title = $"القيمة ({currency})",
                LabelFormatter = value => value.ToString("N0") + $" {currency}",

                // --- خصائص النص (Styling the Labels) ---
                Foreground = System.Windows.Media.Brushes.Black, // اللون الأبيض
                FontSize = 15
            });

            CartesianChart1.LegendLocation = LegendLocation.Top; 

            // 4. تحديث الكنترول (هام لـ WinForms)
            CartesianChart1.Update();
        }

        //دالة مساعدة لتحويل رقم الشهر إلى اسم(لتحسين شكل العرض)
        private string GetMonthName(int monthNumber)
        {
            // يجب التعامل مع هذا بعناية إذا كنت تستهدف لغات متعددة
            return new DateTime(2000, monthNumber, 1).ToString("MMM");
        }

        void LoadMonthlyChartLiner(List<clsMonthlyFlow> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;

            // 1. تنظيف وإعداد التسميات
            CartesianChart1.Series.Clear();
            CartesianChart1.AxisX.Clear();
            CartesianChart1.AxisY.Clear();

            // نستخدم Select لإنشاء تسميات المحور X (نحول الأرقام إلى نص)
            string[] labels = chartData.Select(x => GetMonthName(x.mon)).ToArray();

            // 2. ربط السلاسل
            CartesianChart1.Series = new SeriesCollection
    {
        // === السلسلة 1: الإيرادات (Income) - LineSeries/AreaSeries ===
        new LineSeries // <--- التعديل هنا لجعله خطي
        {
            Title = "الإيرادات",
            Values = new ChartValues<decimal>(chartData.Select(x => x.Income)),
            
            // Fill: تعبئة المنطقة أسفل الخط (مهم للحصول على شكل المنطقة)
            //Fill = System.Windows.Media.Brushes.Green, 
            Fill = System.Windows.Media.Brushes.Transparent, 
            
            // Stroke: لون الخط نفسه
            Stroke = System.Windows.Media.Brushes.DarkGreen, 
            
            // Point Geometry: لإظهار النقاط على الخط (مثل الدوائر في الصورة)
            PointGeometry = DefaultGeometries.Circle,
            PointGeometrySize = 8,

            // يمكنك إزالة DataLabels هنا لتجنب الازدحام
            DataLabels = false,
            LabelPoint = point => point.Y.ToString("N0")
        },
        
        // === السلسلة 2: المصروفات الصافية (NetExpense) - LineSeries/AreaSeries ===
        new LineSeries // <--- التعديل هنا لجعله خطي
        {
            Title = "المصروفات الصافية",
            Values = new ChartValues<decimal>(chartData.Select(x => x.NetExpense)),
            
            // Fill: تعبئة المنطقة أسفل الخط (لون مختلف)
            //Fill = System.Windows.Media.Brushes.Red,
            Fill = System.Windows.Media.Brushes.Transparent,
            
            // Stroke: لون الخط نفسه
            Stroke = System.Windows.Media.Brushes.DarkRed, 
            
            // Point Geometry: لإظهار النقاط
            PointGeometry = DefaultGeometries.Circle,
            PointGeometrySize = 8,

            DataLabels = false,
            LabelPoint = point => point.Y.ToString("N0")
        },

        new LineSeries // <--- تحويل إلى خط
                {
                    Title = "صافي التدفق النقدي",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.NetCashFlow)),
        
                    // لون الخط نفسه
                    Stroke = System.Windows.Media.Brushes.CornflowerBlue,
                    StrokeThickness = 3,
        
                    // لا نريد تعبئة Area، لذا نجعل Fill شفاف
                    //Fill = System.Windows.Media.Brushes.Transparent,
                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(120, 100, 149, 237)), 
        
                    // إظهار النقاط على الخط (لتحسين التمييز)
                    PointGeometry = LiveCharts.Wpf.DefaultGeometries.Circle,
                    PointGeometrySize = 10,

                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                }
        
        // ملاحظة: قمت بتجاهل السلاسل المُعلقة مؤقتاً
    };

            // 3. إعداد المحاور (يبقى كما هو)
            string currency = clsGlobal_UI.CurrentUser?.AccountInfo?.DefaultCurrencyInfo?.CurrencySymbol;

            CartesianChart1.AxisX.Add(new Axis
            {
                Labels = labels,
                Title = "الشهر",
                Separator = new Separator { Step = 1 },

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 14
            });

            CartesianChart1.AxisY.Add(new Axis
            {
                Title = $"القيمة ({currency})",
                LabelFormatter = value => value.ToString("N0") + $" {currency}",

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 14
            });

            CartesianChart1.LegendLocation = LegendLocation.Top;

            // 4. تحديث الكنترول
            CartesianChart1.Update();
        }
    }
}
