using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	//  Die Zeit in Sekunden, die vergeht bevor der nächste Asteroid erzeugt wird
	public float asteroidSpawnZeit;

	//  Der Zeitpunkt an dem der nächste Asteroid erzeugt werden soll.
	private float naechsterSpawn;

	//  Eine Referenz auf das GameObject des Asteroiden
	public GameObject asteroid;

    //  Referenzen auf die UserInterface-Texte für Punktestand, Restart und GameOver
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    //  Gibt an ob das Spiel zu Ende ist oder noch läuft.
    private bool gameOver;

    //  Der momentane Punktestand
    private int punkteStand;

    //  Soundquelle von der aus, alle Sounds des Spiels abgespielt werden.
    private AudioSource soundQuelle;

    //  Start() wird von Unity aufgerufen, wenn das Object erzeugt wird.
    void Start () {
		//  Der erste Asteroid soll 3 Sekunden nach Spielstart erzeugt werden
		naechsterSpawn = Time.time + 3;
        
        punkteStand = 0;
        AktualisierePunktestandText();
        
        //  Setze den Gameover- und Restarttext auf einen leeren String.
        gameOverText.text = "";
        restartText.text = "";

        // Setze die Referenz auf die Audiosource
        soundQuelle = GetComponent<AudioSource>();

    }
	
	// Update() wird von Unity in jedem Frame einmal aufgerufen
	void Update () {

        //  Wenn das Spiel zu Ende und die "r"-Taste gedrückt wird, starte das Spiel neu.
        if(gameOver && Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Level1");
        }

        //  Wenn die aktuelle Spielzeit größer ist, als naechsterSpawn. Erzeuge einen neuen Asteroiden und setze nächsterSpawn neu.
        //  (Time.time ist eine Variable der Unity-Engine. Sie speichert die aktuelle Spielzeit in Sekunden)
		if (Time.time >= naechsterSpawn) {
			ErzeugeAsteroiden ();
			naechsterSpawn = Time.time + asteroidSpawnZeit;
		}
	}
	
    //  Diese Funktion erzeugt einen neuen Asteroiden an einer zufälligen Position am oberen Spielfeldrand
	private GameObject ErzeugeAsteroiden(){
        
        //  Berechne die zufällige Position
		Vector3 spawnPosition = new Vector3 (Random.Range(SpielfeldGrenzen.minX, SpielfeldGrenzen.maxX),0,SpielfeldGrenzen.maxZ + 3);

        //  Die Rotation mit der das Objekt erzeugt werden soll. (Quaternion.Identity bedeutet, dass das Objekt nicht gedreht ist)
        Quaternion spawnRotation = Quaternion.identity;

        //  Erzeuge einen neuen Asteroiden und gib eine Referenz auf diesen zurück
		return Instantiate (asteroid, spawnPosition, spawnRotation);
	}

    //  Diese Funktion aktualisiert den angezeigten Text des Punktestands. 
    //  Sie muss immer aufgerufen werden, nachdem sich die Punkte geändert haben.
    private void AktualisierePunktestandText()
    {
        scoreText.text = "Score: " + punkteStand;
    }

    //  Diese Funktion erhöht den Punktestand und aktualisiert den Text des Punktestands.
    public void ErhoehePunktestand(int punkte)
    {
        punkteStand += punkte;
        AktualisierePunktestandText();
    }

    //  Diese Funktion setzt gameOver auf true und erzeugt den Text der bei Gameover angezeigt werden soll.
    //  Sie muss aufgerufen wenn das Raumschiff des Spielers/der Spielerin zerstört wurde und somit das Spiel zu Ende ist.
    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over";
        restartText.text = "Press 'r' for Restart";
    }

    // Diese Funktion spielt einen sound mit angegebener Lautstärke ab. Die Lautstärke muss zwischen 0 und 1 sein.
    public void SpieleSound(AudioClip sound, float lautstaerke)
    {
        soundQuelle.PlayOneShot(sound, lautstaerke);
    }
}
