using System;
using System.ComponentModel.DataAnnotations;

namespace AFJ.Empregos.Application.ViewModels
{
    public class PlanoTelefoniaVOViewModel
    {
        #region Plano

        [ScaffoldColumn(false)]
        public int PlanoId { get; set; }

        [Required(ErrorMessage = "* Preencha o campo 'Tipo Plano'")]
        public int? IdTipoPlano { get; set; }

        [Required(ErrorMessage = "* Preencha o campo 'Operadora'")]
        public int? IdOperadora { get; set; }

        [Display(Name = "Qtd em Minutos:")]
        [Required(ErrorMessage = "* Preencha o campo 'Minutos'")]
        public string Minutos { get; set; }

        [Display(Name = "Valor da Franquia:")]
        public decimal? Valor { get; set; }

        [Display(Name = "Descrição da Franquia:")]
        [Required(ErrorMessage = "* Preencha o campo 'Franquia'")]
        public string Franquia { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }

        [Display(Name = "Status Plano:")]
        public bool? Status { get; set; }

        #endregion

        #region TipoPlano

        [Display(Name = "Descrição do Tipo de Plano:")]
        public string DescricaoTipoPlano { get; set; }

        #endregion

        #region Operadora

        [Display(Name = "Nome Operadora:")]
        public string NomeOperadora { get; set; }

        #endregion

        #region DDD

        [Display(Name = "Id DDD:")]
        public int? IdDDD { get; set; }

        [Display(Name = "Cód. DDD:")]
        public string CodDDD { get; set; }

        [Display(Name = "UF:")]
        public string UF { get; set; }

        [Display(Name = "Cidade:")]
        public string CidadePrincipal { get; set; }

        #endregion

        public string Mensagem { get; set; }
    }
}
