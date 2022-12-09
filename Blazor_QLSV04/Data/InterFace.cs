namespace Blazor_QLSV04
{
    public interface InterFace
    {
        public void AddSinhVien(SinhVien a);
        public string XepLoaiHocLuc(SinhVien sv);
        public float TinhDTB(SinhVien sv);
        public Task<List<SinhVien>> GetAllSinhVien();
        public Task<bool> XoaSinhVien(SinhVien sv);
        public Task<SinhVien> GetSinhVienByID(string id);
        public Task<bool> AddOrUpdate(SinhVien sv);
        public Task<List<SinhVien>> SearchSVByName(string name);
        public int GetTotalStudentByAcademicAbility(string academicAbility);


    }
}
