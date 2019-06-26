using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	//Referenz auf den Rigidbody
	private Rigidbody rb;

	//Die Geschwindigkeit mit der die Asteroiden fliegen
	public float geschwindigkeit;

	//Rotationsgeschwindigkeit
	public float rotationsGeschwindigkeit;

	//Referenz auf den GameController
	private GameController gameController;

	//Der Sound der bei der Zerstörung eines Asteroiden abgespielt wird.
	public AudioClip explosionsSound;


	//Start() wird von Unity aufgerufen, wenn das Object erzeugt wird.
	void Start(){

		//Setze die Referenz auf den Rigidbody
		rb = GetComponent<Rigidbody> ();

		//Setze die Geschwindigkeit
		rb.velocity = new Vector3 (0, 0, -geschwindigkeit);

		//Setze die Rotationsgeschwindigkeit
		rb.angularVelocity = Random.insideUnitSphere * rotationsGeschwindigkeit;

		//Setze GameController-Referenz
		gameController = FindeGameController();
	}

	//OnTriggerEnter() wird von Unity aufgerufen, wenn ein anderer Collider mit dem eigenen Collider kollidiert.
	void OnTriggerEnter(Collider other)
	{
		//Überprüfe ob das andere Objekt ein Geschoß ist.
		if (other.tag == "Geschoß")
		{
			//Lösche das Geschoß
			Destroy(other.gameObject);

			//Lösche den Asteroiden selbst
			Destroy(gameObject);

			//erhöhe den Punktestand
			gameController.ErhoehePunktestand(10);

			//Spiele den explosionsSound ab
			gameController.SpieleSound(explosionsSound, 0.2f);
		}
	}

	// Diese Methode sucht nach dem GameController
	// Wenn einer gefunden wird, wird eine Referenz darauf zurückgegeben.
	// Wenn kein GameController vorhanden ist, wird das Spiel mit einer Fehlermeldung beendet.
	private GameController FindeGameController() {

		GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		//Befindet sich kein GameController im Spiel ist gameControllerObject == null
		if (gameControllerObject != null)
		{
			return gameControllerObject.GetComponent<GameController>();
		}
		else
		{
			Debug.LogError("Cannot find GameController Script");
			Application.Quit();
			return null;
		}
	}
}