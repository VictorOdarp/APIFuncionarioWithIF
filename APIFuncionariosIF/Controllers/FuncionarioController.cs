using APIFuncionariosIF.Interface;
using APIFuncionariosIF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFuncionariosIF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;

        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionario()
        {
            var list = await _funcionarioInterface.GetFuncionario();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            var funcionario = await _funcionarioInterface.GetFuncionarioById(id);
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel newFuncionario)
        {
            var funcionario = await _funcionarioInterface.CreateFuncionario(newFuncionario);
            return Ok(funcionario);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel upFuncionario)
        {
            var editFuncionario = await _funcionarioInterface.UpdateFuncionario(upFuncionario);
            return Ok(editFuncionario);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            var delFuncionario = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(delFuncionario);
        }

        [HttpPut("InativaFuncionario")]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            var funcionario = await _funcionarioInterface.InativaFuncionario(id);
            return Ok(funcionario);
        }

     }
}
