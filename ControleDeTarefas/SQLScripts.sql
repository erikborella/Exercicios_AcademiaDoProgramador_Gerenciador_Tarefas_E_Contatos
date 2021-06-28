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

INSERT INTO [TBCompromisso]
	(
		[assunto],
		[local],
		[data],
		[horaInicial],
		[horaFinal],
		[contato_id]
	)
	VALUES
	(
			'123',
			'231231',
			'12/12/12',
			'11:30',
			'12:30',
			1
	);


UPDATE [TBCompromisso]
SET
	[assunto] = @assunto,
	[local] = @local,
	[data] = @data,
	[horaInicial] = @horaInicial,
	[horaFinal] = @horaFinal,
	[contato_id] = @contato_id
WHERE
	[Id] = @id;

DELETE FROM [TBCompromisso]
	WHERE [Id] = @id;

SELECT 
	CPS.*,

	CTT.nome AS contato_nome,
	CTT.telefone AS contato_telefone
FROM 
	[TBCompromisso] CPS LEFT JOIN
	[TBContato] CTT
ON
	CPS.contato_id = CTT.Id
WHERE
	CPS.Id = 4;