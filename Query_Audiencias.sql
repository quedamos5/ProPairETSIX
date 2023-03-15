-- 1.- Cadena con mayor audiencia (en la tabla Audiencia) el 15/5/2013 en el Periodo 'Noche1 (20.30 a 
-- 24.00)'
SELECT c.Cadena, SUM(a.Valor)
FROM Periodo as p
	INNER JOIN Audiencia as a
	on p.Id = a.idPeriodo
	INNER JOIN Cadena as c
	on a.IdCadena = c.idCadena
WHERE a.Fecha = '15/5/2013' AND p.Periodo = 'Noche1 (20.30 a 24.00)'
GROUP BY c.Cadena
ORDER BY SUM(a.Valor) DESC
GO

-- 2.- Programa de TELECINCO con más espectadores los jueves (en audienciaprograma)
SELECT c.Cadena, p.Programa 
FROM Cadena as c
	INNER JOIN AudienciaPrograma as ap
	on c.idCadena = ap.IdCadena
	INNER JOIN Programa as p
	on ap.IdPrograma = p.IdPrograma
WHERE c.Cadena = 'TELECINCO' AND DATEPART(DW, ap.FechaHora) = 4
GROUP BY c.Cadena, p.Programa, ap.FechaHora 
ORDER BY SUM(ap.Espectadores) desc

-- (*) 3.- ¿Cuántos programas tiene telecinco entre los cinco primeros del día 8/5/2013 teniendo en 
-- cuenta el share (en audienciaprograma)?
SELECT COUNT(*) as nProgramas
FROM Cadena as c
	INNER JOIN (select top 5 c.idCadena
				from Programa as p
				inner join AudienciaPrograma as ap
				on p.IdPrograma = ap.IdPrograma
				inner join Cadena as c
				on ap.IdCadena = c.idCadena
				where DAY(ap.FechaHora) = '8'
				order by ap.Share desc)
				as subcon
				on c.idCadena = subcon.idCadena
WHERE c.Cadena = 'TELECINCO'
GO

-- 4.- ¿Qué día de la semana tiene más espectadores considerando los datos de AudienciaPrograma?
SELECT DATENAME(DW, FechaHora)
FROM AudienciaPrograma
GROUP BY DATENAME(DW, FechaHora)
ORDER BY SUM(Espectadores) desc
-- 5.- Cinco programas con media más alta de espectadores (en audienciaprograma)que aparezcan dos o
-- más veces.
SELECT TOP 5 p.Programa
FROM AudienciaPrograma as ap
	INNER JOIN Programa as p
	on ap.IdPrograma = p.IdPrograma
GROUP BY p.Programa
HAVING COUNT(p.Programa) >= 2
ORDER BY AVG(ap.Espectadores) DESC
GO

-- (*) 6.- Cuál fue la audiencia (en la tabla audiencia) en el periodo que comienza por Noche2 de la 
-- cadena con el programa más visto en número de espectadores (de la tabla audienciaPrograma) el día 
-- 9/5/2013.
SELECT TOP 1 a.Valor
FROM Periodo as p
	INNER JOIN Audiencia as a
	on p.Id = a.idPeriodo
	INNER JOIN (select top 1 c.idCadena, c.Cadena, ap.Espectadores
				from Programa as p
				inner join AudienciaPrograma as ap
				on p.IdPrograma = ap.IdPrograma
				inner join Cadena as c
				on ap.IdCadena = c.idCadena
			where DAY(ap.FechaHora) = '9'
			order by ap.Espectadores desc) as subcon
			on a.IdCadena = subcon.idCadena
WHERE p.Periodo LIKE '%NOCHE2%' AND a.Fecha = '9/5/2013'
ORDER BY a.Valor desc

select top 1 c.Cadena, ap.Espectadores
from Programa as p
	inner join AudienciaPrograma as ap
	on p.IdPrograma = ap.IdPrograma
	inner join Cadena as c
	on ap.IdCadena = c.idCadena
where DAY(ap.FechaHora) = '9'
order by ap.Espectadores desc
-- 7.- Total de espectadores acumulados según la tabla audienciaprograma de cada Operador, dando 
-- todos los operadores e incluyendo titularidad.
SELECT SUM(ap.Espectadores) as espAcum, o.Operador, t.Titularidad
FROM AudienciaPrograma as ap
	RIGHT JOIN Cadena as c
	on ap.IdCadena = c.idCadena
	RIGHT JOIN Operador as o
	on c.idOperador = o.id
	RIGHT JOIN Titularidad as t
	on o.IdTitularidad = t.id
GROUP BY o.Operador, t.Titularidad
GO

-- (*) 8.- ¿En qué periodo, cadena y fecha está el valor máximo de audiencia (tabla audiencia), de una 
-- cadena que tenga al menos tres programas en audienciaprograma en el mismo día.
SELECT top 1 p.Periodo, c.Cadena, a.Fecha, a.Valor
FROM Periodo as p
	INNER JOIN Audiencia as a
	on p.Id = a.idPeriodo
	INNER JOIN Cadena as c
	on a.IdCadena = c.idCadena
WHERE  c.Cadena in (select distinct c.Cadena
	   from Cadena as c
	   inner join AudienciaPrograma as ap
	   on c.idCadena = ap.IdCadena
	   inner join Programa as p
	   on ap.IdPrograma = p.IdPrograma
	   group by c.Cadena, DAY(ap.FechaHora)
	   )
GROUP BY p.Periodo, c.Cadena, a.Fecha, a.Valor
ORDER BY MAX(a.Valor) desc

-- 9.- ¿En qué hora (sin minutos) hay mayor media de espectadores según audienciaprograma?
SELECT AVG(Espectadores), DATEPART(HOUR, FechaHora)
FROM AudienciaPrograma
GROUP BY DATEPART(HOUR, FechaHora)
ORDER BY AVG(Espectadores)
GO

-- (*) 10.- Para cada fecha indicar qué Empresa es la nº uno de audiencia en el periodo 'Total día' (tabla 
--  audiencia).
SELECT DISTINCT Fecha, (select top 1 o.Operador
	from Operador as o
	INNER JOIN  Cadena as c
	on o.Id = c.idOperador
	INNER JOIN Audiencia as a
	on c.idCadena = a.IdCadena
	INNER JOIN Periodo as p
	on p.Id = a.idPeriodo
	where p.Periodo = 'Total día' and a2.Fecha = a.Fecha
	order by Valor desc)
FROM Audiencia as a2
-- 11.- ¿Cuántos programas diferentes tiene cada empresa, dándolas todas, en AudienciaPrograma?
SELECT o.Operador, COUNT (DISTINCT p.Programa)
FROM Programa as p
	INNER JOIN 
	AudienciaPrograma as ap
	ON p.IdPrograma = ap.IdPrograma
	RIGHT JOIN Cadena as c
	on ap.IdCadena = c.idCadena
	RIGHT JOIN Operador as o
	on c.idOperador = o.id
GROUP BY o.Operador
GO

-- 12.- Para qué día del mes hay más de 4 cadenas distintas en audienciaprograma 
SELECT DATEPART(DAY, FechaHora)
FROM AudienciaPrograma as ap
	INNER JOIN Cadena as c
	on ap.IdCadena = c.idCadena
GROUP BY DATEPART(DAY, FechaHora)
HAVING COUNT(c.Cadena) > 4
GO