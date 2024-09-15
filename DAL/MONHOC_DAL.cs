using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PUBLIC;
namespace DAL
{
    public class MONHOC_DAL
    {
        KETNOI ketnoi = new KETNOI();
        public DataTable load_monhoc()
        {
            string sql = "Load_MonHoc";
            return ketnoi.Load_Data(sql);
        }
        public DataTable load_monhocwithwhere(MONHOC_PUBLIC monhoc_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAMONHOC";
            values[0] = monhoc_public.MAMONHOC;
            string sql = "Load_MonHocWith_Where";
            return ketnoi.Load_DataWithParameter(sql, name, values, parameter);
        }
        public int insert_monhoc(MONHOC_PUBLIC monhoc_public)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAMONHOC";
            name[1] = "@TENMONHOC";
            values[0] = monhoc_public.MAMONHOC;
            values[1] = monhoc_public.TENMONHOC;
            string sql = "Insert_MonHoc";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int update_monhoc(MONHOC_PUBLIC monhoc_public)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAMONHOC";
            name[1] = "@MAMONHOCOLD";
            name[2] = "@TENMONHOC";
            values[0] = monhoc_public.MAMONHOC;
            values[1] = monhoc_public.MAMONHOCOLD;
            values[2] = monhoc_public.TENMONHOC;
            string sql = "Update_MonHoc";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_monhoc(MONHOC_PUBLIC monhoc_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAMONHOC";           
            values[0] = monhoc_public.MAMONHOC;         
            string sql = "Delete_MonHoc";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public DataTable load_made()
        {
            string sql = "SELECT * FROM iddethi";
            return ketnoi.Load_DataNotProcedure(sql);
        }
    }
}
