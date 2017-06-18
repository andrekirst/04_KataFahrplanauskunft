# Deployment-Prozess

## Inhalt des Deployments

### fahrplanauskunft.zip

| Datei | Version | Beschreibung |
|---|---:|---|
| Fahrplanauskunft.dll | *current* | Bibliothek für die Fahrplanauskunft |
| Fahrplanauskunft.UI.Windows.Editor.exe | *current* | Der Bearbeitungseditor für die Fahrplanauskunft |
| Fahrplanauskunft.UI.Windows.Editor.exe.config | | Konfig-Datei für den Bearbeitungseditor |
| Fahrplanauskunft.dll.RoslynCA.json | | |
| MetroFramework.Design.dll | 1.4.0.0 | NuGet-Paket von MetroModernUI |
| MetroFramework.dll | 1.4.0.0 | NuGet-Paket von MetroModernUI |
| MetroFramework.Fonts.dll | 1.4.0.0 | NuGet-Paket von MetroModernUI |
| Newtonsoft.Json.dll | 10.0.2.20802 | NuGet-Paket von Newotonsoft.Json |
| Newtonsoft.Json.xml | | |

#### Dokumentation

Die im Build-Prozess entstandenen HTML-Dokumente, die aus den Markdown-Dateien erzeugt wurden, werden unterhalb des Ordners `dokumentation` abgelegt und mit veröffentlicht.

## Übersicht der Deployment-Ziele

| Branch | Ziel |
|---|---|
| develop | FTP-Server |
| release | GitHub, FTP-Server |
| master | GitHub, FTP-Server, BinTray |

## Deployment über den Build-Prozess

Innerhalb des Build-Prozesses mit Appveyor wird das Deployment ausgeführt. Die Deployment-Ziele sind im Abschnitt [Übersicht der Deployment-Ziele](#übersicht-der-deployment-ziele) hinterlegt.

## Benennung der Deployment-Dateien

| Branch | Ziel | Dateiname |
|---|---|---|
| develop | FTP-Server | fahrplanauskunft-(version)-dev |
| release | GitHub, FTP-Server | fahrplanauskunft-(version)-rc |
| master | GitHub, FTP-Server, Bintray | fahrplanauskunft-(version) |