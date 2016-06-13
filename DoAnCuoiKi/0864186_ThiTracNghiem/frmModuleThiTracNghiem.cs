using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Xml.Linq;

namespace _0864186_ThiTracNghiem
{
    public partial class frmModuleThiTracNghiem : Form
    {
        #region "Biến toàn cục + hàm xử lý"
        private List<CCauTracNghiem> arrCauHoi = new List<CCauTracNghiem>();
        CCauTracNghiem CauTracNghiem = new CCauTracNghiem();

        int cauHienTai = 0;

        int flag = 0;

        bool flaga = false;
        bool flagb = false;
        bool flagc = false;
        bool flagd = false;

        int tongThoiGianThi;

        int soCauDung = 0;
        float diemThi = 0;
        private DateTime thoiGianThi;
       
        /// <summary>
        /// flag = 1 nếu có đáp án
        /// </summary>
        /// <returns></returns>
        private int KTTraLoi()
        {
            if (rbA.Checked == true || rbB.Checked == true || rbC.Checked == true || rbD.Checked == true)
                return 1;
            return 0;
        }
        /// <summary>
        /// nếu KTTraLoi()=1 bật rb tại câu trả lời
        /// </summary>
        private void LuuCauTraLoi()
        {
            if(KTTraLoi()==1)
            {
                if (rbA.Checked == true)
                    arrCauHoi[cauHienTai].CauTraLoi = 1;
                if (rbB.Checked == true)
                    arrCauHoi[cauHienTai].CauTraLoi = 2;
                if (rbC.Checked == true)
                    arrCauHoi[cauHienTai].CauTraLoi = 3;
                if (rbD.Checked == true)
                    arrCauHoi[cauHienTai].CauTraLoi = 4;                           
            }
            else
                arrCauHoi[cauHienTai].CauTraLoi = 0;                           
        }

        private void KiemTraKetQua()
        {
            for (int i = 0; i < arrCauHoi.Count; i++)
            {
                if (arrCauHoi[i].CauTraLoi == arrCauHoi[i].DapAnDung)
                {
                    soCauDung++;
                    diemThi = diemThi + (float)10/arrCauHoi.Count;
                }
                lbSocauDung.Text = soCauDung.ToString() + "/" + arrCauHoi.Count.ToString();
                lbDiem.Text = diemThi.ToString();
                if (diemThi >= 5)
                    lbDanhGia.Text = "Đạt yêu cầu";
                else
                    lbDanhGia.Text = "Không đạt yêu cầu";
            }
        }
        private void ToMauCauDung(int cauHienTai)
        {
            int temp = arrCauHoi[cauHienTai].DapAnDung;
            //bool flag = false;
            if (temp == 1)
            {
                flaga = true;
                flagb = false;
                flagc = false;
                flagd = false;
            }
            if (temp == 2)
            {
                flaga = false;
                flagb = true;
                flagc = false;
                flagd = false;
            }
            if (temp == 3)
            {
                flaga = false;
                flagb = false;
                flagc = true;
                flagd = false;
            }
            
            if (temp == 4)
            {
                flaga = false;
                flagb = false;
                flagc = false;
                flagd = true;
            }
            txtDapAnA.BackColor = flaga ? Color.Yellow : Color.White;
            txtDapAnB.BackColor = flagb ? Color.Yellow : Color.White;
            txtDapAnC.BackColor = flagc ? Color.Yellow : Color.White;
            txtDapAnD.BackColor = flagd ? Color.Yellow : Color.White;
            //if (temp == 1)
            //{
            //    txtDapAnA.BackColor = Color.Yellow;
            //    txtDapAnB.BackColor = Color.White;
            //    txtDapAnC.BackColor = Color.White;
            //    txtDapAnD.BackColor = Color.White;
            //}
            //if (temp == 2)
            //{
            //    txtDapAnA.BackColor = Color.White;
            //    txtDapAnB.BackColor = Color.Yellow;
            //    txtDapAnC.BackColor = Color.White;
            //    txtDapAnD.BackColor = Color.White;
            //}
            //if (temp == 3)
            //{
            //    txtDapAnA.BackColor = Color.White;
            //    txtDapAnB.BackColor = Color.White;
            //    txtDapAnC.BackColor = Color.Yellow;
            //    txtDapAnD.BackColor = Color.White;
            //}
            //if (temp == 4)
            //{
            //    txtDapAnA.BackColor = Color.White;
            //    txtDapAnB.BackColor = Color.White;
            //    txtDapAnC.BackColor = Color.White;
            //    txtDapAnD.BackColor = Color.Yellow;
            //}
                
        }
        //private void ResetRadioButton()
        //{
        //    rbA.Checked = false;
        //    rbB.Checked = false;
        //    rbC.Checked = false;
        //    rbD.Checked = false;
        //}
        private void BatTatRadioButton(bool co)
        {
            rbA.Enabled = co;
            rbB.Enabled = co;
            rbC.Enabled = co;
            rbD.Enabled = co;
        }
        private void BatTrangThairadioButton(int co)
        {
            if (co == 1)
                rbA.Checked = true;
            else if (co == 2)
                rbB.Checked = true;
            else if (co == 3)
                rbC.Checked = true;
            else if (co == 4)
                rbD.Checked = true;
            else
            {
                rbA.Checked = false;
                rbB.Checked = false;
                rbC.Checked = false;
                rbD.Checked = false;
            }
        }
        private void LoadDeThi()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Chon tap tin .xml|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                arrCauHoi.Clear();
                string filePath = dlg.FileName;
                txtDuongDan.Text = filePath;
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlElement root = doc.DocumentElement;
                XmlNodeList rootCauHoi = root.ChildNodes;
                for (int i = 0; i < rootCauHoi.Count; i++)
                {
                    CCauTracNghiem CauTracNghiem = new CCauTracNghiem();
                    XmlNode nodeNoiDungCauHoi = rootCauHoi[i].SelectSingleNode("NoiDung");
                    CauTracNghiem.NoiDungCauHoi = nodeNoiDungCauHoi.InnerText.ToString();
                    XmlNode nodeDapAnA = rootCauHoi[i].SelectSingleNode("DapAnA");
                    CauTracNghiem.DapAnA = nodeDapAnA.InnerText.ToString();
                    XmlNode nodeDapAnB = rootCauHoi[i].SelectSingleNode("DapAnB");
                    CauTracNghiem.DapAnB = nodeDapAnB.InnerText;
                    XmlNode nodeDapAnC = rootCauHoi[i].SelectSingleNode("DapAnC");
                    CauTracNghiem.DapAnC = nodeDapAnC.InnerText;
                    XmlNode nodeDapAnD = rootCauHoi[i].SelectSingleNode("DapAnD");
                    CauTracNghiem.DapAnD = nodeDapAnD.InnerText;
                    XmlNode nodeDapAnDung = rootCauHoi[i].SelectSingleNode("DapAnDung");
                    CauTracNghiem.DapAnDung = int.Parse(nodeDapAnDung.InnerText);
                    //them cau hoi vao list
                    arrCauHoi.Add(CauTracNghiem);
                }
                DialogResult r = MessageBox.Show("Đề thi được nạp thành công. Nhấn [Bắt đầu thi] để làm bài", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (r == DialogResult.OK)
                {
                    btnduongDan.Enabled = false;
                    btnBatDau.Enabled = true;
                    tongThoiGianThi = arrCauHoi.Count * 15;
                    thoiGianThi = new DateTime(2000, 1, 1, 0, tongThoiGianThi / 60, tongThoiGianThi % 60, 0);
                    lbThoiGian.Text = thoiGianThi.Minute.ToString() + " : " + thoiGianThi.Second.ToString();
                }
            }
            else
            {
                DialogResult r = MessageBox.Show("Đề thi chưa được nạp. Bạn không thể bắt đầu bài thi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (r == DialogResult.OK)
                {
                    btnduongDan.Enabled = true;
                    btnBatDau.Enabled = false;
                }
            }
        }
        
        #endregion
        public frmModuleThiTracNghiem()
        {
            InitializeComponent();
        }

        private void frmModuleThiTracNghiem_Load(object sender, EventArgs e)
        {
            btnXemDapAn.Enabled = false;
            btnBatDau.Enabled = false;
            btnCauTiep.Enabled = false;
            btnCauTruoc.Enabled = false;
            btnKetThuc.Enabled = false;
            BatTatRadioButton(false);
            ThoiGianThi.Stop(); 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (r == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void btnduongDan_Click(object sender, EventArgs e)
        {
            LoadDeThi();
            btnKetThuc.Enabled = false;
            BatTatRadioButton(false);
        }

        private void btnCauTiep_Click(object sender, EventArgs e)
        {
            if (cauHienTai <= arrCauHoi.Count-2)
            {
                cauHienTai = cauHienTai + 1;
                BatTrangThairadioButton(arrCauHoi[cauHienTai].CauTraLoi);
                if (flag == 1)
                    ToMauCauDung(cauHienTai);
                txtNoiDungCauHoi.Text = (cauHienTai + 1).ToString() + ". " + arrCauHoi[cauHienTai].NoiDungCauHoi;
                txtDapAnA.Text = arrCauHoi[cauHienTai].DapAnA;
                txtDapAnB.Text = arrCauHoi[cauHienTai].DapAnB;
                txtDapAnC.Text = arrCauHoi[cauHienTai].DapAnC;
                txtDapAnD.Text = arrCauHoi[cauHienTai].DapAnD;
            }
        }

        private void btnCauTruoc_Click(object sender, EventArgs e)
        {

            if (cauHienTai <= arrCauHoi.Count -1)
            {
                cauHienTai = cauHienTai - 1;
                if (cauHienTai >= 0)
                {
                    BatTrangThairadioButton(arrCauHoi[cauHienTai].CauTraLoi);
                    if(flag==1)
                        ToMauCauDung(cauHienTai);
                    txtNoiDungCauHoi.Text = (cauHienTai + 1).ToString() + ". " + arrCauHoi[cauHienTai].NoiDungCauHoi;
                    txtDapAnA.Text = arrCauHoi[cauHienTai].DapAnA;
                    txtDapAnB.Text = arrCauHoi[cauHienTai].DapAnB;
                    txtDapAnC.Text = arrCauHoi[cauHienTai].DapAnC;
                    txtDapAnD.Text = arrCauHoi[cauHienTai].DapAnD;
                }
                else
                {
                    //DialogResult r= MessageBox.Show("ccccccccccccccc", "ddd");
                    cauHienTai = 0;
                }
            }
        }

        private void rbA_CheckedChanged(object sender, EventArgs e)
        {
            LuuCauTraLoi();
        }

        private void rbB_CheckedChanged(object sender, EventArgs e)
        {
            LuuCauTraLoi();
        }

        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            LuuCauTraLoi();
        }

        private void rbD_CheckedChanged(object sender, EventArgs e)
        {
            LuuCauTraLoi();
        }

        private void btnXemDapAn_Click(object sender, EventArgs e)
        {
            flag = 1;
            ToMauCauDung(cauHienTai);
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            ThoiGianThi.Stop();
            KiemTraKetQua();
            btnXemDapAn.Enabled = true;
            btnBatDau.Enabled = false;
            btnduongDan.Enabled = false;
            BatTatRadioButton(false);

        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Thời gian làm bài bắt đầu đếm ngược.Điểm tối đa là 10 điểm.\n\rĐề thi có" +" " +arrCauHoi.Count.ToString()+" " + "câu hỏi" + " Chúc bạn thi tốt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            {
                if (r == DialogResult.OK)
                {
                    ThoiGianThi.Start();
                    btnBatDau.Enabled = false;
                    btnduongDan.Enabled = false;
                    btnKetThuc.Enabled = true;
                    btnXemDapAn.Enabled = false;
                    btnCauTiep.Enabled = true;
                    btnCauTruoc.Enabled = true;
                    BatTatRadioButton(true);
                    txtNoiDungCauHoi.Text = "1. " + arrCauHoi[0].NoiDungCauHoi;
                    txtDapAnA.Text = arrCauHoi[0].DapAnA;
                    txtDapAnB.Text = arrCauHoi[0].DapAnB;
                    txtDapAnC.Text = arrCauHoi[0].DapAnC;
                    txtDapAnD.Text = arrCauHoi[0].DapAnD;
                }
            }
        }

        //private void lbThoiGian_Paint(object sender, PaintEventArgs e)
        //{
        //    lbThoiGian.Text = "60";
        //    Font f = new Font("Arial", 30, FontStyle.Bold);
        //    e.Graphics.DrawString(lbThoiGian.Text, f, Brushes.Azure, 150, 115);
        //}

        private void ThoiGianThi_Tick(object sender, EventArgs e)
        {
            TimeSpan dt = new TimeSpan(0, 0, 1);
            thoiGianThi = thoiGianThi.Subtract(dt);
            lbThoiGian.Text = thoiGianThi.Minute.ToString() + " : " + thoiGianThi.Second.ToString();
            if (thoiGianThi.Minute == 0 && thoiGianThi.Second == 0)
            {
                ThoiGianThi.Enabled = false;
                DialogResult r = MessageBox.Show("Thời gian làm bài đã hết.Mời bạn xem kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                {
                    if (r == DialogResult.OK)
                        KiemTraKetQua();
                }
            }
        }

       

    }
}
