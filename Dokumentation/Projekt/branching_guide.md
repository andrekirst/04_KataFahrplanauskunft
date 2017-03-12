# Branching-Guide

Dieser Guide dient dazu, einen Überblick zu schaffen, wofür welche Branches da sind und wie der Umgang mit diesen ist.

* [System-Branches](branching_guide.md/#system-branches)
* [Kommentare](branching_guide.md/#kommentare)
* [Anleitungen](branching_guide.md/#anleitungen)
  * [Anleitung für das erstellen eines neuen Feature-Branch](branching_guide.md/#anleitung-f%C3%BCr-das-erstellen-eines-neuen-feature-branch)
    * [Lokalen Branch in der Git Bash erzeugen](branching_guide.md#lokalen-branch-in-der-git-bash-erzeugen)
    * [Branch in GitHub erzeugen](branching_guide.md#branch-in-github-erzeugen)
    * [Branch in Visual Studio erzeugen](branching_guide.md#branch-in-visual-studio-erzeugen)
  * [Anleitung für das aktualisieren von **develop** in einen Feature-Branch](branching_guide.md/#anleitung-f%C3%BCr-das-aktualisieren-von-develop-in-einen-feature-branch)
    * [Branch in der Git Bash aktualisieren](branching_guide.md#branch-in-der-git-bash-aktualisieren)
    * [Branch in Visual Studio aktualisieren](branching_guide.md#branch-in-visual-studio-aktualisieren)
  * [Lokalen Branch und Remote nach einem Pull request löschen](branching_guide.md#lokalen-branch-und-remote-nach-einem-pull-request-löschen)
    * [Lokalen Branch und Remote nach einem Pull request in der Git Bash löschen](branching_guide.md#lokalen-branch-und-remote-nach-einem-pull-request-in-der-git-Bash-löschen)
    * [Lokalen Branch und Remote nach einem Pull request in Visual Studio löschen](branching_guide.md#lokalen-branch-und-remote-nach-einem-pull-request-in-visual-studio-löschen)
* [Pull request erstellen](branching_guide.md/#pull-request-erstellen)
* [Pull request mergen](branching_guide.md/#pull-request-mergen)

## System-Branches

### Branch master

Der Branch **master** spiegelt den produktiven Stand des Quellcodes dar.

### Branch develop

Der Branch **develop** spiegelt den lauffähigen Entwicklungsstand dar.

### Branch für ein neues Feature

Ein Branch für eine neues Feature wird immer von **develop** erzeugt. Siehe [Anleitung](branching_guide.md/#anleitung-f%C3%BCr-das-erstellen-eines-neuen-feature-branch).
Desweiteren wird ein Feature-Branch nur erzeugt, wenn es dazu einen [Issue](https://github.com/andrekirst/04_KataFahrplanauskunft/issues) gibt. Aufgrund dessen, ist ein Feature-Branch folgendermaßen zu benennen: `features/issue_<Nummer des Issue>`. Beispiel: `features/issue_62`

## Kommentare

### Kommentare für einen Commit in einem Feature-Branch

Der Kommentar beinhaltet am anfang ein #, gefolgt der Issue-Number, einem Leerzeichen, Bindestrich, Leerzeichen und einem kurzen Kommentar.

Beispiel: `#62 - Anpassung Link`

## Anleitungen

### Anleitung für das erstellen eines neuen Feature-Branch

#### Lokalen Branch in der Git Bash erzeugen

1. `git checkout develop`
1. `git fetch`
1. `git rebase`
1. `git branch features/issue_<Nummer des Issue>`
1. `git checkout features/issue_<Nummer des Issue>`
1. `git push -u origin/features/issue_<Nummer des Issue>`

#### Branch in GitHub erzeugen

1. Den Reiter [*Code*](https://github.com/andrekirst/04_KataFahrplanauskunft) auswählen
1. Branch **develop** auswählen. Da der Branch **develop** der Standard-Branch ist, ist dies meist nicht notwändig
1. DropDown-Button für den Branch drücken
1. In die Textbox den Branchnamen eingeben. Beispiel: `features/issue_<Nummer des Issue>`
1. Enter drücken, um den Branch zu erzeugen

[*Offizielle Hilfe für das Erstellen eines Branch in GitHub*](https://help.github.com/articles/creating-and-deleting-branches-within-your-repository/#creating-a-branch)

#### Branch in Visual Studio erzeugen

1. Auswahl des Fensters *Team Explorer* (Ansicht -> Team Explorer)
1. Button *Branches* drücken
1. Doppelklick auf den Branch **develop**, um in diesen zu wechseln
1. Startseite des *Team Explorer* öffnen. Z.B. über das Haus-Symbol
1. Button *Sync* drücken
1. Drücken des oberen Links *Fetch*
1. Wenn Commits in *Incoming Commits* vorhanden sind, diese mit dem Link *Pull* unterhalb von *Incoming Commits* vom Remote holen
1. Startseite des *Team Explorer* öffnen. Z.B. über das Haus-Symbol
1. Button *Branches* drücken
1. Rechte Maustaste auf den Branch **develop** und den Menüeintrag *New Local Branch From...* drücken
1. Im darauffolgenden Menü den Namen des Branch vergeben. Beispiel: `features/issue_<Nummer des Issue>`
1. Mit Klick auf den Button *Create Branch* den Branch erzeugen
1. Startseite des *Team Explorer* öffnen. Z.B. über das Haus-Symbol
1. Button *Sync* drücken
1. Den Link *Publish* unterhalb von *Outgoing Commits* drücken

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

1. Auswahl des Fensters *Team Explorer* (Ansicht -> Team Explorer)
1. Button *Branches* drücken
1. Doppelklick auf den Branch **develop**, um in diesen zu wechseln
1. Startseite des *Team Explorer* öffnen. Z.B. über das Haus-Symbol
1. Button *Sync* drücken
1. Drücken des oberen Links *Fetch*
1. Wenn Commits in *Incoming Commits* vorhanden sind, diese mit dem Link *Pull* unterhalb von *Incoming Commits* vom Remote holen
1. Button *Branches* drücken
1. In den Branch wechseln, in den von **develop** gemerged werden soll.
1. Rechte Maustaste auf den Branch **develop** und Klick auf *Merge From...*
1. Im darauffolgenden Menü kontrollieren, ob in *Merge from branch* **develop** steht und in *Into current branch* der Branch, in dem **develop** gemerged werden soll. Beispiel: `features/issue_<Nummer des Issue>`
1. Klick auf *Merge*, um die Dateien zu mergen
1. Button *Sync* drücken
1. Wenn bei *Outgoing Commits* Commits vorhanden sind, diese mit dem unteren Link *Push* zum Remote laden

### Lokalen Branch und Remote nach einem Pull request löschen

#### Lokalen Branch und Remote nach einem Pull request in der Git Bash löschen

1. `git checkout develop`
1. `git branch -d <Names des Branches, der gelöscht werden soll>`
1. `git branch -d -r origin/<Names des Branches, der gelöscht werden soll>`

#### Lokalen Branch und Remote nach einem Pull request in Visual Studio löschen

1. Auswahl des Fensters *Team Explorer* (Ansicht -> Team Explorer)
1. Button *Branches* drücken
1. Doppelklick auf den Branch **develop**, um in diesen zu wechseln
1. Branch im angezeigten Baum löschen
1. Remote im Baum unterhalb von `remotes/origin` löschen

## Pull request erstellen

1. Auswählen des Reiters [*Pull requrst*](https://github.com/andrekirst/04_KataFahrplanauskunft/pulls)
1. Klick auf *New pull request*
1. Auswahlen des *base* (Standardmäßig **develop**), in dem die Änderungen eingespielt werden sollen
1. Auswählen des *compare*, aus dem die Änderungen kommen
1. Nachdem beide ausgewählt wurden, analysiert GitHub beide Stände und gibt die Commits und veränderten Dateien aus
1. Klick auf *Create pull request* führt dazu, dass weitere Informationen zum pull request angegeben werden können
1. Titel des Pull request festlegen. Dort nach folgendem Schema den Titel vergeben: `Pull request für #<Nummer des Issue> - <Titel des Issue>`
1. Beschreibung des Pull request festlegen. Dort nach folgendem Schema die Beschreibung vergeben: `Pull request für #<Nummer des Issue> - <Titel des Issue>`
1. Festlegen eines *Reviewers*, der den Pull request analysieren und bewertet
1. Den Pull request jemanden bei *Asignee* zuweisen
1. Bei *Labels* ein *Label* zuordnen. Hier werden die Labels zugeordnet, dem auch dem Issue zugeordnet sind
1. Bei *Milestone* einen Meilenstein zuordnen
1. Klick auf *Create pull request*, um den Pull request zu erstellen

**Information**: Solange der Pull request offen ist, können immer wieder neue Commits in den Branch, aus dem der Pull request entstanden ist, hochgeladen werden. Der letzte Commit löst das Ereignis aus, dass z.B. integrierte Builds neu erstellt werden.

[*Offizielle Hilfe für das erstellen eines Pull request in Github*](https://help.github.com/articles/creating-a-pull-request/)

[*Offizielle Hilfe für das reviewen eines Pull request auf GitHub*](https://help.github.com/articles/reviewing-changes-in-pull-requests/)

## Pull request mergen

1. Pull request auswählen
1. Klick auf *Squash and merge* - Dies beduetet, dass alle Commits in einen Commit zusammengefasst werden und auf den *base*, z.B. **develop**, gesetzt wird
1. Es erscheint ein Titel und Beschreibungsfeld.
1. Den Titel folgendermaßen beschreiben: `Merge features/issue_<Nummer des Issue> in **develop** mit Pull request #<Nummer des Pull request>`. Beispiel: `Merge features/issue_62 in **develop** mit Pull request #64`
1. Die Beschreibung kann leer bleiben
1. Klick auf *Confirm squash and merge*, um den Pull request-Vorgang abuischließen

**Wichtiger Hinweis**: Wenn der Pull request geschlossen und der dazugehörige Branch in GitHub gelöscht ist, diesen auch lokal löschen. **Nicht erneut pushen**. Siehe [Lokalen Branch und Remote nach einem Pull request löschen](branching_guide.md#lokalen-branch-und-remote-nach-einem-pull-request-löschen).

[*Offizielle Hilfe für das mergen eines Pull request in GitHub*](https://help.github.com/articles/merging-a-pull-request/)