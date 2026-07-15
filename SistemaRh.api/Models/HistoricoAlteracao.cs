using System.ComponentModel.DataAnnotations;
namespace SistemaRh.api.Models
{
    public class HistoricoAlteracao
    {
        [Key]
        //para o Entity Framework reconhecer a chave primaria
        public int IdHistorico { get; set; }

        //chave estrangeira para identificar a qual funcionario o historico pertence
        public int IdFuncionario { get; set; }

        //foi utilizado o private set para objetos que não devem ser alterados por nada
        //além do banco de dados 
        public DateTime Alteracao { get; private set; }
        public string CampoAlterado { get; private set; }
        public string ValorAntigo { get; private set; }
        public string ValorNovo { get; private set; }
    }
}
