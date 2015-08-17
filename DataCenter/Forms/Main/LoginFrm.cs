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
    public partial class LoginFrm : DevExpress.XtraEditors.XtraForm
    {
        public LoginFrm()
        {
            InitializeComponent();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد", "خطاء", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                return;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbname.Text.Trim().Length == 0 || tbpass.Text.Trim().Length == 0)
                return;
            if (UserManager.defaultInstance.SignIn(tbname.Text, tbpass.Text))
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(WaitWindowFrm)); DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption("Updating .......");
                //Check If Application Version Is no longer able to run or update
                if (DataManager.VersionExpired())
                {
                    DataCenterX.LogMessage("Application is too old to perform an update, please ask for new version ...", typeof(LoginFrm), nsLib.Utilities.Types.MessageType.Error, null, true);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }

                DataManager.PerformUpdaterDownload(DataManager.GetDownloadDependanceies());// Perform Update Client If Exists
                if (UserManager.defaultInstance.UserInfo.UserID == 1)
                {
                    Dictionary<string, int> UploadFiles = DataManager.GetUploadDependanceies();
                    if (UploadFiles.Count > 0)
                    {
                        if (MessageBox.Show(String.Format("{0} New Files Found{1}Are You Sure You Wanna Update Server List?", UploadFiles.Count, Environment.NewLine), "?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                            DataManager.PerformUpdaterUpload(UploadFiles);// Perform Update Server If Exists
                        
                    }
                }
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
                DialogResult = System.Windows.Forms.DialogResult.OK; 
            }
            else
                DataCenterX.LogMessage("اسم المستخدم او كلمة المرور خاطئة", typeof(ItemPermissionEditorDLG), nsLib.Utilities.Types.MessageType.Error, null, true);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}