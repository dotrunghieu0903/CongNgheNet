using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace _0864186_SoanDeThi
{
    public partial class ucTaoDeThi : UserControl
    {
        public ucTaoDeThi()
        {
            InitializeComponent();
        }
        public void LoadCauHoi_TaoDeThi()
        {
            lvChonCauHoi.Groups.Clear();
            lvChonCauHoi.Items.Clear();
            _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
            var dsChuDe = from chuDe in db.ChuDes select chuDe;
            int dem = 0;
            foreach (var chude in dsChuDe)
            {
                ListViewGroup lvg = new ListViewGroup();
                lvg.Header = chude.tenChuDe;
                lvChonCauHoi.Groups.Add(lvg);

                var ds = from cauHoi in db.CauHois where cauHoi.maChuDe == chude.maChuDe select cauHoi;
                foreach (var cauhoi in ds)
                {
                    ListViewItem lvi = new ListViewItem();
                    dem++;
                    lvi.Text = dem.ToString();
                    lvi.SubItems.Add(cauhoi.noiDung);
                    lvi.Group = lvg;
                    lvi.Tag = cauhoi.maCauHoi;
                    lvChonCauHoi.Items.Add(lvi);
                }
            }

        }

        private void btnTaodeThi_Click(object sender, EventArgs e)
        {
            _0864186_TracNghiemDataContext db = new _0864186_TracNghiemDataContext();
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "Luu file xml|*.xml";
            if (d.ShowDialog() == DialogResult.OK)
            {
                XmlDocument doc = new XmlDocument();
                XmlElement root = doc.CreateElement("DeThi");
                doc.AppendChild(root);

                foreach (ListViewItem lvi in lvChonCauHoi.Items)
                {
                    if (lvi.Checked == true)
                    {
                        int ma_CauHoi = (int)lvi.Tag;
                        CauHoi cauhoi = db.CauHois.Single(c => c.maCauHoi == ma_CauHoi);

                        XmlElement noodCau = doc.CreateElement("CauHoi");
                        root.AppendChild(noodCau);

                        XmlElement nodeNoiDung = doc.CreateElement("NoiDung");
                        noodCau.AppendChild(nodeNoiDung);
                        nodeNoiDung.InnerText = cauhoi.noiDung;

                        XmlElement nodeDapAnA = doc.CreateElement("DapAnA");
                        noodCau.AppendChild(nodeDapAnA);
                        nodeDapAnA.InnerText = cauhoi.dapAnA;

                        XmlElement nodeDapAnB = doc.CreateElement("DapAnB");
                        noodCau.AppendChild(nodeDapAnB);
                        nodeDapAnB.InnerText = cauhoi.dapAnB;

                        XmlElement nodeDapAnC = doc.CreateElement("DapAnC");
                        noodCau.AppendChild(nodeDapAnC);
                        nodeDapAnC.InnerText = cauhoi.dapAnC;

                        XmlElement nodeDapAnD = doc.CreateElement("DapAnD");
                        noodCau.AppendChild(nodeDapAnD);
                        nodeDapAnD.InnerText = cauhoi.dapAnD;

                        XmlElement nodeDapAnDung = doc.CreateElement("DapAnDung");
                        noodCau.AppendChild(nodeDapAnDung);
                        nodeDapAnDung.InnerText = cauhoi.dapAnDung.ToString();

                    }

                }
                doc.Save(d.FileName);
                

            }
        }
    }
}
