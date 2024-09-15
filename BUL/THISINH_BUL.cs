using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PUBLIC;
using DAL;
namespace BUL
{
    public class THISINH_BUL
    {
        THISINH_DAL thisinh_dal = new THISINH_DAL();
        public DataTable load_thisinh()
        {
            return thisinh_dal.load_thisinh();
        }
        public int insert_thisinh(THISINH_PUBLIC thisinh_public)
        {
            return thisinh_dal.insert_thisinh(thisinh_public);
        }
        public int update_thisinh(THISINH_PUBLIC thisinh_public)
        {
            return thisinh_dal.update_thisinh(thisinh_public);
        }
        public int delete_thisinh(THISINH_PUBLIC thisinh_public)
        {
            return thisinh_dal.delete_thisinh(thisinh_public);
        }
        public int insert_hinhthisinh(THISINH_PUBLIC thisinh_public)
        {
            return thisinh_dal.insert_hinhthisinh(thisinh_public);
        }
        public int update_hinhthisinh(THISINH_PUBLIC thisinh_public)
        {
            return thisinh_dal.update_hinhthisinh(thisinh_public);
        }
        public int delete_hinhthisinh(THISINH_PUBLIC thisinh_public)
        {
            return thisinh_dal.delete_hinhthisinh(thisinh_public);
        }
        public DataTable load_thisinh_voidieukien(THISINH_PUBLIC thisinh_public)
        {
            return thisinh_dal.load_thisinh_voidieukien(thisinh_public);
        }
        public DataTable load_ts_PD(THISINH_PUBLIC thisinh_public)
        {
            return thisinh_dal.load_ts_PD(thisinh_public);
        }
    }
}
