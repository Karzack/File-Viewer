# Uppstart
För att starta programmet: öppna Startup-genvägen i main-mappen

# Kort introduktion till programmet
När programmet öppnas möts man av ett fönster som är uppdelat i två sektioner. Till vänster finner vi trädet som visualiserar den hierarkiska strukturen. Till höger har vi kontrollen för att lägga till, ändra eller ta bort noder i trädet. I nuläget finns det bara en nod, Root, som är trädets utgångspunkt. Denna noden kan inte tas bort, men om man inte gillar namnet "Root" så kan man enkelt ändra namnet genom att skriva ett nytt namn i textboxen "Selected Item Title". Namnändring är tillgänglig på samtliga noder i trädet på detta viset baserat på vilken nod som är markerad. När en ny nod är skapad kommer det en liten pil i trädet som markerar att denna noden har barn. När man trycker på denna pil expanderar noden och visar sina barn som nya noder. Expanderingen sker inte automatiskt, tyvärr.

I kontrolldelen finns det även 3 stycken knappar:
* Lägg till
* Ta bort
* Demo träd

Lägg till-knappen öppnar en ny del i programmet där man kan lägga till en ny nod. Allt som krävs är att noden har en titel så skapas den som ett barn till den markerade noden. Om ingen nod är markerad skapas den från Root-noden istället.

Ta bort-knappen raderar den markerade noden i trädet och alla dess barn. Root-noden kan inte tas bort och informerar användaren att hen försöker ta bort roten ifall detta scenario skulle hända.

Demo träd-knappen skapar samtliga noder enligt den givna strängen i instruktionerna. Efter dessa noder är tillagda i trädet plockas denna knappen bort för att inte riskera dubletter bland noderna.

# Milstolpar i uppgiften
Jag känner mig ganska bekväm med att uppnå två av de angivna milstolparna, vilket är öppna/stäng mapparna samt lägg till/ändra/ta bort. Byte mellan visualiseringar känner jag att det inte fungerar speciellt bra med den strukturen jag har använt mig av och Unit-tester är inte något jag är speciellt kunnig i (ÄNNU, det ligger på min planerade inlärningslista).

# Externa verktyg
Dessa externa verktygen har jag använt:
* Autofac: underlätta sammankopplingen mellan delarna i MVVM-modellen samt vid uppstarten
* Newtonsoft.Json: används för läsning av JSON objekt.
