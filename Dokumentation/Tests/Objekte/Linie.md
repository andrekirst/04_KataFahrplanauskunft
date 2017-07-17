# Objekt *Linie*

Test-Assembly: `Fahrtplanauskunft.Test`

Test-Klasse: `T_Linie`

## Testfälle

Linie_Konstruktor_Nummer_Test_Lauf_TEST

#### Beschreibung

Test, ob die Nummer den Wert "Test" beinhaltet und der Lauf den Wert "TEST" beinhaltet.

### Linie_Equals_Nummer_Test_Lauf_TEST

#### Beschreibung

Test der Equals-Methode, dass zwei Linien gleich sind. Nummer: "Test", Lauf: "TEST"

### Linie_Gleichheitsoperator_Gleiche_Liniennummer

#### Beschreibung

Test des Gleichheitsoperators mit zwei Linien mit der gleichen Nummer

### Linie_Gleichheitsoperator_Verschiedene_Liniennummern

#### Beschreibung

Test des Gleichheitsoperators mit zwei Linien mit verschiedenen Nummern

### Linie_Ungleichheitsoperator_Gleiche_Liniennummern

#### Beschreibung

Test des Ungleichheitsoperators mit zwei Linien mit den gleichen Nummern

### Linie_Ungleichheitsoperator_Verschiedene_Liniennummern

#### Beschreibung

Test des Ungleichheitsoperators mit zwei Linien mit verschiedenen Nummern

### Linie_ToString_B1_B11

#### Beschreibung

Testet die Methode ToString. Erwartet "B1 - B11"

### Linie_Farbe_RauteFF4500

#### Beschreibung

Testet, ob die Eigenschaft Farbe den Wert aus dem Konstruktor übernimmt

### Linie_Nummer_und_Lauf_gleich_Farbe_unterschiedlich

#### Beschreibung

Test, dass das Attribut Farbe mit unterschiedlichen Werten verglichen wird

### Linie_GetHashCode_ID_1_Erwarte__842352753

#### Beschreibung

Test, wenn die ID den Wert "1" hat, dass der berechnete Hashwert den Wert -842352753 zurück gibt