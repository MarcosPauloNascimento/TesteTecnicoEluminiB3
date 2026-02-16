using System.Collections.Generic;
using System.Web.Http;
using TesteTecnicoEluminiB3.Application.DTOs;
using TesteTecnicoEluminiB3.Application.Interfaces;

namespace TesteTecnicoEluminiB3.Services.Api.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ICalculoInvestimentoService _calculoInvestimentoService;

        public ValuesController(ICalculoInvestimentoService calculoInvestimentoService)
        {
            _calculoInvestimentoService = calculoInvestimentoService;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public IHttpActionResult Post([FromBody] CalcularInvestimetoDTO request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = _calculoInvestimentoService.ObterCalculoInvestimento(request);

            return Ok(resultado);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
