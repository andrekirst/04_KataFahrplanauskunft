# Zeit

## Beschreibung

Die Zeit, also z.B. eine Abfahrtszeit, wird als Ganzzahl gespeichert. Wenn es "08:00" ist, beträgt der Ganzzahl-Wert 480.

Der Minimalwert beträgt 0 und der Maximalwert 1439.

## Berechnung

### Von Ganzzahl zu Test

Die Zahl wird mit 60 gnzzahlig geteilt. Dieser Wert entspricht der Stunde. Der Divisionsrest entspricht den Minuten.

### Von Text zu Ganzzahl

Es wird die Stunde mit 60 multipliziert. Die Minuten werden dann noch zu der Multiplikation addiert.

## Beispiele

* 480 = "08:00"
* "04:30" = 270
* "23:59" = 1439
* 719 = "11:59"