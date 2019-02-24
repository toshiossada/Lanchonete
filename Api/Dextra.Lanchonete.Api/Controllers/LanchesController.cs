using System;
using System.Collections.Generic;
using Dextra.Lanchonete.Api.Business;
using Dextra.Lanchonete.Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace Dextra.Lanchonete.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    public class LanchesController : Controller
    {
        private readonly ILancheBll _lancheBll;
        public LanchesController(ILancheBll lancheBll)
        {
            _lancheBll = lancheBll;
        }
        
        [HttpGet]
        public IEnumerable<Lanche> GetAll()
        {
            var result = _lancheBll.GetAll();
            return result;
        }
        [HttpGet("{id}", Name="GetLanche")]
        public IActionResult GetById(int id)
        {
            var retorno = _lancheBll.Find(id);

            if (retorno == null)
                return NotFound();

            return new ObjectResult(retorno);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Lanche lanche)
        {
            if(lanche == null) return BadRequest();
            _lancheBll.Add(lanche);
            
            return CreatedAtRoute("GetLanche", new { id = lanche.Id}, lanche);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Lanche lanche){
            if(lanche == null || lanche.Id != id) return BadRequest();

            var _lanche = _lancheBll.Find(id);
            if(_lanche == null) return NotFound();

            _lanche.Descricao = lanche.Descricao;
            _lanche.LancheIngredientes = lanche.LancheIngredientes;

            _lancheBll.Update(_lanche);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var _lanche = _lancheBll.Find(id);
            if(_lanche == null) return NotFound(); 

            _lancheBll.Remove(id);
            return new NoContentResult();
        }
    }
}