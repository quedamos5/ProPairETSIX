use Discos
go

-- 1.- Cuáles son los dos clientes con más puntuaciones efectuadas (sacándolos todos).
select top 2 with ties Nombre, count(*) as numpunt
from Cliente as c 
	inner join Puntuacion as p
	on c.id = p.Idcliente
group by Nombre
order by numpunt desc
go

-- 2.- Media de la puntuación de discos de los intérpretes que 
-- comiencen con A y efectuada en sábado
select i.Interprete, avg(Puntuacion)
from Disco as d
	inner join Puntuacion as p
	on d.IdDisco = p.iddisco
	inner join Interprete as i
	on d.IdInterprete = i.IdInterprete
where i.Interprete like 'A%' and DatePart(dw, p.Fecha) = 6
group by i.Interprete
go

-- 3.- Clientes (dando su nombre) nacidos antes de 1975 que hayan 
-- puntuado a los tipos que contengan 'rock'
select distinct c.Nombre, c.FechaNacimiento
from Cliente as c inner join
	Puntuacion as p on c.id = p.Idcliente
	inner join Disco as d 
	on p.iddisco = d.IdDisco
	inner join DiscoTipo as dt
	on d.IdDisco = dt.IdDisco
	inner join Tipo as t 
	on dt.IdTipo = t.IdTipo
where Year(c.FechaNacimiento) < 1975 and t.tipo like '%rock%'
go

-- 4.- Disco (dando su título) con mayor media de puntuacion que haya sido
-- votado dos o más veces
select top 1 with ties d.Titulo, avg(p.Puntuacion), count(p.Puntuacion)
from Disco as d
	inner join Puntuacion as p
	on d.IdDisco = p.iddisco
group by d.Titulo
having count(p.Puntuacion) >= 2
order by avg(p.Puntuacion) desc
go

-- 5.- Intérprete que más veces haya sido puntuado
select i.Interprete, count(p.Puntuacion)
from Interprete as i
	inner join Disco as d
	on i.IdInterprete = d.IdInterprete
	inner join Puntuacion as p
	on d.IdDisco = p.iddisco
group by i.Interprete
order by count(p.Puntuacion) desc
go

-- 6.- Dos intérpretes con más discos
select top 2 with ties i.Interprete, count(d.Titulo)
from Interprete as i
	inner join Disco as d
	on i.IdInterprete = d.IdInterprete
group by i.Interprete
order by count(d.Titulo) desc
go

-- 7 títulos de los discos que hayan recibido
-- alguna puntuación y el nombre del intérprete
select d.Titulo, i.Interprete
from Interprete as i
	inner join Disco as d
	on i.IdInterprete = d.IdInterprete
	inner join Puntuacion as p
	on d.IdDisco = p.iddisco
where p.Puntuacion > 0
group by d.Titulo, i.Interprete
order by d.Titulo desc
go

-- Segunda Parte.
-- 1.- Cuál es el disco (dando el título) que tiene más tipos
select top 1 with ties d.Titulo, count(t.tipo)
from Disco as d 
	inner join DiscoTipo as dt
	on d.IdDisco = dt.IdDisco
	inner join Tipo as t
	on dt.IdTipo = t.IdTipo
group by Titulo
order by count(t.tipo) desc

-- 2.- Media de la puntuación de discos de los interpretes que 
-- contengan 'Jackson'
select i.Interprete, AVG(Puntuacion)
from Puntuacion as p
	inner join Disco as d
	on p.iddisco = d.IdDisco
	inner join Interprete as i
	on d.IdInterprete = i.IdInterprete
group by Interprete
having i.Interprete like '%Jackson%'
go

-- 3.- Clientes (dando su nombre) nacidos antes de 1975 que hayan 
-- puntuado a los tipos que contengan 'rock'
select c.Nombre, YEAR(c.FechaNacimiento)
from Cliente as c 
	inner join Puntuacion as p
	on c.id = p.Idcliente
	inner join Disco as d
	on p.iddisco = d.IdDisco
	inner join DiscoTipo as dt
	on d.IdDisco = dt.IdDisco
	inner join Tipo as t
	on dt.IdTipo = t.IdTipo
where Puntuacion > 0 and t.tipo like '%rock%' and YEAR(c.FechaNacimiento) < 1975
go

-- 4.- Disco (dando su título) con mayor media de puntuacion que haya 
-- sido votado dos o más veces
select top 1 with ties d.Titulo, avg(p.Puntuacion), count(p.Puntuacion)
from Disco as d
	inner join Puntuacion as p
	on d.IdDisco = p.iddisco
group by d.Titulo
having count(p.Puntuacion) >= 2
order by avg(p.Puntuacion) desc
go

-- 5.- Número de votos realizados por cada cliente (dando su nombre) 
-- incluyéndolos todos los clientes. Ordenar por el nº de votos de
-- mayor a menor
select c.Nombre, COUNT(Puntuacion)
from Cliente as c
	inner join Puntuacion as p
	on c.id = p.Idcliente
group by c.Nombre
order by COUNT(Puntuacion) desc
go

-- 6.- Tipo (dando su denominación) con más discos
select t.tipo, COUNT(d.Titulo)
from Disco as d
	inner join DiscoTipo as dt
	on d.IdDisco = dt.IdDisco
	inner join Tipo as t
	on dt.IdTipo = t.IdTipo
group by t.tipo
order by COUNT(d.Titulo) desc
go

-- 7.- Cuántos discos tiene cada intérprete (por su nombre) dando 
-- todos los intérpretes, ordenado por nº de discos de mayor a menor
select i.Interprete, COUNT(d.Titulo)
from Disco as d
	inner join Interprete as i
	on d.IdInterprete = i.IdInterprete
group by i.Interprete
order by COUNT(d.Titulo) desc
go

-- 1.- Cuáles son los dos clientes con más puntuaciones efectuadas (sacándolos todos).
SELECT TOP 2 WITH TIES c.Nombre, COUNT(p.Puntuacion) 
FROM Cliente AS c
	inner join Puntuacion AS p
	ON c.id = p.Idcliente
GROUP BY c.Nombre
ORDER BY COUNT(p.Puntuacion) DESC 

-- 2.- Media de la puntuación de discos de los intérpretes que 
-- comiencen con A y efectuada en sábado
SELECT  i.Interprete, AVG(p.Puntuacion) AS NumPuntuacion, DATENAME(DW,p.Fecha)
FROM Puntuacion AS p
	INNER JOIN Disco AS d
	ON p.iddisco = d.IdDisco
	INNER JOIN Interprete AS i
	ON d.IdInterprete = i.IdInterprete
GROUP BY i.Interprete, p.Fecha
HAVING DATEPART(DW,p.Fecha) = 6 AND i.Interprete LIKE 'A%'

-- 3.- Clientes (dando su nombre) nacidos antes de 1975 que hayan 
-- puntuado a los tipos que contengan 'rock'
SELECT c.Nombre, YEAR(c.FechaNacimiento),T.Tipo
FROM Cliente AS c
	INNER JOIN Puntuacion AS P
	ON c.id = P.Idcliente
	INNER JOIN Disco AS D
	ON P.iddisco = D.IdDisco
	INNER JOIN DiscoTipo AS DT
	ON D.IdDisco = DT.IdDisco
	INNER JOIN Tipo AS T 
	ON DT.IdTipo = T.IdTipo
GROUP BY 

