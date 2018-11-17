using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Futter : MonoBehaviour {
    // Vorlage für das Futter
    public GameObject dasFutter;

    // Die Begrenzungen des Spielfelds
    public Transform Rand_links;
    public Transform Rand_rechts;
    public Transform Rand_oben;
    public Transform Rand_unten;

    // Prozedur für das Erzeugen des Futters
    void ErzeugeFutter()
    {
        // Zufallszahl zwischen dem linken und dem rechten Rand generieren
        int x = (int)Random.Range(Rand_links.position.x, Rand_rechts.position.x);

        // Zufallszahl zwischen dem unteren und dem oberen Rand generieren
        int y = (int)Random.Range(Rand_unten.position.y, Rand_oben.position.y);

        // Instanzieren des Futters an der Position x,y
        Instantiate(dasFutter, new Vector2(x, y), Quaternion.identity);
    }

    // Initialsierungen
    void Start () {
        InvokeRepeating("ErzeugeFutter", 2, 4);
    }

}
