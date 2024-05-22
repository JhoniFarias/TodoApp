# TodoApp
Projeto desenvolvido com Angular 17 e .net 8

# Back-end

## 📋 Fluent Validation
Utilizei o package **Fluent Validator** para garantir que todas as entradas de dados sejam válidas desde o começo (Fail Fast Validation).

## 🔄 CQRS
### Comandos e Handlers

- **Commands**: Usei para operações de escrita, facilitando a validação e execução de alterações no domínio.
- **Handlers**: Responsáveis por processar commands e queries, conectando-se com todo o fluxo da aplicação.

## 🔐 Autenticação JWT
Utilizei autenticação Jwt utilizando token gerado via google autentication realizado no front-end

## 🧪 Testes Unitários com xUnit
Para garantir que tudo funcione perfeitamente, implementei testes unitários utilizando o xUnit. Isso nos ajuda a dormir tranquilos, sabendo que nosso código está sólido!

# Front-end

## 🔥firebase
utilizei a lib do firebase para fazer todo o controle de autenticação da aplicação

## Bootstrap
utilizei o bootstrap 5

