using System.ComponentModel.DataAnnotations;

namespace Blazor_QLSV04.Data

{
    public class SinhVien_ViewModel
    {
        public string id;


        [Display(Name = "Tên sinh viên")]
        public string ten { get; set; }

        [Display(Name = "Giới tính")]
        public string gioitinh { get; set; }

        [Display(Name = "Tuổi")]
        public int tuoi { get; set; }
        [Display(Name = "Điểm toán")]
        public float diemtoan { get; set; }
        [Display(Name = "Điểm văn")]
        public float diemvan { get; set; }
        [Display(Name = "Điểm Anh")]
        public float diemanh { get; set; }

        [Display(Name = "Điểm trung bình")]
        public float diemtb { get; set; }

        [Display(Name = "Học lực")]
        public string hocluc { get; set; }
    }
}
