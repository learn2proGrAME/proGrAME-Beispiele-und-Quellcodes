using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Dieses Script löscht alle Gameobjects, die den Collider des Aufrufenden Objekts verlassen.
//  Das Script ist an einen Collider angehängt, der über das ganze Spielfeld geht.
//  Es löscht alle Gameobjects die das Spiel verlassen

//  In diesem Spiel benötigen wir dieses Script, um all die Asteroiden und Lasergeschoße zu löschen, die nicht mehr im Spielfeld sind.
//  Diese würden sonst unnötig Speicher und Rechenzeit verbrauchen und irgendwann zu einem Spielabsturz oder Ruckeln führen.

public class LoescheBeiVerlassen : MonoBehaviour {

    // OnTriggerExit wird von Unity aufgerufen, wenn ein anderes Objekt mit einem Collider den Collider des Objekts verlässt an welchen dieses Skript angehängt ist.
	void OnTriggerExit(Collider other){
		Destroy (other.gameObject);
	}
}
