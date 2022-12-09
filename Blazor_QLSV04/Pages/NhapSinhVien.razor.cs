using Blazor_QLSV04.Data;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace Blazor_QLSV04.Pages
{
    public partial class NhapSinhVien:ComponentBase
    {
        public SinhVienEditModel EditModel { get; set; } = new SinhVienEditModel();
        [Parameter] public EventCallback Thoat { get; set; }
        [Parameter] public EventCallback<SinhVien> ThayDoi { set; get; }//Thành phần con hiển thị một sự kiện. Thành phần cha gán một phương thức gọi lại cho sự kiện của thành phần con. Trong Blazor, để thể hiện một sự kiện=> sử dụng EventCallback
        [Inject] InterFace x { get; set; }

        public void LoadData(SinhVien a)
        {
            EditModel.id = a.SinhVienID;
            EditModel.ten = a.Ten;
            EditModel.gioitinh = a.GioiTinh;
            EditModel.tuoi = a.Tuoi;
            EditModel.diemtoan = a.DiemToan;
            EditModel.diemvan = a.DiemVan;
            EditModel.diemanh = a.DiemAnh;
            EditModel.diemtb = a.DiemTB;
            EditModel.hocluc = a.HocLuc;
            StateHasChanged();
        }
        async Task UpdateSv()
        {
            SinhVien a = new SinhVien();
            a.SinhVienID = EditModel.id;
            a.Ten = EditModel.ten;
            a.GioiTinh = EditModel.gioitinh;
            a.Tuoi = EditModel.tuoi;
            a.DiemToan = EditModel.diemtoan;
            a.DiemVan = EditModel.diemvan;
            a.DiemAnh = EditModel.diemanh;
            a.DiemTB = x.TinhDTB(a);
            a.HocLuc = x.XepLoaiHocLuc(a);
            //Thực hiện update sinh viên
            ThayDoi.InvokeAsync(a);//Mục đích để khi ấn nút submit ở "component" nó sẽ thông báo rằng có thay đổi để update lại sv
        }
    }
}
