# Modul 318 Projekt

##### Table of Contents
* [Einleitung](#einleitung)
* [Autor](#autor)
* [Zusammenfassung](#zusammenfassung)
* [Zweck](#zweck)
* [User Stories](#userstories) 
* [Funktionen](#funktionen) 
* [Aktivitäts Diagramm](#activitydiagram)
* [Mockups](#mockups)
* [Tests](#tests)
* [Installation Anleitung](#installation) 

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

<a name="userstories"/>

### User Stories

| ID   | Beschreibung  | Abnahmekrieterien| Priorität |
| -------|:-------------:| -----:|-----:|
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

<a name="activitydiagram"/>

### Aktivitäts Diagramm


![Aktiviäts Diagramm](/images/ActivityDiagramm.png)

<a name="mockups"/>

### Mockups

#### Verbindungssuche

![Mockup](/images/Verbindungssuche.png)

#### Fahrplan

![Mockup](/images/Abfahrtstafel.png)

#### Kartenansicht

![Mockup](/images/Kartenansicht.png)

<a name="tests"/>

## Tests

### Test - Verbindungen suchen

| Schritt | Aktivität                                                     | Erwartetes Resultat                                      |
| ------- | ------------------------------------------------------------- | -------------------------------------------------------- | 
| 1       | In das Suchfeld «Von» wird «Luzern» eingegeben und in das Suchfeld «Nach» wird «Zürich» Eingeben und auf den «Suchen» Knopf gedrückt. | Es werden 4 Verbindungen von Luzern nach Zürich angezeigt. |

### Test - Abfahrtstafel

| Schritt | Aktivität                                                     | Erwartetes Resultat                                      |
| ------- | ------------------------------------------------------------- | -------------------------------------------------------- | 
| 1       | Auf den Tab «Abfahrtstafel» klicken. | Das Fenster des Tabs «Fahrplan wird angezeigt. |
| 2       | In das Suchfeld «Station» die Station «Luzern» eingeben und auf «Suchen» klicken | Der Fahrplan der Station Luzern wird Angezeigt |

### Test - Kartenansicht

| Schritt | Aktivität                                                     | Erwartetes Resultat                                      |
| ------- | ------------------------------------------------------------- | -------------------------------------------------------- | 
| 1       | Auf den Tab «Kartenansicht» klicken. | Das Fenster des Tabs «Kartenansicht» wird angezeigt. |
| 2       | In das Suchfeld «Station» die Station «Basel» eingeben und auf «Suchen» klicken. | Die Kartenansicht der SBB Basel wird auf einer Karte angezeigt. |

### Test - Suchvorschläge

| Schritt | Aktivität                                                     | Erwartetes Resultat                                      |
| ------- | ------------------------------------------------------------- | -------------------------------------------------------- | 
| 1       | In das Suchfeld «Von» wird «Luzern» eingegeben und in das Suchfeld «Nach» wird «Bern» Eingeben. | Für «Luzern» kommen folgende Vorschläge: (Luzern, Luzern Bahhof, Luzern Kantonalbank). Für «Bern» kommen folgende Vorschläge: (Bern, Bern Bahnhof, Bern Hirschengraben). |

### Test - Zeit und Datum

| Schritt | Aktivität                                                     | Erwartetes Resultat                                      |
| ------- | ------------------------------------------------------------- | -------------------------------------------------------- | 
| 1       | Bei der Suche nach Verbindungen ein Datum und eine Zeit angeben und auf «Suchen» klicken. | Das Abreisedatum und die Abreisezeit der Verbindungen ist grösser als die eingegebenen Daten|


### Unit Tests

![Unittest](/images/Unittests.png)

<a name="installation"/>

## Installationsanleitung

[Github Installer Ordner](https://github.com/robertfodor93/Modul-318-SwissTransport/tree/master/installer)

[Installer Direkt Herunterladen](https://github.com/robertfodor93/Modul-318-SwissTransport/raw/fb8dfe0a0f399fdc4d219bf35bab8ca684b5fc4a/installer/SwissTransportSetup.msi)

![Installer](/images/step1.png)

![Installer](/images/step2.png)

![Installer](/images/step3.png)

![Installer](/images/Step4.png)
