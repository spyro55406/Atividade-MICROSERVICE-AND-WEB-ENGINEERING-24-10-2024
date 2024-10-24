using Moq;
using web_app_repository;
using web_app_performance.Controllers;
using wep_app_domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Test
{
    public class ProdutoControllerTest
    {
        private readonly Mock<IProdutoRepository> _productRepositoryMock;
        private readonly ProdutoController _controller;

        public ProdutoControllerTest()
        {
            _productRepositoryMock = new Mock<IProdutoRepository>();
            _controller = new ProdutoController(_productRepositoryMock.Object);
        }

        [Fact]

        public async Task Get_ProdutosOk()
        {
            //Arrange
            var produtos = new List<Produto>
            {
                new Produto()
                {
                    Id = 1,
                    Nome = "produtoteste",
                    Preco = 999,
                    Quantidade_Estoque = 500,
                    Data_Criacao = DateTime.Now
                },
            };

            _productRepositoryMock.Setup(r => r.ListarProdutos()).ReturnsAsync(produtos);

            //Act
            var result = await _controller.GetProduto();

            //Asserts
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(JsonConvert.SerializeObject(produtos), JsonConvert.SerializeObject(okResult.Value));
        }

        [Fact]

        public async Task Get_ListarRetornarNotFound()
        {
            _productRepositoryMock.Setup(u => u.ListarProdutos())
                .ReturnsAsync((IEnumerable<Produto>)null);

            var result = await _controller.GetProduto();

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Post_SalvarProduto()
        {

            //Arrange
            var produto = new Produto()
            {
                Id = 2,
                Nome = "produtoteste2",
                Preco = 919,
                Quantidade_Estoque = 550,
                Data_Criacao = DateTime.Now
            };

            _productRepositoryMock.Setup(u => u.SalvarProduto(It.IsAny<Produto>())).Returns(Task.CompletedTask);

            //Act
            var result = await _controller.Post(produto);

            //Assert
            _productRepositoryMock.Verify(u => u.SalvarProduto(It.IsAny<Produto>()), Times.Once);
            Assert.IsType<OkObjectResult>(result);

        }


    }
}
