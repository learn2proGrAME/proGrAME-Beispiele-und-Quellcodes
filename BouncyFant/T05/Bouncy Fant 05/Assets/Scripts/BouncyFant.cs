
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyFant : MonoBehaviour {
	protected Rigidbody2D Elefantenkoerper;
	protected Animator Animation;
	public float MaxGeschwindigkeit = 10;
	public string Name;

	// Prozedur zum Bewegen des Elefanten
	protected void Gehen(float h)
	{
		/* Geschwindigkeit setzen
            * Die Geschwindigkeit ergibt sich aus aus der Eingabe für die horizontale
            * Geschwindigkeit und der maximalen Höchstgeschwindigkeit des Elefanten
            */
		Elefantenkoerper.velocity = new Vector2(h * MaxGeschwindigkeit, Elefantenkoerper.velocity.y);

		/* Blickrichtung des Elefanten bestimmen.
            * Der Vektor für die Blickrichtung soll ein Vektor sein,
            * der sich aus dem Vorzeichenrückgabewert (-1 oder +1) 
            * der horizontalen Bewegungsrichtung (Mathf.Sign(h)) ergibt.
            * Der y-Wert des Elefanten bleibt gleich, daher transform.localScale.y.       
            */
		if (h != 0) transform.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);

		/* Die Geschwindigkeit wird auf den Absolutbetrag der horizontalen
            * Bewegung gesetzt. Negative Geschwindigkeit gibt es nicht.
            * z.B. wenn ich mit dem Auto im Rückwärtsgang 10km/h fahre, fahre ich 
            * 10km/h in einer Rückwärtsbewegung und nicht "-10km/h" ;)
            */
		Animation.SetFloat("Geschwindigkeit", Mathf.Abs(h));
	}
}


