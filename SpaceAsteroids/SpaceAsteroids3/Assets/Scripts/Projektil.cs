using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektil : MonoBehaviour {

    //Referenz auf den Rigidbody
	private Rigidbody rb;

    //Geschwindigkeit des Projektils
	public float geschwindigkeit;

    //Start() wird von Unity aufgerufen, wenn das Object erzeugt wird.
    void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3(0,0,geschwindigkeit);
	}
}
