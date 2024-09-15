using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PUBLIC;
using System.Data;
namespace DAL
{
    public class DSNOPBAI_DAL
    {
        KETNOI ketnoi = new KETNOI();
        public DataTable load_dsnopbai()
        {
            string sql = "Load_Dsnopbai";
            return ketnoi.Load_Data(sql);
        }
        public int insert_dsnopbai(DSNOPBAI_PUBLIC dsnopbai_public)
        {
            int parameter = 6;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]="@MATHISINH";
            name[1]="@MAMONHOC";
            name[2]="@TENMONHOC";
            name[3]="@SOCAUDUNG";
            name[4]="@SOCAUSAI";
            name[5]="@MADETHI";
            values[0]=dsnopbai_public.MATHISINH;
            values[1]=dsnopbai_public.MAMONHOC;
            values[2]=dsnopbai_public.TENMONHOC;
            values[3]=dsnopbai_public.SOCAUDUNG;
            values[4]=dsnopbai_public.SOCAUSAI;
            values[5]=dsnopbai_public.MADETHI;
            string sql = "Insert_Dsnopbai";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_dsnopbai(DSNOPBAI_PUBLIC dsnopbai_public)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MATHISINH";
            name[1] = "@MADETHI";
            name[2] = "@MAMONHOC";
            values[0] = dsnopbai_public.MATHISINH;
            values[1] = dsnopbai_public.MADETHI;
            values[2] = dsnopbai_public.MAMONHOC;
            string sql = "Delete_Dsnopbai";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int demtongdsnopbai()
        {
            string sql = "Dem_TongDSNOPBAI";
            return ketnoi.ReturnIntegerWithProcedure(sql);
        }
    }
}
