using NHibernate;
using NHibernate.Cfg.Loquacious;
using NHibernate.Linq;
using ISession = NHibernate.ISession;


namespace Blazor_QLSV04
{
    public class SinhVienServices : InterFace
    {
        public void AddSinhVien(SinhVien a)
        {
            using (ISession session = NHibernate.OpenSession())
            {
                try
                {
                    a.SinhVienID = Guid.NewGuid().ToString();
                    session.SaveOrUpdate(a);
                }

                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public string XepLoaiHocLuc(SinhVien sv) // hàm xếp loại học lực
        {
            string HocLuc;
            if (sv.DiemTB >= 8)
            {
                HocLuc = "Giỏi";
            }
            else if (sv.DiemTB >= 6.5)
            {
                HocLuc = "Khá";
            }
            else if (sv.DiemTB >= 5)
            {
                HocLuc = "Trung Bình";
            }
            else
            {
                HocLuc = "Yếu";
            }
            return HocLuc;
        }
        public float TinhDTB(SinhVien sv) // hàm tính điểm trung bình 
        {
            float DiemTB = (sv.DiemToan + sv.DiemVan + sv.DiemAnh) / 3;
            DiemTB = (float)Math.Round(DiemTB, 2); // làm tròn số thập phân 2 chữ số sau giấu phẩy 
            return DiemTB;
        }
        public async Task<List<SinhVien>> GetAllSinhVien()
        {
            try
            {
                List<SinhVien> sv;
                using (ISession session = NHibernate.OpenSession())
                {
                    sv = session.Query<SinhVien>().ToList();
                }
                return sv;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task<bool> XoaSinhVien(SinhVien sv)
        {
            bool result = false;
            using (var session = NHibernate.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        await session.DeleteAsync(sv);
                        await transaction.CommitAsync();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
            return result;
        }
        public async Task<SinhVien> GetSinhVienByID(string id)
        {
            SinhVien sv;
            using (var session = NHibernate.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        sv = session.Get<SinhVien>(id);
                        return sv;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
        }
        public async Task<bool> AddOrUpdate(SinhVien sv)
        {
            bool result = false;
            using (var session = NHibernate.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var Check = session.Get<SinhVien>(sv.SinhVienID);
                
                    try
                    {
                        if (Check == null)
                        {
                            sv.SinhVienID = Guid.NewGuid().ToString();
                            await session.SaveAsync(sv);
                        }
                        else
                        {
                           await session.UpdateAsync(sv);
                        }
                        await transaction.CommitAsync();
                        result = true;
                    }

                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
            return result;

        }
        public async Task<List<SinhVien>> SearchSVByName(string name)
        {

            using (var session = NHibernate.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        List<SinhVien> sv;
                        sv = session.Query<SinhVien>().Where(c => c.Ten.Like('%' + name + '%')).ToList();
                        //await transaction.CommitAsync();
                        return sv;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
                }
            }
        }
        public int GetTotalStudentByAcademicAbility(string academicAbility)
        {
            using (var session = NHibernate.OpenSession())
            {
                try
                {
                    int total = session.Query<SinhVien>().Where(c => c.HocLuc == academicAbility).Count();
                    return total;
                }catch(Exception ex)
                {
                    throw ex;
                }

            }
        }

    }
}
    
