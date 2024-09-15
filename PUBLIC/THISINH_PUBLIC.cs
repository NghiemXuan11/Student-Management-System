using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PUBLIC
{
    public class THISINH_PUBLIC
    {
        private string _MATS;

        public string MATS
        {
            get { return _MATS; }
            set { _MATS = value; }
        }
        private string _MATSOLD;

        public string MATSOLD
        {
            get { return _MATSOLD; }
            set { _MATSOLD = value; }
        }
        private string _TENTHISINH;

        public string TENTHISINH
        {
            get { return _TENTHISINH; }
            set { _TENTHISINH = value; }
        }
        private string _GIOITINH;

        public string GIOITINH
        {
            get { return _GIOITINH; }
            set { _GIOITINH = value; }
        }
        private DateTime _NGAYSINH;

        public DateTime NGAYSINH
        {
            get { return _NGAYSINH; }
            set { _NGAYSINH = value; }
        }
        private string _IDHINH;

        public string IDHINH
        {
            get { return _IDHINH; }
            set { _IDHINH = value; }
        }
        private byte[] _HINH;

        public byte[] HINH
        {
            get { return _HINH; }
            set { _HINH = value; }
        }       
    }
}
