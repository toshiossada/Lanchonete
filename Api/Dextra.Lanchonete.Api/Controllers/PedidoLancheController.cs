using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using Dextra.Lanchonete.Api.Models;
using Dextra.Lanchonete.Api.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace Dextra.Lanchonete.Api.Controllers {
    [EnableCors("CorsPolicy")]
    [Route ("api/v1/[Controller]")]
    public class PedidoLancheController : Controller {
        private readonly IPedidoLancheBll _pedidoLancheBll;
        public PedidoLancheController (IPedidoLancheBll pedidoLancheBll) {
            _pedidoLancheBll = pedidoLancheBll;
        }

        
        [HttpGet]
        public IEnumerable<PedidoLanche> GetAll()
        {
            var result = _pedidoLancheBll.GetAll();
            return result;
        }
        [HttpGet("{id}", Name="GetPedidoLanche")]
        public IActionResult GetById(int id)
        {
            var retorno = _pedidoLancheBll.Find(id);

            if (retorno == null)
                return NotFound();

            return new ObjectResult(retorno);
        }

        [HttpPost]
        public IActionResult Create([FromBody]PedidoLanche pedidoLanche)
        {
            if(pedidoLanche == null) return BadRequest();
            pedidoLanche.ValorFinal = _pedidoLancheBll.CalcularPrecoLanche(pedidoLanche);


            _pedidoLancheBll.Add(pedidoLanche);
            
            return CreatedAtRoute("GetPedidoLanche", new { id = pedidoLanche.Id}, pedidoLanche);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PedidoLanche pedidoLanche){
            if(pedidoLanche == null || pedidoLanche.Id != id) return BadRequest();

            var _pedidoLanche = _pedidoLancheBll.Find(id);
            if(_pedidoLanche == null) return NotFound();

            _pedidoLanche.IdLanche = pedidoLanche.IdLanche;
            _pedidoLanche.IngredientesAdicionais = pedidoLanche.IngredientesAdicionais;
            _pedidoLanche.ValorFinal = pedidoLanche.ValorFinal;

            _pedidoLancheBll.Update(_pedidoLanche);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var _pedidoLanche = _pedidoLancheBll.Find(id);
            if(_pedidoLanche == null) return NotFound(); 

            _pedidoLancheBll.Remove(id);
            return new NoContentResult();
        }
    }
}