using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Dextra.Lanchonete.Api.Business;
using Dextra.Lanchonete.Api.Models;
using Dextra.Lanchonete.Api.Repository;
using Moq;
using Xunit;

namespace Dextra.Lanchonete.Tests
{
    public class PedidoLancheTest
    {
        private readonly Mock<IPedidoLancheRepository> _pedidoLancheRepositoryMock = new Mock<IPedidoLancheRepository>();
        private readonly Mock<ILancheBll> _lancheBllMock = new Mock<ILancheBll>();
        private readonly Mock<IIngredienteBll> _ingredienteBllMock = new Mock<IIngredienteBll>();
        private readonly IPedidoLancheBll _pedidoLancheBll;

        public PedidoLancheTest()
        {
            _pedidoLancheBll = new PedidoLancheBll(_pedidoLancheRepositoryMock.Object, _lancheBllMock.Object, _ingredienteBllMock.Object);
        }


        [Fact]
        public void TestAdd()
        {
            var data = new PedidoLanche()
            {
                IdLanche = 3,
                ValorFinal = 30
            };
            _pedidoLancheBll.Add(data);

            _pedidoLancheRepositoryMock.Verify(x => x.Add(data), Times.Once());
        }

        [Fact]
        public void TestUpdate()
        {
            var setup = new PedidoLanche()
            {
                Id = 1,
                IdLanche = 3,
                ValorFinal = 30
            };
            _pedidoLancheBll.Update(setup);

            _pedidoLancheRepositoryMock.Verify(x => x.Update(setup), Times.Once());
        }

        [Fact]
        public void TestRemove()
        {
            _pedidoLancheBll.Remove(1);

            _pedidoLancheRepositoryMock.Verify(x => x.Remove(1), Times.Once());
        }

        [Fact]
        public void TestGetAll()
        {
            var data = new Collection<PedidoLanche>
            {
                new PedidoLanche{ Id = 1, IdLanche = 1, ValorFinal = 30 },
                new PedidoLanche{ Id = 2, IdLanche = 2, ValorFinal = 50 },
                new PedidoLanche{ Id = 3, IdLanche = 3, ValorFinal = 25 },
            };

            _pedidoLancheRepositoryMock.Setup(theObject => theObject.GetAll()).Returns(data);
            var ingredientes = _pedidoLancheBll.GetAll();

            _pedidoLancheRepositoryMock.Verify(x => x.GetAll(), Times.Once());
            Assert.Equal(3, ingredientes.Count());

        }

        [Fact]
        public void TestFind()
        {
            var data = new PedidoLanche { Id = 1, IdLanche = 1, ValorFinal = 30 };

            _pedidoLancheRepositoryMock.Setup(theObject => theObject.Find(1)).Returns(data);
            var ingrediente = _pedidoLancheBll.Find(1);

            _pedidoLancheRepositoryMock.Verify(x => x.Find(1), Times.Once());
            Assert.NotNull(ingrediente);
            Assert.Equal(1, ingrediente.Id);
        }

        [Fact]
        public void TestValorePromocaoLight()
        {
            var dataPedidoLanche = new PedidoLanche
            {
                Id = 1,
                IdLanche = 1,
                Lanche = new Lanche() { Id = 1 },
                IngredientesAdicionais = new Collection<IngredienteAdicional>()
                {
                    new IngredienteAdicional()
                    {
                        Ingrediente =  new Ingrediente()
                        {
                            Id = 1,
                            Descricao = "Alface",
                            Valor = 0.40
                        }
                    },
                    new IngredienteAdicional()
                    {
                        Ingrediente =  new Ingrediente()
                        {
                            Id = 2,
                            Descricao = "Queijo",
                            Valor = 1.5
                        }
                    },
                    new IngredienteAdicional()
                    {
                        Ingrediente =  new Ingrediente()
                        {
                            Id = 3,
                            Descricao = "Ovo",
                            Valor = 0.8
                        }
                    }
                }
            };

            var dataLanche = new Lanche()
            {
                Descricao = "X-Egg",
                LancheIngredientes = new Collection<LancheIngrediente>()
                {
                    new LancheIngrediente()
                    {
                        Ingrediente = new Ingrediente()
                        {
                            Id = 3,
                            Descricao = "Ovo",
                            Valor = 0.8
                        }
                    },
                    new LancheIngrediente()
                    {
                        Ingrediente = new Ingrediente()
                        {
                            Id = 8,
                            Descricao = "Hamb�rguer de carne",
                            Valor = 3
                        }
                    }
                }
            };

            _lancheBllMock.Setup(theObject => theObject.Find(dataPedidoLanche.Id)).Returns(dataLanche);

            _ingredienteBllMock.Setup(theObject => theObject.FindByDescription("Hamb�rguer de carne")).Returns(new Ingrediente() { Id = 8 });
            _ingredienteBllMock.Setup(theObject => theObject.FindByDescription("Queijo")).Returns(new Ingrediente() { Id = 10 });
            var valor = _pedidoLancheBll.CalcularPrecoLanche(dataPedidoLanche);

            _lancheBllMock.Verify(x => x.Find(1), Times.Once());
            Assert.Equal(5.85, valor);
        }

        [Fact]
        public void TestValorePromocaoQueijo()
        {
            var dataPedidoLanche = new PedidoLanche
            {
                Id = 1,
                IdLanche = 1,
                Lanche = new Lanche() { Id = 1 },
                IngredientesAdicionais = new Collection<IngredienteAdicional>()
                {
                    new IngredienteAdicional()
                    {
                        Quantidade = 6,
                        Ingrediente =  new Ingrediente()
                        {
                            Id = 10,
                            Descricao = "Queijo",
                            Valor = 0.40
                        }
                    }
                }
            };

            var dataLanche = new Lanche()
            {
                Descricao = "X-Egg",
                LancheIngredientes = new Collection<LancheIngrediente>()
                {
                    new LancheIngrediente()
                    {
                        Ingrediente = new Ingrediente()
                        {
                            Id = 3,
                            Descricao = "Hamburguer",
                            Valor = 3
                        }
                    },
                    new LancheIngrediente()
                    {
                        Ingrediente = new Ingrediente()
                        {
                            Id = 10,
                            Descricao = "Queijo",
                            Valor = 0.4
                        }
                    }
                }
            };

            _lancheBllMock.Setup(theObject => theObject.Find(dataPedidoLanche.Id)).Returns(dataLanche);

            _ingredienteBllMock.Setup(theObject => theObject.FindByDescription("Hamb�rguer de carne")).Returns(new Ingrediente() { Id = 8, Valor = 3 });
            _ingredienteBllMock.Setup(theObject => theObject.FindByDescription("Queijo")).Returns(new Ingrediente() { Id = 10, Valor = 0.4 });
            var valor = _pedidoLancheBll.CalcularPrecoLanche(dataPedidoLanche);

            _lancheBllMock.Verify(x => x.Find(1), Times.Once());
            Assert.Equal(5, Math.Round(valor, 2));
        }


        [Fact]
        public void TestValorePromocaoCarne()
        {
            var dataPedidoLanche = new PedidoLanche
            {
                Id = 1,
                IdLanche = 1,
                Lanche = new Lanche() { Id = 1 },
                IngredientesAdicionais = new Collection<IngredienteAdicional>()
                {
                    new IngredienteAdicional()
                    {
                        Quantidade = 6,
                        Ingrediente = new Ingrediente()
                        {
                            Id = 8,
                            Descricao = "Hamb�rguer de carne",
                            Valor = 3
                        }
                    }
                }
            };

            var dataLanche = new Lanche()
            {
                Descricao = "X-Egg",
                LancheIngredientes = new Collection<LancheIngrediente>()
                {
                    new LancheIngrediente()
                    {
                        Ingrediente = new Ingrediente()
                        {
                            Id = 8,
                            Descricao = "Hamb�rguer de carne",
                            Valor = 3
                        }
                    },
                    new LancheIngrediente()
                    {
                        Ingrediente = new Ingrediente()
                        {
                            Id = 10,
                            Descricao = "Queijo",
                            Valor = 0.4
                        }
                    }
                }
            };

            _lancheBllMock.Setup(theObject => theObject.Find(dataPedidoLanche.Id)).Returns(dataLanche);

            _ingredienteBllMock.Setup(theObject => theObject.FindByDescription("Hamb�rguer de carne")).Returns(new Ingrediente() { Id = 8, Valor = 3 });
            _ingredienteBllMock.Setup(theObject => theObject.FindByDescription("Queijo")).Returns(new Ingrediente() { Id = 10, Valor = 0.4 });
            var valor = _pedidoLancheBll.CalcularPrecoLanche(dataPedidoLanche);

            _lancheBllMock.Verify(x => x.Find(1), Times.Once());
            Assert.Equal(15.4, Math.Round(valor, 2));
        }
    }
}