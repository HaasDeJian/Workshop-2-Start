# Mecanim + Cinemachine workshop
 
## 1. Bereid de animaties voor, voor gebruik met het karakter.
### 1.1 Idle animatie.
- Open de ``Animations`` map in de assets folder van unity.
- Selecteer de ``Idle animation`` en navigeer naar de ``Rig`` tab.
- De animatie is nu generiek, zet dit over naar ``Humanoid`` met behulp van de eerste dropdown ``Animation Type``.
- Druk op ``Apply``.

### 1.2 Overige animaties.
- Open de volgende animatie in de ``Animations`` map.
- Navigeer naar de ``Rig`` tab.
- Selecteer de ``Animation Type`` ``Humanoid``.
- De animatie zal nu opnieuw een eigen karakter definitie maken, maar we willen dat het de karakter definitie overneemt van onze ``Idle`` animatie.
- Selecteer in de dropdown ``Avatar Definition`` de ``Copy From Other Avatar`` optie.
- In de ``source`` die verschenen is, selecteer de ``Avatar`` van de ``Idle`` animatie
- Doe dit voor alle andere animaties in de ``Animations`` map, maar selecteer de ``Loop Time`` en ``Loop pose`` checkbox in de ``Animation`` tab voor de animaties die dit nodig hebben. Deze tab is te vinden naast de ``Rig`` tab.

## 2. Opknippen van een animatie
- Selecteer de ``Idle animation`` en navigeer naar de ``Animation`` tab.
- In de 'Animation' tab is er een ``Clip`` sectie.
- Selecteer het ``+`` icon om een nieuwe animatie clip toe te voegen.
- Onder de sectie waar de naam van de animatie zichtbaar is, is er een ``Timeline``.
- Pas de ``Start`` en ``End`` van de nieuwe animatie clip aan door de ``pointers`` of ``waarde`` onder de timeline te veranderen.

## 3. Maak een basis layer met een idle animatie
- Voor het maken van een basis layer, hebben we een ``Animation Controller`` nodig. Voeg deze toe via ``Assets -> Create -> Animator Controller``.
- Sleep de nieuwe ``Animator Controller`` op de ``Y Bot@Idle`` in de ``Hierarchy``.
- Open de ``Animator contoller`` met een dubbel klik.
- Open de ``Animations`` map in de assets folder van unity.
- Sleep de ``Idle`` animation in de ``Animator Base Layer``.

## 4. Maak een blend tree voor de animaties Idle -> Walking -> Running
### 4.1 Blend tree
- In de ``Animator``, navigeer naar de ``Parameters`` tab (linksboven).
- Voeg een nieuwe ``float`` parameter toe met het ``+`` icon en noem deze ``Velocity``.
- In de base layer druk ``Rechter muisknop`` voor een pop-up om nieuwe states toe te voegen.
- Voeg nu een blend tree toe met ``Create state -> From New Blend Tree``.
- Dubbelklik op de blend tree om deze te openen.
- In de blend tree kunnen meerdere animatie clips toegevoegd worden om een smooth transition te krijgen tussen de animaties.
- Voeg 3 nieuwe animaties toe aan de blend tree. Dit kan met ``Rechter muis knop -> Add Motion`` op de blend tree.
- In de ``Inspector`` van de blend tree kunnen de animaties toegevoegd worden. Selecteer het icoon aan de rechter kant van het ``Motion`` veld.
- Voeg de animaties in de volgende volgorde toe, ``Idle -> Walking -> Running``.

### 4.2 Script
- Om aan de blend tree aan te geven wanneer hij de volgende animatie moet afspelen gaan we de ``Velocity`` parameter aanpassen via een C# script.
- Open de ``Scipts`` map in de assets folder van unity.
- Open de ``AnimationControllerScipt``
- Om de parameter in de ``Animator`` te veranderen hebben we een instantie nodig van de ``Animator`` component zelf.
- Voeg een private variable toe aan het script voor een instantie van de ``Animator`` component.
- In de start methode koppel je de instantie van de ``Animator`` component van je karakater met de private variable. Doe dit met ``GetComponent<>();`` 
- Maak een nieuwe methode genaamd ``ExecuteBlendTree()`` die door de ``Update`` van unity uitgevoerd word.
- Voeg in deze methode de functionaliteit toe om door middel van een ``keypress`` de velocity lagzamerhand te verhogen.

 Tips
 - Maak gebruik van een private velocity field om de waarde te veranderen voordat je deze in de blend tree wijzigt.
 - Gebruik het ingebouwde input systeem van unity
 - Gebruik de bestaande variabelen in het script.
 - Zorg ervoor dat de velocity nooit hoger dan 1 is en lager dan 0
 - Zet aan het einde van je methode de ``Veloctiy`` parameter in de blend tree met ``SetFloat`` van de ``Animator`` component

## 5. Maak een nieuwe layer voor de injured animaties
### 5.1 Animator
- Voeg aan de Animator controller een nieuwe layer toe. Dit kan met het ``+`` icon.
- Geef de laag een toepasbare naam zoals ``Injured layer``
- Selecteer de ``gear`` icon van de nieuwe laag en check de ``sync`` checkbox.
- Open de blend tree in de nieuwe laag en verander de animatie clips naar de ``Injured`` versies.

### 5.2 Script
-- In het ``AnimationControllerScript`` is er een functie genaamd ``ChangeLayers`` breid deze uit om op basis van de karakter health de ``Weight`` van de ``Injured`` layer te wijzigen.

Tips:
- Maak gebruik van private parameters voor het opslaan van de ``LayerIndex``. Dit kan uitgelezen worden met de ``GetLayerIndex()`` functie van de ``Animator``.
- Zet de nieuwe layer weight met de methode ``SetLayerWeight``.
- Voor een smooth transitie tussen het gewicht van de ``Injured`` layer kan je ``Matf.SmoothDamp()`` gebruiken.

## 6. Maak een nieuwe layer voor de looking animatie
### 6.1 Aanmaken Avatar Mask
- Voor de looking animatie willen we alleen dat een deel van het karater beweegt.
- Maak een nieuwe ``Avatar Mask`` aan die alleen het hoofd van het karkter heeft. Dit kan in de map ``LayerMask -> Rechter muisklik -> Create -> Avatar Mask``
- Geef de mask een goede naam en open de mask.
- In de mask zijn er twee dropdowns, voor nu kijken we alleen naar de dropdown ``Humanoid``. Klap deze open.
-  Zorg ervoor, door te klikken op de mask, dat alleen het hoofd groen is. 

### 6.2 Aanmaken layer
- Voeg aan de Animator controller een nieuwe layer toe. Dit kan met het ``+`` icon.
- Geef de laag een toepasbare naam zoals ``Looking layer``
- Selecteer de ``gear`` icon van de nieuwe laag en zet de ``Mask`` property op de reeds gecreeërde ``Avatar Mask``
- Zet de layer weight op 1 met behulp van de ``slider`` of door het wijzigen van de ``waarde``. 
- Sleep de ``Looking Behind`` animatie in de nieuwe layer.

## 7. Shooting layer
### 7.1 Animator
- Voeg aan de Animator controller een nieuwe layer toe. Dit kan met het ``+`` icon.
- Geef de laag een toepasbare naam zoals ``Aiming layer``
- Creeër een nieuwe ``Avatar Mask`` voor alleen het bovenlichaam van het karakter en voeg deze toe aan de nieuwe laag.
- Voeg een nieuwe parameter ``IsShooting`` toe aan de Animator. ``Animator tab -> Paramaters -> + icon``
- Voeg aan de ``Aiming layer`` de animaties ``Idle`` en ``Shooting Arrow`` toe.
- Maak een transitie van ``Idle`` naar ``Shooting Arrow`` en van ``Shooting Arrow`` naar ``Idle``. Dit kan met rechtermuislik op een van de animaties.

#### 7.1.1 Transities shooting arrow -> idle
- klik op de pijl die van de ``Shooting Arrow`` naar de ``Idle`` animatie gaat.
- Selecteer de checkbox ``Has Exit time``
- Voeg een nieuwe conditie toe met het ``+`` icon en selecteer de ``IsShooting`` parameter.
- Zorg ervoor dat de conditie ``IsShooting -> false`` is.

#### 7.1.1 Transities idle -> shooting arrow
- herhaal dezelfde stappen maar dan voor de pijl die de andere richting op wijst.
- Laat de ``Has Exit time`` checkbox ongechecked.
- Zorg ervoor dat de conditie ``IsShooting -> true`` is.

### 7.2 Script
- Maak een nieuwe methode genaamd ``ExecuteAim()`` die door de ``Update`` van unity uitgevoerd word.
- Zorg ervoor dat op een bepaalde ``KeyDown`` de layer weight van de ``Aiming layer`` op 1 gezet wordt.

Tip
- Gebruik de ``SetBool`` methode van de ``Animator``
- Zet de layer weight alleen op 1 als de ``KeyDown`` true is.

## 8. Maak animaties voor de kubus
### 8.1 bouncyCube
- Selecteer het ``Cube`` gameobject in de ``Hierarchy``.
- Open de ``Animation window`` met ``ctrl + 6`` of ``Window -> Animation -> Animation``.
- Voeg een nieuwe animatie clip toe en geef dit de naam ``BouncyCube``.
- Druk de ``record`` knop in de ``Animation window`` en beweeg de cube per key frame de gewenste richting op in de ``Y as``

### 8.2 rotatingCube
- Herhaal de stappen om nog een animatie te creeëren die de cube draait op de y as.

Tip
- Het toevoegen van een nieuwe keyfram kan met het ``>|`` icon of door het slepen van de witte bar naar de gewenste positie op de timeline.

## 9. Gebruik additive layer om de animaties te combineren
- Maak een nieuwe ``Animator controller`` aan en voeg deze toe aan de ``Cube``.
- Maak een laag met de ``bouncyCube`` animatie.
- Maak een tweede laag met de ``rotatingCube`` animatie.
- Selecteer de ``gear`` icon van de tweede laag en zet de ``Blending`` property op ``Additive``.
- Zet de layer weight op 1 met behulp van de ``slider`` of door het wijzigen van de ``waarde``. 

## 10 Zorg dat het karakter naar de kubus kijkt (code).
- Check de ``IK Pass`` checkbox in de ``Base layer`` van de avatar animation controller via de ``gear`` icon.
- Voeg de volgende functie toe in het ``AnimationControllerScript``, ``private void OnAnimatorIK(int layerIndex)``
- Implementeer deze functie zodat wanneer een bepaalde knop ingedrukt wordt, de avatar kijkt naar de kubus.

Tip
- Gebruik de ``SetLayerWeight()`` functie voor het uitschakelen van lagen die invloed hebben op het hoofd transform van de avatar zoals de ``Looking layer``
- Gebruik de ``SetLookAtPosition()`` functie van de ``Animator``.
- Gebruik de ``SetLookAtWeight()`` functie van de ``Animator``.
