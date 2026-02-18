using Swashbuckle.Swagger.Annotations;
using System.Web.Http;
using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Application.Interfaces;

namespace TesteTecnicoEluminiB3.Services.Api.Controllers
{

    /// <summary>
    /// Controla operações de clientes.
    /// </summary>
    [RoutePrefix("api/calculadora-investimento")]
    public class CalculadoraInvestimentoController : ApiController
    {
        private readonly ICalculoRendimentoService _calculoInvestimentoService;

        public CalculadoraInvestimentoController(ICalculoRendimentoService calculoInvestimentoService)
        {
            _calculoInvestimentoService = calculoInvestimentoService;
        }


        [HttpPost, Route("cdb")]
        [AllowAnonymous]
        [SwaggerResponse(200, "Sucesso", typeof(ResultadoCalculoDto))]
        [SwaggerResponse(404, "Erro")]
        public IHttpActionResult CalcularRendimento([FromBody] CalcularInvestimetoDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = _calculoInvestimentoService.ObterCalculoInvestimento(request);

            return Ok(resultado);
        }
    }
}
