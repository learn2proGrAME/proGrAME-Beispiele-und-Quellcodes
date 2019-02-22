using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muell : MonoBehaviour {

	// Konstanten für die Maximalanzahl der Kisten definieren
	const int MAXANZAHLKISTEN = 30;
	const int MAXANZAHLKUGELN = 45;

	// Zählvariablen Kisten
	int Anzahlkisten = 0, Anzahlkugeln = 0;

	// Erstellen der GameObjekte für Kisten und Kugeln
	public GameObject Kiste;
	public GameObject Kugel;


	// Initialisierungen
	void Start()
	{
		InvokeRepeating("ErzeugeKiste", 1, 1);
		InvokeRepeating("ErzeugeKugel", 0.5f, 1);
	}

	// Erzeuge an einer Zufallsposition eine Kugel
	void ErzeugeKugel()
	{
		if (Anzahlkugeln < MAXANZAHLKUGELN)
		{
			// Zufallszahl zwischen dem linken und dem rechten Rand generieren
			int x = (int)Random.Range(-13, 13);

			// Instanzieren der Kugel an der Position x,y
			Instantiate(Kugel, new Vector2(x, 8.0f), Quaternion.identity);

			// Anzahl der Kugeln um 1 erhöhen
			Anzahlkugeln++;
		}
	}
	// Erzeuge an einer Zufallsposition eine Kiste
	void ErzeugeKiste()
	{
		if (Anzahlkisten < MAXANZAHLKISTEN)
		{
			// Zufallszahl zwischen dem linken und dem rechten Rand generieren
			int x = (int)Random.Range(-13, 13);

			// Instanzieren der Kiste an der Position x,y
			Instantiate(Kiste, new Vector2(x, 8.0f), Quaternion.identity);

			// Anzahl der Kugeln um 1 erhöhen
			Anzahlkisten++;
		}
	}
}
