using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ossi : BouncyFant {
    // Anfangseinstellungen setzen 
    void Start()
    {
        // Festlegen des Namens
        Name = "Ossi";

        // Elefant mit RigidBody verlinken
        Elefantenkoerper = GetComponent<Rigidbody2D>();

        // Eine Referenz auf den Animator hinzufügen
        Animation = GetComponent<Animator>();

        // Setzen von Ossis Farbe auf einen leichten Blauton - Color(Rot, Grün, Blau)
        GetComponent<SpriteRenderer>().color = new Color(0.76f, 0.86f, 0.98f);

        // Laden des Punktestandes aus den Playerprefs und Anzeigen
        Punkte = PlayerPrefs.GetInt("Punkte" + Name);
        PunkteText.text = Name + " " + Punkte.ToString();
    }

    // Fixed Update ruft Update immer in einem fixen Intervall auf.
    void FixedUpdate()
    {
        Gehen(Input.GetAxis("H-AchseOssi"));
        Springen(KeyCode.UpArrow);
    }
}


