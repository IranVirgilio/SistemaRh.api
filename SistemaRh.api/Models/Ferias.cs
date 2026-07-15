using System.ComponentModel.DataAnnotations;

namespace SistemaRh.api.Models
{  
    
    // lista com as opções de status exatas exigidas pelo pdf para evitar
    // que erros de digitação sejam salvos no banco de dados
    public enum StatusFerias
    {
        Pendente,
        EmAndamento,
        Concluida
    }
    public class Ferias
    {
        [Key] //para o Entity Framework reconhecer a chave primaria
        public int IdFerias { get; set; }
        //Chave estrangeira que liga as férias ao dono dela.
        public int IdFuncionario { get; set; }
        public DateTime InicioFerias { get; set; }
        public DateTime TerminoFerias { get; set; }
        public StatusFerias Status { get; set; }
    }
}
