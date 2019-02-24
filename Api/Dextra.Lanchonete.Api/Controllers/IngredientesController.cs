using System;
using System.Collections.Generic;
using Dextra.Lanchonete.Api.Business;
using Dextra.Lanchonete.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dextra.Lanchonete.Api.Controllers {
    [Route ("api/v1/[Controller]")]
    public class IngredientesController : Controller {
        private readonly IIngredienteBll _ingredienteBll;
        public IngredientesController (IIngredienteBll ingredienteBll) {
            _ingredienteBll = ingredienteBll;
        }

        [HttpGet]
        public IEnumerable<Ingrediente> GetAll () {
            var result = _ingredienteBll.GetAll ();
            return result;
        }

        [HttpGet ("{id}", Name = "GetIngrediente")]
        public IActionResult GetById (int id) {
            var retorno = _ingredienteBll.Find (id);

            if (retorno == null)
                return NotFound ();

            return new ObjectResult (retorno);
        }

        [HttpPost]
        public IActionResult Create ([FromBody] Ingrediente ingrediente) {
            if (ingrediente == null) return BadRequest ();
            _ingredienteBll.Add (ingrediente);

            return CreatedAtRoute ("GetIngrediente", new { id = ingrediente.Id }, ingrediente);
        }

        [HttpPut ("{id}")]
        public IActionResult Update (int id, [FromBody] Ingrediente ingrediente) {
            if (ingrediente == null || ingrediente.Id != id) return BadRequest ();

            var _ingrediente = _ingredienteBll.Find (id);
            if (_ingrediente == null) return NotFound ();

            _ingrediente.Descricao = ingrediente.Descricao;
            _ingrediente.Valor = ingrediente.Valor;

            _ingredienteBll.Update (_ingrediente);

            return new NoContentResult ();
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete (int id) {
            var _ingrediente = _ingredienteBll.Find (id);
            if (_ingrediente == null) return NotFound ();

            _ingredienteBll.Remove (id);
            return new NoContentResult ();
        }
    }
}