use TesteSysMap

create table Usuario 
(
id_usuario int primary key not null,
nome varchar(100) not null,
dataNascimento date not null,
email varchar(70) not null,
senha varchar(MAX) not null,
foto image null
)

Create Table Tarefa
(
id_tarefa int primary Key not null,
descricao varchar(MAX) not null,
dataHora datetime not null,
FK_id_usuario int not null,
foreign key (FK_id_usuario) references Usuario (id_Usuario)
)

Create Table EnviarEmail
(id_email int primary key not null,
Destinatario varchar(100) not null,
Assunto varchar(200) not null,
Corpo varchar(MAX) not null
)