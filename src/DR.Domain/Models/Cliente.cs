using System;
using System.Collections.Generic;

namespace DR.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public byte Imagem { get; set; }
        public bool Residente { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }

        public void DefinirComoExcluido()
        {
            Ativo = false;
            Excluido = true;
        }

        public void DefinirComoAtivo()
        {
            Ativo = true;
            Excluido = false;
        }

        public override bool EhValido()
        {
            if (String.IsNullOrWhiteSpace(this.Nome))
                AdicionarErroValidacao("Nome", "O nome não pode estar vazio");

            if (String.IsNullOrWhiteSpace(this.Email))
                AdicionarErroValidacao("Nome", "O email não pode estar vazio");

            return ValidationResult.Count == 0;
        }
    }
}
