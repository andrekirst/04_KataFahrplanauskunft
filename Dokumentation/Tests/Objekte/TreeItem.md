# Objekt *TreeItem*

Test-Assembly: `Fahrtplanauskunft.Test`

Test-Klasse: `T_TreeItem`

## Testfälle

### TreeItem_Equal_1

#### Beschreibung

Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1" gleich sind.

### TreeItem_Not_Equal_1

#### Beschreibung

Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1" bzw. "H2" nicht gleich sind.

### TreeItem_Equal_2

#### Beschreibung

Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1" und Childs "H2","H4" bzw. Childs "H4","H2" gleich sind.

### TreeItem_Not_Equal_2

#### Beschreibung

Test der Equals-Methode, dass zwei TreeItem mit einer Haltestelle Name: "H1" und Childs "H2","H4" sowie "H2","H5" nicht gleich sind.

### TreeItem_Equal_3

#### Beschreibung

Test der Equals-Methode, dass zwei TreeItem mit jeweils einer Haltestelle Name: "H1", Childs "H2","H4" bzw. Childs "H4","H2" und weitere Grandchildren "H8" gleich sind.

### TreeItem_Not_Equal_3

#### Beschreibung

Test der Equals-Methode, dass zwei TreeItem mit einer Haltestelle Name: "H1" , Childs "H2","H4" und einmal ein weiteres Grandchildren "H8"  sowie einmal ein weiteres Grandchildren "H10" sind nicht gleich.

### TreeItem_Gleichheitsoperator_Gleiches_TreeItem

#### Beschreibung

Test des Gleichheitsoperators mit zwei gleichen TreeItems

### TreeItem_Gleichheitsoperator_Verschiedene_TreeItem

#### Beschreibung

Test des Gleichheitsoperators mit zwei verschiedenen TreeItems

### TreeItem_Ungleichheitsoperator_Gleiches_TreeItem

#### Beschreibung

Test des Ungleichheitsoperators mit zwei gleichen TreeItems

### TreeItem_Ungleichheitsoperator_Verschiedene_TreeItem

#### Beschreibung

Test des Ungleichheitsoperators mit zwei ungleichen TreeItems