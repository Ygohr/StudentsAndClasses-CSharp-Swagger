create database DbDesafioMarlin

create table t_Login (
	login	varchar(100),
	id		int identity(1,1),
	nome	varchar(100),
	primary key(login)
)

create table t_Aluno(
	id			int identity(1,1) not null,
	matricula	int not null UNIQUE,
	nome		varchar(100) null,
	primary key(id)
)

create table t_Turma (
	id		int identity(1,1),
	nome	varchar(100),
	primary key (id)
)

create table t_Turma_Aluno (
	idTurma	int,
	idAluno	int,
	primary key (idTurma, idAluno)
)

insert into t_Login
select
	'login1',
	'Login 1'

insert into t_Aluno
select
	'1154',
	'Jane Doe'

insert into t_Turma
select
	'Biologia'

insert into t_Turma_Aluno
select
	1,
	1