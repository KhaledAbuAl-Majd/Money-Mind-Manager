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
using MoneyMindManager_Presentation.Income_And_Expense.Categories;
using static MoneyMindManagerGlobal.clsDataColumns.clsReportClassess;

namespace MoneyMindManager_Presentation.OverView.Controls
{
    public partial class ctrlCategoryMonthlyFlow : UserControl
    {
        public ctrlCategoryMonthlyFlow()
        {
            InitializeComponent();
        }

        List<clsCategoryMonthlyFlow> _chartData;

        int? _CategoryID = null;
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
                LoadChartColumn(_chartData);
            else if (grbLinerShape.Checked)
                LoadChartLiner(_chartData);
        }

        async Task _SelectCategory(int categoryID,string categoryName)
        {
            kgtxtCategoryName.Text = categoryName + "     ";
            _CategoryID = categoryID;
            await LoadData();
        }
        public async Task<bool> LoadData(int categoryID)
        {
            var category = await clsIncomeAndExpenseCategory.FindCategoryByCategoryID(categoryID);

            if (category == null)
                return false;

            await _SelectCategory(categoryID, category.CategoryName);

            return true;
        }

        private async Task LoadData()
        {
            if (!ValidateChildren() || _CategoryID == null)
            {
                _EmptyChart();
                return;
            }

            DateTime startDate = Convert.ToDateTime(kgtxtFromData.ValidatedText);
            DateTime endDate = Convert.ToDateTime(kgtxtToDate.ValidatedText);


            _chartData = await clsReport.GetCategoryMonthlyFlow(Convert.ToInt32(_CategoryID),startDate, endDate, Convert.ToInt16(clsGlobal_UI.CurrentUser.AccountID));

            LoadMonthlyChart();
        }
        public System.Windows.Media.Brush GetBrush(string hexColor)
        {
            return new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(hexColor));
        }
        void LoadChartColumn(List<clsCategoryMonthlyFlow> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;


            string[] labels = chartData.Select(x => GetMonthName(x.mon, x.Year)).ToArray();

            CartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "الفئة",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.CategorySum)),
                    Fill = System.Windows.Media.Brushes.SeaGreen,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new ColumnSeries
                {
                    Title = "الفئات التابعة",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.CategorySonsSum)),
                    Fill = System.Windows.Media.Brushes.Crimson,
                    DataLabels = true,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new LineSeries 
                {
                    Title = "الإجمالي",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.Total)),

                    Stroke = System.Windows.Media.Brushes.CornflowerBlue,
                    StrokeThickness = 3,
                    Fill = System.Windows.Media.Brushes.Transparent,

                    PointGeometry = LiveCharts.Wpf.DefaultGeometries.Circle,
                    PointGeometrySize = 12,
                    LineSmoothness = 0.8,
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

        private string GetMonthName(byte monthNumber, short year)
        {
            return new DateTime(year, monthNumber, 1).ToString("MMM - yyyy");
        }

        void LoadChartLiner(List<clsCategoryMonthlyFlow> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;

            string[] labels = chartData.Select(x => GetMonthName(x.mon, x.Year)).ToArray();

            CartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "الفئة",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.CategorySum)),

                    Fill = System.Windows.Media.Brushes.Transparent,

                    Stroke = System.Windows.Media.Brushes.DarkGreen,
                   StrokeThickness = 2.5,

                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                    LineSmoothness = 0.8,
                    DataLabels = false,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new LineSeries
                {
                     Title = "الفئات التابعة",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.CategorySonsSum)),

                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.DarkRed,
                    StrokeThickness = 2.5,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                    LineSmoothness = 0.8,
                    DataLabels = false,
                    LabelPoint = point => point.Y.ToString("N0")
                },

                new LineSeries
                {
                    Title = "الإجمالي",
                    Values = new ChartValues<decimal>(chartData.Select(x => x.Total)),
                    Stroke = System.Windows.Media.Brushes.CornflowerBlue,
                    StrokeThickness = 3,

                    Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(120, 100, 149, 237)),
                    PointGeometry = LiveCharts.Wpf.DefaultGeometries.Circle,
                    PointGeometrySize = 12,
                    LineSmoothness = 0.8,
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
            kgtxtFromData.RefreshNumber_DateTimeFormattedText(new DateTime(bofore12Month.Year, bofore12Month.Month, 1).ToString());

            CartesianChart1.LegendLocation = LegendLocation.Top;
            CartesianChart1.DefaultLegend.FontSize = 15;
            CartesianChart1.DataTooltip.FontSize = 14;
        }

        private async void gibtnFindPerson_Click(object sender, EventArgs e)
        {
            await LoadData();
        }

        private void kgtxtCategoryName_IconLeftClick(object sender, EventArgs e)
        {
            var frm = new frmSelectCategory();
            frm.OnCategorySelected += Frm_OnCategorySelected;
            clsGlobal_UI.MainForm.AddNewFormAsDialog(frm);
        }

        private async void Frm_OnCategorySelected(object sender, frmSelectCategory.SelecteCategoryEventArgs e)
        {
            await _SelectCategory(e.CategoryID, e.CategoryName); 
        }

    }
}
