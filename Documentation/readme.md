# Documentation

## Krav
- [X] Registrera parkering i en databas med Code First (EF)
- [X] Använd EF för queries
- [X] Vi ska kunna ta ut och lägga till data i vår databas (vem som kommer och vem som går)
- [ ] Hantera antal slottar i p-hus (databasen)
- [ ] Betalning / fakturering
- [X] Inläsning från API till 
- [X] response mappas in hos oss
- [x] vi ska kotrollera om kändisen varit med i SW
- [x] Om ja, får hen parkera om de åker ett fräckt starship
- [ ] TESTA UNDER TIDEN _INTE_ EFTER
- [ ] Skapa en *runklass* som håller uppbyggnaden av appen

### Ordning
### Databas
- [x] Rita upp nån sorts ritning över databasen
- [x] bygg databasen
- [x] ta ut och lägga in data
- [ ] constraints på tillgänglighet
- [X] kontrollera / manipulera data

Att tänka på:

Personen skall ej läggas till om i databasen om den inte är valid.
Måste kolla om en person redan är i Databasen, då kan dom inte läggas till fören dom lämnat
När dom lämnar parkeringen skall dom helt och hållet tas bort ifrån databasen, vill dom parkera igen skall dom läggas in i databasen på nytt. 

Att dom är med i APIt(är kända), har fordon och att det finns en plats ledig, då läggs dom in i databasen.



När man startar ska men kolla antal ledig platser och skriva om det finns och i så fall antal, samt om det inte finns



### API
- [x] Anropa
   Först person ==> Fordon ==> kolla ledig parkering ==> lägg in i databasen
- [ ] Jämföra 
Krav: Vi måste skicka request för varje ny besökare och det skall göras async

### UX
1. Layout i grova drag
2. Bestäm hur vi ska presentera (med vad och i vilken form)
3. Om en person kommer ska man kunna klicka på skeppet man skall parkera



