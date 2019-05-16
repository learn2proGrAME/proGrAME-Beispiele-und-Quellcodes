using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In dieser statischen Klasse werden die Spielfeldgrenzen gespeichert, damit andere Objekte und Skripte darauf zugreifen können.
[System.Serializable]
public static class SpielfeldGrenzen
{
    public static float minX = -5.3f;
    public static float maxX = 5.3f;
    public static float minZ = -2.7f;
    public static float maxZ = 15.0f;
}
