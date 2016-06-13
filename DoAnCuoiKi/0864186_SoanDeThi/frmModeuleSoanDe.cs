using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _0864186_SoanDeThi
{
    public partial class frmModeuleSoanDe : Form
    {
        #region "Biến toàn cục"
        //UserControl
        ucSoanCauHoi ucSCH = new ucSoanCauHoi();
        ucTaoDeThi ucTDT = new ucTaoDeThi();
        #endregion
        public frmModeuleSoanDe()
        {
            InitializeComponent();
        }
       
        private void frmModeuleSoanDe_Load(object sender, EventArgs e)
        {
            
            panelMain.Controls.Add(ucSCH);
            ucSCH.LoadDuLieu_SoanCauHoi();
            ucSCH.LoadDuLieu_ChuDe();
            ucTDT.LoadCauHoi_TaoDeThi();
            
        }

        private void btnSoanCauHoi_Click(object sender, EventArgs e)
        {
            ucTDT.Visible = false;
            ucSCH.Visible = true;
        }

        private void btnTaoDeThi_Click(object sender, EventArgs e)
        {
            ucSCH.XoaTruongDuLieu();
            ucSCH.Visible = false;
            panelMain.Controls.Add(ucTDT);
            ucTDT.Visible = true;
            ucSCH.LoadDuLieu_SoanCauHoi();
            ucTDT.LoadCauHoi_TaoDeThi();
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            DialogResult r =MessageBox.Show("Vui lòng liên hệ: \n\rTrần Minh Vương - MSSV:0864186\n\r Số điện thoại: 0934 103 448","Trợ giúp",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
