using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBookStore1.Models;

using PagedList;
using PagedList.Mvc;

namespace MvcBookStore1.Controllers
{
    public class BookStoreController : Controller
    {
        //Trang chính
        //-------------------------------------------------------------------
        dbQLBansachDataContext data = new dbQLBansachDataContext();
        private List<SACH> Laysachmoi(int count, string name)
        {
            if (name != null && name != "")
            {
                return (from s in data.SACHes where s.Tensach.ToUpper().Contains(name.ToUpper()) orderby s.Ngaycapnhat descending select s).Take(count).ToList();
            }
            else
                return (from s in data.SACHes orderby s.Ngaycapnhat descending select s).Take(count).ToList();
        }
        // GET: BookStore
        public ActionResult Index(int ? page, FormCollection fc)
        {
            ViewBag.TenDN = User.Identity.Name;
            //tạo biến quy định dố sp trên mỗi trang
            int pageSize = 5;
            //Tao bien so trang
            int pageNum = (page ?? 1);

            //
           
            string name = fc["SearchString"];
            //Lấy top 5 Album bán chạy nhất
            var sachmoi = Laysachmoi(15,name);
            return View(sachmoi.ToPagedList(pageNum,pageSize));

            //
            
        }

        //Chủ đề 
        //------------------------------------------------------------
        public ActionResult Chude()
        {
            var chude = from cd in data.CHUDEs select cd;
            return PartialView(chude);
        }

        public ActionResult SPTheochude(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }

        //NXB
        //------------------------------------------------------------------------
        public ActionResult Nhaxuatban()
        {
            var chude = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(chude);
        }

        public ActionResult SPTheoNXB(int id)
        {
            var sach = from s in data.SACHes where s.MaNXB == id select s;
            return View(sach);
        }

        //Chi tiết sản phẩm
        //-----------------------------------------------------------------------------------
        public ActionResult Details(int id)
        {
            var sach = from s in data.SACHes
                       where s.Masach == id
                       select s;
            return View(sach.Single());
        }
    }
}