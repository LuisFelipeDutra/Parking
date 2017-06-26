SELECT COUNT(VagaID)
FROM Vagas
WHERE Ocupada = 'false';

var disponiveis = (from Vagas in contexto.Vagas
where Vagas.Ocupada == 'false'
select VagaID).Count();var disponiveis = from v in contexto.Vagas
where v.Ocupada == 'false'
select v.Count(); 

var disponiveis = from v in contexto.Vagas
where v.Ocupada == 'false'
select VagaID.Count(); 

