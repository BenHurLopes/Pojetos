using NHibernate.Validator.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estabelecimento.Models
{
    public class Pessoa
    {
        public virtual int Id { get; set; }
        [NotNullNotEmpty]
        public virtual string Nome { get; set; }
        [NotNullNotEmpty]
        public virtual DateTime DataNascimento { get; set; }

    }
}