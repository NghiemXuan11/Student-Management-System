using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PUBLIC;
namespace DAL
{
    public class THISINH_DAL
    {
        KETNOI ketnoi = new KETNOI();
        public DataTable load_thisinh()
        {
            string sql = "Load_ThiSinh";
            return ketnoi.Load_Data(sql);
        }
        public int insert_thisinh(THISINH_PUBLIC thisinh_public)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]="@MATS";
            name[1]="@TENTHISINH";
            name[2]="@GIOITINH";
            name[3]="@NGAYSINH";
            values[0]=thisinh_public.MATS;
            values[1]=thisinh_public.TENTHISINH;
            values[2]=thisinh_public.GIOITINH;
            values[3]=thisinh_public.NGAYSINH;
            string sql = "Insert_ThiSinh";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int update_thisinh(THISINH_PUBLIC thisinh_public)
        {
            int parameter = 5;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MATS";
            name[1] = "@MATSOLD";
            name[2] = "@TENTHISINH";
            name[3] = "@GIOITINH";
            name[4] = "@NGAYSINH";
            values[0] = thisinh_public.MATS;
            values[1] = thisinh_public.MATSOLD;
            values[2] = thisinh_public.TENTHISINH;
            values[3] = thisinh_public.GIOITINH;
            values[4] = thisinh_public.NGAYSINH;
            string sql = "Update_ThiSinh";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_thisinh(THISINH_PUBLIC thisinh_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MATS";            
            values[0] = thisinh_public.MATS;            
            string sql = "Delete_ThiSinh";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int insert_hinhthisinh(THISINH_PUBLIC thisinh_public)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@HINH";
            name[1] = "@MATS";
            values[0] = thisinh_public.HINH;
            values[1] = thisinh_public.MATS;
            string sql = "Insert_HinhThiSinh";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int update_hinhthisinh(THISINH_PUBLIC thisinh_public)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@ID";
            name[1] = "@HINH";
            name[2] = "@MATS";
            values[0] = thisinh_public.IDHINH;
            values[1] = thisinh_public.HINH;
            values[2] = thisinh_public.MATS;
            string sql = "Update_HinhThiSinh";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_hinhthisinh(THISINH_PUBLIC thisinh_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@ID";          
            values[0] = thisinh_public.IDHINH;
            string sql = "Delete_HinhThiSinh";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public DataTable load_thisinh_voidieukien(THISINH_PUBLIC thisinh_public)
        {
            string sql = "select thisinh.TENTHISINH,thisinh.MATS,thisinh.GIOITINH,hinhts.HINH from thisinh inner join hinhts on thisinh.MATS=hinhts.MATS where thisinh.MATS='"+thisinh_public.MATS+"'";
            return ketnoi.Load_DataNotProcedure(sql);
        }
        public DataTable load_ts_PD(THISINH_PUBLIC thisinh_public)
        {
            string sql = "SELECT TENTHISINH,MATS FROM thisinh WHERE MATS='"+thisinh_public.MATS+"'";
            return ketnoi.Load_DataNotProcedure(sql);
        }
    }
}
