# Linie

Basisklasse: `FahrplanauskunftObjektBase`

## Beschreibung

Eine Linie ist eine Sammlung von Haltestellen, die das jeweilige Transportsystem, wie eine Linie, abfährt.

Eine Linie kann mit dem Namen öfters vorkommen, aber dafür muss der Ident unterschiedlich sein.

## Attribute

| Name | Datentyp | Beschreibung |
|---|---|---|
| Nummer | *string* | Die Nummer präsentiert die Anzeige der Linie. Bsp.: 3 |
| Lauf | *string* | Der Lauf beschreibt die Laufrichtung der Linie. Bsp.: 3_RICHTUNG_ZIEL_A |
| Farbe | *string* | Die Farbe, die zur Dartsellung in den Oberflächen dient |

## Beispiele

* Linie "U1"
  * Nummer: "U1"
  * Lauf: "U1_NORD"
  * Farbe: "#FF4500"
* Linie "U1"
  * Nummer: "U1"
  * Lauf: "UI_SUED"
  * Farbe: "#FF4500"