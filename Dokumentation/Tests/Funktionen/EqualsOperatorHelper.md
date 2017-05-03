# Funktionen *EqualsHelper*

Test-Assembly: `Fahrtplanauskunft.Test`

Test-Klasse: `T_EqualsHelper`

## Testfälle

### EqualsOperatorHelper_Parameters_Null

#### Beschreibung

Wenn beide Objekte Null sind, dann true zurückgeben

### EqualsOperatorHelper_Parameter_a_Ist_Null_b_Nicht_Null

#### Beschreibung

Wenn Objekt a nicht NULL ist und Objekt b Null ist, dann false zurückgeben

### EqualsOperatorHelper_Parameter_a_Ist_Nicht_Null_b_ist_Null

#### Beschreibung

Wenn Objekt b nicht NULL ist und Objekt a Null ist, dann false zurückgeben

### EqualsOperatorHelper_Beide_Parameter_gleiche_Instanz

#### Beschreibung

Wenn beide Objekte die gleiche Instanz haben, dann true zurückgeben

### EqualsOperatorHelper_Unterschiedliche_Instanzen_Unterschiedliche_Werte

#### Beschreibung

Zwei Unterschiedliche Instanzen mit verschiedenen Werten geben false zurück

### EqualsOperatorHelper_Unterschiedliche_Instanzen_gleiche_Werte

#### Beschreibung

Zwei Unterschiedliche Instanzen mit gleichen Werten geben false zurück