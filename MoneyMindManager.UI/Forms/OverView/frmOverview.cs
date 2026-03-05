using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MoneyMindManager.Core.Enums;
using MoneyMindManager.UI.Abstractions;

namespace MoneyMindManager_Presentation.OverView
{
    public partial class frmOverView : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessageBoxService _messageBoxService;
        private readonly IUserSession _userSession;

        public frmOverView(IServiceProvider serviceProvider, IMessageBoxService messageBoxService, IUserSession userSession)
        {
            this._serviceProvider = serviceProvider;
            this._messageBoxService = messageBoxService;
            this._userSession = userSession;

            if (!_CheckPermissions())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
        }

        bool _CheckPermissions()
        {
            if (_userSession.IsHasPermissions(enPermissions.OverView))
                return true;

            _messageBoxService.DisplayError("ليس لديك صلاحية شاشة لمحة عامة.");
            return false;
        }

        private bool OpenAtContainer<T>(Func<T, bool> initialize = null) where T : Form
        {
            var frm = _serviceProvider.GetRequiredService<T>();

            if (initialize is null || !initialize.Invoke(frm))
            {
                frm?.Dispose();
                return false;
            }

            return _LoadFormAtPanelContainer(frm);
        }
        bool _LoadFormAtPanelContainer(Form frm)
        {
            if (frm == null)
                return false;

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;


            if (!frm.IsDisposed)
            {
                gpnlFormContainer.Controls.Clear();

                gpnlFormContainer.Controls.Add(frm);
                frm.Show();
                frm.BringToFront();
            }

            return true;
        }
        private void frmOverView_Shown(object sender, EventArgs e)
        {
            gbtnGeneral.PerformClick();
        }

        private void gbtnGeneral_Click(object sender, EventArgs e)
        {
            OpenAtContainer<frmOverviewGeneral>(frm =>
            {
                return frm.Initilaize();
            });
        }


        private void gbtnDebts_Click(object sender, EventArgs e)
        {
            OpenAtContainer<frmOverViewDebts>(frm =>
            {
                return frm.Initilaize();
            });
        }

        private void gbtnCategories_Click(object sender, EventArgs e)
        {
            OpenAtContainer<frmOverViewCategories>(frm =>
            {
                return frm.Initilaize();
            });
        }
    }
}
