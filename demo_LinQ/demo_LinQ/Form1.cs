using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_LinQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //khoi tao nguon du lieu
            int[] MangSo = { 50, 43, 7, 22, 15, 36, 2, 8, 10, 6, 99, 33 };

            //tao truy van
            IEnumerable<int> query = from n in MangSo
                                     where n > 10
                                     orderby n
                                     select n;

            //thuc thi truy van
            StringBuilder kq = new StringBuilder();
            foreach (int pt in query)
                kq.AppendLine(pt.ToString());
            KetQua.Text = kq.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<SinhVien> dssv = new List<SinhVien>()
            {
                new SinhVien {MSSV="12520359", TenSV="Nguyen Thanh Long", Lop="KHMT2012", GioiTinh="Nam"},
                new SinhVien {MSSV="12520778", TenSV="Lai Thi Thien Thanh", Lop="MMT2012", GioiTinh="Nu"},
                new SinhVien {MSSV="13520934", TenSV="Tran Quang Dai", Lop="CNPM2013", GioiTinh="Nam"},
                new SinhVien {MSSV="13520324", TenSV="Vo Quoc Huy", Lop="KHMT2013", GioiTinh="Nam"},
                new SinhVien {MSSV="12520614", TenSV="Pham Hoang Thuong", Lop="KHMT2012", GioiTinh="Nu"},
                new SinhVien {MSSV="12520016", TenSV="Nguyen Ngoc Linh", Lop="KTMT2012", GioiTinh="Nu"},
            };

            IEnumerable<SinhVien> query = from sv in dssv
                                          where sv.GioiTinh == "Nam"
                                          orderby sv.MSSV
                                          select sv;

            StringBuilder str = new StringBuilder();
            foreach (var sv in query)
                str.AppendLine(sv.MSSV + "\t" + sv.TenSV + "\t" + sv.Lop + "\t" + sv.GioiTinh);
            KetQua.Text = str.ToString();
        }
    }

    class SinhVien
    {
        public string MSSV { get; set; }
        public string TenSV { get; set; }
        public string Lop { get; set; }
        public string GioiTinh { get; set; }
    }
}
