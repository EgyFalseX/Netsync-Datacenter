using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataCenter.Managers;

namespace DataCenter.Forms
{
    public partial class MSExcelViewerFrm : DevExpress.XtraEditors.XtraForm
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(MSExcelViewerFrm));
        DataSources.dsQueries.QryItemsRow _row;
        nsLib.Utilities.UpdateInfo notify;
        System.IO.MemoryStream ms;

        public MSExcelViewerFrm(DataSources.dsQueries.QryItemsRow row)
        {
            InitializeComponent();

            _row = row;
            notify = new nsLib.Utilities.UpdateInfo();
            notify.AddItem(false); notify.AddItem(false);
            notify.AddItem(new int()); notify.AddItem(new int());
            this.Text = row.ItemName;
        }
        private void MSExcelViewerFrm_Load(object sender, EventArgs e)
        {
            LoadFile();
        }
        private void LoadFile()
        {
            notify.SetValue(0, false); notify.SetValue(1, false);
            ms = new System.IO.MemoryStream();
            notify.OnItemChanged += notifyDownload_OnItemChanged;
            ProgressFrm FrmProg = new ProgressFrm(notify, 1);
            DataCenterX.NSManager.C_ReciveFile(ms, AppManager.defaultInstance.GetServerOption(nsLib.Utilities.Types.ServerOptions.FilesPath) + _row.PhysicalName, ref notify);
            FrmProg.ShowDialog();
        }
        void notifyDownload_OnItemChanged(int index, object value)
        {
            switch (index)
            {
                case 0://Complate
                    this.Invoke(new MethodInvoker(() =>
                    {
                        //pbc.Visible = false;
                        if ((bool)value)
                            DataCenterX.LogMessage("تم تحميل الملف", typeof(MSExcelViewerFrm), nsLib.Utilities.Types.MessageType.Success);
                        else
                            DataCenterX.LogMessage("لم يتم تحميل الملف", typeof(ImageViewerFrm), nsLib.Utilities.Types.MessageType.Error, null, true);
                        ViewFile();
                    })
                   );
                    notify.OnItemChanged -= notifyDownload_OnItemChanged;
                    break;
                case 1://Cancel
                    if ((bool)value)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            //pbc.Visible = false;
                        }));
                    }
                    notify.OnItemChanged -= notifyDownload_OnItemChanged;
                    break;
                case 2://Progress Max Value
                    //pbc.Invoke(new MethodInvoker(() => { pbc.Properties.Maximum = Convert.ToInt32(value); }));
                    break;
                case 3://Progress Value
                    //pbc.Invoke(new MethodInvoker(() => { pbc.EditValue = Convert.ToInt32(value); }));
                    break;
            }
        }
        void ViewFile()
        {
            try
            {
                bool OpnedState = spreadsheetControlMain.LoadDocument(ms.ToArray(), DevExpress.Spreadsheet.DocumentFormat.Xlsx);

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
                DataCenterX.LogMessage("لم يتم عرض الملف", typeof(MSWordViewerFrm), nsLib.Utilities.Types.MessageType.Error, ex, true);

            }
        }
    }
}