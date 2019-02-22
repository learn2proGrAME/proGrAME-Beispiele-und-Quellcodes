using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielfeld : MonoBehaviour {
	public GameObject Boden;

	// Initialisierungen
	void Start ()
	{
		// In dieser Schleife wird der Boden gezeichnet
		for (int i = -20; i <= 20; i++) ZeichnenBoden(i);
	}

	// In dieser Prozedur wird der Boden gezeichnet
	public void ZeichnenBoden(int x)
	{
		Instantiate(Boden, new Vector3(x * 0.75f, -6.81f, -4), Quaternion.identity);
	}
}