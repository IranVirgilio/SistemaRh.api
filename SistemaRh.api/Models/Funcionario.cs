using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // nescessario adicionar essa linha para  tratar erro na criação do banco de dados


namespace SistemaRh.api.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é Obrigatório!.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 a 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo é Obrigatório!.")]
        public string Cargo { get; set; } = string.Empty;

        public DateTime DataAdmissao { get; set; }

        [Column (TypeName = "decimal(18,2)")] // <= delimitando o tamanho do valor para o banco e avisando sobre os centavos
        [Range(0.01, 500000.00, ErrorMessage = "Digite um valor de salário válido!.")] // <- Exige que o salário seja maior que zero.
        public decimal Salario { get; set; }

        public bool Ativo { get; set; }
    }
    
}
