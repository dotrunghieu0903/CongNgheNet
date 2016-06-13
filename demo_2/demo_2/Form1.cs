using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<MonHoc> dsmh = new List<MonHoc>()
            {
                new MonHoc {Mamon="HP2_1", Tenmon="Nền tảng lập trình C#", He="KTV" },
                new MonHoc {Mamon="HP2_2", Tenmon="Công nghệ ADO.NET", He="KTV" },
                new MonHoc {Mamon="HP3_1", Tenmon="Lập trình Windows", He="KTV" },
                new MonHoc {Mamon="HP3_2", Tenmon="Lập trình web với HTML", He="KTV" },
                new MonHoc {Mamon="LINQ", Tenmon="Công nghệ LinQ", He="CD" },
                new MonHoc {Mamon="C++", Tenmon="Lập trình hướng đối tượng", He="CD" },
                new MonHoc {Mamon="XML", Tenmon="Công nghệ XML", He="QT" },
            };

            List<He> dshe = new List<He>()
            {
                new He {Mahe="KTV", Tenhe="Kỹ thuật viên" },
                new He {Mahe="CD", Tenhe="Chuyên đề" },
                new He {Mahe="QT", Tenhe="Chứng chỉ quốc tế" },
            };


            var query = dsmh
                        .Join(dshe,
                              mh => mh.He,
                              h => h.Mahe,
                              (mh, h) => new { h.Mahe, h.Tenhe, mh.Mamon, mh.Tenmon }
                              );

            StringBuilder str = new StringBuilder();
            foreach (var mh in query)
                str.AppendLine(mh.Mahe + "\t" +mh.Tenhe +"\t" + mh.Mamon + "\t" + mh.Tenmon);
            KetQua.Text = str.ToString();
        }
    }

    class MonHoc
    {
        public string Mamon { get; set; }
        public string Tenmon { get; set; }
        public string He { get; set; }
    }

    class He
    {
        public string Mahe { get; set; }
        public string Tenhe { get; set; }
    }
}
