using Microsoft.AspNetCore.Mvc;
using Anotacao_Services2Apipg;
using Compromissos_Models2Api;

namespace Anotacao_WebAPI.Controllers
{/// <summary>
/// Lista de Anotacoes
/// </summary>
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
            
            return new ObjectResult(_servicos.Anotacao.GetCompromissoListResponse());
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
            
            AnotacaoRegistoResponse? anotRegistoResponse = _servicos.Anotacao.ObterCompromissoResponse(id);
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
            
            if (_servicos.Anotacao.AdicionarAnotacaoRequest(value))
            {
                
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
            if (_servicos.Anotacao.ModificarCompromissoRequest(id, value))
            {

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
        /// 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            AnotacaoServices _servicos = new AnotacaoServices();
         
            if (_servicos.Anotacao.ApagarCompromisso(id))
            {
                
                return new OkResult();
            }
            return new BadRequestResult();
        }
    }
}