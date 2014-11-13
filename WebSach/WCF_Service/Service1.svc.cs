using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;

namespace WCF_Service
{
  
    public class Service1 : IService1
    {
        QLBSEntities ds = new QLBSEntities();

        //Hien Thi Danh Sách Sản Phẩm
        public List<Sach> GetData()
        {
            List<Sach> sach = new List<Sach>();
          
             sach = (from p in ds.Saches orderby p.NgayCapNhat descending select p).ToList();
             return sach;
        }

        //Hiển thị Các chủ đê sách
        public List<ChuDe> Chude()
        {
            return   (from p in ds.ChuDes select p).ToList();
        }

        //Hiển Thị Các sản phẩm bán chạy
        public List<Sach> Sanphambanchay()
        {
           return (from t in ds.Saches where t.HetHang == false && t.Active == null orderby t.DaBan descending select t).Take(8).ToList();
        }

     
        public List<ChuDe> DSLoaiTimKiem()
        {
            return  (from p in ds.ChuDes select p).ToList();
        }

        //Hiển Thị chi tiết Sản phẩm phẩm được chọn
        public Sach Chitietsanpham(int masp)
        {
            return ds.Saches.Single(dm => dm.SachID == masp);
        }


        //public Sach SPCungLoai1(int Sachid)
        //{
        //    return (ds.Saches.SingleOrDefault(p => p.SachID == Sachid && p.Active == null));
        //}

        //public List<Sach> SPCungLoai2(int chudeid, int sachid)
        //{
        //    return (from t in ds.Saches where t.ChuDeID == chudeid && t.SachID != sachid select t).ToList();
        //}


        //Hiển thị sách theo chủ đề được chọn

        public List<Sach> TimkiemSachTheoChude(int chudeid)
        {
           return  (from t in ds.Saches where t.ChuDeID == chudeid select t).ToList();
        }



        //Login 

        //ForgotPassword 

        public List<KhachHang> ThongTinKhachHang(string email)
        {
          return (from kh in ds.KhachHangs where (kh.Email == email) select kh).ToList();
        }

        //Kiểm tra tên Đăng nhập có bị trùng
        public bool KiemtraDk(string tendangnhap)
        {
          
            var result = (ds.KhachHangs.Where(e => e.TenDangNhap == tendangnhap)).FirstOrDefault();

            return result!=null;

            //bool x = result != null;
            //return x;
        }

        // Thêm khách hàng mới khi đk

        public bool ThemKhacHang(string hoten, string diachi,string sodienthoai, string tendangnhap, string matkhau, DateTime ngaysinh, bool gioitinh, string email)
        {
            try
            {
                KhachHang dm = new KhachHang();
                dm.HoTen = hoten;
                dm.DiaChi = diachi;
                dm.DienThoai = sodienthoai;
                dm.TenDangNhap = tendangnhap;
                dm.MatKhau = matkhau;
                dm.NgaySinh = ngaysinh;
                dm.GioiTinh = gioitinh;
                dm.Email = email;
               
                ds.KhachHangs.Add(dm);
                ds.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //login






        public List<KhachHang> KiemTraDangNhap(string tendangnhap, string pass)
        {
            return (from t in ds.KhachHangs where (t.TenDangNhap == tendangnhap)  select t).ToList();
        }



#region Thêm sách

        public bool InsertSach(string tensach, int giaban, int chudeID, int nhaxuatbanID, string mota, string hinhbia, int sotrang, int trongluong, DateTime ngaycapnhap, int soluongban, bool hethang, int daban)
        {
            try
            {
                Sach dm = new Sach();
                dm.TenSach = tensach;
                dm.GiaBan = giaban;
                dm.ChuDeID = chudeID;
                dm.NhaXuatBanID = nhaxuatbanID;
                dm.MoTa = mota;
                dm.HinhBia = hinhbia;
                dm.SoTrang = sotrang;
                dm.TrongLuong = trongluong;
                dm.NgayCapNhat = ngaycapnhap;
              
                dm.SoLuongBan = soluongban;
                dm.HetHang = hethang;
                dm.DaBan = daban;

                ds.Saches.Add(dm);
                ds.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateSach(int sachid, string tensach, int giaban, int chudeID, int nhaxuatbanID, string mota, string hinhbia, int sotrang, int trongluong, DateTime ngaycapnhap, int soluongban, bool hethang, int daban)
        {
            try
            {
                Sach dm = ds.Saches.Single(d => d.SachID == sachid);

                dm.TenSach = tensach;
                dm.GiaBan = giaban;
                dm.ChuDeID = chudeID;
                dm.NhaXuatBanID = nhaxuatbanID;
                dm.MoTa = mota;
                dm.HinhBia = hinhbia;
                dm.SoTrang = sotrang;
                dm.TrongLuong = trongluong;
                dm.NgayCapNhat = ngaycapnhap;
                dm.SoLuongBan = soluongban;
                dm.HetHang = hethang;
                dm.DaBan = daban;
                ds.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteSach(int sachid)
        {
            try
            {
                Sach dm = ds.Saches.Single(d => d.SachID == sachid);
                dm.Active = true;
                ds.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
               return false;
            }
         
        }


        public List<Sach> HienthiSach()
        {
            return (from p in ds.Saches where(p.Active==null) select p).ToList();
        }

#endregion


        //Kiêm Tra đăng Nhập Form
        public bool KiemTraDNForm(string user, string pass)
        {
            var result = (ds.KhachHangs.Where(e => e.TenDangNhap == user&&e.MatKhau==pass&&e.Admin==true)).FirstOrDefault();

            return result != null;
        }



        // Kiểm Tra khách hàng đã đăng nhập vào trang web để lấy thông tin kh
        public List<KhachHang> KiemtraTendangnhap(string tendangnhap)
        {
            return (from t in ds.KhachHangs where (t.TenDangNhap == tendangnhap) select t).ToList();
        }


        public DatHang ThemDonDathang(int makh, string tenkh, string diadiem, DateTime ngaydathang, double trigia, bool dagiao)
        {
            try
            {
                DatHang dh = new DatHang();
                dh.KhachHangID = makh;
                dh.TenKhachHang = tenkh;
                dh.DiaDiem = diadiem;
                dh.NgayDatHang = ngaydathang;
                dh.TriGia = trigia;
                dh.DaGiao = dagiao;

                ds.DatHangs.Add(dh);
                ds.SaveChanges();
                return dh;
            }
            catch (Exception)
            {

                return null;
            }
           
        }


        public Sach LaychitietSach_donDH(int sachid)
        {
            return (from sa in ds.Saches where (sa.SachID == sachid) select sa).FirstOrDefault() ;
        }


        public bool ThemChitietDonDatHang(int dathangid, int sachid, int soluong, double dongia, double thanhtien)
        {
            try
            {
                DatHangCT dh= new DatHangCT();
                dh.DatHangID = dathangid;
                dh.SachID = sachid;
                dh.SoLuong = soluong;
                dh.DonGia = dongia;
                dh.ThanhTien = thanhtien;

                ds.DatHangCTs.Add(dh);
                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public KhachHang LayKhachHang(string tendangnhap)
        {
            return (from kh in ds.KhachHangs where (kh.TenDangNhap == tendangnhap) select kh).FirstOrDefault();
        }





#region    service Nhap Hang

        // Thêm phiếu nhập
        public bool ThemPhieuNhap(DateTime ngaynhap,float tongtien)
        {
            try
            {
                PhieuNhap p = new PhieuNhap();
                p.NgayNhap = ngaynhap;
                p.TongTien = tongtien;
                ds.PhieuNhaps.Add(p);
                ds.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
               return false;
            }
        }

        // Hiển thị ds phiếu Nhập
        public List<PhieuNhap> GetPhieuNhap()
        {
            return (from p in ds.PhieuNhaps select p).ToList();
        }

        // Lấy chi tiết phiếu Nhập theo mã của phiếu nhập
        public List<PhieuNhapCT> GetPhieuNhapCT(int phieunhapid)
        {
            return (from p in ds.PhieuNhapCTs where(p.IDPhieuNhap==phieunhapid)select p).ToList();
        }


        public bool ThemChiTietPhieuNhap(int idphieunhap, int idmasach, float dongia, float thanhtien, int soluong)
        {

            try
            {
                PhieuNhapCT p = new PhieuNhapCT();
                p.IDPhieuNhap = idphieunhap;
                p.IDSach = idmasach;
                p.DonGia = dongia;
                p.ThanhTien = thanhtien;
                p.SoLuong = soluong;
                ds.PhieuNhapCTs.Add(p);
                ds.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           

        }

        public float ThanhTien(int maphieunhap)
        {
           
                  var kh=(from o in ds.PhieuNhapCTs
                  where o.IDPhieuNhap == maphieunhap
                  select new {o.ThanhTien}
                  ).ToList();

                  return (Convert.ToSingle(kh.Sum(x=>x.ThanhTien)));
          
        }


        public bool UpdatePhieuNhap(int maphieunhap, float thanhtien)
        {
           

            try
            {
                PhieuNhap dm = ds.PhieuNhaps.Single(d => d.ID==maphieunhap);

                dm.TongTien = thanhtien;
                ds.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool XoaPhieuNhapCT(int ma)
        {
        
            PhieuNhapCT all = (from c in ds.PhieuNhapCTs where (c.ID==ma)select c).FirstOrDefault();
            ds.PhieuNhapCTs.Remove(all);
            ds.SaveChanges();
            return true;

        }


        public bool ThemsoLuongSach(int masach, int soluong)
        {
            try
            {
                Sach dm = ds.Saches.Single(d => d.SachID == masach);       
                dm.SoLuongBan = dm.SoLuongBan+soluong;
                ds.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool GiamSoLuongSach(int masach, int soluong)
        {
            try
            {
                Sach dm = ds.Saches.Single(d => d.SachID == masach);
                dm.SoLuongBan = dm.SoLuongBan - soluong;
                ds.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


#endregion



        /// <summary>
        /// tac giac
        /// </summary>
        /// <returns></returns>
        public List<TacGia> HienTHiTacGia()
        {
            return ds.TacGias.ToList();
        }


        public bool ThemTacGia(string tentacgia, string diachi)
        {
            try
            {
                TacGia dd = new TacGia();
                dd.TenTacGia = tentacgia;
                dd.DiaChi =diachi;
                ds.TacGias.Add(dd);
                ds.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                
               return false;
            }
        }


        public bool XoaTacGia(int matacgia)
        {
            try
            {
                TacGia all = (from c in ds.TacGias where (c.TacGiaID == matacgia) select c).FirstOrDefault();
                ds.TacGias.Remove(all);
                ds.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool UpdateTacGia(int matacgia, string ten, string diachi)
        {
            try
            {
                TacGia dm = ds.TacGias.Single(d => d.TacGiaID == matacgia);
               
                dm.TenTacGia = ten;
                dm.DiaChi = diachi;
                ds.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
         
        }

     


  #region Tồn Kho
        public List<Sach> ThongKeConHang()
        {
          
            List<Sach> kh = (from o in ds.Saches
                      where o.Active == null && o.SoLuongBan!=0
                      select o
                 ).ToList();

            return kh;
        }
        public List<Sach> ThongKeHetHang()
        {
            List<Sach> kh = (from o in ds.Saches
                             where o.Active == null && o.SoLuongBan == 0
                             select o
             ).ToList();

            return kh;
        }
  #endregion




 #region Xử lÝ đơn hàng
        public List<DatHang> DsdondatHang()
        {
            List<DatHang> kh = (from o in ds.DatHangs
                           
                             select o
              ).ToList();

            return kh;
        }

        //chi tiet hoa don theo ma
        public List<DatHangCT> CHitietdondathang(int madondh)
        {
            return (from i in ds.DatHangCTs where i.DatHangID == madondh select i).ToList();
        }
        public List<DatHangCT> DsDatHangCts()
        {
            return ds.DatHangCTs.ToList();
        }

        public bool ThemChiTietDonHang(int dathangid, int sachid, int soluong, float dongia, float thanhtien)
        {
            try
            {
                DatHangCT ct = new DatHangCT();
                ct.DatHangID = dathangid;
                ct.SachID = sachid;
                ct.SoLuong = soluong;
                ct.DonGia = dongia;
                ct.ThanhTien = thanhtien;
                ds.DatHangCTs.Add(ct);
                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           

        }

        public bool XoachitietDH(int dathangid, int sachid)
        {

            DatHangCT all = (from c in ds.DatHangCTs where (c.DatHangID == dathangid && c.SachID == sachid) select c).FirstOrDefault();
            ds.DatHangCTs.Remove(all);
            ds.SaveChanges();
            return true;
        }

        // tinh gia tri hoa don
        public float TongGiaTriHoadon(int madh)
        {
            var k = (from o in ds.DatHangCTs
                      where o.DatHangID == madh
                      select new { o.ThanhTien }
                ).ToList();

            return (Convert.ToSingle(k.Sum(x => x.ThanhTien)));
        }

        // cap nhat don hang
        public bool UpdateDonHang(int mahd, float tien)
        {
            try
            {
                DatHang dm = ds.DatHangs.Single(d => d.DatHangID == mahd);

           
                dm.TriGia = tien;
                ds.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // cap nhat trang thai
        public bool UpdateTrangThai(int mahd)
        {
            try
            {
                DatHang dm = ds.DatHangs.Single(d => d.DatHangID == mahd);


                dm.DaGiao = true;
                ds.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
  #endregion













     
    }



}
