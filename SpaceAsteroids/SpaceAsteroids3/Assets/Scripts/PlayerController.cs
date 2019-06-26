using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
	//  Referenz auf den Rigidbody
	private Rigidbody rb;

    // Sound für den laser
    public AudioClip laserSound;

    // Sound für die Explosion wenn Player zerstört wird
    public AudioClip explosionsSound;

	// Die Position an der die Lasergeschoße erzeugt werden sollen
	public Transform positionLaserKanone;

	// Das Gameobjekt für das Lasergeschoß
	public GameObject laserGeschoß;

	// Referenz auf den GameController
	public GameController gameController;

	//  Die minimale Zeit die vergehen muss, bevor man noch einmal schießen kann
	public float nachladeZeit;

	//  Der nächste Zeitpunkt ab dem wieder geschossen werden kann.
	private float zeitpunktNaechsterSchuss;
    
	//  Die maximale Geschwindigkeit des Spielers/der Spielerin.
	public float maxGeschwindigkeit;

    //  Start() wird von Unity aufgerufen, wenn das Object erzeugt wird.
    void Start()
    {
        //  Setze die Referenz auf den Rigidbody
        rb = GetComponent<Rigidbody> ();

        //  Setze den Zeitpunkt ab dem geschossen werden kann auf die aktuelle Spielzeit
        zeitpunktNaechsterSchuss = Time.time;
    }

    // Update() wird von Unity in jedem Frame einmal aufgerufen
    void Update(){
        //  Wenn der Fire-Button gedrückt wird, schieße!
		if(Input.GetButton("Fire1")){
			FeuereLaser();
		}
	}

    //  FixedUpdate() wird von Unity in fixen Zeitabständen aufgerufen.
    //  Code der mit der Unity-Physikengine zu tun hat, sollte immer in FixedUpdate() und nicht in Update() stehen.
    void FixedUpdate()
    {
		//Setze die Geschwindigkeit
        float geschwindigkeitHorizontal = Input.GetAxis("Horizontal") * maxGeschwindigkeit;
        float geschwindigkeitVertikal = Input.GetAxis("Vertical") * maxGeschwindigkeit;
        rb.velocity = new Vector3(geschwindigkeitHorizontal, 0.0f, geschwindigkeitVertikal);


        // Stelle sicher, dass sich die Spielerin/der Spieler nicht außerhalb des Spielfelds befindet.
        float posX = Mathf.Clamp(rb.position.x, SpielfeldGrenzen.minX, SpielfeldGrenzen.maxX);
        float posZ = Mathf.Clamp(rb.position.z, SpielfeldGrenzen.minZ, SpielfeldGrenzen.maxZ);
        rb.position = new Vector3(posX, 0.0f, posZ);
	
		//  Drehe das Raumschiff zur Seite, abhängig von der horizontalen Geschwindigkeit;
		rb.rotation = Quaternion.AngleAxis(-90, new Vector3(1,0,0)) * Quaternion.AngleAxis (35 * Input.GetAxis ("Horizontal"), new Vector3 (0, 1, 0));

	}

    //  Diese Funktion erzeugt ein neues Lasergeschoß falls (aufgrund der Nachladezeit) möglich.
	private void FeuereLaser(){
		if (zeitpunktNaechsterSchuss < Time.time) {
			Instantiate (laserGeschoß, positionLaserKanone.position, Quaternion.identity);
			zeitpunktNaechsterSchuss = Time.time + nachladeZeit;
		}
	}

    //OnTriggerEnter() wird von Unity aufgerufen, wenn ein anderer Collider mit dem eigenen Collider kollidiert.
    private void OnTriggerEnter(Collider other)
    {
        // Überprüfe ob das Kollisionsobjekt ein Hindernis ist.
        if(other.tag == "Hindernis")
        {
            // Spiele den Explosionssound ab
            gameController.SpieleSound(explosionsSound, 1.0f);

            // Gib dem GameController bescheid, dass das Spiel zu ende ist.
            gameController.GameOver();

            // Lösche das PlayerObject
            Destroy(gameObject);
        }
    }

   
}