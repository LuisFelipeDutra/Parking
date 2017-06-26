SELECT COUNT(VagaID)
FROM Vagas
WHERE Ocupada = 'false';

var disponiveis = (from Vagas in contexto.Vagas
where Vagas.Ocupada == 'false'
select VagaID).Count();


var disponiveis = from v in db.Vagas
where v.Ocupada == 'false'
select v.Count(); 

var disponiveis = from v in contexto.Vagas
where v.Ocupada == 'false'
select VagaID.Count(); 

Select Count(VagaID)
From Vagas
Where Ocupada = 'False';

var data = (from vagas in db.Vagas
                       where vagas.Ocupada == false
                       select vagas).Count();

