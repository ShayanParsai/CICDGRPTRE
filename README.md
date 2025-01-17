Dokumentation - Grupp 3

**Lokalt körande och testning**
- Installera .NET SDK (version 9.0 eller högre).
- Klona repot från GitHub: git clone https://github.com/<ditt-repo>/CICDGRPTRE.git
- Navigera till projektmappen: cd CICDGRPTRE/personnummer
- Bygg applikationen: dotnet build
- Kör applikationen: dotnet run

**Köra applikationen med Docker**
- Dra ner Docker-imagen från Docker Hub : docker pull chalamdor/personnummer:latest
- Starta containern: docker run -it chalamdor/personnummer:latest

**Svenska regler för personnummer**
Ett svenskt personnummer består av 10 siffror:
ÅÅMMDD-XXXX (där ÅÅ är år, MM är månad, och DD är dag).
Bindestrecket är valfritt men krävs om formatet innehåller 12 siffror (ex. YYYYMMDD-XXXX).
De fyra sista siffrorna är unika för varje individ.
Valideringen i applikationen kontrollerar att:
Personnumret har korrekt längd (10 eller 12 siffror).
Alla tecken är numeriska.

Standardvärdet (1234567890) används om inget personnummer anges.
