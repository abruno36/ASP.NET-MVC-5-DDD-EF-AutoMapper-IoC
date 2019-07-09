
using System;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        //Relacionamento com a entidade Cliente
        public int ClienteId{ get; set; }

        public virtual Cliente Cliente{ get; set; }

        #region IEntity

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool Active { get; set; }

        #endregion
    }
}
