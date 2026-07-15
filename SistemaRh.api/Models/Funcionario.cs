using System.ComponentModel.DataAnnotations.Schema; // nescessario adicionar essa linha para
                                                    // tratar erro na criação do banco de dados
namespace SistemaRh.api.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public DateTime DataAdmissao { get; set; }

        [Column (TypeName = "decimal(18,2)")] // <= delimitando o tamanho do valor para o banco
                                            // e avisando sobre os centavos
        public decimal Salario { get; set; }
        public bool Ativo { get; set; }
    }
    
}
