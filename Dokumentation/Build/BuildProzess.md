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
| **cache** | *...* | Speichert die angegebenen Ordner im Cache. Pfadangaben in der Konfigurationsdatei |
| **clone_folder** | *c:\projects\04_katafahrplanauskunft* | Der Ablageort, in dem der Aufurf `git clone` das Repository ablegt |
| **configuration** | *Release* | Es wird die Konfiguration für MSBuild *Release* gewählt |
| **environment.sonarqubeprefix** | "" | Variable für den Prefix für SonarQube |
| **environment.COVERALLS_REPO_TOKEN** | *o90DGx/Fmc85k/gMdZ3SzlyUi+a6JCg50LtSqm5zw5k2cbLaIsgKyNjORVGERs0G* | Sicherer Token für Coveralls |
| **environment.SONARQUBE_TOKEN** | *sFo2TCruCWRcpHbTVAyLc4DZCDBxiGzRpLkv1Cq2oquDiKjo1yuCh73IN8ceKZ65* | Sicherer Token für SonarQube |
| **image** | *Visual Studio 2015* | Es wird die VM-Vorlage *Visual Studio 2015* verwendet |
| **matrix:fast_finish** | *true* | Bricht den Build-Prozess sofort ab, wenn ein Fehler auftritt |
| **platform** | *Any CPU* | Es wird die Plattform für MSBuild *Any CPU* gewählt |
| **skip_branch_with_pr** | *false* | Es werden Builds erzeugt, wenn es sich um einen Pull Request handelt |
| **version** | *1.0.{build}* | Die Version entspricht 1.0 und der Buildnummer, die von AppVeyor gesetzt wird |

#### Grober Ablauf des Build-Prozesses

1. Installation des Chocolatey-Packge **msbuild-sonarqube-runner**
1. Start des SonarQube-Runners
1. Ausführen von **msbuild** für die Solution *Fahrplanauskunft*
1. Ausführen der entstandenen Tests
1. Ausführen von **OpenCover** zur Ermittlung der Testabdeckung. Entstandene Testabdeckung wird in der Datei `./opencovertests.xml` abgelegt
1. Übermittlung der Testabdeckung an coveralls mit **coveralls.net**
1. Beendigung des SonarQube-Runners und Übermittlung der Ergebniss an das SonarQube-Projekt
1. Erstellung des Artifaktes
    1. Kopieren der Ausgabe aus dem `bin`-Ordner in den Artifakt-Ordner
    1. Generierung der Dokumentationen von Markdown nach HTML mit `pandoc` und Ausgabe in den Artifakt-Ordner
    1. Upload des Artifakt

### SonarQube

SonarQube wird zum analysieren des Quellcodes genutzt.

#### SonarQube-Konfiguration

Damit SonarQube das Projekt übernehmen kann, muss ein Token erstellt werden. Dieser heißt "04_KataFahrplanauskunft". Dieser genertierte Token muss in AppVeyor unter "Settings/Environment" unter "Add variable" eingerichtet werden. Name: "SonarToken". Wert: "abc...". Dieser Wert muss dann mit dem Schloss-Symbol verschlüsselt werden.

#### SonarQube im Build

Damit SonarQube angewendet werden kann, wird mittels `choco install "msbuild-sonarqube-runner" -y` das Paket für den SonarQube-Runner für MSBuild installiert.
In den nächsten Schritten, wird das Build für SonarQube vorbereitet, das Build selber durchgeführt und der Abschluss von SonarQube angewandt. Diese Informationen befinden sich im Abschnitt `build_script`.

Die Versionen in Sonarqube werden folgendermaßen gebildet:

| Branch | Beispiel | Beschreibung |
|---|---|---|
| master | 1.0.101 | Ist nach einem Pull request nach **master** erstellt |
| develop | dev-1.0.101 | Ist nach einem Pull request nach **develop** erstellt |
| *Pull request* | pr-1.0.101-#55 | Wenn ein Pull request erstellt ist. Als Suffix die Nummer des Pull request mit einer Raute (`#`) davor |

### Coveralls

[Coveralls](https://coveralls.io/) ist ein Webdienst, um die Testabdeckung des implementierten Codes über einene Zeitraum zu verfolgen und anzuzeigen.

#### Coveralls-Konfiguration

Damit Coveralls das Projekt übernehmen kann, muss ein Token erstellt werden. Dieser wird im Abschnitt `environemnt` in der Datei `appveyor.yml` als *secure* abgelegt.

##### Coveralls im Build

Im Abschnitt `build_script` in der Datei `appveyor.yml` wird das NuGet-Package [coveralls.net](https://www.nuget.org/packages/coveralls.net/) benutzt, um die entstandene Datei `./opencovertests.xml` an coveralls.io zu senden.