Aplikacija se otvori u okolini Microsoft Visual Studio.

U datoteci appsettings.Development u mapi AbySalto.Junior je potrebno u varijabli DefaultConnection unutar ConnectionStrings 
staviti poveznicu na bazu podataka u kojoj će se spremati podaci i dohvaćati podaci iz te iste baze podataka.

U okolini Microsoft Visual Studio se zatim pokrenu naredbe add-migration za dodavanje migracije
i update-database za ažuriranje baze podataka.

Nakon toga se aplikacija pokrene unutar okoline Microsoft Visual Studio.
