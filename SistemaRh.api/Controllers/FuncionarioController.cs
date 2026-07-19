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
        // Endpoint responde a requisições do tipo POST na url da api/funcionario
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

        // Método de requisoções do tipo leitura
        [HttpGet]
        public async Task <ActionResult<IEnumerable<Funcionario>>> ListarTodos()
        {
            // O EF core vai no banco e trás tudo para uma lista em memória
            var listaFuncionario = await _context.Funcionario.ToListAsync();

            // retona o status (ok) com a lista de funcionários no corpo da resposta
            return Ok(listaFuncionario);
        }

        //Informa que este método atende requisiçõe PUT e exige o número do ID na url da api
        [HttpPut("{id}")]
        public async Task<ActionResult<Funcionario>> Atualizar(int id, [FromBody] Funcionario dadosAtualizados)
        {
            // Verifica se o ID do funcionário requisitado existe no banco
            var funcionarioNoBanco = await _context.Funcionario.FindAsync(id);

            // Se não encontrar o funciónário com a ID solicitada informa a mensagem de erro
            if (funcionarioNoBanco == null)
            {
                return NotFound("Funcionário não encontrado no bando de dados");
            }

            // Atualiza os campos alterados no banco de dados
            funcionarioNoBanco.Nome = dadosAtualizados.Nome;
            funcionarioNoBanco.Cargo = dadosAtualizados.Cargo;
            funcionarioNoBanco.Salario = dadosAtualizados.Salario;
            funcionarioNoBanco.Ativo = dadosAtualizados.Ativo;

            // O EF detecta o que mudou e gera o comando UPDATE no SQL Server
            await _context.SaveChangesAsync();

            // Devolve o status 200 (ok) e mostra o funcionário atualizado
            return Ok(funcionarioNoBanco);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var funcionarioNoBanco = await _context.Funcionario.FindAsync(id);

            if (funcionarioNoBanco == null)
            {
                return NotFound("Funcionário não encntrado no banco para exclusão");
            }

            _context.Funcionario.Remove(funcionarioNoBanco);

            await _context.SaveChangesAsync();

            return Ok("Funcionário excluído do sistema com Sucesso!");
        }
    }
}
