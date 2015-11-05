using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataCenter.Managers;

namespace DataCenter.Forms.Data
{
    public partial class MultiUploadDLG : DevExpress.XtraEditors.XtraForm
    {
        public List<Core.MultiUpload> ds;
        int _categoryId = 0;
        public MultiUploadDLG(int categoryId)
        {
            InitializeComponent();
            ds = new List<Core.MultiUpload>();
            gridControlMain.DataSource = ds;
            _categoryId = categoryId;
        }
        public void ReloadData()
        {
            gridControlMain.RefreshDataSource();
        }
        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            for (int i = 0; i < ofd.FileNames.Length; i++)
            {
                Core.MultiUpload nF = new Core.MultiUpload(ofd.SafeFileNames[i].Substring(0, ofd.SafeFileNames[i].LastIndexOf('.')), ofd.FileNames[i], dsDataCenter.Types[0].TypeId, false);
                ds.Add(nF);
            }
            ReloadData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            ripbProgress.Maximum = ds.Count;
            beiProgress.EditValue = 0;
            DateTime ServerDatetime = AppManager.defaultInstance.ServerDateTime();
            foreach (Core.MultiUpload file in ds)
            {
                nsLib.Utilities.UpdateInfo notify = new nsLib.Utilities.UpdateInfo();
                notify.SetValue(0, false); notify.SetValue(1, false); notify.SetValue(2, pbc.Properties.Maximum); notify.SetValue(3, pbc.EditValue);
                notify.OnItemChanged += notifyUpload_OnItemChanged;
                string PhysicalName  = string.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                DataCenterX.NSManager.C_SendFile(file.Filename, AppManager.defaultInstance.GetServerOption(nsLib.Utilities.Types.ServerOptions.FilesPath) + PhysicalName, ref notify);
                int ItemId = (int)AppManager.defaultInstance.adpQry.ScalarQueryItemNewId();
                int EffectedRows = itemTableAdapter.Insert(ItemId, file.Filename, file.Filetype, _categoryId, string.Empty, ServerDatetime, ServerDatetime , UserManager.defaultInstance.UserInfo.UserID, true, PhysicalName, file.Filelock, UserManager.defaultInstance.UserInfo.UserID);
                if (EffectedRows <= 0)
                    DataCenterX.LogMessage("لم نتمكن من اضافة الملف " + file.Filename, typeof(ItemBrowserFrm), nsLib.Utilities.Types.MessageType.Error, null, true);
                else
                {
                    DataManager.defaultInstance.AddDefaultItemPrivilages(ItemId);
                    AppManager.defaultInstance.LogOperation(nsLib.Utilities.Types.LogType.Item, ItemId, nsLib.Utilities.Types.LogOpType.Inset);
                    DataCenterX.LogMessage("تم اضافة ملف", typeof(ItemBrowserFrm), nsLib.Utilities.Types.MessageType.Success, null, true);
                }
                beiProgress.EditValue = Convert.ToInt32(beiProgress.EditValue) + 1;
            }
        }

        void notifyUpload_OnItemChanged(object sender, int index, object value)
        {
            nsLib.Utilities.UpdateInfo notify = (nsLib.Utilities.UpdateInfo)sender;
            switch (index)
            {
                case 0://Complate
                    this.Invoke(new MethodInvoker(() =>
                    {
                        if ((bool)value)
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                    })
                   );
                    notify.OnItemChanged -= notifyUpload_OnItemChanged;
                    notify.SetValue(0, false); notify.SetValue(1, false);
                    break;
                case 1://Cancel
                    if ((bool)value)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            //xtraTabControlMain.Enabled = true;
                            //gcCommands.Enabled = true;
                            //pnlProgress.Visible = false;
                        }));
                    }
                    notify.OnItemChanged -= notifyUpload_OnItemChanged;
                    notify.SetValue(0, false); notify.SetValue(1, false);
                    break;
                case 2://Progress Max Value
                    pbc.Invoke(new MethodInvoker(() =>
                    {
                        pbc.Properties.Maximum = Convert.ToInt32(value);
                    })
                    );
                    break;
                case 3://Progress Value
                    pbc.Invoke(new MethodInvoker(() =>
                    {
                        pbc.EditValue = Convert.ToInt32(value);
                    })
                   );
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void repositoryItemButtonEditDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Core.MultiUpload file = (Core.MultiUpload)gridViewMain.GetRow(gridViewMain.FocusedRowHandle);
            ds.Remove(file);
            ReloadData();
        }
    }
}