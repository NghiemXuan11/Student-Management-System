using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using PUBLIC;
namespace BUL
{
    public class CAUHOI_BUL
    {
        CAUHOI_DAL cauhoi_dal = new CAUHOI_DAL();
        public DataTable load_cauhoi(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.load_cauhoi(cauhoi_public);
        }
        public int insert_iddethi(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.insert_iddethi(cauhoi_public);
        }
        public int insert_cauhoi(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.insert_cauhoi(cauhoi_public);
        }
        public int update_cauhoi(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.update_cauhoi(cauhoi_public);
        }
        public int delete_cauhoi(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.delete_cauhoi(cauhoi_public);
        }
        public int update_cauhoidachon(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.update_cauhoidachon(cauhoi_public);
        }
        public int update_cauhoidachonRD(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.update_cauhoidachonRD(cauhoi_public);
        }
        public DataTable load_cauhoidachon(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.load_cauhoidachon(cauhoi_public);
        }
        public int check_caudung(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.check_caudung(cauhoi_public);
        }
        public DataTable load_cauhoi_insert(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.load_cauhoi_insert(cauhoi_public);
        }
        public int delete_cauhoiDACHON(CAUHOI_PUBLIC cauhoi_public)
        {
            return cauhoi_dal.delete_cauhoiDACHON(cauhoi_public);
        }
    }
}
