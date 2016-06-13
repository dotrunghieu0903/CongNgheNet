using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _0864186_ThiTracNghiem
{
    class CCauTracNghiem
    {
        private string _NoiDungCauHoi;
        private string _DapAnA;
        private string _DapAnB;
        private string _DapAnC;
        private string _DapAnD;
        private int _DapAnDung;
        private int _CauTraLoi;

        

        public string NoiDungCauHoi
        {
            get { return _NoiDungCauHoi; }
            set { _NoiDungCauHoi=value; }
        }
        public string DapAnA
        {
            get { return _DapAnA; }
            set { _DapAnA=value; }
        }
        public string DapAnB
        {
            get { return _DapAnB; }
            set { _DapAnB=value; }
        }
        public string DapAnC
        {
            get { return _DapAnC; }
            set { _DapAnC=value; }
        }
        public string DapAnD
        {
            get { return _DapAnD; }
            set { _DapAnD=value; }
        }
        public int DapAnDung
        {
            get { return _DapAnDung; }
            set { _DapAnDung=value; }
        }

        public int CauTraLoi
        {
            get { return _CauTraLoi; }
            set { _CauTraLoi = value; }
        }
        public CCauTracNghiem()
        {
            this.NoiDungCauHoi = string.Empty;
            this.DapAnA = string.Empty;
            this.DapAnB = string.Empty;
            this.DapAnC = string.Empty;
            this.DapAnD = string.Empty;
            this.DapAnDung = 0;
            this.CauTraLoi = 0;
        }
        public CCauTracNghiem(CCauTracNghiem cauHoi)
        {
            this.NoiDungCauHoi = cauHoi.NoiDungCauHoi;
            this.DapAnA = cauHoi.DapAnA;
            this.DapAnB = cauHoi.DapAnB;
            this.DapAnC = cauHoi.DapAnC;
            this.DapAnD = cauHoi.DapAnD;
            this.DapAnDung = cauHoi.DapAnDung;
            this.CauTraLoi = cauHoi.CauTraLoi;
        }
    }
}
