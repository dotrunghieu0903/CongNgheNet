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
    public partial class frmTheLoai : Form
    {
        #region "Biến toàn cục"
        //UserControl
        ucSoanCauHoi ucSCH = new ucSoanCauHoi();
        ucTaoDeThi ucTDT = new ucTaoDeThi();
        List<int> listChuDe = new List<int>();
        #endregion
        public frmTheLoai()
        {
            InitializeComponent();
        }
        private void LoadDuLieu()
        {
            _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
            var ds = from ChuDe in db.ChuDes select ChuDe;
            lvChuDe.Items.Clear();
            foreach (var chuDe in ds)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = chuDe.tenChuDe;
                lv.Tag = chuDe.maChuDe;
                lvChuDe.Items.Add(lv);
            }
        }
        //private int TaoMaChuDe()
        //{
        //    return lvChuDe.Items.Count + 1;
        //}
        private void btnThoat_Click(object sender, EventArgs e)
        {
            //ucSCH.LoadDuLieu_ChuDe();
            this.Close();
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
            ChuDe chuDe=new ChuDe();
            if (txtNoiDungChuDe.Text == "")
            {
                DialogResult r = MessageBox.Show("Vui lòng nhập nội dung chủ đề", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                //int temp = TaoMaChuDe();
                //chuDe.maChuDe = temp;
                chuDe.tenChuDe = txtNoiDungChuDe.Text;
                
                db.ChuDes.InsertOnSubmit(chuDe);
                db.SubmitChanges();
                LoadDuLieu();
                txtNoiDungChuDe.ResetText();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvChuDe.SelectedItems.Count > 0)
            {
                int ma_ChuDe = (int)lvChuDe.SelectedItems[0].Tag;
                _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
                ChuDe chuDe=db.ChuDes.Single(cd=>cd.maChuDe == ma_ChuDe);
                var ds = from cauHoi in db.CauHois where cauHoi.maChuDe == ma_ChuDe select cauHoi;
                db.CauHois.DeleteAllOnSubmit(ds);
                db.ChuDes.DeleteOnSubmit(chuDe);
                db.SubmitChanges(); 
                LoadDuLieu();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvChuDe.SelectedItems.Count > 0)
            {
                int ma_ChuDe = (int)lvChuDe.SelectedItems[0].Tag;
                _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
                ChuDe chuDe = db.ChuDes.Single(cd => cd.maChuDe == ma_ChuDe);
                txtNoiDungChuDe.Focus();
                chuDe.tenChuDe = txtNoiDungChuDe.Text;
                db.SubmitChanges();
                LoadDuLieu();
                txtNoiDungChuDe.ResetText();
            }
        }
    }
}
