# Dokumentation für die Installation von benötigten Paketen

## Installation Chocolatey-Packagemanager

Um Skripte ausführen zu können, folgendes Kommand in der PowerShell ausführen:

```bash
Set-ExecutionPolicy -ExecutionPolicy Unrestricted
```

Die Frage darauf hin mit `A` beantworten.

## Pakete installieren

Um Pakete zu installieren, folgendes Skript im Ordner `install` ausführen:

```bash
.\install_packages.ps1
```

## Pakete aktualisieren

Um Pakete zu aktualisieren, folgendes Skript im Ordner `install` ausführen:

```bash
.\upgrade_packages.ps1
```

## Pakete erweitern

Um Pakete zu erweitern, muss die Datei [packages.config](packages.config) angepasst werden. Weitere Informationen befinden sich im [Wiki](https://github.com/chocolatey/choco/wiki/CommandsInstall#packagesconfig) vom [Choco-Projekt](https://github.com/chocolatey/choco) auf github.