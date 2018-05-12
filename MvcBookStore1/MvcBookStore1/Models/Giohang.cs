using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBookStore1.Models
{
    public class Giohang
    {
        //Tạo đối tượng data chứa dữ liệu từ model dbBansach đã tạo
        dbQLBansachDataContext data = new dbQLBansachDataContext();
        public int iMasach { get; set; }
        public string sTensach { get; set; }
        public string sAnhbia { get; set; }
        public Double dDongia { get; set; }
        public int iSoluong { get; set; }
        public Double dThanhtien { get { return iSoluong * dDongia; } }

        //Khởi tạo giỏ hàng theo Masach dc truyền vào với Soluong mac dinh là 1
        public Giohang(int Masach)
        {
            iMasach = Masach;
            SACH sach = data.SACHes.Single(n => n.Masach == iMasach);
            sTensach = sach.Tensach;
            sAnhbia = sach.Hinhminhhoa;
            dDongia = double.Parse(sach.Dongia.ToString());
            iSoluong = 1;
        }
    }
}