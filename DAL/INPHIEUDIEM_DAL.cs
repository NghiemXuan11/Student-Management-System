using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PUBLIC;
using System.Data;
namespace DAL
{
    public class INPHIEUDIEM_DAL
    {
        KETNOI ketnoi = new KETNOI();
        public DataTable load_phieudiem(INPHIEUDIEM_PUBLIC phieudiem_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@MATS";
            values[0] = phieudiem_public.MATS;
            string sql = "Load_PhieuDiem";
            return ketnoi.Load_DataWithParameter(sql, name, values, parameter);
        }
        public int insert_phieudiem(INPHIEUDIEM_PUBLIC phieudiem_public)
        {
            int parameter = 7;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0]="@monthi";
            name[1]="@tongsocau";
            name[2]="@socaudung";
            name[3]="@socausai";
            name[4]="@tongdiem";
            name[5]="@MATS";
            name[6] = "@madethi";
            values[0]=phieudiem_public.Monthi;
            values[1]=phieudiem_public.Tongsocau;
            values[2]=phieudiem_public.Socaudung;
            values[3]=phieudiem_public.Socausai;
            values[4]=phieudiem_public.Tongdiem;
            values[5]=phieudiem_public.MATS;
            values[6] = phieudiem_public.Madethi;
            string sql = "Insert_PhieuDiem";
            return ketnoi.Execute(sql, name, values, parameter);
        }
        public int delete_phieudiem(INPHIEUDIEM_PUBLIC phieudiem_public)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];          
            name[0] = "@MATS";                    
            values[0] = phieudiem_public.MATS;           
            string sql = "Delete_PhieuDiem";
            return ketnoi.Execute(sql, name, values, parameter);
        }
    }
}
