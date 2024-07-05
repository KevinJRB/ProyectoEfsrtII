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



insert into Productos (cod_prod,nom_prod,desc_prod,pre_prod,stk_prod)
values
(100022,'Teclado Logictech','Teclado Comun',37.5,14),
(100023,'Mouse Teraware 4W019 ','Mouse gamer Teraware',20, 50),
(100024,'Logitech g20','Mouse gamer',270,15),
(100025,'SanDisk Cruser Blade 8GB','Memoria USB',20,60),
(100026,'Parlante IBlue ','Parlante Desktop',20,25),
(100027,'SanDisk UltraShift 32GB','memoria USB',30,75),
(100028,'Mouse Logitech M110','Mouse Comun',30,58),
(100029,'Mouse  Genius NX700 ','Mouse Comun',30,50),
(100030,'Audifonos gamer Teraware','Audifonos',129,25),
(100031,'Web Cam Logictech','Camara Web',349.9,17),
(100032,'Mouse Pad Teraware S ','Mouse Pad',19.9,60),
(100034,'Mouse Inalambrico Teraware 800xb','Mouse Gamer',19.9,59),
(100035,'Hub Targus 4 USB 3.0','USB Hub',94.9,10),
(100036,'Mouse Pad Logitech Dark ','Mouse Pad',41,45),
(100037,'Mouse Genius m170','Mouse Comun',24.9,36)
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



/*alter table Usuarios
add
go
*/
insert into Usuarios(cod_us,nom_us,ctr_us,id_tpu,est_us,cor_us) 
values
(156234,'JulianHernandez','152asd5',2,'Activo','julhern@gmail.com'),
(156235,'GloriaMiranda','123421@',3,'No Activo','gmiranda23@gmail.com'),
(156236,'EstebanCazorla','45sdc2',3,'Activo','ecm@outlook.com'),
(156237,'EduardoChavez','24k45',1,'Activo','echavez91@gmail.com'),
(156238,'FelipeUchoa','9597bjso',2,'Activo','felipeucho@gmail.com')
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
	insert into Productos (cod_prod,nom_prod,desc_prod,pre_prod,stk_prod)values(@COD_PROD,@NOM_PROD,@DESC_PROD,@PRE_PROD,
	@STK_PROD)
go

/*execute pa_insertar_producto '199832','Test44','Test',20,20
go*/

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
	where a.nom_prod like @NOM_PROD+'%' and eli_prod='NO'
go

/*execute pa_listar_producto ''
go*/

--Eliminar

------------PAs tipoUsuario

--Insertar tipoUsuario
create or alter procedure pa_insertar_tipousuario
@ID_TPU char(1),@NOM_TPU varchar(20)
as
	insert into tipousuario (id_tpu,nom_tpu) values(@ID_TPU,@NOM_TPU)
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
	where a.nom_tpu like @NOM_TPU+'%' and eli_tip = 'No'
go

execute pa_listar_producto 'B'
go

--Eliminar tipousuario

------------PAs usuario

--Insertar usuario
/*create or alter procedure pa_insertar_usuario
@COD_US char(6),@NOM_US varchar(25),@CTR_US varchar(25),
@ID_TPU char(1),@EST_US varchar(10),@COR_US varchar(25)
as
	insert into Usuarios(cod_us,nom_us,ctr_us,id_tpu,est_us,cor_us) values(@COD_US,@NOM_US,@CTR_US,@ID_TPU,
	@EST_US,@COR_US)
go*/


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
	where a.nom_us like @NOM_US+'%' and eli_us='No'
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