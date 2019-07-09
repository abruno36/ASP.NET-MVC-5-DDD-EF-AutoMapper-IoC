using System;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public virtual IEnumerable<Produto> Produtos{ get; set; }

        #region IEntity

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool Active { get; set; }

        #endregion

        public bool ClienteEspecial(Cliente cliente)
        {
            return cliente.Active && DateTime.Now.Year - cliente.DateCreated.Year >= 5;
        }

    }
}
