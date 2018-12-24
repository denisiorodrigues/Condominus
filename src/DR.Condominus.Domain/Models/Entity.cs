using System;
using System.Collections.Generic;

namespace DR.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
            ValidationResult = new Dictionary<string, string>();
        }

        public Guid Id { get; set; }

        public IDictionary<string, string> ValidationResult { get; set; }

        public void AdicionarErroValidacao(string erro, string mensagem)
        {
            ValidationResult.Add(erro, mensagem);
        }

        public abstract bool EhValido();
    }
}
