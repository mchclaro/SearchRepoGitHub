## Teste técnico - Entrevista Dev. Backend

### Descrição do Projeto
### Você deverá desenvolver uma aplicação web que permita:
### •	Buscar repositórios públicos do GitHub utilizando o nome (ou parte do nome) do repositório como filtro;
### •	Marcar repositórios como favoritos durante a execução da aplicação;
### •	Exibir uma lista de repositórios ordenada por relevância, conforme lógica de negócio definida por você.


## Funcionalidades Obrigatórias
### Buscar repositórios públicos por nome
### Deve ser possível pesquisar por qualquer repositório público no GitHub.
### A chamada à API do GitHub deve ser implementada por você. o	API aberta: https://api.github.com

## Marcar repositórios como favoritos
### Deve existir uma funcionalidade para favoritar/desfavoritar repositórios.
### Os favoritos devem ser mantidos em tempo de execução, sem persistência em banco de dados.
## Listar repositórios por relevância
### Crie um endpoint que retorne os repositórios ordenados por relevância.
### Você deverá definir a lógica de cálculo da relevância com base em dados como:
#### Estrelas (stargazers_count)
#### Forks (forks_count)
#### Watchers (watchers_count)
### Explique sua escolha de lógica via comentários no código.


