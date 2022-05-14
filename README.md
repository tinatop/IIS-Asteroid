# IIS-Asteroid 
SPECIFIKACIJA PROJEKTA 

1. REST API sučelje koje uključuje servis koji će se pozivati POST metodom i slati XML datoteku za spremanje novog entiteta u sustavu 
   koja će se validirati korištenjem XSD datoteke. 
2. REST API sučelje koje uključuje servis koji će se pozivati POST metodom i slati XML datoteku za spremanje novog entiteta u sustavu 
   koja će se validirati korištenjem RNG datoteke.
3. SOAP sučelje koje uključuje servis koji prima termin po kojem će se pretraživati entitet, a na „backendu“ će generirati XML datoteku 
   koje sadrži informacije o svim entitetima, nakon čega će se ta generirana datoteka pretraživati korištenjem XPath izraza i vratiti rezultate. 
4. Generiranu datoteku iz prethodnog koraka korištenjem JAXB-a provjeriti je li u skladu sa zadanom XSD datotekom.
5. Kreirati XML-RPC poslužiteljsku aplikaciju koja će korištenjem DHMZ (https://vrijeme.hr/hrvatska_n.xml) omogućiti dohvat trenutne temperature 
   prema zadanom nazivu grada. 
6. Pronaći proizvoljan javni REST API i integrirati se s njime korištenjem sigurnosnih ključeva ili implementirati vlastiti REST API koji će 
   implementirati sigurnosne aspekte korištenjem JWT tokena.
7. Napisati klijentsku desktop ili web aplikaciju (Java ili C#) koja će korisnicima omogućavati pozivanje usluga iz prvih šest koraka. 
