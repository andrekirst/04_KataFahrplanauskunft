# Objekt FahrzeugSpeicher

Das Objekt FahrzeugSpeicher dient dazu, die Dateien für Haltestellen, Linien, Haltestellenfahrplaneinträge und Streckenabschnitte aus einem angegeben Ordner zu laden.

## Dateiformat

Die Dateien sind im json-Format abgespeichert und werden mit dem NuGet-Package **Newtonsoft.Json** geladen.

## Objekte

### Haltestellen

Es gibt eine Datei mit allen Haltestellen. Diese Datei ist `haltestellen.json`