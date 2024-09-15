using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PUBLIC
{
    public class GIAOVIEN_PUBLIC
    {
        private string _MAGV;

        public string MAGV
        {
            get { return _MAGV; }
            set { _MAGV = value; }
        }
        private string _MAGVOLD;

        public string MAGVOLD
        {
            get { return _MAGVOLD; }
            set { _MAGVOLD = value; }
        }
        private string _TENGV;

        public string TENGV
        {
            get { return _TENGV; }
            set { _TENGV = value; }
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
        private string _MAMONHOC;

        public string MAMONHOC
        {
            get { return _MAMONHOC; }
            set { _MAMONHOC = value; }
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
