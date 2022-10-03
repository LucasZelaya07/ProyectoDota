create procedure storedAltaHeroes
@Numero int,
@Nombre varchar(50),
@Descripcion varchar(150),
@UrlImagen varchar(300),
@IdTipo int,
@IdDebilidad int,
@IdVentaja int
as
insert into HEROES values (@Numero, @Nombre, @Descripcion, @UrlImagen, @IdTipo, @IdDebilidad, @IdVentaja, 1)