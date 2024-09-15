using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PUBLIC;
namespace DAL
{
    public class CAUHOI_DAL
    {
        KETNOI ketnoi = new KETNOI();
        public DataTable load_cauhoi(CAUHOI_PUBLIC cauhoi_public)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAMONHOC";
            name[1] = "@MADETHI";
            values[0] = cauhoi_public.MAMONHOC;
            values[1] = cauhoi_public.MADETHI;
            string sql = "Load_CauHoi";
            return ketnoi.Load_DataWithParameter(sql, name, values, parameter);
        }
        public DataTable load_cauhoi_insert(CAUHOI_PUBLIC cauhoi_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAMONHOC";            
            values[0] = cauhoi_public.MAMONHOC;
            string sql = "SELECT cauhoi.noidung,cauhoi.DA1,cauhoi.DA2,cauhoi.DA3,cauhoi.DA4,cauhoi.DA,monhoc.TENMONHOC,cauhoi.DAPAN,cauhoi.madethi FROM CAUHOI INNER JOIN monhoc ON monhoc.MAMONHOC=cauhoi.MAMONHOC where cauhoi.MAMONHOC=@MAMONHOC";
            return ketnoi.Load_DataWithParameterNotprocedure(sql, name, values, parameter);
        }
        public int insert_iddethi(CAUHOI_PUBLIC cauhoi_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MADETHI";          
            values[0] = cauhoi_public.MADETHI;
            string sql = "Insert_Iddethi";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int insert_cauhoi(CAUHOI_PUBLIC cauhoi_public)
        {
            int parameter = 9;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]="@NOIDUNG";
            name[1]="@DA1";
            name[2]="@DA2";
            name[3]="@DA3";
            name[4]="@DA4";
            name[5]="@DA";
            name[6] = "@MAMONHOC";
            name[7] = "@DAPAN";
            name[8] = "@MADETHI";
            values[0]=cauhoi_public.NOIDUNG;
            values[1]=cauhoi_public.DA1;
            values[2]=cauhoi_public.DA2;
            values[3]=cauhoi_public.DA3;
            values[4]=cauhoi_public.DA4;
            values[5] = cauhoi_public.DA;
            values[6] = cauhoi_public.MAMONHOC;
            values[7] = cauhoi_public.DAPAN;
            values[8] = cauhoi_public.MADETHI;
            string sql = "Insert_CauHoi";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int update_cauhoi(CAUHOI_PUBLIC cauhoi_public)
        {
            int parameter = 8;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@NOIDUNG";
            name[1] = "@NOIDUNGOLD";
            name[2] = "@DA1";
            name[3] = "@DA2";
            name[4] = "@DA3";
            name[5] = "@DA4";
            name[6] = "@DA";
            name[7] = "@DAPAN";
            values[0] = cauhoi_public.NOIDUNG;
            values[1] = cauhoi_public.NOIDUNGOLD;
            values[2] = cauhoi_public.DA1;
            values[3] = cauhoi_public.DA2;
            values[4] = cauhoi_public.DA3;
            values[5] = cauhoi_public.DA4;
            values[6] = cauhoi_public.DA;
            values[7] = cauhoi_public.DAPAN;
            string sql = "Update_CauHoi";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_cauhoi(CAUHOI_PUBLIC cauhoi_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@NOIDUNG";           
            values[0] = cauhoi_public.NOIDUNG;          
            string sql = "Delete_CauHoi";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_cauhoiDACHON(CAUHOI_PUBLIC cauhoi_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@NOIDUNG";
            values[0] = cauhoi_public.NOIDUNG;
            string sql = "Delete_CauHoiDaChon";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int update_cauhoidachon(CAUHOI_PUBLIC cauhoi_public)
        {                         
                int parameter = 2;
                string[] name = new string[parameter];
                object[] values = new object[parameter];
                name[0] = "@MAMONHOC";
                name[1] = "@MADETHI";
                values[0] = cauhoi_public.MAMONHOC;
                values[1] = cauhoi_public.MADETHI;
                string sql = "Update_CauHoiDaChon";
                return ketnoi.Execute(sql, name, values, parameter);                
        }

        public int update_cauhoidachonRD(CAUHOI_PUBLIC cauhoi_public)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@noidung";
            name[1] = "@DA";
            values[0] = cauhoi_public.NOIDUNG;
            values[1] = cauhoi_public.DA;
            string sql = "Update_CauHoiDaChonRD";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public DataTable load_cauhoidachon(CAUHOI_PUBLIC cauhoi_public)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAMONHOC";
            name[1] = "@MADETHI";
            values[0] = cauhoi_public.MAMONHOC;
            values[1] = cauhoi_public.MADETHI;
            string sql = "Load_CauHoiDaChon";
            return ketnoi.Load_DataWithParameter(sql, name, values, parameter);
        }
        public int check_caudung(CAUHOI_PUBLIC cauhoi_public)
        {          
                string sql = "SELECT COUNT(*) FROM cauhoi WHERE cauhoi.DA=N'" + cauhoi_public.DA + "' and cauhoi.noidung=N'" + cauhoi_public.NOIDUNG + "'";
                return ketnoi.ReturnInteger(sql);                                                       
        }
    }
}
