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

###  Haltestellen_von_Linie_B1_sind_H1_H2_H3_H4_H5

#### Beschreibung

Es soll die Funktion Liefere_Haltestellen_einer_Linie mit dem Wert Linie B1 aufgerufen werden und die Ausgabe soll eine Liste mit dem Umstiegspunkt H1, H2, H3, H4 und H5 zurückgeben.

###  Haltestellen_von_Linie_B2_sind_H6_H4_H7_H8_H9

#### Beschreibung

Es soll die Funktion Liefere_Haltestellen_einer_Linie mit dem Wert Linie B2 aufgerufen werden und die Ausgabe soll eine Liste mit dem Umstiegspunkt H6, H4, H7, H8 und H9 zurückgeben.

###  Funktion: Liefere_eindeutige_Umstiegspunkte

#### Beschreibung

Es soll die Funktion Liefere_eindeutige_Umstiegspunkte mit eine Liste von Umstiegspunkten aufgerufen werden und die Ausgabe soll eine eindeutige Liste von Umstiegspunkten zurückgeben.  
Testdaten:  
2 Umstiegspunkte Up1 und Up3 sind 2 Umstiegspunkte Up1 und Up3  
3 Umstiegspunkte Up1, Up3 und Up3 sind 2 Umstiegspunkte Up1 und Up3  
4 Umstiegspunkte Up1, Up2, Up3 und Up3 sind 3 Umstiegspunkte Up1, Up2 und Up3  

