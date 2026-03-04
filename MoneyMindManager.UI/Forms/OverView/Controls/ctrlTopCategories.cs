using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using KhaledControlLibrary1;
using LiveCharts;
using LiveCharts.Wpf;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Reports.Categories;
using MoneyMindManager.UI.Abstractions;
using MoneyMindManager_Presentation.Global;


namespace MoneyMindManager_Presentation.OverView.Controls
{
    public partial class ctrlTopCategories : UserControl
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IReportApiClient _reportApi;
        private IFormateHelper _formateHelper;

        private bool isInitialized = false;
        public ctrlTopCategories()
        {
            InitializeComponent();
        }

        public bool Initilaize(IUserSession userSession, IMessageBoxService messageBoxService, IReportApiClient reportApiClient,IFormateHelper formateHelper)
        {
            if (userSession is null || messageBoxService is null || reportApiClient is null || formateHelper is null)
                return false;

            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._reportApi = reportApiClient;
            this._formateHelper = formateHelper;
            isInitialized = true;
            return true;
        }

        bool _IsIncome;

        public bool IsIncome
        {
            get
            {
                return _IsIncome;
            }

            set
            {
                _IsIncome = value;
            }
        }
        void _EmptyChart()
        {
            PieChart1.Series.Clear();
            PieChart1.AxisX.Clear();
            PieChart1.AxisY.Clear();
            PieChart1.Series = new SeriesCollection();
        }

        public async Task<bool> LoadData()
        {
            if (!ValidateChildren())
            {
                _EmptyChart();
                return false;
            }

            if (!isInitialized)
                return false;

            DateTime? startDate = _formateHelper.TryConvertToDateTime(kgtxtFromData.ValidatedText);
            DateTime? endDate = _formateHelper.TryConvertToDateTime(kgtxtToDate.ValidatedText);

            var result = await _reportApi.GetTopCategories(startDate, endDate, _IsIncome, Convert.ToInt16(_userSession.CurrentUser.AccountID));

            if (!result.IsSuccess)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return false;
            }

            var _chartData = result.Data.ToList();

            LoadTopCategoriesPieChart(_chartData);
            return true;
        }

        public void LoadTopCategoriesPieChart(List<TopCategoriesReportModel> chartData)
        {
            // 1. تحقق من وجود بيانات
            if (chartData == null || chartData.Count == 0)
            {
                _EmptyChart();
                return;
            }

            SeriesCollection pieSeries = new SeriesCollection();

            string[] colors = new string[] {  "#0A66C2","#005F8E", "SlateBlue", "#FF9F1C", "#D68954",  "#04A08B",
            "#FF562F","#0052CC","#8F7267","#172B4C"};
            int colorIndex = 0;

            foreach (var category in chartData.OrderBy(c => c.Ranking))
            {
                // استخدمت mode and reaminder عشان لو عدد الفئات اكبر من عدد الالوان
                SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFromString(colors[colorIndex % colors.Length]);

                PieSeries piece = new PieSeries
                {
                    Title = category.CategoryName,
                    Values = new ChartValues<decimal> { category.Value },
                    Fill = brush,
                    FontSize = 15,
                    DataLabels = (category.Percentage > 0.05m),

                    LabelPoint = point => $"{point.Y.ToString("N0")}\n({point.Participation:P2})"
                };

                pieSeries.Add(piece);
                colorIndex++;
            }

            PieChart1.Series = pieSeries;

            PieChart1.Update();
        }

        private void ctrlTopCategories_Load(object sender, EventArgs e)
        {
            PieChart1.DefaultLegend.FontSize = 15;
            PieChart1.DataTooltip.FontSize = 14;
            PieChart1.LegendLocation = LegendLocation.Right;
            PieChart1.DataTooltip.Background = System.Windows.Media.Brushes.White;
            PieChart1.DataTooltip.Foreground = System.Windows.Media.Brushes.Black;

            if (_IsIncome)
            {
                ctrlInfoIcon1.ToolTipText = "يُظهر هذا المخطط توزيع أكبر 7 فئات رئيسية للإيرادات، حيث تمثل قيمة كل فئة مجموع التحصيلات (الإيراد) كنسبة من الإجمالي للفترة المحددة.";
            }
            else
            {
                ctrlInfoIcon1.ToolTipText = "يُظهر هذا المخطط توزيع أكبر 7 فئات رئيسية للمصروفات، حيث تمثل قيمة كل فئة مجموع الإنفاق الصافي (المصروفات - المرتجعات) كنسبة من الإجمالي للفترة المحددة.";
            }
        }

        private void kgtxt_OnValidationError(object sender, KhaledGuna2TextBox.ValidatingErrorEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.CancelEventArgs.Cancel = true;
            errorProvider1.SetError(kgtxt, clsPL_Utils.GetValidationErrorTypeString(e.validationErrorType, kgtxt));
        }

        private void kgtxt_OnValidationSuccess(object sender, CancelEventArgs e)
        {
            KhaledGuna2TextBox kgtxt = (KhaledGuna2TextBox)sender;
            e.Cancel = false;
            errorProvider1.SetError(kgtxt, null);
        }

        private async void gibtnFindPerson_Click(object sender, EventArgs e)
        {
            gibtnRefresh.Enabled = false;
            await LoadData();
            gibtnRefresh.Enabled = true;

        }
    }
}
