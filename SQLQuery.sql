create  database efsrt2
go

use  efsrt2
go

create table Productos
(
cod_prod char(6) not null primary key,
nom_prod varchar(40) null,
desc_prod varchar(50) null,
pre_prod decimal(6,2) null,
stk_prod int null
)
go

insert into Productos values
(101334,'Test 1','Desc test 1',30.5,5),
(101213,'Test 2','Desc test 2',30.0,0),
(102141,'Test 3','Desc test 3',40.5,15)
go

insert into Productos values
(101123,'Test 4','Desc test 4',37.5,14),
(101512,'Test 5','Desc test 5',20,50),
(102523,'Test 6','Desc test 6',100,2)
go

insert into Productos values
(103223,'Best 4','Desc test 4',37.5,14)
go

/*alter table Productos
add
go
*/


create table tipoUsuario(
id_tpu char(1) not null primary key  ,
nom_tpu varchar(20) not null 
)
go

/*alter table tipoUsuario
add
go
*/

insert into tipoUsuario values(1,'Cliente'),(2,'Empleado'),(3,'Administrador')
go

create table Usuarios(
cod_us char(6) not null primary key,
nom_us varchar(25) not null unique,
ctr_us varchar(25),
id_tpu char(1),
est_us varchar(10),
cor_us varchar(25) default('Sin correo'),
constraint fk_tipoU foreign key(id_tpu) references tipoUsuario(id_tpu)
)
go

select*from Usuarios
go

/*alter table Usuarios
add
go
*/

insert into Usuarios values
(123154,'Usuario1','948gkd',1,'Activo','1455@gmail.com'),
(123213,'Usuario2','9552fkd',1,'Inactivo','po25@gmail.com'),
(125431,'Usuario3','lsa9d',2,'Activo','us45@gmail.com'),
(123255,'Usuario4','lsa933',2,'Inactivo','cualquiera@gmail.com'),
(124215,'Usuario5','8541dasa',3,'Activo','Si@gmail.com')
go

/*alter table Usuarios
add
go
*/

---Crud procedientos

--PAs Productos

--Insertar
create or alter procedure pa_insertar_producto
@COD_PROD char(6),@NOM_PROD varchar(40),@DESC_PROD varchar(50),
@PRE_PROD decimal(6,2),@STK_PROD int
as
	insert into Productos values(@COD_PROD,@NOM_PROD,@DESC_PROD,@PRE_PROD,
	@STK_PROD)
go

--Actualizar
create or alter procedure pa_actualizar_producto
@COD_PROD char(6),@NOM_PROD varchar(40),@DESC_PROD varchar(50),
@PRE_PROD decimal(6,2),@STK_PROD int
as
	update Productos 
	set nom_prod=@NOM_PROD,desc_prod=@DESC_PROD,pre_prod=@PRE_PROD,
	stk_prod=@STK_PROD
	where cod_prod=@COD_PROD
go
--Listar
create or alter procedure pa_listar_producto
@NOM_PROD varchar(40) = '%'
as
	select a.cod_prod,a.nom_prod,a.desc_prod,a.pre_prod,
	a.stk_prod
	from Productos a
	where a.nom_prod like @NOM_PROD+'%'
go

execute pa_listar_producto 'B'
go

--Eliminar

------------PAs tipoUsuario

--Insertar tipoUsuario
create or alter procedure pa_insertar_tipousuario
@ID_TPU char(1),@NOM_TPU varchar(20)
as
	insert into tipousuario values(@ID_TPU,@NOM_TPU)
go


--Actualizar tipoUsuario
create or alter procedure pa_actualizar_tipousuario
@ID_TPU char(1),@NOM_TPU varchar(20)
as
	update tipoUsuario 
	set nom_tpu=@NOM_TPU
	where id_tpu=@ID_TPU
go
--Listar tipousuario
create or alter procedure pa_listar_tipousuario
@NOM_TPU varchar(20) = '%'
as
	select a.id_tpu,a.nom_tpu
	from tipoUsuario a
	where a.nom_tpu like @NOM_TPU+'%'
go

execute pa_listar_producto 'B'
go

--Eliminar tipousuario

------------PAs usuario

--Insertar usuario
create or alter procedure pa_insertar_usuario
@COD_US char(6),@NOM_US varchar(25),@CTR_US varchar(25),
@ID_TPU char(1),@EST_US varchar(10),@COR_US varchar(25)
as
	insert into Usuarios(cod_us,nom_us,ctr_us,id_tpu,est_us,cor_us) values(@COD_US,@NOM_US,@CTR_US,@ID_TPU,
	@EST_US,@COR_US)
go


--Actualizar usuario
create or alter procedure pa_actualizar_usuario
@COD_US char(6),@NOM_US varchar(25),@CTR_US varchar(25),
@ID_TPU char(1),@EST_US varchar(10),@COR_US varchar(25)
as
	update Usuarios 
	set cod_us=@COD_US,nom_us=@NOM_US,ctr_us=@CTR_US,
	id_tpu=@ID_TPU,est_us=@EST_US,cor_us=@COR_US
	where cod_us=@COD_US
go
--Listar usuario
create or alter procedure pa_listar_usuario
@NOM_US varchar(40) = '%'
as
	select a.cod_us,a.nom_us,a.ctr_us,a.id_tpu,
	a.est_us,a.cor_us
	from Usuarios a
	where a.nom_us like @NOM_US+'%'
go

use Efsrt2
go

-----------------------------------------------------------------------------------------------------------------------

create or alter procedure pa_insertar_usuario
@COD_US char(6),@NOM_US varchar(25),@CTR_US varchar(25),
@ID_TPU char(1),@EST_US varchar(10),@COR_US varchar(25)
as
	insert into Usuarios(cod_us,nom_us,ctr_us,id_tpu,est_us,cor_us) values(@COD_US,@NOM_US,@CTR_US,@ID_TPU,
	@EST_US,@COR_US)
go

--Columnas para eliminar

alter table Productos
add eli_prod char(2) default 'No' with values
go

alter table tipoUsuario
add eli_tip	char(2) default 'No' with values
go

alter table Usuarios
add eli_us	char(2) default 'No' with values
go

--Metodos eliminar

create OR alter procedure pa_eliminar_producto
@COD_PROD char(6)
as
	update Productos
		set eli_prod='Si'
	where cod_prod = @COD_PROD
go

create OR alter procedure pa_eliminar_tipousuario
@ID_TPU char(1)
as
	update tipoUsuario
		set eli_tip='Si'
	where id_tpu = @ID_TPU
go

create OR alter procedure pa_eliminar_usuario
@COD_US char(6)
as
	update Usuarios
		set eli_us='Si'
	where cod_us = @COD_US
go