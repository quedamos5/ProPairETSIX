use EmpresasInformaticas
go

-- 1.- Artículo que más unidades en total se ha vendido sin considerar los de tipos que contengan
-- 'ALMACENAMIENTO' ni los de 'VARIOS'
SELECT TOP 1 WITH TIES c.descripcion, SUM(fc.Cantidad)
FROM FacturaComponente as fc
	 INNER JOIN Componente as c
	 on fc.CodComponente = c.clave
	 INNER JOIN TipoComponente as tc
	 on c.CodTipo = tc.CodTipo
WHERE tc.Tipo NOT LIKE '%ALMACENAMIENTO%' AND tc.Tipo NOT LIKE '%VARIOS%'
GROUP BY c.descripcion
order by SUM(Cantidad) DESC
go
	 
-- 2.- Tienda con mayores ventas en importe
SELECT t.NombreTienda, SUM(fc.PrecioAplicado * fc.Cantidad) as Importe
FROM Tienda as t
	 INNER JOIN Factura as f
	 on t.IdTienda = f.idTienda
	 INNER JOIN FacturaComponente as fc
	 on f.NFactura = fc.NFactura
GROUP BY t.NombreTienda
ORDER BY SUM(fc.PrecioAplicado * fc.Cantidad) desc
GO

-- 3.- Tienda con mayor número de facturas realizadas (sacar todas las que coincidan)
SELECT t.NombreTienda, COUNT(fc.NFactura)
FROM Tienda as t
	INNER JOIN Factura as f
	on t.IdTienda = f.idTienda
	INNER JOIN FacturaComponente as fc
	on f.NFactura = fc.NFactura
GROUP BY t.NombreTienda
ORDER BY COUNT(fc.NFactura) DESC
GO 

-- 4.- Artículos vendidos, dando su nombre, indicando el nº de veces que referencia esté a NULL
SELECT c.clave,COUNT(*) - COUNT(fc.Referencia)
FROM Componente as c
	INNER JOIN FacturaComponente as fc
	on c.clave = fc.CodComponente
GROUP BY c.clave
HAVING COUNT(*) - COUNT(fc.Referencia) > 0
GO

-- 5.- Importe de las facturas de las tiendas de Localidad 'La Laguna'
SELECT t.NombreTienda, SUM(fc.PrecioAplicado * fc.Cantidad)
FROM FacturaComponente as fc
	INNER JOIN Factura as f
	on fc.NFactura = f.NFactura
	INNER JOIN Tienda as t
	on f.idTienda = t.IdTienda
WHERE t.Localidad = 'La Laguna'
GROUP BY t.NombreTienda
GO

-- 6.- Nº de componentes vendidos por tipo de los tipos que contengan 'impresora'
SELECT c.clave, SUM(fc.Cantidad)
FROM FacturaComponente as fc
	 INNER JOIN Componente as c
	 on fc.CodComponente = c.clave
	 INNER JOIN TipoComponente as tc
	 on c.CodTipo = tc.CodTipo
WHERE tc.Tipo like '%impresora%' 
GROUP BY c.clave
GO
-- 7.- Nº de la Factura con más unidades vendidas (sacando todas las coincidentes) de las tiendas que
-- contengan 'CRUZ' en la localidad.
SELECT TOP 1 fc.NFactura, SUM(fc.Cantidad)
FROM FacturaComponente as fc
	INNER JOIN Factura as f
	on fc.NFactura = f.NFactura
	INNER JOIN Tienda as t
	on f.idTienda = t.IdTienda
WHERE t.Localidad LIKE '%CRUZ%'
GROUP BY fc.NFactura
ORDER BY SUM(fc.Cantidad) DESC
GO

-- 8.- Importe por Tipo de Componente, dando el nombre del tipo de componente y sacándolos todos.
SELECT tc.Tipo, SUM(c.precio)
FROM TipoComponente as tc
	INNER JOIN Componente as c
	on tc.CodTipo = c.CodTipo
GROUP BY tc.Tipo
GO

-- 9.-Total de ventas (en importe) del mes de mayo
SELECT  SUM(PrecioAplicado)
FROM Factura as f
	INNER JOIN FacturaComponente as fc
	on f.NFactura = fc.NFactura
WHERE MONTH(f.Fecha) = 5
GO

-- 10.- Tienda con la factura en la que se vendieron más artículos.
SELECT top 1 t.NombreTienda, Cantidad
FROM FacturaComponente as fc
	INNER JOIN Factura as f
	on fc.NFactura = f.NFactura
	INNER JOIN Tienda as t
	on f.idTienda = t.IdTienda
order by fc.Cantidad desc
go

-- 11.- Tipos de componente no vendidos
SELECT tc.tipo
FROM FacturaComponente as fc
	 INNER JOIN Componente as c
	 on fc.CodComponente = c.clave
	 INNER JOIN TipoComponente as tc
	 on c.CodTipo = tc.CodTipo
WHERE fc.Cantidad = 0
GROUP BY tc.Tipo
GO

-- 12.- Especificar las facturas con más de 2 artículos, indicando el nombre de la tienda.SELECT fc.NFactura, t.NombreTienda, fc.CantidadFROM FacturaComponente as fc
	INNER JOIN Factura as f
	on fc.NFactura = f.NFactura
	INNER JOIN Tienda as t
	on f.idTienda = t.IdTienda
WHERE fc.Cantidad > 2
GO