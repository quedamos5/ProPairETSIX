use Restaurante
go
-- 1.- Contar cuántos platos se han servido por Tipo de Plato (la descripción 
--del Tipo de plato). 
SELECT COUNT(*) as numPlatos, tp.TipoPlato
FROM Plato as p 
	INNER JOIN TipoPlato as tp
	on p.CodTipoPlato = tp.CodTipoPlato
GROUP BY tp.TipoPlato
ORDER BY COUNT(*) DESC

--2.- Contar las comidas servidas en las mesas, sacando todas las mesas. 
SELECT COUNT(*) as numComida, m.CodMesa 
FROM Mesa as m
	INNER JOIN Comida as c
	on m.CodMesa = c.CodMesa
	INNER JOIN DetalleComida as dc
	on c.IdComida = dc.IdComida
WHERE dc.Servido = 'S'
GROUP BY m.CodMesa
GO

--3.- Dar la mesa y la fecha de la comida que más platos consumió del tipo 
--de plato carnes, sacándolas todas si hay más de una. 
SELECT TOP 1 WITH TIES COUNT(*) as numPlatos, c.Fecha, c.CodMesa
FROM Comida as c
	INNER JOIN DetalleComida as dc
	on c.IdComida = dc.IdComida
	INNER JOIN Plato as p
	on dc.CodPlato = p.CodPlato
	INNER JOIN TipoPlato as tp
	on p.CodTipoPlato = tp.CodTipoPlato
WHERE tp.TipoPlato = 'Carnes'
GROUP BY c.CodMesa, c.Fecha
ORDER BY COUNT(*) DESC


--4.- Comidas pagadas (dando mesa y fecha) que han consumido algo de bebidas. 
SELECT c.CodMesa, c.Fecha
FROM Comida as c
	INNER JOIN DetalleComida AS dc
	on c.IdComida = dc.IdComida
	INNER JOIN Plato as p
	on dc.CodPlato = p.CodPlato
	INNER JOIN TipoPlato as tp
	on p.CodTipoPlato = tp.CodTipoPlato
WHERE Pagado = 'S' and tp.Agrupa = 'Bebida'
GO

--5.- Importe total de las comidas pagadas de las mesas que comienzan con A. 
SELECT c.CodMesa, SUM(dc.PrecioPlato) as importeTotal
FROM Comida as c
	INNER JOIN DetalleComida as dc
	on c.IdComida = dc.IdComida
WHERE c.CodMesa like 'A%'
GROUP BY c.CodMesa

--6.- Día de la semana con mayor facturación.
SELECT TOP 1 DATEPART(DW, c.Fecha), SUM(dc.PrecioPlato)
FROM Comida as c
	INNER JOIN DetalleComida as dc
	on c.IdComida = dc.IdComida
GROUP BY DATEPART(DW, c.Fecha)
ORDER BY SUM(dc.PrecioPlato) DESC

--7.- Tipo de plato (dando la descripción del tipo de plato) que no sea bebida 
--y que menos veces se ha pedido. 
SELECT tp.TipoPlato
FROM TipoPlato as tp
	INNER JOIN Plato as p
	on tp.CodTipoPlato = p.CodTipoPlato
	INNER JOIN DetalleComida as dc
	on p.CodPlato = dc.CodPlato
WHERE tp.Agrupa != 'Bebida'
GROUP BY tp.TipoPlato
ORDER BY count(Servido) desc

--8.- Para cada plato, dando su nombre y sacándolos todos, indicar el nº de 
--comidas en las que ha aparecido.
SELECT p.Plato, COUNT(p.Plato)
FROM Plato as p
	INNER JOIN DetalleComida as dc
	on p.CodPlato = dc.CodPlato
	INNER JOIN Comida as c
	on dc.IdComida = c.IdComida
GROUP BY p.Plato

--(*) 9.- Dar las comidas pendientes de pagar (dando mesa y fecha) con todos
--sus platos servidos. 
SELECT c.Fecha, c.CodMesa, 
(select count(p.Plato)
from Plato as p
	inner join DetalleComida as dc
	on p.CodPlato = dc.CodPlato
where dc.Servido = 'S' and dc.IdComida = c.IdComida) as sub
FROM Comida as c
WHERE c.Pagado = 'N' 

--(*) 10.- Comidas (dando mesa y fecha) que sólo han consumido bebidas.
SELECT c.Fecha, c.CodMesa, 
(select count(p.Plato)
from Plato as p
	inner join TipoPlato as tp
	on p.CodTipoPlato = tp.CodTipoPlato
	inner join DetalleComida as dc
	on p.CodPlato = dc.CodPlato
where tp.Agrupa = 'Bebida' and c.IdComida = dc.IdComida) as sub
FROM Comida as c

--11.- Calcular el plato con mayor diferencia entre lo que se cobró y el precio
--actual (de la tabla Plato). 
SELECT p.Plato, p.Precio, dc.PrecioPlato, (dc.PrecioPlato - p.Precio)
FROM Plato as p
	INNER JOIN DetalleComida as dc
	on p.CodPlato = dc.CodPlato
GROUP BY p.Plato, p.Precio, dc.PrecioPlato
ORDER BY (dc.PrecioPlato - p.Precio) DESC

--12.- Sacar la estadística por días, incluyendo nº platos (incluyendo 
--bebidas), el nº de comidas realizadas y el importe de los platos (incluyendo bebidas). 
SELECT DATEPART(DW, c.Fecha), COUNT(p.Plato) as numPlato, COUNT(DISTINCT c.IdComida) as numComidas, SUM(PrecioPlato)
FROM Comida as c
	INNER JOIN DetalleComida as dc
	on c.IdComida = dc.IdComida
	INNER JOIN Plato as p
	on dc.CodPlato = p.CodPlato
GROUP BY DATEPART(DW, c.Fecha)


--    1. Dar el plato más caro de cada comida.
SELECT c.IdComida, (select top 1 p.Plato
					from DetalleComida as dc
						INNER JOIN Plato as p
						on dc.CodPlato = p.CodPlato
						where dc.IdComida = c.IdComida
						order by p.Precio desc)
FROM Comida as c

--    2. Para cada comida dar el número de platos servidos 
--       y el número de platos no servidos.
SELECT c.IdComida,
(select COUNT(*)
from DetalleComida as dc
	inner join Plato as p
	on dc.CodPlato = p.CodPlato
	where Servido = 'S' and c.IdComida = dc.IdComida) as platosServidos,
(select COUNT(*)
from DetalleComida as dc
	inner join Plato as p
	on dc.CodPlato = p.CodPlato
	where Servido = 'N' and c.IdComida = dc.IdComida)
FROM Comida as c


--    3. Dar el plato más caro de cada tipo de plato.
SELECT (select top 1 p.Plato
		from Plato as p
		where p.CodTipoPlato = tp.CodTipoPlato
		order by p.Precio desc)
FROM TipoPlato as tp
--    4. Dar el plato más caro del tipo de plato con más platos que no sean bebidas.
SELECT TOP 1(select top 1p.Plato
		from Plato as p
		where p.CodTipoPlato = tp.CodTipoPlato
		order by p.Precio desc)
FROM TipoPlato as tp
WHERE 
ORDER BY (select COUNT(p.Plato)
				from Plato as p
				where p.CodTipoPlato = tp.CodTipoPlato AND tp.Agrupa != 'Bebida') DESC

select top 1p.Plato
		from Plato as p
		where p.CodTipoPlato = (select top 1 tp.CodTipoPlato
								from TipoPlato as tp
									inner join Plato as p
									on tp.CodTipoPlato = p.CodTipoPlato
								where tp.Agrupa != 'Bebida'
								group by tp.CodTipoPlato
								order by COUNT(p.Plato) desc)
		order by p.Precio desc
--    5. Dar los platos servidos de la comida más barata.
SELECT p.Plato
FROM Plato as p
	INNER JOIN DetalleComida as dc
	on p.CodPlato = dc.CodPlato
	INNER JOIN (select top 1 c.IdComida
				from Comida as c
					inner join DetalleComida as dc
					on c.IdComida = dc.IdComida
				group by c.IdComida
				order by SUM(dc.PrecioPlato) asc) as sub
	on dc.IdComida = sub.IdComida

--    6. Dar los tipos de platos servidos de la comida más cara.
SELECT tp.TipoPlato
FROM Plato as p
	INNER JOIN DetalleComida as dc
	on p.CodPlato = dc.CodPlato
	INNER JOIN (select top 1 c.IdComida
				from Comida as c
					inner join DetalleComida as dc
					on c.IdComida = dc.IdComida
				group by c.IdComida
				order by SUM(dc.PrecioPlato) desc) as sub
	on dc.IdComida = sub.IdComida
	inner join TipoPlato as tp
	on p.CodTipoPlato = tp.CodTipoPlato

--    7. Dar las comidas pendientes de pagar (dando mesa y fecha) con todos
--       sus platos servidos.
SELECT c.Fecha, c.CodMesa, 
(select count(p.Plato)
from Plato as p
	inner join DetalleComida as dc
	on p.CodPlato = dc.CodPlato
where dc.Servido = 'S' and dc.IdComida = c.IdComida) as sub
FROM Comida as c
WHERE c.Pagado = 'N' 

--    8. Comidas (dando mesa y fecha) que sólo han consumido bebidas
SELECT c.Fecha, c.CodMesa, 
(select count(p.Plato)
from Plato as p
	inner join TipoPlato as tp
	on p.CodTipoPlato = tp.CodTipoPlato
	inner join DetalleComida as dc
	on p.CodPlato = dc.CodPlato
where tp.Agrupa = 'Bebida' and c.IdComida = dc.IdComida) as sub
FROM Comida as c

--    9. Mostrar los platos de las Comidas que han servido más de 5 bebidas.
SELECT pa.Plato, dce.IdComida
FROM Plato as pa
	INNER JOIN DetalleComida as dce
	on pa.CodPlato = dce.CodPlato
WHERE (select COUNT(tp.Agrupa)
		from DetalleComida as dc
			inner join Plato as p
			on p.CodPlato = dc.CodPlato
			inner join TipoPlato as tp
			on p.CodTipoPlato = tp.CodTipoPlato
		where tp.Agrupa = 'Bebida' and dce.IdComida = dc.IdComida) > 5 
ORDER BY dce.IdComida

--    10. Comidas (dando mesa y fecha) que han servido más bebidas que platos.
SELECT ca.CodMesa, ca.Fecha
FROM Comida as ca
WHERE (select COUNT(tp.Agrupa)
		from Comida as c
			inner join DetalleComida as dc
			on c.IdComida = dc.IdComida 
			inner join Plato as p
			on p.CodPlato = dc.CodPlato
			inner join TipoPlato as tp
			on p.CodTipoPlato = tp.CodTipoPlato
		where tp.Agrupa = 'Bebida' and ca.IdComida = c.IdComida) >  (select COUNT(tp.Agrupa)
		from Comida as c
			inner join DetalleComida as dc
			on c.IdComida = dc.IdComida 
			inner join Plato as p
			on p.CodPlato = dc.CodPlato
			inner join TipoPlato as tp
			on p.CodTipoPlato = tp.CodTipoPlato
		where tp.Agrupa = 'Plato' and ca.IdComida = c.IdComida)
