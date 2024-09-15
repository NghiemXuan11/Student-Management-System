using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using PUBLIC;
using System.Data;
namespace BUL
{
    public class DSNOPBAI_BUL
    {
        DSNOPBAI_DAL dsnopbai_dal = new DSNOPBAI_DAL();
        public DataTable load_dsnopbai()
        {
            return dsnopbai_dal.load_dsnopbai();
        }
        public int insert_dsnopbai(DSNOPBAI_PUBLIC dsnopbai_public)
        {
            return dsnopbai_dal.insert_dsnopbai(dsnopbai_public);
        }
        public int delete_dsnopbai(DSNOPBAI_PUBLIC dsnopbai_public)
        {
            return dsnopbai_dal.delete_dsnopbai(dsnopbai_public);
        }
        public int demtongdsnopbai()
        {
            return dsnopbai_dal.demtongdsnopbai();
        }

    }
}
