using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} catacteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [MaxLength(150, ErrorMessage = "Maximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }

        #region IEntity
        
        [ScaffoldColumn(false)] //Data não será exibida
        public DateTime DateCreated { get; set; }

        [ScaffoldColumn(false)] //Data não será exibida
        public DateTime DateUpdated { get; set; }

        public bool Active { get; set; }

        #endregion
    }
}