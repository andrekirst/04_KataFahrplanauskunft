# Objekt *FahrplanauskunftObjektBase*

Test-Assembly: `Fahrtplanauskunft.Test`

Test-Klasse: `T_FahrplanauskunftObjektBase`

Test-Objekt-Klasse: `TestKlasseFahrplanauskunftObjektBase`

```csharp
private class TestKlasseFahrplanauskunftObjektBase : FahrplanauskunftObjektBase
{
    public TestKlasseFahrplanauskunftObjektBase(string id)
        : base(id)
    {
    }
}
```

## Testfälle

### FahrplanauskunftObjektBase_Konstruktor_Eigenschaft_ID

#### Beschreibung

Test, ob der Konstruktor die Eigenschaft ID setzt

### FahrplanauskunftObjektBase_Konstruktor_Eigenschaft_ID_Null_AutoGenerateGuid

#### Beschreibung

Test, wenn der Konstruktor den Parameter automatisch eine ID per `Guid.NewGuid()` vergibt, wenn der Wert NULL ist

### FahrplanauskunftObjektBase_Konstruktor_Eigenschaft_ID_Empty_AutoGenerateGuid

#### Beschreibung

Test, wenn der Konstruktor den Parameter automatisch eine ID per `Guid.NewGuid()` vergibt, wenn der Wert `string.Empty` ist

### FahrplanauskunftObjektBase_GetHashCode_ID_1_Erwarte__842352753

#### Beschreibung

Test, wenn die ID den Wert "1" hat, dass der berechnete Hashwert den Wert -842352753 zurück gibt

### FahrplanauskunftObjektBase_Equals_ID_1_Vergleich_ID_1_Gleich

#### Beschreibung

Testet, ob zwei Objekte mit jeweils der ID "1" beim Vergleich mit `FahrplanauskunftObjektBase.Equals(object)` true zurück gibt

### FahrplanauskunftObjektBase_Equals_ID_1_Vergleich_ID_2_Ungleich

#### Beschreibung

Testet, ob zwei Objekte mit der ID "1" bzw. ID "2" beim Vergleich mit `FahrplanauskunftObjektBase.Equals(object)` false zurück gibt

### FahrplanauskunftObjektBase_Equals_Object

#### Beschreibung

Test, ob `FahrplanauskunftObjektBase.Equals(object)` aufgerufen wird und true bei Gleichheit zurückgibt