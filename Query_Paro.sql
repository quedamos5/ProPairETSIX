-- 1.- Municipios de la isla de Tenerife
SELECT m.Municipio
FROM Islas AS i
	INNER JOIN MunicipiosIslas AS mi
	on i.CISLA = mi.CISLA
	INNER JOIN Municipios as m
	on mi.CodMunicipio = m.CodMunicipio
WHERE i.ISLA = 'Tenerife'
GO

-- 2.- Paro en la Industria en la Provincia de León en el mes de febrero de 2013
SELECT SUM(pm.ParoIndustria) as paroIndustria
FROM Provincias AS p
	INNER JOIN Municipios AS m
	on p.CodProvincia = m.CodProvincia
	INNER JOIN ParoMes as pm
	on m.CodMunicipio = pm.CodMunicipio
WHERE p.Provincia = 'León' and MONTH(pm.Fecha) = 2 and YEAR(pm.Fecha) = 2013
GO

-- 3.- Mostrar las comunidades autónomas y el nº de habitantes (padrón), ordenándolas 
-- de mayor a menor población
SELECT ca.CA, SUM(pa.Padron) as numHab
FROM ComunidadesAutonomas as ca
	INNER JOIN Provincias as p
	on ca.CodCA = p.CodCA
	INNER JOIN Municipios as m
	on p.CodProvincia = m.CodProvincia
	INNER JOIN Padron as pa
	on m.CodMunicipio = pa.CodMunicipio
GROUP BY ca.CA
ORDER BY SUM(pa.Padron) DESC
GO

-- 4.- Qué Comunidad Autónoma tiene mayor diferencia entre el paro mujeres en la edad 
-- 25-45 y la de mujeres menores de 25, en enero de 2013. 
SELECT TOP 1 ca.CA, SUM( pm.ParoMujerEdad25_45 - pm.ParoMujerEdadMenor25) as diferencia
FROM ComunidadesAutonomas as ca
	INNER JOIN Provincias as p
	on ca.CodCA = p.CodCA
	INNER JOIN Municipios as m
	on p.CodProvincia = m.CodProvincia
	INNER JOIN ParoMes as pm
	on m.CodMunicipio = pm.CodMunicipio
WHERE MONTH(pm.Fecha) = 1 and YEAR(pm.Fecha) = 2013
GROUP BY ca.CA
ORDER BY diferencia DESC
GO 
-- 5.- Comunidades autónomas sin islas
SELECT CA
FROM ComunidadesAutonomas 
WHERE CA not like '%Canarias%' AND CA not like '%Balears, Illes%'
GROUP BY CA
GO

-- 6.- Crear una vista que muestre el nombre de la comunidad autónoma, el de la 
-- provincia y el del municipio, junto al total de paro registrado a fecha 1/3/2013 y al 
-- padrón. Usar esta vista para mostrar la división entre paro registrado y padrón para 
-- todas las Comunidades autónomas.
CREATE VIEW VParoPadron
as
SELECT ca.CA, p.Provincia, m.Municipio, SUM(pm.TotalParoRegistrado) as paro, SUM(pa.Padron) as padron
FROM ComunidadesAutonomas as ca
	INNER JOIN Provincias as p
	on ca.CodCA = p.CodCA
	INNER JOIN Municipios as m
	on p.CodProvincia = m.CodProvincia
	INNER JOIN Padron as pa
	on m.CodMunicipio = pa.CodMunicipio
	INNER JOIN ParoMes as pm
	on m.CodMunicipio = pm.CodMunicipio
WHERE pm.Fecha = '1/3/2013'
GROUP BY ca.CA, p.Provincia, m.Municipio
GO

select *, paro / padron as divison
from VParoPadron

-- *7.- Dar los nombres de los municipios de la Comunidad autónoma con mayor paro en
-- agricultura (en febrero de 2013).
SELECT m.Municipio as mun, paroA.CA
FROM Municipios as m
	INNER JOIN Provincias as p
	on m.CodProvincia = p.CodProvincia
	INNER JOIN (select top 1 with ties CA, ca.CodCA
				from ComunidadesAutonomas as ca
					inner join Provincias as p
					on ca.CodCA = p.CodCA 
					inner join Municipios as m
					on p.CodProvincia = m.CodProvincia
					inner join ParoMes as pm
					on m.CodMunicipio = pm.CodMunicipio
					where MONTH(pm.Fecha) = 2 and YEAR(pm.Fecha) = 2013
					group by ca.CA, ca.CodCA
					order by SUM(pm.ParoAgricultura) desc) as paroA
	on p.CodCA = paroA.CodCA
GO

SELECT m.Municipio, ca.CA
FROM ComunidadesAutonomas as ca
	INNER JOIN Provincias as p
	on ca.CodCA = p.CodCA
	INNER JOIN Municipios as m
	on p.CodProvincia = m.CodProvincia
WHERE ca.CA = (select top 1 with ties CA
				from ComunidadesAutonomas as ca
					inner join Provincias as p
					on ca.CodCA = p.CodCA 
					inner join Municipios as m
					on p.CodProvincia = m.CodProvincia
					inner join ParoMes as pm
					on m.CodMunicipio = pm.CodMunicipio
					where month(pm.Fecha) = 2 and YEAR(pm.Fecha) = 2013
					group by ca.CA
					order by SUM(pm.ParoAgricultura) desc)
GO
	
-- *8.- Número de municipios con más de 200000 habitantes por Comunidad Autónoma 
-- en el padrón, sacando todas las Comunidades Autónomas
SELECT ca.CA, COUNT(numHab.CodMunicipio)
FROM ComunidadesAutonomas as ca
	LEFT JOIN Provincias as p
	on ca.CodCA = p.CodCA
	LEFT JOIN Municipios as m
	on p.CodProvincia = m.CodProvincia
	LEFT JOIN (select pa.CodMunicipio
				from Municipios as m
				inner join Padron as pa
				on m.CodMunicipio = pa.CodMunicipio
				where pa.Padron > 200000
				group by pa.CodMunicipio) as numHab
	on m.CodMunicipio = numHab.CodMunicipio
GROUP BY ca.CA

-- *9.- Municipios con más parados en Servicios entre los habitantes del padrón en 
-- febrero de 2013 que la media nacional de la misma división
SELECT m.Municipio
FROM Padron as p
	INNER JOIN Municipios as m
	on p.CodMunicipio = m.CodMunicipio
	INNER JOIN ParoMes as pm
	on m.CodMunicipio = pm.CodMunicipio
WHERE pm.ParoServicios / p.Padron > (select AVG(pm.ParoServicios / p.Padron)
									 from  Padron as p
										inner join ParoMes as pm
										on p.CodMunicipio = pm.CodMunicipio
									where MONTH(pm.Fecha) = 2
										) AND MONTH(pm.Fecha) = 2

-- 10.- Indicar para cada Comunidad Autónoma el nº de habitantes por municipio 
-- (padrón dividido entre número de municipios), ordenándolas de menor a mayor
SELECT cm.CA, (SUM(pa.Padron) / COUNT(m.Municipio))
FROM ComunidadesAutonomas as cm
	INNER JOIN Provincias as p
	on cm.CodCA = p.CodCA
	INNER JOIN Municipios as m
	on p.CodProvincia = m.CodProvincia
	INNER JOIN Padron as pa
	on m.CodMunicipio = pa.CodMunicipio
GROUP BY cm.CA
order by (SUM(pa.Padron) / COUNT(m.Municipio)) desc

-- *11.- Diferencia por Comunidad Autónoma entre el nº de parados en marzo de 2013 y 
-- en enero de 2013
SELECT c.CA, c.codCA,
(select SUM(pa.TotalParoRegistrado)
	from ParoMes as pa
	inner join Municipios as m
	on pa.CodMunicipio = m.Municipio
	inner join Provincias as p
	on m.CodProvincia = p.CodProvincia
	where (DATEPART(MONTH, pa.fecha) = 3)
		and (DATEPART(YEAR, pa.fecha) = 2013) and (p.CodCA = c.CodCA)
	group by p.CodCA)
FROM ComunidadesAutonomas AS c

-- *12.- Municipio con más habitantes de cada Comunidad Autónoma.SELECT ca.CA,(select top 1 m.Municipio	from Municipios as m	inner join Padron as p	on m.CodMunicipio = p.CodMunicipio	inner join Provincias as pr	on m.CodProvincia = pr.CodProvincia	where ca.CodCA = pr.CodCA	order by p.Padron desc)from ComunidadesAutonomas as ca