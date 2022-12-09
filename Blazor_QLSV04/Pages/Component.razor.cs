using Microsoft.AspNetCore.Components;
using Blazor_QLSV04.Data;
using NHibernate.Hql.Ast;

namespace Blazor_QLSV04.Pages
{
    public partial class Component:ComponentBase
    {
        [Inject] InterFace SinhVienService { get; set; }
        List<SinhVien_ViewModel> abc { get; set; } 
        List<SinhVien> sinhViens { get; set; }
        NhapSinhVien nhapSinhVien = new NhapSinhVien();
        EditSV editsv = new EditSV();
        bool visible = false;
        public class TasksearchSV
        {
          public  string Ten { get; set; }
        }
        TasksearchSV tasksearchSV = new TasksearchSV();

        public List<SinhVien_ViewModel> ChangeTo_ListModel(List<SinhVien> sv)
        {
            List<SinhVien_ViewModel> svmodels = new List<SinhVien_ViewModel>();

            sv.ForEach(v =>
            {
                SinhVien_ViewModel svmodel = new SinhVien_ViewModel();
                svmodel.id = v.SinhVienID;
                svmodel.ten = v.Ten;
                svmodel.tuoi = v.Tuoi;
                svmodel.gioitinh = v.GioiTinh;
                svmodel.diemtoan = v.DiemToan;
                svmodel.diemanh = v.DiemAnh;
                svmodel.diemvan = v.DiemVan;
                svmodel.diemtb = v.DiemTB;
                svmodel.hocluc = v.HocLuc;
                svmodels.Add(svmodel);
            });
                return svmodels;
                 
        }
        public async Task GetSinhVienToModel()//thang nay chay sau
        {
            abc.Clear();
            sinhViens = await SinhVienService.GetAllSinhVien();
            abc = ChangeTo_ListModel(sinhViens);
            StateHasChanged();
        }
        protected override async Task OnInitializedAsync()//thang nay chay truoc
        {
            abc = new();
            sinhViens = new();
            await GetSinhVienToModel();
        }
        async Task Delete(SinhVien_ViewModel a)
        {
            SinhVien sv = await SinhVienService.GetSinhVienByID(a.id);//Tìm trong data thằng đã chọn từ model
            await SinhVienService.XoaSinhVien(sv);//xóa thằng đó
            await GetSinhVienToModel();//trả lại ra giao diện danh sách mới sau khi xóa
        }
        async Task Save(SinhVien a)
        {
            //await SinhVienService.AddOrUpdate(sv);
            SinhVienService.AddOrUpdate(a);
            await GetSinhVienToModel();
            visible = false;
        }
        async Task UpdateSinhVien(SinhVien_ViewModel a)
        {
            visible = true;
            SinhVien x = await SinhVienService.GetSinhVienByID(a.id);
            nhapSinhVien.LoadData(x);
        }

        async Task Add()
        {   
            SinhVien sv = new SinhVien();
            sv.SinhVienID = Guid.NewGuid().ToString();
            nhapSinhVien.LoadData(sv);
            visible = true;

        }

        async Task SearchSV()
        {
            var ten = tasksearchSV.Ten;
            sinhViens = await SinhVienService.SearchSVByName(ten);
            abc.Clear();
            abc = ChangeTo_ListModel(sinhViens);
            StateHasChanged();
        }


    }
}
