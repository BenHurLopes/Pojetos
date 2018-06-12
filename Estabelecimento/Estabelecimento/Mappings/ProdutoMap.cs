using Estabelecimento.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estabelecimento.Mappings
{
    class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.Codigo).Column("CODIGO").Not.Nullable(); ;
            Map(x => x.Nome).Column("NOME").Not.Nullable(); ;
            Map(x => x.PrecoUnitario).Column("PRECOUNITARIO").Not.Nullable(); ;
            Table("PRODUTO");
        }
    }
}