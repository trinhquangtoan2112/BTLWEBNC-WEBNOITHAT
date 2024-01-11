using BTLWEBNC_WEBNOITHAT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BTLWEBNC_WEBNOITHAT.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]

    public class HomeAdminController : Controller
    {
        QlbanNoiThatContext db = new QlbanNoiThatContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);

            return View(lst);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = db.TDanhMucSps.FirstOrDefault(p => p.MaSp == sanPham.MaSp);
                if (existingProduct != null)
                {
                    ModelState.AddModelError("MaSp", "Mã sản phẩm đã tồn tại");
                    ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
                    return View(sanPham);
                }
                else
                {
                    if (sanPham.ThoiGianBaoHanh > 0)
                    {
                        db.TDanhMucSps.Add(sanPham);
                        db.SaveChanges();
                        return RedirectToAction("DanhMucSanPham");
                    }
                    else
                    {
                        ModelState.AddModelError("ThoiGianBaoHanh", "Thời gian bảo hành phải lớn hơn 0");
                        ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
                        return View(sanPham);
                    }
                }
            }
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            return View(sanPham);
            //if (ModelState.IsValid)
            //{
            //    db.TDanhMucSps.Add(sanPham);
            //    db.SaveChanges();
            //    return RedirectToAction("DanhMucSanPham");
            //}
            //return View(sanPham);
        }
        

        [Route("UpdateSanPham")]
        [HttpGet]
        public IActionResult UpdateSanPham(string maSanPham)
        {
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(), "MaLoai", "Loai");
            var sanPham = db.TDanhMucSps.Find(maSanPham);
            return View(sanPham);
        }
        [Route("UpdateSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSanPham(TDanhMucSp sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(sanPham);
        }
        
        [Route("XoaSanPham")]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.TChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();
            if (chiTietSanPham.Count > 0)
            {
                TempData["Message"] = "Không xóa được sản phẩm này!";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSanPham);
            if (anhSanPham.Any()) db.RemoveRange(anhSanPham);
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm này đã được xóa!";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }
    }
}
