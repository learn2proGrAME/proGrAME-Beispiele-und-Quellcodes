using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GrueneSchlange : Schlange {

	// Use this for initialization
	void Start () {
        // Aufrufen der Bewegungsmethode der Schlange
        // Parameter: Name, Startzeit, Wiederholungsrate (Angaben in Sekunden)
        InvokeRepeating("Bewegen", 0.2f, 0.2f);

        // Farbe der Schlange auf gruen setzen. 
        // Die Farbe der Vorlage ist ja weiss
        Farbe = Color.green;
    }
	
	// Update is called once per frame
	void Update () {
        // Tasteneingaben fuer die Bewegung der Schlange abfragen
        // In Klammer werden die gewuenschten Tasten zur Steuerung der Schlage eingegeben
        UpdateTasteneingabe(KeyCode.A, KeyCode.D, KeyCode.S, KeyCode.W);
	}
}
