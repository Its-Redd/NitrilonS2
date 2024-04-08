# KRAVSPECIFIKATION NITRILON
Kravspecifikationen opdeles i subsystems:

Subsystem 01: Event Rating
Subsystem 02: Medlemsh�ndtering
Subsystem 03: Rollespilsgrupper

## Subsystem 01: Event Rating
Akt�rer:
* System: Den tablet og webpage som g�sten interagerer med. 
* G�st: En person til Nitricon event.
* Eventansvarlig: den der skal have vist oversigterne over g�sternes bed�mmelse.

01: En g�st skal kunne bed�mme oplevelsen af et event, med valg af �n v�rdi p� en skala med tre niveauer.

02: G�sten skal have feedback efter indtastningen af bed�mmelsen.

03: Systemet skal automatisk klarg�re til n�ste indtastning, efter en indtastning.

04: Den eventansvarlige skal kunne v�lge et event for at f� vist antallet af bed�mmelser i hver bed�mmelsesniveau.

# IKKE-FUNKTIONELLE KRAV
Systemet skal overholde f�lgende ikke-funktionelle krav:
1. Databasen skal hostes p� en Microsoft SQL Express Server 2019 p� din lokale maskine.
2. Backend skal udvikles i C# med Visual Studio 2022.
3. Backend skal v�re en ASP.NET Core application med .NET 8 som runtime.
4. Backend skal hostes p� en IIS Express p� din lokale maskine til udvikling.
5. Backend skal til produktion kunne deployes p� en Windows Server 2019 maskine p� en IIS med .NET 8 som runtime.
6. Alle frontends skal udvikles i HTML5, CSS3 og javascript eller tilsvarende.
7a. Frontend til Event Rating skal designes til og kunne afvikles i en browser p� en iOS tablet.
7b. Frontend til Event Rating skal designes til og kunne afvikles i en browser p� en Android tablet.
8a. Frontend til medlemsh�ndtering skal designes til og kunne afvikles i Chrome desktop browser p� Windows 10.
8b. Frontend til medlemsh�ndtering skal designes til og kunne afvikles i Edge desktop browser p� Windows 10.
8c. Frontend til medlemsh�ndtering skal designes til og kunne afvikles i Firefox desktop browser p� Windows 10.
9a. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Chrome desktop browser p� Windows 10.
9b. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Edge desktop browser p� Windows 10.
9c. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Firefox desktop browser p� Windows 10.
9d. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Safari mobil browser p� iOS.
9e. Frontend til rollespilsgrupper skal designes til og kunne afvikles i Chrome mobil browser p� Android.
10a. Kommunikation mellem klient og server skal anvende HTTP eller HTTPS som protokol.
10b. Kommunikation mellem klient og server skal anvende JSON som dataformat.

NOTE: Der skal ikke tages hensyn til sikkerhed, GDPR, kryptering mv., da det ligger uden for fagets m�l.