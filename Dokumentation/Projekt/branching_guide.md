# Branching-Guide

Dieser Guide dient dazu, einen Überblick zu schaffen, wofür welche Branches da sind und wie der Umgang mit diesen ist.

## System-Branches

### Branch master

Der Branch **master** spiegelt den produktiven Stand des Quellcodes das.

### Branch develop

Der Branch **develop** spiegelt den lauffähigen Entwicklungsstand dar.

### Branch für ein neues Feature

Ein Branch für eine neues Feature wird immer von **develop** erzeugt.

## Anleitungen

### Anleitung für das erstellen eines neuen Feature-Branch (lokal)

1. `git checkout develop`
1. `git fetch`
1. `git rebase`
1. `git branch features/issue_<Nummer des Issue>`
1. `git checkout features/issue_<Nummer des Issue>`

### Anleitung für das aktualisieren von **develop** in einen Feature-Branch

1. `git checkout develop`
1. `git s`