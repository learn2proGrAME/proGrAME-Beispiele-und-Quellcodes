using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class RoteSchlange : Schlange {

    // Use this for initialization
    void Start()
    {
        // Aufrufen der Bewegungsmethode der Schlange
        // Parameter: Name, Startzeit, Wiederholungsrate (Angaben in Sekunden)
        InvokeRepeating("Bewegen", 0.2f, 0.2f);
    }


    // Update is called once per frame
    void Update()
    {
        // Tasteneingaben fuer die Bewegung der Schlange abfragen
        // In Klammer werden die gewuenschten Tasten zur Steuerung der Schlage eingegeben
        UpdateTasteneingabe(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.DownArrow, KeyCode.UpArrow);
    }
}
