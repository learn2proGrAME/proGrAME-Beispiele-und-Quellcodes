using System.Collections.Generic;
using UnityEngine;

public class Ossi : BouncyFant {
	// Anfangseinstellungen setzen 
	void Start ()
	{
		// Den Namen setzen
		Name = "Ossi";

		// Elefant mit RigidBody verlinken
		Elefantenkoerper = GetComponent<Rigidbody2D>();

		// Eine Referenz auf den Animator hinzufügen
		Animation = GetComponent<Animator>();

		// Setzen von Ellis Farbe auf einen leichten Rotton - Color(Rot, Grün, Blau)
		GetComponent<SpriteRenderer>().color = new Color(0.76f, 0.86f, 0.98f);
	}

	// Fixed Update wird immer in einem fixen Intervall aufgerufen.
	void FixedUpdate()
	{
		Gehen(Input.GetAxis("H-AchseOssi"));
		Springen(KeyCode.UpArrow);
	}
}
