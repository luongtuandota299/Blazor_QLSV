using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace Blazor_QLSV04
{
    public class SinhVien
    {

        public virtual string SinhVienID { get; set; }
        public virtual string Ten { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual int Tuoi { get; set; }
        public virtual float DiemToan { get; set; }
        public virtual float DiemAnh { get; set; }
        public virtual float DiemVan { get; set; }
        public virtual float DiemTB { get; set; }
        public virtual string HocLuc { get; set; }
    }

}
