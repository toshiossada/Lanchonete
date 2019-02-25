using System;
using System.Collections.Generic;
using System.Linq;
using Dextra.Lanchonete.Api.Models;
using Dextra.Lanchonete.Api.Repository;

namespace Dextra.Lanchonete.Api.Business {
    public class PedidoLancheBll : IPedidoLancheBll {
        private readonly IPedidoLancheRepository _pedidoLancheRepository;
        private readonly ILancheBll _lancheBll;
        private readonly IIngredienteBll _ingredienteBll;
        public PedidoLancheBll (IPedidoLancheRepository pedidoLancheRepository, ILancheBll lancheBll, IIngredienteBll ingredienteBll) {
            _pedidoLancheRepository = pedidoLancheRepository;
            _lancheBll = lancheBll;
            _ingredienteBll = ingredienteBll;
        }

        public void Add (PedidoLanche pedidoLanche) {
            foreach (var item in pedidoLanche.IngredientesAdicionais) {
                item.Ingrediente = null;
            }
            //pedidoLanche.IngredientesAdicionais = null;
            pedidoLanche.Lanche = null;

            _pedidoLancheRepository.Add (pedidoLanche);
        }

        public PedidoLanche Find (int id) {
            return _pedidoLancheRepository.Find (id);
        }

        public IEnumerable<PedidoLanche> GetAll () {
            return _pedidoLancheRepository.GetAll ();
        }

        public void Remove (int id) {
            _pedidoLancheRepository.Remove (id);
        }

        public void Update (PedidoLanche pedidoLanche) {
            _pedidoLancheRepository.Update (pedidoLanche);
        }

        public double CalcularPrecoLanche (PedidoLanche pedidoLanche) {
            double valorFinal = 0;
            var lanche = _lancheBll.Find (pedidoLanche.Lanche.Id);
            foreach (var item in lanche.LancheIngredientes) {
                valorFinal += item.Ingrediente.Valor;
            }

            foreach (var item in pedidoLanche.IngredientesAdicionais) {
                valorFinal += item.Ingrediente.Valor * item.Quantidade;
            }

            //Aplica Promoção Light caso satisfaça as regras da promoção
            if (PromocaoLight (lanche.LancheIngredientes, pedidoLanche.IngredientesAdicionais)) {
                valorFinal = valorFinal - (valorFinal * 0.1);
            }

            //A cada 3 Hambúrgueres de carne o cliente não paga um
            valorFinal -= PromocaoCarne (lanche.LancheIngredientes, pedidoLanche.IngredientesAdicionais);
            //A cada 3 Queijos o cliente não paga um
            valorFinal -= PromocaoQueijo (lanche.LancheIngredientes, pedidoLanche.IngredientesAdicionais);

            return valorFinal;
        }

        // Promoção Light:	Se o lanche tem alface e não tem bacon, ganha 10% de desconto.

        private bool PromocaoLight (ICollection<LancheIngrediente> lancheIngredientes, ICollection<IngredienteAdicional> ingredientesAdicionais) {
            var descBacon = "Bacon";
            var descAlface = "Alface";

            var hasBacon = ingredientesAdicionais.Any (r => r.Ingrediente.Descricao == descBacon) || lancheIngredientes.Any (r => r.Ingrediente.Descricao == descBacon);
            var hasAlface = ingredientesAdicionais.Any (r => r.Ingrediente.Descricao == descAlface) || lancheIngredientes.Any (r => r.Ingrediente.Descricao == descAlface);

            return !hasBacon && hasAlface;
        }

        //A cada 3 porções de carne o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante.
        private double PromocaoCarne (ICollection<LancheIngrediente> lancheIngredientes, ICollection<IngredienteAdicional> ingredientesAdicionais) {
            var descCarne = "Hambúrguer de carne";
            var carne = _ingredienteBll.FindByDescription (descCarne);

            var qtdCarne = ingredientesAdicionais.Where(r => r.Ingrediente.Id == carne.Id).Sum(r => r.Quantidade) + lancheIngredientes.Count (r => r.Ingrediente.Id == carne.Id);
            var desconto = carne.Valor * Math.Round (qtdCarne / 3.0);

            return desconto;
        }

        //A cada 3 porções de queijo o cliente só paga 2. Se o lanche tiver 6 porções, ocliente pagará 4. Assim por diante...
        private double PromocaoQueijo (ICollection<LancheIngrediente> lancheIngredientes, ICollection<IngredienteAdicional> ingredientesAdicionais) {
            var descQueijo = "Queijo";
            var queijo = _ingredienteBll.FindByDescription (descQueijo);

            var qtdQueijo = ingredientesAdicionais.Where (r => r.Ingrediente.Id == queijo.Id).Sum(r => r.Quantidade)  + lancheIngredientes.Count (r => r.Ingrediente.Id == queijo.Id);
            var desconto = queijo.Valor * Math.Round (qtdQueijo / 3.0);

            return desconto;
        }
    }
}