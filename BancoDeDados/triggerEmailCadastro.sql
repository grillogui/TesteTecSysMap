use TesteSysMap

create trigger trEnviarEmailCadastro

on dbo.Usuario

for insert
as
begin

 declare
     @id_usuario int,
	 @nome varchar(100),
	 @email varchar(70);

 select
     @id_usuario = id_usuario,
	 @nome = nome,
	 @email = email

 From
     inserted 

 insert into dbo.EnviarEmail
 (
     Destinatario,
	 Assunto,
	 Corpo
 )

  Values
  (
     'contato@sistemas.com.br',
	 'Novo usuario cadastrado',
	 'Novo Usuario cadastrado:' + cast(@id_usuario as varchar) + @nome + 'email:' + @email
  )

  END