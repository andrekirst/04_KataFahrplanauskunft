# Build-Prozess

## AppVeyor

### Beschreibung

Umgesetzt wird der automatisierte Build- und Test-Prozess auf der Plattform [AppVeyor](https://ci.appveyor.com/project/andrekirst/04-katafahrplanauskunft).

### Konfiguration

Konfiguriert wird der Prozess mit der Datei [appveyor.yml](/appveyor.yml).

#### Konfigurationswerte

| Attribut | Wert | Beschreibung |
|---|---|---|
| **assembly:patch** | *true* | |
| **assembly:file** | *AssemblyInfo.** | Filtert auf *AssemblyInfo.** |
| **assembly:assembly_version** | *"1.0.{build}"* | Setzt die Version auf 1.0 und die von AppVeyor gesetzte Buildnummer |
| **assembly:assembly_file_version** | *"{version}"* | Setzt die Assembly-Dateiversion auf die AppVeyor gesetzte Version |
| **assembly:assembly_informational_version** | *"{version}"* | Setzt die Assembly-Dateiversion auf die AppVeyor gesetzte Version |
| **branches:only** | *master*, *develop* | Es werden nur Builds erzeugt, wenn der Branch *master* oder *develop* ist |
| **build:parallel** | *false* | MSBuild kompiliert die Projekte sequentiell |
| **build:project** | *src/Fahrplanauskunft/Fahrplanauskunft.sln* | Die Solution-Datei, die MSBuild verwendet |
| **build:include_nuget_references** | *true* | |
| **build:verbosity** | *normal* | Loggt MSBuild-Ausgaben mit dem *normal*-Level |
| **cache** | *...* | Speichert die angegebenen Ordner im Cache. Pfadangaben in der Konfigurationsdatei |
| **clone_folder** | *c:\projects\04_katafahrplanauskunft* | Der Ablageort, in dem der Aufurf `git clone` das Repository ablegt |
| **configuration** | *Release* | Es wird die Konfiguration für MSBuild *Release* gewählt |
| **image** | *Visual Studio 2015* | Es wird die VM-Vorlage *Visual Studio 2015* verwendet |
| **matrix:fast_finish** | *true* | Bricht den Build-Prozess sofort ab, wenn ein Fehler auftritt |
| **platform** | *Any CPU* | Es wird die Plattform für MSBuild *Any CPU* gewählt |
| **skip_branch_with_pr** | *false* | Es werden Builds erzeugt, wenn es sich um einen Pull Request handelt |
| **test:assemblies** | *Fahrplanauskunft.Test.dll* | Testet die Bibliothek `Fahrplanauskunft.Test.dll` |
| **version** | *1.0.{build}* | Die Version entspricht 1.0 und der Buildnummer, die von AppVeyor gesetzt wird |