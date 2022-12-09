namespace Blazor_QLSV04.Data
{
    public class SinhVienEditModel
    {
        public virtual string id { get; set; }

        public virtual string ten { get; set; }

        public virtual string gioitinh { get; set; }

        public virtual int tuoi { get; set; }
        public virtual float diemtoan { get; set; }
        public virtual float diemvan { get; set; }
        public virtual float diemanh { get; set; }

        public virtual float diemtb { get; set; }
        public virtual string hocluc { get; set; }
    }
}
