Aplikacija se otvori u okolini Microsoft Visual Studio.

U datoteci appsettings.Development u mapi AbySalto.Junior je potrebno u varijabli DefaultConnection unutar ConnectionStrings 
staviti poveznicu na bazu podataka u kojoj će se spremati podaci i dohvaćati podaci iz te iste baze podataka.

U okolini Microsoft Visual Studio se zatim pokrenu naredbe add-migration za dodavanje migracije
i update-database za ažuriranje baze podataka.

Nakon toga se aplikacija pokrene unutar okoline Microsoft Visual Studio i u web pregledniku se otvori stranica https://localhost:7056.

Drugi način za pokrenuti aplikaciju je da se u naredbenom retku pozicioniramo u mapi AbySalto.Junior.
Nakon toga pokrenemo naredbu dotnet run i u web pregledniku otvorimo stranicu http://localhost:5074.
Prije pokretanja aplikacije, u naredbenom retku je također prvo potrebno dodati migracije i ažurirati bazu podataka.
