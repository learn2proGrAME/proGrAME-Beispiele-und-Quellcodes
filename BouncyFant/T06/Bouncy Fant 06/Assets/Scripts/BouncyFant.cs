
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyFant : MonoBehaviour {
	protected Rigidbody2D Elefantenkoerper;
	protected Animator Animation;
	public float MaxGeschwindigkeit = 10;
	public string Name;
	public float Sprungkraft = 300;

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

	// Feststellen, ob der Elefant am Boden ist.
	protected bool AmBoden()
	{
		// Abfragen der Grenzen der Kollisionsobjekte
		Bounds Grenze = GetComponent<Collider2D>().bounds;
		float Spielraum = Grenze.size.y * 0.1f;

		// Berechnen einer Position die ein wenig unter der Kante des Kollisionsobjekts liegt
		// sonst kann es vorkommen, dass der Elefant nicht springen kann, wenn er ganz still steht.
		Vector2 v = new Vector2(Grenze.center.x, Grenze.min.y - Spielraum);

		// Kollisionsabfrage:  mittels einer Linie  
		RaycastHit2D Kollision = Physics2D.Linecast(v, Grenze.center);

		// "true" zurückgeben, wenn das Kollisionsobjekt nicht der Elefant selbst ist.
		return (Kollision.collider.gameObject != gameObject);
	}

	// Springen
	protected void Springen(KeyCode Taste)
	{
		// Herausfinden, ob der Elefant irgendwo steht, von wo er abspringen kann
		bool springenmoeglich = AmBoden();

		/* Wenn der Pfeil nach oben gedrückt wird und Springen möglich,
     * d.h. der Elefant hat etwas, von wo er aus wegspringen kann,
     * dann bekommt der Elefantenkörper einen Impuls (Addforce),
     * entsprechend der von uns gewählten Sprungkraft
     */
		if (Input.GetKey(Taste) && springenmoeglich)
			Elefantenkoerper.AddForce(Vector2.up * Sprungkraft);

		/*
     * Wenn der Elefant gerade springt, dann springen auf nicht möglich setzen.
     * Nicht = Rufzeichen(!).
     */
		Animation.SetBool("Springen", !springenmoeglich);
	}
}


