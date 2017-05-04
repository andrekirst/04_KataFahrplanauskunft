# Objekt *Streckenabschnitt*

Test-Assembly: `Fahrtplanauskunft.Test`

Test-Klasse: `T_Streckenabschnitt`

## Testfälle

### Streckenabschnitt_Konstruktor_Dauer_1_StartHaltestelle_Nicht_NULL_ZielHaltestelle_Nicht_NULL_Linien_1

#### Beschreibung

Test, ob der Streckenabschnitt die Dauer von 1 hat, eine Start- und ZielHaltestelle hat, sowie dass eine Linie auf dem Streckebschnitt fährt.

### Streckenabschnitt_Equals_Name_Test_Ident_TEST

#### Beschreibung

Test der Equals-Methode, dass zwei gleiche Streckenabschnitte vergleicht

### Streckenabschnitt_Gleichheitsoperator_Gleicher_Streckenabschnitt

#### Beschreibung

Test des Gleichheitsoperators mit zwei gleichen Streckenabschnitten

### Streckenabschnitt_Gleichheitsoperator_Verschiedene_Streckenabschnitte

#### Beschreibung

Test des Gleichheitsoperators mit zwei verschiedenen Streckenabschnitten

### Streckenabschnitt_Ungleichheitsoperator_Gleicher_Streckenabschnitt

#### Beschreibung

Test des Ungleichheitsoperators mit zwei gleichen Streckenabschnitten

### Streckenabschnitt_Ungleichheitsoperator_Verschiedene_Streckenabschnitte

#### Beschreibung

Test des Ungleichheitsoperators mit zwei ungleichen Streckenabschnitten

### Streckenabschnitt_GetHashCode

#### Beschreibung

Testet den Hashcode, der durch die Dauer, die zwei Haltestellen und die Linien erzeugt wird