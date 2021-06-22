SELECT * FROM TBTarefa

INSERT INTO [TBTarefa] 
	(
		[titulo],
		[dataCriacao],
		[percentualConcluido],
		[prioridade]
	)
	VALUES 
	(
		'Tarefa 1',
		'06/18/2021',
		0,
		3
	)

UPDATE TBTarefa
	SET
		[dataConclusao] = '06/20/2021',
		[percentualConcluido] = 100
	WHERE
		[Id] = 7

DELETE FROM [TBTarefa]
	