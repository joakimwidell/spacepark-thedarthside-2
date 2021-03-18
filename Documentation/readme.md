# Documentation

## Krav
* Registrera parkering i en databas med Code First (EF)
* Använd EF för queries
* Vi ska kunna ta ut och lägga till data i vår databas (vem som kommer och vem som går)
* Hantera antal slottar i p-hus (databasen)
* Betalning / fakturering
* Inläsning från API till 
* response mappas in hos oss
* vi ska kotrollera om kändisen varit med i SW
* Om ja, får hen parkera om de åker ett fräckt starship
* TESTA UNDER TIDEN _INTE_ EFTER

### Ordning
### Databas
1. Rita upp nån sorts ritning över databasen
2. bygg databasen
3. ta ut och lägga in data
4. constraints på tillgänglighet
5. kontrollera / manipulera data

Att tänka på:

Personen skall ej läggas till om i databasen om den inte är valid.
Måste kolla om en person redan är i Databasen, då kan dom inte läggas till fören dom lämnat
När dom lämnar parkeringen skall dom helt och hållet tas bort ifrån databasen, vill dom parkera igen skall dom läggas in i databasen på nytt. 

Att dom är med i APIt(är kända), har fordon och att det finns en plats ledig, då läggs dom in i databasen.



### API
1. Anropa
   Först person ==> Fordon ==> kolla ledig parkering ==> lägg in i databasen
2. Jämföra 
Krav: Vi måste skicka request för varje ny besökare och det skall göras async

### UX
1. Layout i grova drag
2. Bestäm hur vi ska presentera (med vad och i vilken form)
3. Om en person kommer ska man kunna klicka på skeppet man skall parkera



