using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Domain.Models
{
    public class Residencia : Entity
    {
        public string Nome { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
