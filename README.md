# Modul 318 Projekt


##### Table of Contents


## Einleitung

<a name="autor"/>

### Autor

Autor: Robert Fodor
Erstelldatum: 12.02.2022
Letzte version: 14.04.2022

<a name="zussamenfassung"/>

### Zusammenfassung

In dem Projekt des Modules 318 geht es darum, eine Applikation zu entwickeln, welche die Fahrpläne des öffentlichen Verkehrs anzeigt. Mit der Applikation soll es möglich seine Verbindungen zu suchen, wie auch die Fahrpläne einer Station.

<a name="zweck"/>

### Zweck

Der Zweck dieses Dokumentes dient dazu die Projektarbeit im Modul 318 zu Dokumentieren. Das Dokument enthält User Stories, Funktionalitäten, Mockups, Bug liste, Aktivitätsdiagramme, Testfälle, wie auch die Installationsanleitung.

### User Stories

| ID   | Beschreibung  | Abnahmekrieterien| Priorität |
| -----|:-------------:| -----:|-----:|
| M318-01 | Als Benutzer möchte ich der Lage sein den Start und Endstationen zu wählen.| Der Benutzer bekommt die richtigen Verbindungen basierend auf den Start und Ziel Ort. | 1 |
| M318-02 | Als Benutzer möchte ich das mir die nächsten 4 Verbindungen angezeigt werden bei der Auswahl einer Reiseroute. | Der Benutzer erhält nur die 4 nächsten Verbindungen basierend auf seiner Auswahl. | 1 |
| M318-03 | Als Benutzer möchte ich den Standort der nächsten Station vom aktuellen Standort anzeigen lassen | Der Benutzer erhält die nächste Station auf einer Kartenansicht, basierend auf seiner Location. | 1 |
| M318-04 | Als Benutzer möchte ich eine Abfahrtstafel einer gewählten Station angezeigt erhalten. | Dem Benutzer wird die Abfahrstafel einer gewählten Station angezeigt. | 2 |
| M318-05 | Als Benutzer möchte ich bei der Suche nach Stationen Vorschläge basierend nach meiner Eingabe erhalten. | Der Benutzer erhält die richtigen Vorschläge basierend auf die angegebenen Buchstaben. | 2 |
| M318-06 | Als Benutzer möchte ich Verbindungen durch Datumseingabe filtrieren können. | Der Benutzer kann Verbindungen nach Datum und Zeit einschränken. | 3 |
| M318-07 | Als Benutzer möchte ich den Standort einer Station per Kartenansicht ansehen kann. | Der Benutzer ist in der Lage per Karten Ansicht die Standorte aller Stationen anzusehen. | 3 |
| M318-08 | Als Benutzer möchte ich über relevante Zugverbindungen per E-Mail benachrichtigt werden. | Der Benutzer erhält eine E-Mail mit seinen Verbindungen. | 3 |
| M318-09 | Als Benutzer möchte ich gewählte Linien in eine Favoritenliste aufnehmen. | Der Benutzer kann gewählte Linien in eine Favoritenliste aufnehmen | 3 |

<a name="funktionen"/>

## Funktionen
In der Tabele ist ersichtlich welche Funktionen umgesetz wurden und welche nicht.
| User Story | Priorität | Status | Details                      |
| ----------- | --------- | ------ | --------------------------------- | 
| M318-01       | 1         | ✅      | Die suche nach Verbindungen wurde erfolgreich implementiert. | 
| M318-02       | 1         | ✅      | Bei der Verbindungsuche werden nur 4 Verbindungen per suche angezeigt. | 
| M318-03       | 1         | :interrobang: | Per Karten Ansicht kann man eine Station per Namen suchen und der Standort wird mit «MapPins» auf der Karte angezeigt. Standort Ortung an sich wurde nicht implementiert. Die «MapPins» wurden durch die «GMap» Extension und der «SearchCH» API umgesetzt. | 
| M318-04       | 2         | ✅      | Die Abfahrtstafel einer gesuchten Station wird angezeigt. | 
| M318-05       | 2         | ✅      | Bei der suche nach Stationen werden Vorschläge angeboten. Dieses wurde durch eine selbst erstellte «UserControl» umgesetzt und in jeder «View» verwendet|
| M318-06       | 3         | ✅      | Bei der Suche nach Verbindungen kann man die suche mit Datum und Zeit Eingrenzen. |  
| M318-07         | 3         | ✅      | Bei der Suche nach Standorten einer Station fokussiert das Kartenfenster auf den Standort der Station. |  
| M318-08        | 3         | ❌     |  |
| M318-09        | 3         | ❌     |  |
