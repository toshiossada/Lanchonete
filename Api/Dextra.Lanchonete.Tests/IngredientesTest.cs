using Dextra.Lanchonete.Api.Business;
using Dextra.Lanchonete.Api.Models;
using Dextra.Lanchonete.Api.Repository;
using Moq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace Dextra.Lanchonete.Tests {
    public class IngredientesTest {
        private readonly Mock<IIngredienteRepository> _ingredienteRepositoryMock = new Mock<IIngredienteRepository>();
        private readonly IIngredienteBll _ingredienteBll;

        public IngredientesTest()
        {
            _ingredienteBll = new IngredienteBll(_ingredienteRepositoryMock.Object);
        }

        [Fact]
        public void TestAdd () {
            var ingrediente = new Ingrediente()
            {
                Descricao = "Teste",
                Valor = 300
            };
            _ingredienteBll.Add(ingrediente);

            _ingredienteRepositoryMock.Verify(x => x.Add(ingrediente), Times.Once());
        }

        [Fact]
        public void TestUpdate()
        {
            var ingrediente = new Ingrediente()
            {
                Id = 1,
                Descricao = "Teste",
                Valor = 300
            };
            _ingredienteBll.Update(ingrediente);

            _ingredienteRepositoryMock.Verify(x => x.Update(ingrediente), Times.Once());
        }

        [Fact]
        public void TestRemove()
        {
            _ingredienteBll.Remove(1);

            _ingredienteRepositoryMock.Verify(x => x.Remove(1), Times.Once());
        }

        [Fact]
        public void TestGetAll()
        {
            var data = new Collection<Ingrediente>
            {
                new Ingrediente{ Id = 1, Descricao = "Teste 1", Valor = 30 },
                new Ingrediente{ Id = 2, Descricao = "Teste 2", Valor = 540 },
                new Ingrediente{ Id = 3, Descricao = "Teste 4", Valor = 71 }
            };
            
            _ingredienteRepositoryMock.Setup(theObject => theObject.GetAll()).Returns(data);
            var ingredientes = _ingredienteBll.GetAll();

            _ingredienteRepositoryMock.Verify(x => x.GetAll(), Times.Once());
            Assert.Equal(3, ingredientes.Count());

        }

        [Fact]
        public void TestFind()
        {
            var data = new Ingrediente { Id = 1, Descricao = "Teste 1", Valor = 30 };

            _ingredienteRepositoryMock.Setup(theObject => theObject.Find(1)).Returns(data);
            var ingrediente = _ingredienteBll.Find(1);

            _ingredienteRepositoryMock.Verify(x => x.Find(1), Times.Once());
            Assert.NotNull(ingrediente);
            Assert.Equal(1, ingrediente.Id);
        }
    }
}