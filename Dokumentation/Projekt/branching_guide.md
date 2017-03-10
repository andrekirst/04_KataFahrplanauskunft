# Branching-Guide

Dieser Guide dient dazu, einen Überblick zu schaffen, wofür welche Branches da sind und wie der Umgang mit diesen ist.

## System-Branches

### Branch master

Der Branch **master** spiegelt den produktiven Stand des Quellcodes dar.

### Branch develop

Der Branch **develop** spiegelt den lauffähigen Entwicklungsstand dar.

### Branch für ein neues Feature

Ein Branch für eine neues Feature wird immer von **develop** erzeugt. Siehe [Anleitung](branching_guide.md/#anleitung-f%C3%BCr-das-erstellen-eines-neuen-feature-branch).
Desweiteren wird ein Feature-Branch nur erzeugt, wenn es dazu einen [Issue](https://github.com/andrekirst/04_KataFahrplanauskunft/issues) gibt. Aufgrund dessen, ist ein Feature-Branch folgendermaßen zu benennen: `features/issue_<Nummer des Issue>`.

## Kommentare

### Kommentare für einen Commit in einem Feature-Branch

Der Kommentar beinhaltet am anfang ein #, gefolgt der Issue-Number, einem Leerzeichen, Bindestrich, Leerzeichen und einem kurzen Kommentar.

Beispiel: `#62 - Anpassung Link`

## Anleitungen

### Anleitung für das erstellen eines neuen Feature-Branch

#### Lokalen Branch erzeugen

1. Öffnen der Git Bash
1. `git checkout develop`
1. `git fetch`
1. `git rebase`
1. `git branch features/issue_<Nummer des Issue>`
1. `git checkout features/issue_<Nummer des Issue>`
1. `git push -u origin/features/issue_<Nummer des Issue>`

#### Branch in GitHub erzeugen

TODO

#### Branch in Visual Studio erzeugen

TODO

### Anleitung für das aktualisieren von **develop** in einen Feature-Branch

#### Branch in der Git Bash aktualisieren

1. `git checkout develop`
1. `git fetch`
1. `git rebase`
1. `git checkout features/issue_<Nummer des Issue>`
1. `git merge develop`
1. `git commit -m "Merge develop into features/issue_<Nummer des Issue>"`
1. `git push`

#### Branch in Visual Studio aktualisieren

TODO