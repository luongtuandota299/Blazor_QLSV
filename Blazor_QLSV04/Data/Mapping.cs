using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blazor_QLSV04
{
    internal class Mapping : ClassMap<SinhVien>
    {
        public Mapping()
        {
            LazyLoad();
            Id(x => x.SinhVienID).GeneratedBy.Assigned().Column("SinhVienID");
            Map(x => x.Ten).Column("Ten");
            Map(x => x.GioiTinh).Column("GioiTinh");
            Map(x => x.Tuoi).Column("Tuoi");
            Map(x => x.DiemAnh).Column("DiemAnh");
            Map(x => x.DiemToan).Column("DiemToan");
            Map(x => x.DiemVan).Column("DiemVan");
            Map(x => x.DiemTB).Column("DiemTB");
            Map(x => x.HocLuc).Column("HocLuc");
            Table("sinhViens");
        }

    }
}
