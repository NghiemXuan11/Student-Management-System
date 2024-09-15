using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using PUBLIC;
using System.Data;
namespace BUL
{
    public class MONHOC_BUL
    {
        MONHOC_DAL monhoc_dal = new MONHOC_DAL();
        public DataTable load_monhoc()
        {
            return monhoc_dal.load_monhoc();
        }
        public int insert_monhoc(MONHOC_PUBLIC monhoc_public)
        {
            return monhoc_dal.insert_monhoc(monhoc_public);
        }
        public int update_monhoc(MONHOC_PUBLIC monhoc_public)
        {
            return monhoc_dal.update_monhoc(monhoc_public);
        }
        public int delete_monhoc(MONHOC_PUBLIC monhoc_public)
        {
            return monhoc_dal.delete_monhoc(monhoc_public);
        }
        public DataTable load_monhocwithwhere(MONHOC_PUBLIC monhoc_public)
        {
            return monhoc_dal.load_monhocwithwhere(monhoc_public);
        }
        public DataTable load_made()
        {
            return monhoc_dal.load_made();
        }
    }
}
