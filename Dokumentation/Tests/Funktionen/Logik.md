# Funktionen *Logik*

Test-Assembly: `Fahrtplanauskunft.Test`

Test-Klasse: `T_Logik`

Test-Daten: `TestSatzBrainstorming`

## Testfälle

### Umstiegspunkte_von_Linie_B1_sind_H2_H4

#### Beschreibung

Es soll die Funktion Liefere_Umstiegspunkte_fuer_Linie mit dem Wert Linie B1 aufgerufen werden und die Ausgabe soll eine Liste von Umstiegspunkten H2 und H4 zurückgeben.

### Umstiegspunkte_von_Linie_B3_sind_H2_H8

#### Beschreibung

Es soll die Funktion Liefere_Umstiegspunkte_fuer_Linie mit dem Wert Linie B3 aufgerufen werden und die Ausgabe soll eine Liste von Umstiegspunkten H2 und H8 zurückgeben.

### Umsteigepunkte_von_Linie_B4_ist_H8

#### Beschreibung

Es soll die Funktion Liefere_Umstiegspunkte_fuer_Linie mit dem Wert Linie B4 aufgerufen werden und die Ausgabe soll eine Liste mit dem Umstiegspunkt H8 zurückgeben.

### Haltestellen_von_Linie_B1_sind_H1_H2_H3_H4_H5

#### Beschreibung

Es soll die Funktion Liefere_Haltestellen_einer_Linie mit dem Wert Linie B1 aufgerufen werden und die Ausgabe soll eine Liste mit dem Umstiegspunkt H1, H2, H3, H4 und H5 zurückgeben.

### Haltestellen_von_Linie_B2_sind_H6_H4_H7_H8_H9

#### Beschreibung

Es soll die Funktion Liefere_Haltestellen_einer_Linie mit dem Wert Linie B2 aufgerufen werden und die Ausgabe soll eine Liste mit dem Umstiegspunkt H6, H4, H7, H8 und H9 zurückgeben.

### Funktion: Liefere_eindeutige_Umstiegspunkte

#### Beschreibung

Es soll die Funktion Liefere_eindeutige_Umstiegspunkte mit eine Liste von Umstiegspunkten aufgerufen werden und die Ausgabe soll eine eindeutige Liste von Umstiegspunkten zurückgeben.

#### Testdaten:

2 Umstiegspunkte Up1 und Up3 sind 2 Umstiegspunkte Up1 und Up3
3 Umstiegspunkte Up1, Up3 und Up3 sind 2 Umstiegspunkte Up1 und Up3
4 Umstiegspunkte Up1, Up2, Up3 und Up3 sind 3 Umstiegspunkte Up1, Up2 und Up3

###  Funktion: Liefere_Naechste_Umstiegspunkte_von_Haltestelle

#### Beschreibung

Liefere die nächsten möglichen Umstiegspunkte einer Haltestelle und ignoriere schon bereits ermittelte Umstiegspunkte

#### Testdaten:

Beginnend von Haltestelle H1 gibt es 2 nächste Umstiegspunkte H2 und H4
Beginnend von Haltestelle H2 gibt es 2 nächste Umstiegspunkte H4 und H8
Kommend von Haltestelle H1, gibt es an Haltestelle H2 einen nächsten Umstiegspunkt H8
Kommend von Haltestelle H12, gibt es an Haltestelle H8 zwei nächste Umstiegspunkte H2 und H4

### Funktion: Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B31_von_H10_nach_H11

#### Beschreibung

Sortierung einer Liste von Haltestellen für die Linie B31, bei der die Start-Haltestelle H10 ist und die Ziel-Haltestelle H11

### Funktion: Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B32_von_H11_nach_H10

#### Beschreibung

Sortierung einer Liste von Haltestellen für die Linie B32, bei der die Start-Haltestelle H11 ist und die Ziel-Haltestelle H12 ist

### Funktion: Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B41_von_H14_nach_H15

#### Beschreibung

Sortierung einer Liste von Haltestellen für die Linie B41, bei der die Start-Haltestelle H14 ist und die Ziel-Haltestelle H15 ist

### Funktion: Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B42_von_H15_nach_H14

#### Beschreibung

Sortierung einer Liste von Haltestellen für die Linie B42, bei der die Start-Haltestelle H15 ist und die Ziel-Haltestelle H14 ist

### Funktion: Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B11_von_H1_nach_H12_Fehler_Nicht_gleiche_Linie

#### Beschreibung

Negativ-Test - Sortierung einer Liste von Haltestellen für die Linie B11, bei der die Start-Haltestelle H1 ist und die Ziel-Haltestelle H12 ist. Hier muss der Fehler kommen, dass die Ziel-Haltestelle H12 nicht zur Linie B11 gehört

### Funktion: Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B41_von_H1_nach_H12_Fehler_Nicht_gleiche_Linie

#### Beschreibung

Negativ-Test - Sortierung einer Liste von Haltestellen für die Linie B41, bei der die Start-Haltestelle H1 ist und die Ziel-Haltestelle H12 ist. Hier muss der Fehler kommen, dass die Start-Haltestelle H1 nicht zur Linie B41 gehört

### Funktion: Ist_Linie_An_Haltestelle_Linie_B11_Haltestelle_H1

#### Beschreibung

Test, ob die Linie B11 an der Haltestelle H1 ist

### Funktion: Ist_Linie_An_Haltestelle_Negativ_Linie_B41_Haltestelle_H1

#### Beschreibung

Negativ-Test - Test, dass die Linie B41 nicht an der Haltestelle H1 ist

### Funktion: Liefere_Streckenabschnitte_einer_Linie_Linie_B11

#### Beschreibung

Test, das nur Streckenabschnitte geliefert werden, an der sich auch die Linie B11 befindet

### Funktion: Liefere_Streckenabschnitte_einer_Haltestelle_einer_Linie_Haltestelle_H1_Linie_B11

#### Beschreibung

Test, dass an der Haltstelle H1 für die Linie B11 ein Streckenabschnitt zurückgegeben wird

### Funktion: Liefere_Streckenabschnitte_einer_Haltestelle_einer_Linie_Haltestelle_H2_Linie_B11

#### Beschreibung

Test, dass an der Haltstelle H1 für die Linie B11 zwei Streckenabschnitte zurückgegeben werden

### Funktion: Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Linie_B31_von_H10_nach_H8

#### Beschreibung

Sortierung einer Liste von Haltestellen für die Linie B31, bei der die Start-Haltestelle H10 ist und die Ziel-Haltestelle H8

###  Funktion: Liefere_Hierarchie_Route_von_Haltestelle

#### Beschreibung

Liefert eine Hierarchie mit möglichen Umstiegspunkten von einer Haltestelle

#### Testdaten:

Hierarchie möglichen Route von Haltestelle H1
Hierarchie möglichen Route von Haltestelle H2
Hierarchie möglichen Route von Haltestelle H12

### Funktion: Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Initialisiere_StartHaltestelle_H1

#### Beschreibung

Test für das Initialisieren der Start-Haltestellen in das sortierte Dictionary

### Funktion: Ueberpruefe_Ist_Linie_An_Haltestelle_B11_H1

#### Beschreibung

Test, ob die Linie B11 an der Haltetelle H1 ist

### Funktion: Ueberpruefe_Ist_Linie_An_Haltestelle_LinieIstNichtAnHaltestelleException

#### Beschriebung

Test, ob die Exception LinieIstNichtAnHaltestelleException geworfen wird

### Funktion: Sortiere_Liste_von_Haltestellen_von_Start_nach_Ziel_Verwalte_Hilfsobjekte_1

#### Beschreibung

Test, ob das Hinzufügen und Entfernen aus Listen für das Sortieren einer Liste von Haltestellen funktioniert

### Funktion: Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H1_zu_H2_Ergebnis_2

#### Beschreibung

Berechnung der Fahrtdauer von der Haltestelle H1 zu H2. Die erwartete Fahrtdauer beträgt 2 Minuten

### Funktion: Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H1_zu_H4_Ergebnis_6

#### Beschreibung

Berechnung der Fahrtdauer von der Haltestelle H1 zu H4. Die erwartete Fahrtdauer beträgt 6 Minuten

### Funktion: Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H12_zu_H16_Ergebnis_12

#### Beschreibung

Berechnung der Fahrtdauer von der Haltestelle H12 zu H16. Die erwartete Fahrtdauer beträgt 12 Minuten

### Funktion: Berechne_Fahrtdauer_von_Haltestelle_zu_Haltestelle_von_H16_zu_H12_Ergebnis_12

#### Beschreibung

Berechnung der Fahrtdauer von der Haltestelle H16 zu H12. Die erwartete Fahrtdauer beträgt 12 Minuten

### Funktion: ErmittleAbfahrtszeit_Haltestelle_H2_Linie_B11_Wunsch_770_Soll_783

#### Beschreibung

Test für die Ermittlung der nächsten Abfahrtszeit an der Haltestelle H2, Linie B11 mit der Wunschabfahrtszeit 770 (12:50 Uhr). Sollwert 783 (13:03 Uhr)

### Funktion: ErmittleAbfahrtszeit_Haltestelle_H2_Linie_B11_Wunsch_1433_Soll_3

#### Beschreibung

Test für die Ermittlung der nächsten Abfahrtszeit an der Haltestelle H2, Linie B11 mit der Wunschabfahrtszeit 1433 (23:53 Uhr). Sollwert 3 (00:03 Uhr)

### Funktion: ErmittleAbfahrtszeit_Haltestelle_H2_Linie_B11_Wunsch_3_Soll_3

#### Beschreibung

Test für die Ermittlung der nächsten Abfahrtszeit an der Haltestelle H2, Linie B11 mit der Wunschabfahrtszeit 3 (23:53 Uhr). Sollwert 3 (00:03 Uhr)