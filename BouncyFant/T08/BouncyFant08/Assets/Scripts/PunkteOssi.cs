using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunkteOssi : MonoBehaviour {

    // Setzen des Anfangspunktestands auf 0
    public static int Punkte = 0;
    public Text PunkteText;

    void Start()
    {
        PunkteText = GetComponent<Text>();
    }

    void Update()
    {
        PunkteText.text = "Ossi: " + Punkte;
    }
}
