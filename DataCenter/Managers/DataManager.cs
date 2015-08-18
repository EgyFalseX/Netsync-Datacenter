using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Data.SqlClient;
using log4net;
using System.Data;
using System.IO;

namespace DataCenter.Managers
{
    public class DataManager
    {
        
        #region -   Variables   -
        private static readonly ILog Logger = log4net.LogManager.GetLogger(typeof(DataManager));
        public static DataManager defaultInstance;
        DataSources.dsDataCenter dsData;
        public DataSources.dsQueries dsQry;
        DataSources.dsDataCenterTableAdapters.AppRoleTableAdapter adpAppRole;
        DataSources.dsDataCenterTableAdapters.QueriesTableAdapter AdpQry;
        DataSources.dsDataCenterTableAdapters.CategoryRoleTableAdapter adpCategoryRole;
        DataSources.dsDataCenterTableAdapters.CategoryUserTableAdapter adpCategoryUser;
        DataSources.dsDataCenterTableAdapters.ItemUserTableAdapter adpItemUser;
        DataSources.dsDataCenterTableAdapters.LogsTableAdapter adpLogs;

        public static Char SplitChar = Convert.ToChar("|");
        public static string DecryptPassword = "FalseX";
        //public static Data.dsDataTableAdapters.QueriesTableAdapter adpQry = new Data.dsDataTableAdapters.QueriesTableAdapter();
        #endregion
        #region -   Functions   -
        public DataManager()
        {
            dsData = new DataSources.dsDataCenter();
            dsQry = new DataSources.dsQueries();
            adpAppRole = new DataSources.dsDataCenterTableAdapters.AppRoleTableAdapter();
            AdpQry = new DataSources.dsDataCenterTableAdapters.QueriesTableAdapter();
            adpCategoryRole = new DataSources.dsDataCenterTableAdapters.CategoryRoleTableAdapter();
            adpCategoryUser = new DataSources.dsDataCenterTableAdapters.CategoryUserTableAdapter();
            adpItemUser = new DataSources.dsDataCenterTableAdapters.ItemUserTableAdapter();
            adpLogs = new DataSources.dsDataCenterTableAdapters.LogsTableAdapter();
        }
        public static bool Init()
        {
            try
            {
                defaultInstance = new DataManager();
                if (!defaultInstance.CreateDefaultData())
                    return false;
                DataCenterX.LogMessage("Init ... Done", typeof(DataManager), nsLib.Utilities.Types.MessageType.Debug);
                return true;
            }
            catch (Exception ex)
            {
                DataCenterX.LogMessage("Init ... Error", typeof(DataManager), nsLib.Utilities.Types.MessageType.Error, ex);
                return false;
            }
        }
        public static string GenerateDatabaseScript(string DatabasePath)
        {
            return string.Format(Properties.Settings.Default.CreateDatabaseScript.Replace("FalseX2013", DatabasePath));
        }
        public bool CreateDefaultData()
        {
            try
            {
                AdpQry.InsertDefaultData();

                DataCenter.Forms.MainFrm frm = new DataCenter.Forms.MainFrm();
                foreach (DevExpress.XtraBars.BarItem item in frm.ribbonControl.Items)
                {
                    if (item.Name != string.Empty)
                        adpAppRole.InsertQueryInsertIfNotExists(item.Name);
                }

                DataCenterX.LogMessage("Create Default Data ... Done", typeof(DataManager), nsLib.Utilities.Types.MessageType.Debug);
                return true;
            }
            catch (Exception ex)
            {
                DataCenterX.LogMessage("Create Default Data ... Error", typeof(DataManager), nsLib.Utilities.Types.MessageType.Error, ex);
                return false;
            }
            
        }
        public static bool IsNullOrEmpty(object obj)
        {
            if (obj == null)
                return true;

            if (obj.ToString() == string.Empty)
                return true;
            else
                return false;
        }
        public bool AddDefaultCategoryAndInheritancePrivilages(int CategoryId, int ParentCategoryId = -1)
        {
            try
            {
                int userid = UserManager.defaultInstance.UserInfo.UserID;
                DataSources.dsDataCenter.CategoryRoleDataTable CatRole = new DataSources.dsDataCenter.CategoryRoleDataTable();
                DataSources.dsDataCenter.CategoryUserDataTable CatUser = new DataSources.dsDataCenter.CategoryUserDataTable();
                adpCategoryRole.FillByInheritances(CatRole, ParentCategoryId);
                adpCategoryUser.FillByInheritances(CatUser, ParentCategoryId);
                //add parent roles
                foreach (DataSources.dsDataCenter.CategoryRoleRow item in CatRole)
                {
                    item.CategoryId = CategoryId;
                    item.AcceptChanges();
                    item.SetAdded();
                }
                adpCategoryRole.Update(CatRole);
                //add parent users
                foreach (DataSources.dsDataCenter.CategoryUserRow item in CatUser)
                {
                    item.CategoryId = CategoryId;
                    item.AcceptChanges();
                    item.SetAdded();
                }
                adpCategoryUser.Update(CatUser);
                //add me as default user
                if ((int)adpCategoryUser.ScalarQueryExistsUserID_CategoryId(userid, CategoryId) == 0)
                {
                    DataSources.dsDataCenter.CategoryUserRow row = CatUser.NewCategoryUserRow();
                    row.UserID = userid; row.CategoryId = CategoryId;
                    row.CanRead = row.CanWrite = row.CanInsert = row.CanDelete = true;
                    row.UserLevelId = (int)nsLib.Utilities.Types.UserLevelType.Administrator;
                    row.GrantId = (int)nsLib.Utilities.Types.GrantType.allow;
                    row.Inheritance = false;

                    adpCategoryUser.Insert(row.UserID, row.CategoryId, row.CanRead, row.CanWrite, row.CanInsert, 
                        row.CanDelete, row.Inheritance, null, row.UserLevelId, row.GrantId);
                }
                DataCenterX.LogMessage("Add Default Category And InheritancePrivilages ... Done", typeof(DataManager), nsLib.Utilities.Types.MessageType.Debug);
                return true;
            }
            catch (SqlException ex)
            {
                DataCenterX.LogMessage("Add Default Category And InheritancePrivilages ... Error", typeof(DataManager), nsLib.Utilities.Types.MessageType.Error, ex);
                return false;
            }
        }
        public bool AddDefaultItemPrivilages(int ItemId)
        {
            try
            {
                int userid = UserManager.defaultInstance.UserInfo.UserID;
                adpItemUser.Insert(ItemId, userid, true, true, true, true, (int)nsLib.Utilities.Types.GrantType.allow);
                DataCenterX.LogMessage("Add Default Item Privilages ... Done", typeof(DataManager), nsLib.Utilities.Types.MessageType.Debug);
                return true;
            }
            catch (SqlException ex)
            {
                DataCenterX.LogMessage("Add Default Item Privilages ... Error", typeof(DataManager), nsLib.Utilities.Types.MessageType.Error, ex);
                return false;
            }

        }
        public bool UpdateSubCategoryInheritancePrivilages(DataSources.dsDataCenter.CategoryUserRow row, bool delete)
        {
            try
            {
                if (delete)
                {
                    DataManager.defaultInstance.AdpQry.DeleteInheritanceUser(row.CategoryId, row.UserID, row.GrantId);
                    return true;
                }
                if (row.Inheritance)
                {
                    DataManager.defaultInstance.AdpQry.UpdateInheritanceUser(row.CategoryId, row.UserID, row.CanRead,
                        row.CanWrite, row.CanInsert, row.CanDelete, row.Inheritance, row.UserLevelId, row.GrantId);
                }
                else
                    DataManager.defaultInstance.AdpQry.DeleteInheritanceUser(row.CategoryId, row.UserID, row.GrantId);
                DataCenterX.LogMessage("Update Sub Category Inheritance Privilages ... Done", typeof(DataManager), nsLib.Utilities.Types.MessageType.Debug);
                return true;
            }
            catch (SqlException ex)
            {
                DataCenterX.LogMessage("Update Sub Category Inheritance Privilages ... Error", typeof(DataManager), nsLib.Utilities.Types.MessageType.Error, ex);

                return false;
            }
        }
        public bool UpdateSubCategoryInheritancePrivilages(DataSources.dsDataCenter.CategoryRoleRow row, bool delete)
        {
            try
            {
                if (delete)
                {
                    DataManager.defaultInstance.AdpQry.DeleteInheritanceRole(row.CategoryId, row.RoleID, row.GrantId);
                    return true;
                }
                if (row.Inheritance)
                {
                    DataManager.defaultInstance.AdpQry.UpdateInheritanceRole(row.CategoryId, row.RoleID, row.CanRead,
                        row.CanWrite, row.CanInsert, row.CanDelete, row.Inheritance, row.UserLevelId, row.GrantId);
                }
                else
                    DataManager.defaultInstance.AdpQry.DeleteInheritanceRole(row.CategoryId, row.RoleID, row.GrantId);
                DataCenterX.LogMessage("Add Default Item Privilages ... Done", typeof(DataManager), nsLib.Utilities.Types.MessageType.Debug);
                return true;
            }
            catch (SqlException ex)
            {
                DataCenterX.LogMessage("Add Default Item Privilages ... Error", typeof(DataManager), nsLib.Utilities.Types.MessageType.Error, ex);
                return false;
            }
        }
        public string GetItemLockuser(int ItemId)
        {
            return adpLogs.ScalarQueryGetLockUser(ItemId).ToString();
        }
        public bool MoveCategoryInheritancePrivilages(int CategoryId, int NewParentId)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DataCenterConnectionString);
            SqlDataAdapter adp = new SqlDataAdapter() { SelectCommand = new SqlCommand("", con) };
            SqlCommand cmd = new SqlCommand("", con);

            con.Open();
            //All Sub Category
            DataSources.dsDataCenter.CategoryDataTable Categories = new DataSources.dsDataCenter.CategoryDataTable();
            adp.SelectCommand.CommandText = string.Format(@";WITH ret (CategoryId, ParentID, CategoryName) AS(
            SELECT CategoryId, ParentID, '' FROM Category WHERE CategoryId = {0}
            UNION ALL
	        SELECT t.CategoryId, t.ParentID, '' FROM Category t INNER JOIN ret r ON t.ParentID = r.CategoryId )
            select * from ret", CategoryId);
            adp.Fill(Categories);
            //All Role Should Delete
            DataSources.dsDataCenter.CategoryRoleDataTable ROLES = new DataSources.dsDataCenter.CategoryRoleDataTable();
            adp.SelectCommand.CommandText = string.Format(@"Select * FROM CategoryRole WHERE CategoryId = {0} AND Inheritance = 1 AND InheritanceCategoryId <> CategoryId", CategoryId);
            adp.Fill(ROLES);
            //All User Should Delete
            DataSources.dsDataCenter.CategoryUserDataTable USERS = new DataSources.dsDataCenter.CategoryUserDataTable();
            adp.SelectCommand.CommandText = string.Format(@"SELECT * FROM CategoryUser WHERE CategoryId = {0} AND Inheritance = 1 AND InheritanceCategoryId <> CategoryId", CategoryId);
            adp.Fill(USERS);
            foreach (DataSources.dsDataCenter.CategoryRow cat in Categories)
            {
                foreach (DataSources.dsDataCenter.CategoryRoleRow catRole in ROLES)
                {

                    cmd.CommandText = string.Format(@"DELETE FROM CategoryRole WHERE CategoryId = {0} AND RoleID = {1} AND GrantId = {2}", cat.CategoryId, catRole.RoleID, catRole.GrantId);
                    cmd.ExecuteNonQuery();
                }
                foreach (DataSources.dsDataCenter.CategoryUserRow catUser in USERS)
                {
                    cmd.CommandText = string.Format(@"DELETE FROM CategoryUser WHERE CategoryId = {0} AND UserID = {1} AND GrantId = {2}", cat.CategoryId, catUser.UserID, catUser.GrantId);
                    cmd.ExecuteNonQuery();
                }
            }

            //All Role Should Add
            adp.SelectCommand.CommandText = string.Format(@"Select * FROM CategoryRole WHERE CategoryId = {0} AND Inheritance = 1", NewParentId);
            ROLES.Clear();
            adp.Fill(ROLES);
            //All User Should Add
            adp.SelectCommand.CommandText = string.Format(@"SELECT * FROM CategoryUser WHERE CategoryId = {0} AND Inheritance = 1", NewParentId);
            USERS.Clear();
            adp.Fill(USERS);

            cmd.CommandText = @"if exists(select * from CategoryRole where CategoryId = @CategoryId and RoleID = @RoleID and GrantId = @GrantId)
            begin
            UPDATE CategoryRole SET CanRead = @CanRead, CanWrite = @CanWrite, CanInsert = @CanInsert, CanDelete = @CanDelete, Inheritance = @Inheritance, 
            InheritanceCategoryId = @InheritanceCategoryId, UserLevelId = @UserLevelId
            WHERE CategoryId = @CategoryId and RoleID = @RoleID and GrantId = @GrantId
            end
            else
            begin
            INSERT INTO CategoryRole (CategoryId, RoleID, CanRead, CanWrite, CanInsert, CanDelete, Inheritance, InheritanceCategoryId, UserLevelId, GrantId)
            VALUES (@CategoryId, @RoleID, @CanRead, @CanWrite, @CanInsert, @CanDelete, @Inheritance, @InheritanceCategoryId, @UserLevelId, @GrantId)
            end";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@RoleID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@CanRead", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@CanWrite", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@CanInsert", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@CanDelete", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@Inheritance", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@InheritanceCategoryId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@UserLevelId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@GrantId", SqlDbType.Int));

            foreach (DataSources.dsDataCenter.CategoryRow cat in Categories)
            {
                foreach (DataSources.dsDataCenter.CategoryRoleRow catRole in ROLES)
                {
                    cmd.Parameters["@CategoryId"].Value = cat.CategoryId;
                    cmd.Parameters["@RoleID"].Value = catRole.RoleID;
                    cmd.Parameters["@CanRead"].Value = catRole.CanRead;
                    cmd.Parameters["@CanWrite"].Value = catRole.CanWrite;
                    cmd.Parameters["@CanInsert"].Value = catRole.CanInsert;
                    cmd.Parameters["@CanDelete"].Value = catRole.CanDelete;
                    cmd.Parameters["@Inheritance"].Value = catRole.Inheritance;
                    cmd.Parameters["@InheritanceCategoryId"].Value = catRole.InheritanceCategoryId;
                    cmd.Parameters["@UserLevelId"].Value = catRole.UserLevelId;
                    cmd.Parameters["@GrantId"].Value = catRole.GrantId;
                    cmd.ExecuteNonQuery();
                }
            }

            cmd.CommandText = @"if exists(select * from CategoryUser where CategoryId = @CategoryId and UserID = @UserID and GrantId = @GrantId)
            begin
            UPDATE CategoryUser SET CanRead = @CanRead, CanWrite = @CanWrite, CanInsert = @CanInsert, CanDelete = @CanDelete, Inheritance = @Inheritance, 
            InheritanceCategoryId = @InheritanceCategoryId, UserLevelId = @UserLevelId
            WHERE CategoryId = @CategoryId and UserID = @UserID and GrantId = @GrantId
            end
            else
            begin
            INSERT INTO CategoryUser (CategoryId, UserID, CanRead, CanWrite, CanInsert, CanDelete, Inheritance, InheritanceCategoryId, UserLevelId, GrantId)
            VALUES (@CategoryId, @UserID, @CanRead, @CanWrite, @CanInsert, @CanDelete, @Inheritance, @InheritanceCategoryId, @UserLevelId, @GrantId)
            end";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@CanRead", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@CanWrite", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@CanInsert", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@CanDelete", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@Inheritance", SqlDbType.Bit));
            cmd.Parameters.Add(new SqlParameter("@InheritanceCategoryId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@UserLevelId", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@GrantId", SqlDbType.Int));
            foreach (DataSources.dsDataCenter.CategoryRow cat in Categories)
            {
                foreach (DataSources.dsDataCenter.CategoryUserRow catUser in USERS)
                {
                    cmd.Parameters["@CategoryId"].Value = cat.CategoryId;
                    cmd.Parameters["@UserID"].Value = catUser.UserID;
                    cmd.Parameters["@CanRead"].Value = catUser.CanRead;
                    cmd.Parameters["@CanWrite"].Value = catUser.CanWrite;
                    cmd.Parameters["@CanInsert"].Value = catUser.CanInsert;
                    cmd.Parameters["@CanDelete"].Value = catUser.CanDelete;
                    cmd.Parameters["@Inheritance"].Value = catUser.Inheritance;
                    cmd.Parameters["@InheritanceCategoryId"].Value = catUser.InheritanceCategoryId;
                    cmd.Parameters["@UserLevelId"].Value = catUser.UserLevelId;
                    cmd.Parameters["@GrantId"].Value = catUser.GrantId;
                    cmd.ExecuteNonQuery();
                }
            }
            con.Close(); con.Dispose(); cmd.Dispose(); adp.Dispose();
            return true;
        }
        public void GetFormPriv(int UserID, string FormName, ref bool Selecting, ref bool Inserting, ref bool Updateing, ref bool Deleting)
        {
            Selecting = false; Inserting = false; Updateing = false; Deleting = false;

            if (FormName.Substring(FormName.Length - 3).ToLower() == "frm")
                FormName = FormName.Substring(0, FormName.Length - 3);
            FormName = AppManager.defaultInstance.AppMenuName + FormName;

            if (UserManager.defaultInstance.UserAppRoles == null)
                return;

            foreach (DataSources.dsDataCenter.AppRoleRow row in UserManager.defaultInstance.UserAppRoles.Rows)
            {
                if (row.MenuItemName != FormName)
                    continue;
                if (row.Selecting)
                    Selecting = row.Selecting;
                if (row.Inserting)
                    Inserting = row.Inserting;
                if (row.Updateing)
                    Updateing = row.Updateing;
                if (row.Deleting)
                    Deleting = row.Deleting;
            }
        }
        public static bool VersionExpired()
        {
            
            try
            {
                int currentVersion = Convert.ToInt32(System.Windows.Forms.Application.ProductVersion.Replace(".", ""));
                object MinAppVersion = new DataSources.dsDataCenterTableAdapters.QueriesTableAdapter().GetAppOptionValue(Uti.Types.AppOptionName.MinAppVersion.ToString());

                if (MinAppVersion == null)
                    return true;
                else
                {
                    if (currentVersion < Convert.ToInt32(MinAppVersion))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                DataCenterX.LogMessage(ex.Message, typeof(DataManager), nsLib.Utilities.Types.MessageType.Error, ex, true);
                return true;
            }
        }
        public static Dictionary<string, int> GetCurrentAssemblyFiles()
        {
            Dictionary<string, int> Asm = new Dictionary<string, int>();
            Asm.Add("DevExpress.BonusSkins.v15.1.dll", 151415188);
            Asm.Add("DevExpress.Charts.v15.1.Core.dll", 151415188);
            Asm.Add("DevExpress.Data.v15.1.dll", 151415188);
            Asm.Add("DevExpress.DataAccess.v15.1.dll", 151415188);
            Asm.Add("DevExpress.DataAccess.v15.1.UI.dll", 151415188);
            Asm.Add("DevExpress.Office.v15.1.Core.dll", 151415188);
            Asm.Add("DevExpress.Printing.v15.1.Core.dll", 151415188);
            Asm.Add("DevExpress.RichEdit.v15.1.Core.dll", 151415188);
            Asm.Add("DevExpress.Spreadsheet.v15.1.Core.dll", 151415188);
            Asm.Add("DevExpress.Utils.v15.1.dll", 151415188);
            Asm.Add("DevExpress.Utils.v15.1.UI.dll", 151415188);
            Asm.Add("DevExpress.XtraBars.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraCharts.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraEditors.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraGrid.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraLayout.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraNavBar.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraPrinting.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraRichEdit.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraSpreadsheet.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraTreeList.v15.1.dll", 151415188);
            Asm.Add("DevExpress.XtraWizard.v15.1.dll", 151415188);
            Asm.Add("FXFW.dll", 1004);
            Asm.Add("Ionic.Zip.dll", 1918);
            Asm.Add("log4net.dll", 12110);
            Asm.Add(Application.ProductName + ".exe", Convert.ToInt32(System.Windows.Forms.Application.ProductVersion.Replace(".", "")));

            return Asm;
        }
        public static DataCenter.DataSources.dsDataCenter.AppDependenceFileDataTable GetDownloadDependanceies()
        {
            using (DataCenter.DataSources.dsDataCenterTableAdapters.AppDependenceFileTableAdapter adpQry = new DataSources.dsDataCenterTableAdapters.AppDependenceFileTableAdapter())
            {
                DataCenter.DataSources.dsDataCenter.AppDependenceFileDataTable RequiredFilesTbl = new DataCenter.DataSources.dsDataCenter.AppDependenceFileDataTable();
                adpQry.FillByLiteData(RequiredFilesTbl);
                Dictionary<string, int> ExistsFiles = GetCurrentAssemblyFiles();
                for (int i = (RequiredFilesTbl.Count - 1); i >= 0; i--)
                {
                    DataCenter.DataSources.dsDataCenter.AppDependenceFileRow row = (DataCenter.DataSources.dsDataCenter.AppDependenceFileRow)RequiredFilesTbl.Rows[i];
                    int Version = 0;
                    if (ExistsFiles.TryGetValue(row.FileName, out Version))
                    {
                        if (row.FileVersion <= Version)
                            RequiredFilesTbl.Rows.RemoveAt(i);
                    }
                }
                return RequiredFilesTbl;
            }
        }
        public static void PerformUpdaterDownload(DataCenter.DataSources.dsDataCenter.AppDependenceFileDataTable tbl)
        {
            if (tbl.Count == 0)// No Update Found
                return;
            string Data = String.Format("{0}|{1}|", (int)Uti.Types.UpdaterArgsEnum.Download, Properties.Settings.Default.DataCenterConnectionString);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                Data += ((DataCenter.DataSources.dsDataCenter.AppDependenceFileRow)tbl.Rows[i]).FileName;
                if (i + 1 < tbl.Rows.Count)
                    Data += "|";
            }
        
            Data = String.Format("\"{0}\"", Data);
            using (System.Diagnostics.Process process = new System.Diagnostics.Process() { StartInfo = new System.Diagnostics.ProcessStartInfo(DataCenterX.updaterPath, Data) })
            {
                process.Start();
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        public static void PerformUpdaterUpload(Dictionary<string, int> FilesList)
        {
            string Data = String.Format("{0}{1}{2}{1}", (int)Uti.Types.UpdaterArgsEnum.Upload, SplitChar, Properties.Settings.Default.DataCenterConnectionString);

            foreach (KeyValuePair<string, int> item in FilesList)
            {
                Data += String.Format("{0}{1}{2}{1}", item.Key, SplitChar, item.Value);
            }
            Data = Data.Substring(0, Data.Length - 1);


            //Data = FXFW.EncDec.Encrypt(Data, "FalseX");// Encrypt Arg Data
            Data = String.Format("\"{0}\"", Data);
            using (System.Diagnostics.Process process = new System.Diagnostics.Process() { StartInfo = new System.Diagnostics.ProcessStartInfo(Program.updaterPath, Data) })
            {
                process.Start();
            }

            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        public static Dictionary<string, int> GetUploadDependanceies()
        {
            Dictionary<string, int> NeededFiles = new Dictionary<string, int>();
            using (DataCenter.DataSources.dsDataCenterTableAdapters.AppDependenceFileTableAdapter adpQry = new DataSources.dsDataCenterTableAdapters.AppDependenceFileTableAdapter())
            {
                DataCenter.DataSources.dsDataCenter.AppDependenceFileDataTable RequiredFilesTbl = new DataCenter.DataSources.dsDataCenter.AppDependenceFileDataTable();
                adpQry.FillByLiteData(RequiredFilesTbl);
                Dictionary<string, int> AppFiles = GetCurrentAssemblyFiles();
                foreach (KeyValuePair<string, int> item in AppFiles)
                {
                    DataCenter.DataSources.dsDataCenter.AppDependenceFileRow row = RequiredFilesTbl.FindByFileName(item.Key);
                    if (row == null)
                        NeededFiles.Add(item.Key, item.Value);
                    else
                    {
                        if (row.FileVersion < item.Value)
                            NeededFiles.Add(item.Key, item.Value);
                    }
                }
            }
            return NeededFiles;
        }
        public static MemoryStream CompressFile(byte[] date)
        {
            using (Ionic.Zip.ZipFile zFile = new Ionic.Zip.ZipFile())
            {
                zFile.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                zFile.Comment = String.Format("This zip archive was created by the CreateZip example application on machine '{0}'", System.Net.Dns.GetHostName());
                zFile.AddEntry("zUpdateObject.exe", date);
                MemoryStream ms = new MemoryStream();
                zFile.Save(ms);
                return ms;
            }
        }
        public static MemoryStream DecompressFile(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            using (Ionic.Zip.ZipFile zFile = Ionic.Zip.ZipFile.Read(new MemoryStream(data)))
            {
                foreach (Ionic.Zip.ZipEntry entry in zFile)
                {
                    entry.Extract(ms);
                }
            }
            return ms;
        }
        
        #endregion
        
    }
}