# Deployment-Prozess

## Inhalt des Deployments

### fahrplanauskunft.zip

| Datei | Version |
|---|---:|
| Fahrplanauskunft.dll | *current* |
| Fahrplanauskunft.UI.WindowsForms.Editor.exe | *current* |
| Fahrplanauskunft.UI.WindowsForms.Editor.exe.config | |
| Fahrplanauskunft.dll.RoslynCA.json | |
| Newtonsoft.Json.dll | 10.0.3.21018 |
| Newtonsoft.Json.xml | |

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