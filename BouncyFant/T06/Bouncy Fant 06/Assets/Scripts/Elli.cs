using System.Collections.Generic;
using UnityEngine;

public class Elli : BouncyFant {
	// Anfangseinstellungen setzen 
	void Start ()
	{
		// Den Namen setzen
		Name = "Elli";

		// Elefant mit RigidBody verlinken
		Elefantenkoerper = GetComponent<Rigidbody2D>();

		// Eine Referenz auf den Animator hinzufügen
		Animation = GetComponent<Animator>();

		// Setzen von Ellis Farbe auf einen leichten Rotton - Color(Rot, Grün, Blau)
		GetComponent<SpriteRenderer>().color = new Color(0.96f, 0.85f, 0.8f);
	}

	// Fixed Update wird immer in einem fixen Intervall aufgerufen.
	void FixedUpdate()
	{
		Gehen(Input.GetAxis("H-AchseElli"));
		Springen(KeyCode.W);
	}
}
