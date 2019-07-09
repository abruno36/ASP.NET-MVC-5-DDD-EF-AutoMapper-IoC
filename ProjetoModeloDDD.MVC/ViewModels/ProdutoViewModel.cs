using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo Nome do Produto obrigatório")]
        [MaxLength(250, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0}de 2 catacteres")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal),"0","9999999999999")]
        [Required(ErrorMessage = "Campo Valor do Produto obrigatório")]
        public decimal Valor { get; set; }

        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }

        #region IEntity

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public bool Active { get; set; }

        #endregion

    }
}