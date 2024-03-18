# Mecanim + Cinemachine workshop
 
## 1. Bereid de animaties voor, voor gebruik met het karakter.
- De animaties zijn nu generiek, zet ze over naar het avatar van het karakter.
- Loop animaties als dit nodig is.

## 2. Maak een basis layer met een idle animatie
- Maak een eerste layer met de Idle animatie.

## 3. Maak een blend tree voor de animaties Idle -> Walking -> Running
- Maak een blend tree in de basis layer voor het blenden tussen Idle -> Walking -> Running.
- Gebruik het script om de animatie op de blend tree over te zetten en om de blend waarde aan te passen.

## 4. Maak een nieuwe layer voor de injured animaties
- Maak een 2de layer aan, zet de checkbox sync aan en vul de states met de injured animaties.
- Maak gebruik van de functie ``ChangeLayers`` om het gewicht van de injured layer te wijzigen.

## 5. Maak een nieuwe layer voor de shooting animatie
- Maak een mask die alleen het bovenlichaam van het karakter gebruikt.
- Pas de mask op de nieuwe layer toe.
- Voeg de shooting animatie toe.
- Ga over op de shooting animatie bij de druk op een knop via het script. 

(TIP: Bij het enter en exit op de layer kan er logica worden toegepast om de shooting animatie van begin tot eind te laten lopen. Zie: ``StateMachineBehaviour``)

## 6. Maak een nieuwe layer voor de looking animatie
- Maak een mask die alleen het hoofd van het karakter gebruikt.
- Pas de mask op de nieuwe layer toe.
- Voeg de looking animatie toe.
- Zet het gewicht op 1.

## 7. Maak animaties voor de kubus
- Maak animatie voor de kubus waarbij deze op en neer beweegt.
- Maak een roteer animatie voor de kubus.

## 8. Gebruik additive layer om de animaties te combineren
- Voeg een basis layer toe voor een van de twee animaties.
- Voeg een additive layer toe voor de overige animatie.

## 9 Zorg dat het karakter naar de kubus kijkt.
- Maak gebruik van LookAt om het karakter naar de kubus te laten kijken wanneer er op een knop wordt gedrukt.
- Dezelfde knop moet de LookAt ook weer uitschakelen.