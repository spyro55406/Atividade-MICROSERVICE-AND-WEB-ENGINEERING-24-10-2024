function gerarStringAleatoria(tamanho) {
  const caracteres = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  let resultado = '';

  for (let i = 0; i < tamanho; i++) {
    const indice = Math.floor(Math.random() * caracteres.length);
    resultado += caracteres[indice];
  }

  return resultado;
}

describe('Cadastro de Produto', () => {
  it('passes', () => {
    cy.visit('http://127.0.0.1:5500/cadastrar-produto.html')

    const nomeProduto = gerarStringAleatoria(6);
    const preco = (Math.random() * 100).toFixed(2);
    const quantidade = Math.floor(Math.random() * 100); 
    const data = new Date().toISOString().split('T')[0]; 

    cy.get('#productName').type(nomeProduto);
    cy.get('#productPrice').type(preco);
    cy.get('#productQuantity').type(quantidade);
    cy.get('#productDate').type(data);

    cy.get('.btn-success').click();

    cy.get('#successMessage').should('contain', 'Produto cadastrado com sucesso!')
  });
});
