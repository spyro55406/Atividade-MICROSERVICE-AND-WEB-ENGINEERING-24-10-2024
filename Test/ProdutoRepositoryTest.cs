using Moq;
using web_app_repository;
using wep_app_domain;

namespace Test
{
    public class ProdutoRepositoryTest
    {
        [Fact]
        public async Task ListarProdutos()
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
                  new Produto()
                {
                     Id = 2,
                    Nome = "produtoteste2",
                    Preco = 909,
                    Quantidade_Estoque = 700,
                    Data_Criacao = DateTime.Now
                },
            };

            var productRepositoryMock = new Mock<IProdutoRepository>();
            productRepositoryMock.Setup(u => u.ListarProdutos()).ReturnsAsync(produtos);
            var productRepository = productRepositoryMock.Object;

            //Act
            var result = await productRepository.ListarProdutos();

            //Assert
            Assert.Equal(produtos, result);



        }
    }
}
