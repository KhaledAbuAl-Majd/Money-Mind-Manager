using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Models.Reports.Debts;
using MoneyMindManager.UI.Abstractions;


namespace MoneyMindManager_Presentation.OverView.Controls
{
    public partial class ctrlTopDebtorsRanking : UserControl
    {
        private IUserSession _userSession;
        private IMessageBoxService _messageBoxService;
        private IReportApiClient _reportApi;

        private bool isInitialized = false;
        public ctrlTopDebtorsRanking()
        {
            InitializeComponent();
        }

        public bool Initilaize(IUserSession userSession, IMessageBoxService messageBoxService, IReportApiClient reportApiClient)
        {
            if (userSession is null || messageBoxService is null || reportApiClient is null)
                return false;

            this._userSession = userSession;
            this._messageBoxService = messageBoxService;
            this._reportApi = reportApiClient;
            isInitialized = true;
            return true;
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

        public async Task<bool> LoadData()
        {
            if (!isInitialized)
                return false;

            bool isLending = false;

            if (gcbDebtType.Text == "الدائنون لي")
                isLending = false;
            else if (gcbDebtType.Text == "المدينون لي")
                isLending = true;
            else
            {
                _messageBoxService.DisplayError("خطأ في تحديد نوع الدين !");
                return false;
            }

            var result = await _reportApi.GetTopDebtorsRanking(isLending, Convert.ToInt16(_userSession.CurrentUser.AccountID));

            if (!result.IsSuccess)
            {
                _messageBoxService.DisplayError(result.ErrorMessage);
                return false;
            }

            var chartData = result.Data.ToList();

            _EmptyChart();
            LoadChartColumn(chartData);
            return true;
        }

        void LoadChartColumn(List<TopDebtorsRankingReportModel> chartData)
        {
            if (chartData == null || chartData.Count == 0) return;


            string[] labels = chartData.Select(x => $"{x.PersonName} : الاسم\nمعرف الشخص : {x.PersonID}").ToArray();

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
                ShowLabels = false,
                Title = "ترتيب أكبر 5 أشخاص مدينين/دائنين",
                Separator = new Separator { Step = 1 },

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 15,
            });


            string currency = clsPL_Global.CurrentUser?.AccountInfo?.DefaultCurrencyInfo?.CurrencySymbol;

            CartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = $"القيمة ({currency})",
                LabelFormatter = value => value.ToString("N0"),

                Foreground = System.Windows.Media.Brushes.Black,
                FontSize = 15
            });

            CartesianChart1.Update();
        }

        private void ctrlMonthlyFlow_Load(object sender, EventArgs e)
        {
            CartesianChart1.LegendLocation = LegendLocation.Top;
            CartesianChart1.DefaultLegend.FontSize = 15;
            CartesianChart1.DataTooltip.FontSize = 14;
        }

        private async void gcbDebtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadData();
        }
    }
}
