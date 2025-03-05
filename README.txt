
Descrição do projeto:

Par de Apis que gerenciam processos judiciais, a primeira é responsável pelo CRUD dos processos,
aonde é possível; listar todos os processos, postar um novo projeto, buscar um processo pelo seu número,
atualizar informações de um processo existente e deletar processos do banco de dados
juntamente com suas movimentações. 
A segunda é responsavel por gerenciar as movimentações dos processos, sendo vinculada aos processos pelo
número de cada um deles, que é usado como chave estrangeira no banco de dados. Nos endpoints da Api é possível
listar todas as movimentações de um processo pelo seu número, adicionar novas movimentações,
e também possui um endpoint de delete que é chamado pela Api de processos, pois quando se deseja excluir um 
processo suas movimentações também são excluídas.

Tecnologias usadas:

Linguagem: C# e Sql(Apenas consultas verificatórias no bando de dados)
IDE: Visual Studio
Frameworks: Entity Framework
Banco de dados: SqlServer gerenciado pelo Azure Data Studio.  

Descrição das entidades no banco de dados:

Um processo possui: 	Id tipo int, autoincremento
			Número do processo, tipo string, apenas caracteres numéricos
			Autor, tipo string
			Réu, tipo string
			Data de Cadastro, tipo Data




Uma movimentação possui: 	Id tipo int, autoincremento
				Descrição da movimentação, tipo string
				Data da movimentação, tipo Data
				Numero do processo, chave estrangeira


Instruções para uso dos Endpoints:

Para adicionar um novo processo basta passar as informações no corpo da requisição, com os formatos descritos acima.
Para atualizar ou deletar um processo é preciso ter seu número que é composto por 20 caracteres numéricos.
Para gerar uma nova movimentação é necessário passar o número do processo e a descrição da movimentação. 		 