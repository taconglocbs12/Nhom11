using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Service
{
     
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        
      //Hien Thi Danh Sách Sản Phẩm
        [OperationContract]
        List<Sach> GetData();
        
        //Hiển thị Các chủ đê sách
        [OperationContract]
        List<ChuDe> Chude();

        //Hiển thị sách theo chủ đề được chọn
        [OperationContract]
        List<Sach> TimkiemSachTheoChude(int chudeid);


        //Hiển Thị Các sản phẩm bán chạy
        [OperationContract]
        List<Sach> Sanphambanchay();


        [OperationContract]
        List<ChuDe> DSLoaiTimKiem();


        //Hiển Thị chi tiết Sản phẩm phẩm được chọn
        [OperationContract]
        Sach Chitietsanpham(int masp);



        //[OperationContract]
        //Sach SPCungLoai1(int Sachid);
        //[OperationContract]
        //List<Sach> SPCungLoai2(int chudeid, int sachid);

      

        //ForgotPassword 
        [OperationContract]
        List<KhachHang> ThongTinKhachHang(string email);

        //Đăng kí 

        //Kiểm tra tên Đăng nhập có bị trùng
        [OperationContract]
        bool KiemtraDk(string tendangnhap);

        // Thêm khách hàng mới khi đk
        [OperationContract]
        bool ThemKhacHang(string hoten,string diachi,string sodienthoai,string tendangnhap,string matkhau,DateTime ngaysinh,bool gioitinh,string email);



        //Login khách hàng
        [OperationContract]
        List<KhachHang> KiemTraDangNhap(string tendangnhap,string pass);



        //Kiem tra đăng Nhập Admin From
        [OperationContract]
        bool KiemTraDNForm(string user,string pass);

        //Hiển thị sách tren form
        [OperationContract]
        List<Sach> HienthiSach();

        //thêm sách
        [OperationContract]
       
        bool InsertSach(string tensach, int giaban, int chudeID, int nhaxuatbanID, string mota, string hinhbia, int sotrang, int trongluong, DateTime ngaycapnhap, int soluongban, bool hethang, int daban);
       //cap nhat sách
        [OperationContract]
        bool UpdateSach(int sachid, string tensach, int giaban, int chudeID, int nhaxuatbanID, string mota, string hinhbia, int sotrang, int trongluong, DateTime ngaycapnhap, int soluongban, bool hethang, int daban);
        
        //Xóa sách
        [OperationContract]
        bool DeleteSach(int sachid);




        //Cart
         [OperationContract]
        // Kiểm Tra khách hàng đã đăng nhập vào trang web để lấy thông tin kh
        List<KhachHang> KiemtraTendangnhap(string tendangnhap);


        //Thêm đơn đặt hàng khi khác hàng mua
        [OperationContract]
        DatHang ThemDonDathang(int makh, string tenkh,string diadiem, DateTime ngaydathang, double trigia, bool dagiao);


        //Lấy chi tiết sách
        [OperationContract]
        Sach LaychitietSach_donDH(int sachid);


        // Thêm chi tiết của đơn đặt hàng
        [OperationContract]
        bool ThemChitietDonDatHang(int dathangid,int sachid,int soluong,double dongia,double thanhtien);

        //lấy thông tin khách hàng
        [OperationContract]
        KhachHang LayKhachHang(string tendangnhap);



#region Xử lý Nhập Hàng, service Nhập

        // Hiển thị ds phiếu Nhập
        [OperationContract]
        List<PhieuNhap> GetPhieuNhap();

        // Thêm phiếu nhập
        [OperationContract]
        bool ThemPhieuNhap(DateTime ngayNhap, float tongtien);

        // Lấy chi tiết phiếu Nhập theo mã của phiếu nhập
         [OperationContract]
        List<PhieuNhapCT> GetPhieuNhapCT(int phieunhapid);

        //Thêm chi tiết phiếu nhập
        [OperationContract]
        bool ThemChiTietPhieuNhap(int idphieunhap, int idmasach, float dongia, float thanhtien, int soluong);


        //Tính tổng tiền của tất cả các phiếu chi tiết
        [OperationContract]
        float ThanhTien(int maphieunhap);

        //Update lại số tiên của phiếu nhập hàng
        [OperationContract]
        bool UpdatePhieuNhap(int maphieunhap, float thanhtien);


        // Xóa phiếu nhập chi tiết
        [OperationContract]
        bool XoaPhieuNhapCT(int ma);



        // Tiến hành thêm số lượng sách khi nhập hàng
        [OperationContract]
        bool ThemsoLuongSach(int masach,int soluong);
        [OperationContract]
        bool GiamSoLuongSach(int masach, int soluong);

#endregion
   
   

   
#region Quản Lý tác Giả


        // them, sua, xoa Tac Gia
        [OperationContract]
        List<TacGia> HienTHiTacGia();

        [OperationContract]
        bool ThemTacGia(string tentacgia, string diachi );

        [OperationContract]
        bool XoaTacGia(int matacgia);
        [OperationContract]
        bool UpdateTacGia(int matacgia,string ten,string diachi);

#endregion


#region Tồn kho

        [OperationContract]
        List<Sach> ThongKeConHang();

        [OperationContract]
        List<Sach> ThongKeHetHang();
#endregion



#region xử lý đơn Hàng

        //hien thi ds đơn đặt hàng
        [OperationContract]
        List<DatHang> DsdondatHang();

        //hiển thi chi tiết đơn đặt hàng theo mã hóa đơn
        [OperationContract]
        List<DatHangCT> CHitietdondathang(int madondh);

        //Ds tất cả các chi tiết đơn đặt hàng
        [OperationContract]
        List<DatHangCT> DsDatHangCts();

        
        //thêm, xóa một chi tiết đơn đặt hàng
        [OperationContract]
        bool ThemChiTietDonHang(int dathangid,int sachid,int soluong,float dongia,float thanhtien);

        [OperationContract]
        bool XoachitietDH(int dathangid, int sachid);


        //Tính tổng giá trị Hóa đơn
        [OperationContract]
        float TongGiaTriHoadon(int madh);
        // Cập nhật ddơn hàng
        [OperationContract]
        bool UpdateDonHang(int mahd, float tien);
        [OperationContract]
         
        //Thay đổi trạng thái giao và chưa giao
        bool UpdateTrangThai(int mahd);




 #endregion







    }
    

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
  
   
}
