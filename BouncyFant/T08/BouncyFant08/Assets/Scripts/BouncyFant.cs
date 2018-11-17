using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BouncyFant : MonoBehaviour
{
    protected Rigidbody2D Elefantenkoerper;
    protected Animator Animation;
    public string Name;
    public float maxGeschwindigkeit = 10;
    public float Sprungkraft = 300;
    protected int Punkte;
    public Text PunkteText;
    public Text GewinnerText;

    // Prozedur zum Bewegen des Elefanten
    protected void Gehen(float h)
    {
        /* Geschwindigkeit setzen
            * Die Geschwindigkeit ergibt sich aus aus der Eingabe für die horizontale
            * Geschwindigkeit und der maximalen Höchstgeschwindigkeit des Elefanten
            */
        Elefantenkoerper.velocity = new Vector2(h * maxGeschwindigkeit, Elefantenkoerper.velocity.y);

        /* Blickrichtung des Elefanten bestimmen.
            * Der Vektor für die Blickrichtung soll ein Vektor sein,
            * der sich aus dem Vorzeichenrückgabewert (-1 oder +1) 
            * der horizontalen Bewegungsrichtung (Mathf.Sign(h)) und 
            * dem Skalierungsfaktor auf der x-Achse ergibt.
            * Der y-Wert des Elefanten bleibt gleich, daher nehmen wir nur den 
            * Skalierungsfaktor "transform.localScale.y".       
            */
        if (h != 0)
            transform.localScale = new Vector2(Mathf.Sign(h) *
                Mathf.Abs(transform.localScale.x), transform.localScale.y);

        /* Die Geschwindigkeit wird auf den Absolutbetrag der horizontalen
            * Bewegung gesetzt. Negative Geschwindigkeit gibt es nicht.
            * z.B. wenn ich mit dem Auto im Rückwärtsgang 10km/h fahre, fahre ich 
            * 10km/h in einer Rückwärtsbewegung und nicht "-10km/h" ;)
            */
        Animation.SetFloat("Geschwindigkeit", Mathf.Abs(h));
    }

    // Feststellen, ob der Elefant am Boden ist.
    protected bool amBoden()
    {
        // Abfragen der Grenzen der Kollisionsobjekte
        Bounds Grenze = GetComponent<Collider2D>().bounds;
        float Spielraum = Grenze.size.y * 0.1f;

        /* Berechnen einer Position die ein wenig unter der Kante des
         * Kollisionsobjekts liegt sonst kann es vorkommen, dass der 
         * Elefant nicht springen kann, wenn er ganz still steht.
         */
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
        bool springenmoeglich = amBoden();

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

    // Neuladen der Szene nach einer Wartezeit
    void NeuLaden()
    {
        SceneManager.LoadScene("sceneBouncyFant");
        Time.timeScale = 1.0f;
    }

    // Beim Berühren des Pilzes die Punkte erhöhen und einen Gewinntext ausgeben.
    void OnCollisionEnter2D(Collision2D col)
    {
        // Falls das Kollisionsobjekt der Pilz ist ...    
        if (col.gameObject.name == "Pilz")
        {
            Punkte++; // Erhöhen des Punktestands um 1
            // Punktestand dauerhaft speichern,
            // damit beim Neuladen der Szene der Punktestand nicht verloren geht
            PlayerPrefs.SetInt("Punkte" + Name, Punkte);
            // Name und Punkte anzeigen
            PunkteText.text = Name + " " + Punkte.ToString(); 
            GewinnerText.text = Name + "  W I N S !"; // Gewinnermeldung 
            if (Punkte >= 10)
            {
                GewinnerText.text = "L E V E L   C O M P L E T E D"; // Geschafft
                // Rücksetzen des Punktestands für alle Elefanten auf 0 
                Punkte = 0;
                PlayerPrefs.SetInt("PunkteElli", Punkte);
                PlayerPrefs.SetInt("PunkteOssi", Punkte);
            }
            // Zerstören des Pilzes
            Destroy(col.gameObject);
            // Planen des Neuladens der Szene nach 3 Sekunden Wartezeit
            Invoke("NeuLaden", 3);
        }
    }

    // Rücksetzen der Levelpunktestände beim Beenden des Spiels
    void OnApplicationQuit()
    {
        // Rücksetzen des Punktestands für alle Elefanten auf 0 
        PlayerPrefs.SetInt("PunkteElli", 0);
        PlayerPrefs.SetInt("PunkteOssi", 0);
    }
}
