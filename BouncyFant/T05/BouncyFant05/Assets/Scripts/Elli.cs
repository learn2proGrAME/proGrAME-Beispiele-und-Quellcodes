using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elli : BouncyFant {
    // Anfangseinstellungen setzen 
    void Start ()
    {
        // Elefant mit RigidBody verlinken
        Elefantenkoerper = GetComponent<Rigidbody2D>();

        // Eine Referenz auf den Animator hinzufügen
        Animation = GetComponent<Animator>();

        // Setzen von Ellis Farbe auf einen leichten Rotton - Color(Rot, Grün, Blau)
        GetComponent<SpriteRenderer>().color = new Color(0.94f, 0.85f, 0.85f);
    }

    // Fixed Update ruft Update immer in einem fixen Intervall auf.
    void FixedUpdate()
    {
        Gehen(Input.GetAxis("H-AchseElli"));
    }
}

