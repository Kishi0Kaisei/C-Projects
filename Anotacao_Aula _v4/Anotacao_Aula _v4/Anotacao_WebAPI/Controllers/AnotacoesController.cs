using Microsoft.AspNetCore.Mvc;
using Compromissos_Models2Api;
using CompromissoServices;

namespace Anotacao_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnotacoesController : ControllerBase
    {
        /// <summary>
        /// devolve a lista de anotações
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<AnotacaoRegistoResponse>), StatusCodes.Status200OK)]
        //status code 200 é OK
        public IActionResult Index()
        {
            AnotacaoServices _servicos = new AnotacaoServices();
            _servicos.Anotacoes.ImportarDados();
            return new ObjectResult(_servicos.Anotacoes.GetCompromissoListResponse()); 
        }

        //Acrescentar para CRUD:
        /// <summary>
        /// obter anotação por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] //fornecer id, colocar minusculas
        [Produces("application/json")] //este endpoint produz um objeto json
        [ProducesResponseType(typeof(AnotacaoRegistoResponse), StatusCodes.Status200OK)]
        public IActionResult GetId(int id)
        {
            AnotacaoServices _servicos = new AnotacaoServices();
            _servicos.Anotacoes.ImportarDados();
            AnotacaoRegistoResponse? anotRegistoResponse = _servicos.Anotacoes.ObterCompromissoResponse(id); 
            if (anotRegistoResponse != null)
            {
                return new ObjectResult(anotRegistoResponse);
            }
            return new NotFoundResult();
        }
        //Acrescentar:
        /// <summary>
        /// inserir anotação
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] AnotacaoRegistoRequest value)
        {
            AnotacaoServices _servicos = new AnotacaoServices();
            _servicos.Anotacoes.ImportarDados();
            if (_servicos.Anotacoes.AdicionarAnotacaoRequest(value)) 
            {
                _servicos.Anotacoes.ExportarDados();
                return new OkResult();
            }
            return new BadRequestResult(); 
        }
        //Acrescentar:
        /// <summary>
        /// modificar anotação
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut("{id}")] //fornecer o id o queremos alterar, e damos o valor que queremos alterar
        public IActionResult Put(int id, [FromBody] AnotacaoRegistoRequest value) 
        {
            AnotacaoServices _servicos = new AnotacaoServices();
            _servicos.Anotacoes.ImportarDados();
            if (_servicos.Anotacoes.ModificarCompromissoRequest(id, value)) 
            {
                _servicos.Anotacoes.ExportarDados();
                return new OkResult();
            }
            return new BadRequestResult(); 
        }
        //Acrescentar:
        /// <summary>
        /// apagar anotação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AnotacaoServices _servicos = new AnotacaoServices();
            _servicos.Anotacoes.ImportarDados();
            if (_servicos.Anotacoes.ApagarCompromisso(id)) 
            {
                _servicos.Anotacoes.ExportarDados();
                return new OkResult();
            }
            return new BadRequestResult();
        }
    }
}