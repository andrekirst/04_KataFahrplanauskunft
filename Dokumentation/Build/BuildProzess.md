# Build-Prozess

## AppVeyor

### Beschreibung

Umgesetzt wird der automatisierte Build- und Test-Prozess auf der Plattform [AppVeyor](https://ci.appveyor.com/project/andrekirst/04-katafahrplanauskunft).

### Konfiguration

Konfiguriert wird der Prozess mit der Datei [appveyor.yml](/appveyor.yml).

#### Konfigurationswerte

| Attribut | Wert | Beschreibung |
|---|---|---|
| **version** | *1.0.{build}* | Die Version entspricht 1.0 und der Buildnummer, die von AppVeyor gesetzt wird |
| **branches** | *master*, *develop* | Es werden nur Builds erzeugt, wenn der Branch *master* oder *develop* ist |
| **skip_branch_with_pr** | *false* | Es werden Builds erzeugt, wenn es sich um einen Pull Request handelt |
| **image** | *Visual Studio 2015* | Es wird die VM-Vorlage *Visual Studio 2015* verwendet |
| **platform** | *Any CPU* | Es wird die Plattform für MSBuild *Any CPU* gewählt |
| **configuration** | *Release* | Es wird die Konfiguration für MSBuild *Release* gewählt |