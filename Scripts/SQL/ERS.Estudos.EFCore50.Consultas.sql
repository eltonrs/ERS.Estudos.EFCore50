SELECT * FROM Pessoa;

SELECT * FROM Pessoa ORDER BY Nome;

-- Consulta do EF Core para trazer paginado:

exec sp_executesql N'SELECT [p].[Id], [p].[DataNascimento], [p].[Nome]
FROM [Pessoa] AS [p]
ORDER BY [p].[Nome]
OFFSET @__p_0 ROWS FETCH NEXT @__p_1 ROWS ONLY',N'@__p_0 int,@__p_1 int',@__p_0=6,@__p_1=3