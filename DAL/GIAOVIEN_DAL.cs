using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PUBLIC;
using System.Data;
namespace DAL
{
    public class GIAOVIEN_DAL
    {
        KETNOI ketnoi = new KETNOI();
        public DataTable load_giaovien()
        {
            string sql = "Load_GiaoVien";
            return ketnoi.Load_Data(sql);
        }
        public int insert_giaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            int parameter = 5;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAGV";
            name[1] = "@TENGIAOVIEN";
            name[2] = "@GIOITINH";
            name[3] = "@NGAYSINH";
            name[4] = "@MAMONHOC";
            values[0] = giaovien_public.MAGV;
            values[1] = giaovien_public.TENGV;
            values[2] = giaovien_public.GIOITINH;
            values[3] = giaovien_public.NGAYSINH;
            values[4] = giaovien_public.MAMONHOC;
            string sql = "Insert_GiaoVien";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int update_giaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            int parameter = 6;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAGV";
            name[1] = "@MAGVOLD";
            name[2] = "@TENGIAOVIEN";
            name[3] = "@GIOITINH";
            name[4] = "@NGAYSINH";
            name[5] = "@MAMONHOC";
            values[0] = giaovien_public.MAGV;
            values[1] = giaovien_public.MAGVOLD;
            values[2] = giaovien_public.TENGV;
            values[3] = giaovien_public.GIOITINH;
            values[4] = giaovien_public.NGAYSINH;
            values[5] = giaovien_public.MAMONHOC;
            string sql = "Update_GiaoVien";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_giaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MAGV";           
            values[0] = giaovien_public.MAGV;           
            string sql = "Delete_GiaoVien";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int insert_hinhgiaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            int parameter = 2;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@HINH";
            name[1] = "@MAGV";
            values[0] = giaovien_public.HINH;
            values[1] = giaovien_public.MAGV;           
            string sql = "Insert_HinhGiaoVien";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int update_hinhgiaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@ID";
            name[1] = "@HINH";
            name[2] = "@MAGV";
            values[0] = giaovien_public.IDHINH;
            values[1] = giaovien_public.HINH;
            values[2] = giaovien_public.MAGV;
            string sql = "Update_HinhGiaoVien";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_hinhgiaovien(GIAOVIEN_PUBLIC giaovien_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@ID";            
            values[0] = giaovien_public.IDHINH;          
            string sql = "Delete_HinhGiaoVien";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public DataTable load_giaovien_voidieukien(GIAOVIEN_PUBLIC giaovien_public)
        {            
            string sql = "SELECT giaovien.TENGIAOVIEN,giaovien.MAGV,monhoc.TENMONHOC,giaovien.GIOITINH,monhoc.mamonhoc ,hinhgv.HINH FROM giaovien INNER JOIN monhoc ON giaovien.MAMONHOC=monhoc.MAMONHOC INNER JOIN hinhgv ON giaovien.MAGV=hinhgv.MAGV WHERE giaovien.MAGV='"+giaovien_public.MAGV+"'";
            return ketnoi.Load_DataNotProcedure(sql);
        }
        public DataTable load_gv_PD(GIAOVIEN_PUBLIC giaovien_public)
        {
            string sql = "SELECT TENGIAOVIEN,MAGV FROM giaovien WHERE MAGV='" + giaovien_public.MAGV + "'";
            return ketnoi.Load_DataNotProcedure(sql);
        }
    }
}
