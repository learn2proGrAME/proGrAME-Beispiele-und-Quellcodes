using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	// Deklariere hier alle benötigten Variablen



    //Start() wird von Unity aufgerufen, wenn das Object erzeugt wird.
    void Start(){
		
        
    }

    //OnTriggerEnter() wird von Unity aufgerufen, wenn ein anderer Collider mit dem eigenen Collider kollidiert.
    void OnTriggerEnter(Collider other)
    {
        
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