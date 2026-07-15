using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaRh.api.Data;
using SistemaRh.api.Models;

namespace SistemaRh.api.Controllers
{
    //Etiqueta que avisa ao .NET que esta classe não é comum e server
    //para responder requisição de API
    [ApiController]

    // Define endereço para acessar este controlador na internet
    [Route ("api/[controller]")]

    public class FuncionarioController : ControllerBase
    {
        //variavel criada para guardar a conexão com o banco de dados
        private readonly AppDbContext _context;

        // Construtor criado para receber o AppDbContexte que foi configurado no Program.cs
        // a tal da "Injeção de Dependência
        public FuncionarioController (AppDbContext context)
        {
            _context = context;
        }
        // Endpoint responde a requisições do tipo POST em api/funcionario
        [HttpPost]
        public async Task<ActionResult <Funcionario>> Cadastrar([FromBody] Funcionario novofuncionario)
        {
            // Adiciona o funcionario a tabela da memória do Entity Frameword
            _context.Funcionario.Add(novofuncionario);

            //Manda o entity gerar o INSERT e salvar no banco sql
            await _context.SaveChangesAsync();

            // devolde o status 200 junto com os dados do funcionário recém criado com o ID preenchido
            return Ok(novofuncionario);
        }

    }
}
