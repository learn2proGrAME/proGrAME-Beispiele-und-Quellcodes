using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Schlange : MonoBehaviour {
    /* Private Variablen */
    List<Transform> Koerpersegment = new List<Transform>();

    /* Geschützte Variablen, 
     * auf die jedoch in der abgeleiteten Klasse 
     * zugegriffen werden kann*/
    protected bool hatgefressen = false;

    /* Öffentliche Variablen 
     Öffentliche Variablen können entweder im Quelltext 
     der abgeleiteten Klasse oder direkt im Unity Inspector 
     in den Einstellungen für das Script bearbeitet werden */
    public Color Farbe = Color.yellow;
    public Text Infotext;
    // Am Anfang bewegt sich die Schlange von links nach rechts
    public Vector2 Richtung = Vector2.right;
    public GameObject Schlangenkoerper;


    public void OnTriggerEnter2D(Collider2D Kollisionsobjekt)
    {
        if (Kollisionsobjekt.name.StartsWith("Futter_Vorlage"))
        {
            hatgefressen = true;

            // Das Futter entfernen
            Destroy(Kollisionsobjekt.gameObject);
        }
        else
        {
            Infotext.text = "G a m e  O v e r !";
            Time.timeScale = 0;
        }
    }

    void Bewegen()
    {
        Vector2 alteposition = transform.position;

        // Setzen der Farbe des Schlangenkopfes
        // GetComponent<SpriteRenderer>().color = Farbe;
        // Setzen der Farbe des Schlangenkoerpers
        Schlangenkoerper.GetComponent<SpriteRenderer>().color = Farbe;

        // Die Schlange in die entsprechende Richtung bewegen
        transform.Translate(Richtung);
        
        if (hatgefressen)
        {
            // Hinzufuegen eines Schlangekoerpersegements
            GameObject go = (GameObject)Instantiate(Schlangenkoerper,
                                                    alteposition,
                                                    Quaternion.identity);

            // Einfuegen des neuen Schlangensegments in die Luecke
            Koerpersegment.Insert(0, go.transform);
            hatgefressen = false;
        }
        // Ansonsten: Wenn die Schlange aus mehr als nur dem Kopf besteht 
        // wird der clevere Bewegungsalgorithmus gestartet.
        else if (Koerpersegment.Count > 0)
        {
            // Das letzte Segment des Schlange an der alten Position des Kopfes einfuegen
            Koerpersegment.Last().position = alteposition;

            // Letzes Segment in die Luecke kopieren und danach loeschen
            Koerpersegment.Insert(0, Koerpersegment.Last());
            Koerpersegment.RemoveAt(Koerpersegment.Count - 1);
        }

    }

    // Initialisierungen
    void Start()
    {

    }

    // Aktualsieren etwaiger Tastatureingaben
    public void UpdateTasteneingabe(KeyCode links, KeyCode rechts, KeyCode unten, KeyCode oben)
    {
        if (Input.GetKey(links)) Richtung = Vector2.left;
        else if (Input.GetKey(rechts)) Richtung = Vector2.right;
        else if (Input.GetKey(unten)) Richtung = Vector2.down;
        else if (Input.GetKey(oben)) Richtung = Vector2.up;

        // Cheat fuer Wachsen ohne zu Fressen
        if (Input.GetKey(KeyCode.F2)) hatgefressen = true;
    }
}
