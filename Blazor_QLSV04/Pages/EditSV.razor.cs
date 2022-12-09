using Blazor_QLSV04.Data;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace Blazor_QLSV04.Pages
{
    public partial class EditSV:ComponentBase
    {
        public SinhVienEditModel EditModel1 { get; set; } = new SinhVienEditModel();
        [Parameter] public EventCallback Thoat1 { get; set; }
        [Parameter] public EventCallback<SinhVien> ThayDoi1 { set; get; }//Thành phần con hiển thị một sự kiện. Thành phần cha gán một phương thức gọi lại cho sự kiện của thành phần con. Trong Blazor, để thể hiện một sự kiện=> sử dụng EventCallback
        [Inject] InterFace x1 { get; set; }
        public void UpdateSv1()
        {
            SinhVien a = new SinhVien();
            a.SinhVienID = EditModel1.id;
            a.Ten = EditModel1.ten;
            a.GioiTinh = EditModel1.gioitinh;
            a.Tuoi = EditModel1.tuoi;
            a.DiemToan = EditModel1.diemtoan;
            a.DiemVan = EditModel1.diemvan;
            a.DiemAnh = EditModel1.diemanh;
            a.DiemTB = x1.TinhDTB(a);
            a.HocLuc = x1.XepLoaiHocLuc(a);
            //Thực hiện update sinh viên
            x1.AddSinhVien(a);
            ThayDoi1.InvokeAsync(a);//Mục đích để khi ấn nút submit ở "component" nó sẽ thông báo rằng có thay đổi để update lại sv
        }
    }
}
