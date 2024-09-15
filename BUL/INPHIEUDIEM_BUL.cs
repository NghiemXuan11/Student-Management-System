using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using PUBLIC;
namespace BUL
{
    public class INPHIEUDIEM_BUL
    {
        INPHIEUDIEM_DAL inphieudiem_dal = new INPHIEUDIEM_DAL();
        public DataTable load_phieudiem(INPHIEUDIEM_PUBLIC phieudiem_public)
        {
            return inphieudiem_dal.load_phieudiem(phieudiem_public);
        }
        public int insert_phieudiem(INPHIEUDIEM_PUBLIC phieudiem_public)
        {
            return inphieudiem_dal.insert_phieudiem(phieudiem_public);
        }
        public int delete_phieudiem(INPHIEUDIEM_PUBLIC phieudiem_public)
        {
            return inphieudiem_dal.delete_phieudiem(phieudiem_public);
        }
    }
}
