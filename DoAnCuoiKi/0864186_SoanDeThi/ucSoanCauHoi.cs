using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _0864186_SoanDeThi
{
    public partial class ucSoanCauHoi : UserControl
    {
        #region "Biến toàn cục"
        List<int> listChuDe = new List<int>();

        #endregion
        private void LuuDapAnDung()
        {
            _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
            var dsCauHoi = from CauHoi in db.CauHois select CauHoi;
            foreach (var cauHoi in dsCauHoi)
            {
                if (rbA.Checked == true)
                    cauHoi.dapAnDung = 1;
                if (rbB.Checked == true)
                    cauHoi.dapAnDung = 2;
                if (rbC.Checked == true)
                    cauHoi.dapAnDung = 3;
                if (rbD.Checked == true)
                    cauHoi.dapAnDung = 4;
            }
        }
        private void HienDapAnDung()
        {
            int ma_CauHoi = (int)lvHienThiCauHoi.SelectedItems[0].Tag;
            _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
            CauHoi cauHoi = db.CauHois.Single(ch => ch.maCauHoi == ma_CauHoi);
            int dapAn = (int)cauHoi.dapAnDung;
                switch (dapAn)
                {
                    case 1:
                            rbA.Checked = true;
                        break;
                    case 2:
                            rbB.Checked = true;
                        break;
                    case 3:
                            rbC.Checked = true;
                        break;
                    case 4:
                            rbD.Checked = true;
                        break;
                }
        }
        /// <summary>
        /// Hàm xóa các trường dữ liệu
        /// </summary>
        public void XoaTruongDuLieu()
        {
            btnThem.Enabled = true;
            txtNoiDungCauHoi.ResetText();
            txtDapAnA.ResetText();
            txtDapAnB.ResetText();
            txtDapAnC.ResetText();
            txtDapAnD.ResetText();
            rbA.Checked = false;
            rbB.Checked = false;
            rbC.Checked = false;
            rbD.Checked = false;
            cbbChuDe.Text = null;
        }
        public ucSoanCauHoi()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Ham load du lieu tu csdl len
        /// </summary>
        public void LoadDuLieu_SoanCauHoi()
        {
            btnThem.Enabled = true;
            _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
            var ds = from CauHoi in db.CauHois select CauHoi;
            lvHienThiCauHoi.Items.Clear();
            foreach (var CauHoi in ds)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = CauHoi.noiDung;
                lv.Tag = CauHoi.maCauHoi;
                lvHienThiCauHoi.Items.Add(lv);
            }
        }
        /// <summary>
        /// Lay du lieu trong bang chu de
        /// </summary>
        public void LoadDuLieu_ChuDe()
        {
            _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
            var ds = from ChuDe in db.ChuDes select ChuDe;
            cbbChuDe.Items.Clear();
            //ComboBox cb = new ComboBox();
            foreach (var chuDe in ds)
            {
                cbbChuDe.Items.Add(chuDe.tenChuDe);
                listChuDe.Add(chuDe.maChuDe);
            }
        }
        /// <summary>
        /// Lien ket form Quan Ly Chu De
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuanLyChuDe_Click(object sender, EventArgs e)
        {
            frmTheLoai frmTL = new frmTheLoai();
            frmTL.ShowDialog();
            LoadDuLieu_ChuDe();
            XoaTruongDuLieu();
        }
        /// <summary>
        /// Them cau hoi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtNoiDungCauHoi.Text == "" ||
                txtDapAnA.Text == "" ||
                txtDapAnB.Text == "" ||
                txtDapAnC.Text == "" ||
                txtDapAnD.Text == "" )
            {
                DialogResult r = MessageBox.Show("Vui lòng nhập đầy đủ nội dung câu hỏi và đáp án! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (rbA.Checked == false && rbB.Checked == false && rbC.Checked == false && rbD.Checked == false)
            {
                DialogResult r = MessageBox.Show("Bạn chưa chọn đáp án đúng cho câu hỏi. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (cbbChuDe.SelectedIndex<0)
            {
                DialogResult r = MessageBox.Show("Vui lòng chọn chủ đề cho câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
                CauHoi cauHoi = new CauHoi();
                
                int ma_ChuDe = cbbChuDe.SelectedIndex;
                //cauHoi.maChuDe = ma_ChuDe + 1;
                cauHoi.maChuDe = listChuDe[ma_ChuDe];
                cauHoi.noiDung = txtNoiDungCauHoi.Text;
                cauHoi.dapAnA = txtDapAnA.Text;
                cauHoi.dapAnB = txtDapAnB.Text;
                cauHoi.dapAnC = txtDapAnC.Text;
                cauHoi.dapAnD = txtDapAnD.Text;
                if (rbA.Checked == true)
                    cauHoi.dapAnDung = 1;
                else if (rbB.Checked == true)
                    cauHoi.dapAnDung = 2;
                else if (rbC.Checked == true)
                    cauHoi.dapAnDung = 3;
                else
                    cauHoi.dapAnDung = 4;
                db.CauHois.InsertOnSubmit(cauHoi);
                db.SubmitChanges();
                LoadDuLieu_SoanCauHoi();
                XoaTruongDuLieu();
            }
        }
        /// <summary>
        /// Xoa cau hoi trong listview & database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtNoiDungCauHoi.Text == "" ||
                txtDapAnA.Text == "" ||
                txtDapAnB.Text == "" ||
                txtDapAnC.Text == "" ||
                txtDapAnD.Text == "" )
            {
                DialogResult r = MessageBox.Show("Vui lòng nhập đầy đủ nội dung câu hỏi và đáp án! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (rbA.Checked == false && rbB.Checked == false && rbC.Checked == false && rbD.Checked == false)
            {
                DialogResult r = MessageBox.Show("Bạn chưa chọn đáp án đúng cho câu hỏi. ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (cbbChuDe.SelectedIndex < 0)
            {
                DialogResult r = MessageBox.Show("Vui lòng chọn chủ đề cho câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (lvHienThiCauHoi.SelectedItems.Count > 0)
                {
                    int ma_CauHoi = (int)lvHienThiCauHoi.SelectedItems[0].Tag;
                    _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
                    CauHoi cauHoi = db.CauHois.Single(ch => ch.maCauHoi == ma_CauHoi);
                    db.CauHois.DeleteOnSubmit(cauHoi);
                    db.SubmitChanges();
                    LoadDuLieu_SoanCauHoi();
                    XoaTruongDuLieu();
                }
            }
        }
        /// <summary>
        /// Cap nhat cau hoi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lvHienThiCauHoi.SelectedItems.Count > 0)
            {
                int ma_CauHoi = (int)lvHienThiCauHoi.SelectedItems[0].Tag;
                _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
                CauHoi cauHoi = db.CauHois.Single(ch => ch.maCauHoi == ma_CauHoi);
                txtNoiDungCauHoi.Focus();
                int ma_ChuDe = cbbChuDe.SelectedIndex;
                //cauHoi.maChuDe = ma_ChuDe + 1;
                cauHoi.maChuDe = listChuDe[ma_ChuDe];
                cauHoi.noiDung = txtNoiDungCauHoi.Text;
                cauHoi.dapAnA = txtDapAnA.Text;
                cauHoi.dapAnB = txtDapAnB.Text;
                cauHoi.dapAnC = txtDapAnC.Text;
                cauHoi.dapAnD = txtDapAnD.Text;
                if (rbA.Checked == true)
                    cauHoi.dapAnDung = 1;
                else if (rbB.Checked == true)
                    cauHoi.dapAnDung = 2;
                else if (rbC.Checked == true)
                    cauHoi.dapAnDung = 3;
                else
                    cauHoi.dapAnDung = 4;
                db.SubmitChanges();
                LoadDuLieu_SoanCauHoi();
                XoaTruongDuLieu();
            }
        }
        /// <summary>
        /// Hien thi du lieu khi chon trong listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvHienThiCauHoi_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvHienThiCauHoi.SelectedItems.Count > 0)
            {
                btnThem.Enabled=false;
                int ma_CauHoi = (int)lvHienThiCauHoi.SelectedItems[0].Tag;
                _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
                CauHoi cauHoi = db.CauHois.Single(ch => ch.maCauHoi == ma_CauHoi);
                txtNoiDungCauHoi.Text = cauHoi.noiDung;
                txtDapAnA.Text = cauHoi.dapAnA;
                txtDapAnB.Text = cauHoi.dapAnB;
                txtDapAnC.Text = cauHoi.dapAnC;
                txtDapAnD.Text = cauHoi.dapAnD;
                HienDapAnDung();
                int temp = (int)cauHoi.maChuDe;
                ChuDe chuDe = db.ChuDes.Single(cd => cd.maChuDe == cauHoi.maChuDe);
                cbbChuDe.Text = chuDe.tenChuDe;
                //cbbChuDe.Items[temp - 1];
            }
        }
        /// <summary>
        /// Xoa truong du lieu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaTruong_Click(object sender, EventArgs e)
        {
            XoaTruongDuLieu();
        }
       
    }
}
