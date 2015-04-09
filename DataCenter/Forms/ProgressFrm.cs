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

namespace DataCenter.Forms
{
    public partial class ProgressFrm : DevExpress.XtraEditors.XtraForm
    {
        readonly nsLib.Utilities.UpdateInfo _notify = null;
        readonly int _cancelInx = 0;
        public ProgressFrm()
        {
            InitializeComponent();
        }
        public ProgressFrm(nsLib.Utilities.UpdateInfo notify, int cancelInx)
        {
            InitializeComponent();
            _notify = notify;
            _cancelInx = cancelInx;
            _notify.OnItemChanged += _notify_OnItemChanged;
        }
        void _notify_OnItemChanged(int index, object value)
        {
            switch (index)
            {
                case 0://Complate
                    _notify.OnItemChanged -= _notify_OnItemChanged;
                    Invoke(new MethodInvoker(() => { Close(); }));
                    break;
                case 1://Cancel
                    _notify.OnItemChanged -= _notify_OnItemChanged;
                    Invoke(new MethodInvoker(() => { Close(); }));
                    break;
                case 2://Progress Max Value
                    pbc.Invoke(new MethodInvoker(() => { pbc.Properties.Maximum = Convert.ToInt32(value); }));
                    break;
                case 3://Progress Value
                    pbc.Invoke(new MethodInvoker(() => { pbc.EditValue = Convert.ToInt32(value); }));
                    break;
                default:
                    break;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _notify.SetValue(_cancelInx, true);
        }

    }
}