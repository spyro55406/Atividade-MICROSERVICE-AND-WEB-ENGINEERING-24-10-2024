function gerarStringAleatoria(tamanho) {
  const caracteres = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
  let resultado = '';

  for (let i = 0; i < tamanho; i++) {
    const indice = Math.floor(Math.random() * caracteres.length);
    resultado += caracteres[indice];
  }

  return resultado;
}

describe('Cadastro de Produto - Erro', () => {
  beforeEach(() => {
    cy.visit('http://127.0.0.1:5500/cadastrar-produto.html');
  });

  it('passes', () => {
    cy.get('#productName').type('Produto Teste');
    cy.get('#productPrice').clear().type('-10'); // Preço inválido
    cy.get('#productQuantity').clear().type('5'); // Quantidade válida
    cy.get('#productDate').type(new Date().toISOString().split('T')[0]); // Data válida

    cy.get('.btn-success').click();

    cy.get('#validationError').should('be.visible')
      .and('contain', 'Preencha todos os campos com valores válidos!');
  });

  it('passes', () => {
    cy.get('#productName').type('Produto Teste');
    cy.get('#productPrice').clear().type('25.00'); // Preço válido
    cy.get('#productQuantity').clear().type('-5'); // Quantidade inválida
    cy.get('#productDate').type(new Date().toISOString().split('T')[0]); // Data válida

    cy.get('.btn-success').click();

    cy.get('#validationError').should('be.visible')
      .and('contain', 'Preencha todos os campos com valores válidos!');

  });
});
