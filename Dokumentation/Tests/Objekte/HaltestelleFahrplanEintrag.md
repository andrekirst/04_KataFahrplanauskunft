# Objekt *HaltestelleFahrplanEintrag*

Test-Assembly: `Fahrtplanauskunft.Test`

Test-Klasse: `T_HaltestelleFahrplanEintrag`

## Testfälle

### Konstruktor_Haltestelle_NICHT_NULL_Uhrzeit_750_Linie_NICHT_NULL

#### Beschreibung

Test, ob die Haltestelle nicht NULL ist, dass die Uhrzeit den Wert "750" hat und die Linie nicht NULL ist.

### HaltestellenFahrplanEintrag_Equals_Uhrzeit_720_Linie_U1_Haltestelle_H1

#### Beschreibung

Test, dass die Equals-Methode zwei Haltestellenfahrplaneinträge verschiedener Instanzen mit jeweils der Uhrzeit von 720, Linie U1 und Haltestelle H1 als den gleichen Haltestellenfahrplaneintrag identifiziert

### HaltestellenFahrplanEintrag_Gleichheitsoperator_Gleiches_Objekt

#### Beschreibung

Test des Gleichheitsoperators mit zwei gleichen Haltestellenfahrplaneinträge

### HaltestellenFahrplanEintrag_Gleichheitsoperator_Ungleiches_Objekt

#### Beschreibung

Test des Gleichheitsoperators mit zwei ungleichen Haltestellenfahrplaneinträge

### HaltestellenFahrplanEintrag_Ungleichheitsoperator_Gleiches_Objekt

#### Beschreibung

Test des Ungleichheitsoperators mit zwei gleichen Haltestellenfahrplaneinträgen

### HaltestellenFahrplanEintrage_Ungleichheitsoperator_Verschiedene_Haltestellenname

#### Beschreibung

Test des Ungleichheitsoperators mit zwei ungleichen Haltestellenfahrplaneinträgen

### HaltestellenFahrplanEintrage_GetHashCode

#### Beschreibung

Testet den Hashcode, der durch die Uhrzeit, die Linie und die Haltestelle erzeugt wird