## Rotas

1. **GET: /api/products/**
  
  Retorna a lista dos produtos em ordem decrescente do último produto cadastrado.
  Caso passados os parâmetros ```page``` (Indice da página) e ```totalItens``` (Total de itens a serem exibidos por página) o retorno será uma lista páginada.
  
  *EXEMPLO*
  
  **URL:**
  ```/api/products/page=1&totalItens=2```
  
  **Retorno em Json:**
        
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

Retorna o produto cadastrado pelo nome.

  *EXEMPLO*

  **URL:**
  ```/api/products/Produto 1```
  
  **Retorno em Json:**
        
```json
{
	"Id" : 12,
	"Name" : "Produto 1",
	"Price": 23.50,
	"Created": "2020/11/21"
}
```

3. **DELETE: /api/products/{name}**

Remove o produto pelo nome.

  *EXEMPLO*

**URL:**
  ```/api/products/Produto 1```

4. **POST: /api/products**

Cadastra um novo produto. Devem ser passados os valores de ```Name``` e ```Price```, as propriedades ```Id``` e ```Created``` são inseridas automáticamente pelo banco de dados.

  *EXEMPLO*

  **URL:**
  ```/api/products```
  
  **Json:**

```json
{
	"Name" : "Produto 3",
	"Price": 55.59
}
```
