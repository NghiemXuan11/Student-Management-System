using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PUBLIC;
namespace DAL
{
    public class TAIKHOAN_DAL
    {
        KETNOI ketnoi = new KETNOI();

        public DataTable load_taikhoan()
        {
            string sql = "Load_TaiKhoan";
            return ketnoi.Load_Data(sql);
        }
        public int insert_taikhoan(TAIKHOAN_PUBLIC taikhoan_public)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]="@TENTK";
            name[1]="@MATKHAU";
            name[2]="@IDTAIKHOAN";
            name[3]="@QUYEN";
            values[0]=taikhoan_public.TENTK;
            values[1]=taikhoan_public.MATKHAU;
            values[2]=taikhoan_public.IDTAIKHOAN;
            values[3]=taikhoan_public.QUYEN;
            string sql = "Insert_TaiKhoan";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int update_taikhoan(TAIKHOAN_PUBLIC taikhoan_public)
        {
            int parameter = 4;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@TENTK";
            name[1] = "@MATKHAU";
            name[2] = "@IDTAIKHOAN";
            name[3] = "@QUYEN";
            values[0] = taikhoan_public.TENTK;
            values[1] = taikhoan_public.MATKHAU;
            values[2] = taikhoan_public.IDTAIKHOAN;
            values[3] = taikhoan_public.QUYEN;
            string sql = "Update_TaiKhoan";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_taikhoan(TAIKHOAN_PUBLIC taikhoan_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@TENTK";            
            values[0] = taikhoan_public.TENTK;            
            string sql = "Delete_TaiKhoan";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int check_dangnhap(TAIKHOAN_PUBLIC taikhoan_public)
        {
            string sql = "SELECT COUNT(*) FROM TAIKHOAN WHERE TENTK='" + taikhoan_public.TENTK + "' AND MATKHAU='" + taikhoan_public.MATKHAU + "'";
            return ketnoi.ReturnInteger(sql);
        }
        public string check_quyentaikhoan(TAIKHOAN_PUBLIC taikhoan_public)
        {
            string sql = "SELECT QUYEN FROM TAIKHOAN WHERE TENTK='" + taikhoan_public.TENTK + "' AND MATKHAU='" + taikhoan_public.MATKHAU + "'";
            return ketnoi.ReturnString(sql);
        }
        public string get_IDTAIKHOAN(TAIKHOAN_PUBLIC taikhoan_public)
        {
            string sql = "SELECT IDTAIKHOAN FROM TAIKHOAN WHERE TENTK='" + taikhoan_public.TENTK + "' AND MATKHAU='" + taikhoan_public.MATKHAU + "'";
            return ketnoi.ReturnString(sql);
        }
    }
}
