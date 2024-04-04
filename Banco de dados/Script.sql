create database emprestimobd;
use emprestimobd;

create table usuario_tb(
	idusuario int primary key auto_increment,
    nameusuario varchar(50)
);

create table livro_tb(
	idlivro int primary key auto_increment,
    namelivro varchar(50),
    imglivro varchar(255)
);

create table emprestimo_tb(
	idempre int primary key auto_increment,
    dataemp varchar(20),
    datadev varchar(20),
    idusuario int references usuario_tb(idusuario)
);

create table itensemp(
	iditem int primary key auto_increment,
    idempre int references emprestimo_tb(idempre),
    idlivro int references livro_tb(idlivro)    
);

select * from itensemp;

insert into usuario_tb values (default,'Pedro'),(default,'henrique');