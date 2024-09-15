using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using PUBLIC;
using System.Data;
namespace BUL
{
    public class GIAOVIEN_BUL
    {
        GIAOVIEN_DAL giaovien_dal = new GIAOVIEN_DAL();
        public DataTable load_giaovien()
        {
            return giaovien_dal.load_giaovien();
        }
        public int insert_giaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            return giaovien_dal.insert_giaovien(giaovien_public);
        }
        public int update_giaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            return giaovien_dal.update_giaovien(giaovien_public);
        }
        public int delete_giaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            return giaovien_dal.delete_giaovien(giaovien_public);
        }
        public int insert_hinhgiaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            return giaovien_dal.insert_hinhgiaovien(giaovien_public);
        }
        public int update_hinhgiaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            return giaovien_dal.update_hinhgiaovien(giaovien_public);
        }
        public int delete_hinhgiaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            return giaovien_dal.delete_hinhgiaovien(giaovien_public);
        }
        public DataTable load_giaovien_voidieukien(GIAOVIEN_PUBLIC giaovien_public)
        {
            return giaovien_dal.load_giaovien_voidieukien(giaovien_public);
        }
        public DataTable load_gv_PD(GIAOVIEN_PUBLIC giaovien_public)
        {
            return giaovien_dal.load_gv_PD(giaovien_public);
        }
    }
}
