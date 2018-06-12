using Estabelecimento.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estabelecimento.Mappings
{
    class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Id(x => x.Id).Column("ID").GeneratedBy.Identity();
            Map(x => x.Nome).Column("NOME").Not.Nullable();
            Map(x => x.DataNascimento).Column("DATANASCIMENTO").Not.Nullable();
            Table("PESSOA");
        }
    }
}