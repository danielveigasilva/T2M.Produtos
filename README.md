## Rotas

1. **GET: /api/products/**
  Retorna a lista dos produtos em ordem decrescente do último produto cadastrado.
  Caso passados os parâmetros ```page``` (Indice da página) e ```totalItens``` (Total de itens a serem exibidos por página) o retorno será uma lista páginada.
  
  URL:
  ```/api/products/page=1&totalItens=2```
  
  Json:
        ```json
        [
          {
	          "Id" : 12,
	          "Name" : "Produto 1",
            "Price": 23.50,
            "Created": "2020/11/21"
          },
          {
	          "Id" : 13,
	          "Name" : "Produto 2",
            "Price": 42.90,
            "Created": "2020/11/21"
          }
        ]
        ```
  
2. **GET: /api/products/{name}**

3. **DELETE: /api/products/{name}**

4. **POST: /api/products**
