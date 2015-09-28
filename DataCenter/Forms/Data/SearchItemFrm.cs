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

namespace DataCenter.Forms.Data
{
    public partial class SearchItemFrm : DevExpress.XtraEditors.XtraForm
    {
        DataSources.Linq.dsDataCenterLinqDataContext dsLinq = new DataSources.Linq.dsDataCenterLinqDataContext();
        public SearchItemFrm()
        {
            InitializeComponent();
        }
        private Task LoadDataAsync()
        {
            return Task.Run(() => 
            {
                LSMSData.QueryableSource = from q in dsLinq.GetUserItem(Managers.UserManager.defaultInstance.UserInfo.UserID, null) select q;
            });
        }
        private void SearchItemFrm_Load(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private void contextMenuStripFile_Opening(object sender, CancelEventArgs e)
        {
            if (gridViewFiles.SelectedRowsCount == 0)
                viewCatToolStripMenuItem.Enabled = false;
            else
                viewCatToolStripMenuItem.Enabled = true;
        }

        private void viewCatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSources.Linq.GetUserItemResult Item = (DataSources.Linq.GetUserItemResult)gridViewFiles.GetRow(gridViewFiles.FocusedRowHandle);
            if (this.ParentForm.GetType() == typeof(MainFrm))
            {
                ((MainFrm)this.ParentForm).FrmItem.SetCatFocused((int)Item.CategoryId);
            }
        }
    }
}