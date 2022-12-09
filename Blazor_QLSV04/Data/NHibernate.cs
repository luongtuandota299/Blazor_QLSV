
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using ISession = NHibernate.ISession;
    
namespace Blazor_QLSV04
{
    public static class NHibernate
    {
        public static ISessionFactory _sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory == null ? _sessionFactory = OpenConect() : _sessionFactory; }
        }

        public static ISessionFactory OpenConect()
        {
            string connectionString = @"Data Source=LOTUS-PC\TUAN;Initial Catalog=QLSV_01;Integrated Security=True";

            var sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.
                ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SinhVien>()).
                ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory;
        }
        public static ISession OpenSession()
        {
            try
            {
                return SessionFactory.OpenSession();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
