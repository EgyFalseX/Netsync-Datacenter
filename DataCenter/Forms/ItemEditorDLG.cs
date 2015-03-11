using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using nsLib.Utilities;
using DataCenter.Managers;

namespace DataCenter.Forms
{
    public partial class ItemEditorDLG : DevExpress.XtraEditors.XtraForm
    {
        #region -   Variables   -
        DataSources.dsDataCenter.ItemRow _row;
        nsLib.Utilities.UpdateInfo notify;
        
        #endregion
        #region -   Functions   -
        public ItemEditorDLG(DataSources.dsDataCenter.ItemRow row, string filePath = "")
        {
            InitializeComponent();
            _row = row;
            if (filePath != "")
                ofd.FileName = filePath;
            notify = new nsLib.Utilities.UpdateInfo();
            notify.AddItem(false); notify.AddItem(false); 
            notify.AddItem(pbc.Properties.Maximum); notify.AddItem(pbc.EditValue);
        }
        private void BindingsCollection()
        {
            empBindingSource.DataSource = DataManager.defaultInstance.dsQry; empBindingSource.DataMember = "Emp";
            asaseBindingSource.DataSource = DataManager.defaultInstance.dsQry; asaseBindingSource.DataMember = "asase";
            alsofofBindingSource.DataSource = DataManager.defaultInstance.dsQry; alsofofBindingSource.DataMember = "alsofof";
            faslBindingSource.DataSource = DataManager.defaultInstance.dsQry; faslBindingSource.DataMember = "fasl";
            //studentBindingSource.DataSource = DataManager.defaultInstance.dsQry; studentBindingSource.DataMember = "Student";
                
            DataSources.dsDataCenterTableAdapters.CategoryTableAdapter adpCat = new DataSources.dsDataCenterTableAdapters.CategoryTableAdapter();
            DataSources.dsDataCenterTableAdapters.ItemTableAdapter adpItem = new DataSources.dsDataCenterTableAdapters.ItemTableAdapter();

            if (!_row.IsNull("ItemName"))
                tbItemName.EditValue = _row.ItemName;

            if (!_row.IsNull("TypeId"))
                lueTypeId.EditValue = _row.TypeId;

            if (!_row.IsNull("CreateIn"))
                lblCreateIn.Text = _row.CreateIn.ToString();

            if (!_row.IsNull("ModifyIn"))
                lblModifyIn.Text = _row.ModifyIn.ToString();

            if (!_row.IsNull("UserIn"))
                lblUserIn.Text = new DataSources.dsDataCenterTableAdapters.UsersTableAdapter().ScalarQueryUserID(_row.UserIn);

            if (!_row.IsNull("CategoryId"))
                lblParentName.Text = adpCat.ScalarQueryCategoryName(_row.CategoryId);

            if (!_row.IsNull("Info"))
                tbInfo.EditValue = _row.Info;

            if (!_row.IsNull("Locker"))
            {
                ceLocker.Checked = _row.Locker;
                if (_row.Locker)
                {
                    btnDownload.Enabled = false;
                    btnUpload.Enabled = false;
                    lblLockByLable.Visible = true;
                    lblLockBy.Visible = true;
                    lblLockBy.Text = DataManager.defaultInstance.GetItemLockuser(_row.ItemId);
                }
            }

            if (!_row.IsNull("EmpCode"))
            {
                lueEmpCode.EditValue = _row.EmpCode;
                ceEmp.Checked = true;
            }
            if (!_row.IsNull("asase_code"))
            {
                lueasase_code.EditValue = _row.asase_code;
                ceStu.Checked = true;
            }
            if (!_row.IsNull("alsofof_code"))
            {
                luealsofof_code.EditValue = _row.alsofof_code;
                ceStu.Checked = true;
            }
            if (!_row.IsNull("fasl_code"))
            {
                luefasl_code.EditValue = _row.fasl_code;
                ceStu.Checked = true;
            }
            if (!_row.IsNull("stu_code"))
            {
                luestu_code.EditValue = _row.stu_code;
                ceStu.Checked = true;
            }

        }
      
        #endregion
        #region - Event Handlers -
        private void CategoryEditorDLG_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsQueries.Emp' table. You can move, or remove it, as needed.
            //this.empTableAdapter.Fill(this.dsQueries.Emp);
            //// TODO: This line of code loads data into the 'dsQueries.Student' table. You can move, or remove it, as needed.
            //this.studentTableAdapter.Fill(this.dsQueries.Student);
            //// TODO: This line of code loads data into the 'dsQueries.fasl' table. You can move, or remove it, as needed.
            //this.faslTableAdapter.Fill(this.dsQueries.fasl);
            //// TODO: This line of code loads data into the 'dsQueries.alsofof' table. You can move, or remove it, as needed.
            //this.alsofofTableAdapter.Fill(this.dsQueries.alsofof);
            //// TODO: This line of code loads data into the 'dsQueries.asase' table. You can move, or remove it, as needed.
            //this.asaseTableAdapter.Fill(this.dsQueries.asase);

            // TODO: This line of code loads data into the 'dsDataCenter.Types' table. You can move, or remove it, as needed.
            this.typesTableAdapter.Fill(this.dsDataCenter.Types);

            BindingsCollection();
        }
        private void ceEmp_CheckedChanged(object sender, EventArgs e)
        {
            gcEmp.Enabled = !gcEmp.Enabled;
        }
        private void ceStu_CheckedChanged(object sender, EventArgs e)
        {
            gcStu.Enabled = !gcStu.Enabled;
        }
        private void lueStu_EditValueChanged(object sender, EventArgs e)
        {
            int asase_code = -1, alsofof_code = -1, fasl_code = -1;
            if (!DataManager.IsNullOrEmpty(lueasase_code.EditValue))
                asase_code = Convert.ToInt32(lueasase_code.EditValue);
            if (!DataManager.IsNullOrEmpty(luealsofof_code.EditValue))
                alsofof_code = Convert.ToInt32(luealsofof_code.EditValue);
            if (!DataManager.IsNullOrEmpty(luefasl_code.EditValue))
                fasl_code = Convert.ToInt32(luefasl_code.EditValue);

            studentTableAdapter.FillByPram(dsQueries.Student, asase_code, alsofof_code, fasl_code);


        }
        private void ceLocker_CheckedChanged(object sender, EventArgs e)
        {
            if (ceLocker.Checked)
            {
                ceLocker.Text = "مغلق";
                ceLocker.ForeColor = Color.Red;
            }
            else
            {
                ceLocker.Text = "متاح";
                ceLocker.ForeColor = Color.Green;
            }
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
        }
       
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;
            //Should Download File Here
            xtraTabControlMain.Enabled = false;
            gcCommands.Enabled = false;
            pnlProgress.Visible = true;

            notify.SetValue(0, false); notify.SetValue(1, false);
            
            notify.OnItemChanged += notifyDownload_OnItemChanged;
            DataCenterX.NSManager.C_ReciveFile(sfd.FileName, AppManager.defaultInstance.GetServerOption(nsLib.Utilities.Types.ServerOptions.FilesPath) + _row.PhysicalName, ref notify);
        }
        void notifyDownload_OnItemChanged(int index, object value)
        {
            switch (index)
            {
                case 0://Complate
                    this.Invoke(new MethodInvoker(() =>
                    {
                        xtraTabControlMain.Enabled = true;
                        gcCommands.Enabled = true;
                        pnlProgress.Visible = false;
                        if ((bool)value)
                            DataCenterX.LogMessage("تم حفظ الملف", typeof(ItemEditorDLG), nsLib.Utilities.Types.MessageType.Success, null, true);
                        else
                            DataCenterX.LogMessage("لم يتم حفظ الملف", typeof(ItemEditorDLG), nsLib.Utilities.Types.MessageType.Error, null, true);
                    })
                   );
                    notify.OnItemChanged -= notifyDownload_OnItemChanged;
                    //notify.SetValue(0, false); notify.SetValue(1, false);
                    break;
                case 1://Cancel
                    if ((bool)value)
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                        xtraTabControlMain.Enabled = true;
                        gcCommands.Enabled = true;
                        pnlProgress.Visible = false;
                        }));
                    }
                    notify.OnItemChanged -= notifyDownload_OnItemChanged;
                    //notify.SetValue(0, false); notify.SetValue(1, false);
                    break;
                case 2://Progress Max Value
                    pbc.Invoke(new MethodInvoker(() => { pbc.Properties.Maximum = Convert.ToInt32(value); }));
                    break;
                case 3://Progress Value
                    pbc.Invoke(new MethodInvoker(() => { pbc.EditValue = Convert.ToInt32(value); }));
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbItemName.EditValue != null && tbItemName.EditValue.ToString() != string.Empty)
                _row.ItemName = tbItemName.EditValue.ToString();

            if (lueTypeId.EditValue != null && lueTypeId.EditValue.ToString() != string.Empty)
                _row.TypeId = Convert.ToInt32(lueTypeId.EditValue);

            _row.ModifyIn = (DateTime)AppManager.defaultInstance.ServerDateTime();

            if (_row.RowState == DataRowState.Detached)
            {
                _row.OwnerId = UserManager.defaultInstance.UserInfo.UserID;
                _row.CreateIn = _row.ModifyIn;
                _row.active = true;
            }

            _row.UserIn = UserManager.defaultInstance.UserInfo.UserID;

            if (tbInfo.EditValue != null && tbInfo.EditValue.ToString() != string.Empty)
                _row.Info = tbInfo.EditValue.ToString();

            if (ceLocker.EditValue != null)
                _row.Locker = ceLocker.Checked;

            if (ceEmp.Checked)
            {
                if (!DataManager.IsNullOrEmpty(lueEmpCode.EditValue))
                    _row.EmpCode = Convert.ToInt32(lueEmpCode.EditValue);
            }
            else
                _row.SetEmpCodeNull();


            if (ceStu.Checked)
            {
                if (!DataManager.IsNullOrEmpty(lueasase_code.EditValue))
                    _row.asase_code = Convert.ToInt32(lueasase_code.EditValue);

                if (!DataManager.IsNullOrEmpty(luealsofof_code.EditValue))
                    _row.alsofof_code = Convert.ToInt32(luealsofof_code.EditValue);

                if (!DataManager.IsNullOrEmpty(luefasl_code.EditValue))
                    _row.fasl_code = Convert.ToInt32(luefasl_code.EditValue);

                if (!DataManager.IsNullOrEmpty(luestu_code.EditValue))
                    _row.stu_code = Convert.ToInt32(luestu_code.EditValue);
            }
            else
            {
                _row.Setasase_codeNull();
                _row.Setalsofof_codeNull();
                _row.Setfasl_codeNull();
                _row.Setstu_codeNull();
            }

            if (ofd.FileName == string.Empty)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                xtraTabControlMain.Enabled = false;
                gcCommands.Enabled = false;
                pnlProgress.Visible = true;

                _row.PhysicalName = string.Format("{0}{1}{2}{3}{4}{5}{6}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

                notify.SetValue(0, false); notify.SetValue(1, false);
                notify.OnItemChanged += notifyUpload_OnItemChanged;
                DataCenterX.NSManager.C_SendFile(ofd.FileName, AppManager.defaultInstance.GetServerOption(nsLib.Utilities.Types.ServerOptions.FilesPath) + _row.PhysicalName, ref notify);
            }
        }
        void notifyUpload_OnItemChanged(int index, object value)
        {
            switch (index)
            {
                case 0://Complate
                    this.Invoke(new MethodInvoker(() =>
                    {
                        xtraTabControlMain.Enabled = true;
                        gcCommands.Enabled = true;
                        pnlProgress.Visible = false;
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
                            xtraTabControlMain.Enabled = true;
                            gcCommands.Enabled = true;
                            pnlProgress.Visible = false;
                        }));
                    }
                    notify.OnItemChanged -= notifyUpload_OnItemChanged;
                    notify.SetValue(0, false); notify.SetValue(1, false);
                    break;
                case 2://Progress Max Value
                    pbc.Invoke(new MethodInvoker(() => 
                    {
                        pbc.Properties.Maximum = Convert.ToInt32(value); })
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
            notify.SetValue(1, true);//Cancel Op
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion

    }
}
