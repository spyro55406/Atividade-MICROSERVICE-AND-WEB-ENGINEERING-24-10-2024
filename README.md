Checkpoint realizado por Guilherme Miguel e Vicenzo Castelli
<br/>
<br/>
Comandos:
<br/>
docker run --name database-mysql -e MYSQL_ROOT_PASSWORD=123 -p 3306:3306 -d mysql
<br/>
docker run --name redis -p 6379:6379 -d redis
<br/>
<br/>
SCRIPT UTILIZADO:
<br/>
CREATE TABLE sys.produtos ( id INT NOT NULL AUTO_INCREMENT, nome VARCHAR(45) NULL, preco DOUBLE NULL, quantidade_estoque INT NULL, data_criacao VARCHAR(45) NULL, PRIMARY KEY (id));
