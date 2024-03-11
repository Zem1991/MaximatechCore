## Instruções - Teste da MáximaTech

Candidato:	Felipe Lopes Zem

LinkedIn:	https://www.linkedin.com/in/zemfelipelopes/


## Instalações necessárias

Para a execução dos testes, você deverá dispor em sua máquina dos seguintes softwares:
Visual Studio (ou outra IDE de sua preferência), para executar os projetos a serem baixados.
PgAdmin, para uso do banco de dados PostgreSQL cujos projetos farão uso.


## Passo 01)	Obtendo e executando os projetos

O teste solicitou dois projetos, onde um foi feito em .NET MVC e serve de front-end, enquanto que o outro foi feito em .NET Core versão 7.0 e serve de back-end. Adicionalmente o teste solicitou a criação de um banco de dados em PostgreSQL, que poderá ser criado durante as etapas aqui descritas ou mesmo reaproveitado da solução de algum outro candidato.
Em todo o caso, você deve baixar os seguintes projetos:

https://github.com/Zem1991/MaximatechMVC

https://github.com/Zem1991/MaximatechCore

Após realizar o download de ambos, e extraí-los para onde preferir, execute o arquivo Solution (extensão ‘.sln’) de ambos. Isso irá abrir o Visual Studio e carregar todos os arquivos de cada projeto, em instâncias distintas da IDE.

Neste momento, você já poderá executar ambos para conferir que nenhum erro de compilação estará presente. Executando ambos, os seguintes links deverão ser abertos automaticamente pelo seu navegador:

O projeto MVC irá abrir:	https://localhost:7244/

O projeto Core irá abrir:	https://localhost:7210/swagger/index.html

No entanto, pela falta do banco de dados, nenhuma ação será possível. As próximas etapas irão justamente corrigir isso.


## Passo 02)	Conectando a um banco de dados

Para este passo você dispõe de duas opções: criar um banco de dados do zero, ou aproveitar um já existente. Escolha a alternativa de sua preferência abaixo.

### Passo 02.A) Criar um banco de dados do zero

Dentro do seu PgAdmin, crie um banco com as seguintes informações:

Nome do banco		=	TesteMaximatech

Endereço	=	localhost

Porta		=	5432

Usuário		=	postgres

Senha		=	qwe123


Após criar o banco, volte para o projeto Core. No Visual Studio, abra o Package Manager Console. Na janela do console, selecione o projeto “main\infrastructure”. Por fim digite ambos os comandos abaixo:

Add-Migration TesteMaximatech

Update-Database


Como o banco foi criado, e neste teste não foi solicitado o cadastro dos departamentos, estes precisarão ser inseridos diretamente. Portanto, retorne ao PgAdmin e conectado ao DB recém criado, execute a seguinte query:

INSERT INTO public."DEPARTMENT"
("Codigo", "Descricao")
VALUES 
('010', 'BEBIDAS'),
('020', 'CONGELADOS'),
('030', 'LATICINIOS'),
('040', 'VEGETAIS');

### Passo 02.B) Aproveitar banco de dados existente

Dentro do projeto Core, encontre os arquivos “appsettings.Development.json” e “appsettings.json”. Ambos estão contidos no projeto “main\Api”. Em ambos os arquivos a linha “TesteMaximatech” informa a Connection String necessária para que o projeto encontre e conecte ao banco de dados de sua escolha.
Edite esta linha de modo que faça sentido para o banco que deseja utilizar.


