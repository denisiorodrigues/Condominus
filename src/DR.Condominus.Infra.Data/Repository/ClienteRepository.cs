using DR.Domain.Interfaces;
using DR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Condominus.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Ativo);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override Cliente ObterPorId(Guid id)
        {
            return Db.Clientes.AsNoTracking().Include("Enderecos").FirstOrDefault(c => c.Id == id) ;
        }

        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.DefinirComoExcluido();

            base.Atualizar(cliente);
        }
    }
}
