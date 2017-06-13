# Releasenotes für Version 1.0

## Features

* #14 - Objekt Linie aus dem Brainstorming in der C#-Solution erstellen `feature`
* #10 - Konvertierer für die Uhrzeit `feature`
* #16 - Objekt Haltestelle aus dem Brainstorming in der C#-Solution erstellen `feature`
* #19 - Objekt HaltestelleFahrplanEintrag aus dem Brainstorming in der C#-Solution erstellen `feature`
* #24 - Objekt Streckenabschnitt aus dem Brainstorming in der C#-Solution erstellen `feature`
* #26 - Objekt Verbindungsanfrage aus dem Brainstorming in der C#-Solution erstellen `feature`
* #28 - Erstellung eines Lademechanismus für das Objekt Haltestelle `feature`
* #34 - Erstellung eines Lademechanismus für das Objekt Linie `feature`
* #36 - Erstellung eines Lademechanismus für das Objekt Streckenabschnitt `feature`
* #39 - Erstellung eines Lademechanismus für das Objekt HaltestelleFahrplanEintrag `feature`
* #60 - ToString-Methode für Haltestelle implementieren `feature`
* #56 - Objekt Hierarchie-Objekt erstellt sowie liefere die Hierarchie von Umstiegspunkten für eine Haltestelle `feature`
* #57 - Sortierung einer Liste von einer Haltestelle zu einer anderen Haltestelle `feature`
* #69 - Vereinheitlichung von Equals `feature`
* #55 - Berechnung der Gesamtfahrtdauer von einer Haltestelle zu einer anderen Haltestelle `feature`
* #70 - Vergleichsoperatoren == und != implementieren `feature`
* #80 - Bericht für Testabdeckung erstellen und in Build-Prozess implementieren `feature`, `umgebung`
* #84 - StyleCop in den Build-Prozess einbinden `feature`, `umgebung`
* #85 - Deployment konfigurieren `feature`, `umgebung`
* #82 - Update der NuGet-Packages `umgebung`, `dokumentation`
* #83 - Ermittlung der nächsten Abfahrtszeit `feature`
* #92 - Dokumentation als PDF oder HTML erzeugen und im Deployment einschließen `feature`, `umgebung`
* #100 - Streckenabschnitte haben nur noch eine Linie `feature`, `Testdaten`
* #93 - Überarbeitung Releasenotes und Einbau in Deployment-Prozess `feature`, `umgebung`
* #103 - Entfernen der Vergleiche von strings, anstatt des richtigen Objektes `überarbeiten`
* #107 - ToString-Methode für Objekte Linie `feature`

## Bugfixes

* #67 - Fehler in Haltestelle.Equals, wenn das Vergleichsobjekt nicht Haltestelle ist `bug`
* #86 - Build-Prozess fehlerhaft, wenn es außerhalb eines Pull request stattfindet `bug`, `umgebung`
* #90 - Fehler beim Upload für SFTP, BinTray falscher Branch und falsche Konfiguration `bug`, `umgebung`
* #98 - Fehler bei der Konvertierung der Zeit von Zahl zu Text, wenn die Zahl den Wert 800 hat `bug`