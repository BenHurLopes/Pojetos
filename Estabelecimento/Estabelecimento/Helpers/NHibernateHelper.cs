using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace Estabelecimento.Helpers
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(@"Data Source=BEN-HUR;Initial Catalog=EstabelecimentoDB;User Id=sa;Password=ragnarok;Integrated Security=True")
                              .ShowSql()
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                        .SetOutputFile(@"D:\Git\Pojetos\Estabelecimento\Estabelecimento\Script.sql")
                                          .Create(false, false))
                    .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}