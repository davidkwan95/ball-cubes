using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public float moveSpeed = 8.0f;
	public Material completedPlatformMaterial;
	public bool touched;

	private Vector3 velocity;
	private Transform sphere;
	private GameObject gameController;

	// Use this for initialization
	void Start () {
		sphere = GameObject.Find ("Sphere").transform;
		gameController = GameObject.Find ("GameController");
	}

	void OnCollisionEnter(){
		if (!touched) {
			touched = true;
			gameController.GetComponent<GameController> ().score += 1;
			GetComponent<Renderer>().material = completedPlatformMaterial;
			gameController.GetComponent<GameController> ().currentPlatform = this.gameObject;
			gameController.GetComponent<GameController>().SpawnNewPlatform ();

			// Play the platform hit sound
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play ();
		}
	}

	// Update is called once per frame
	void Update () {
		velocity = sphere.forward * -moveSpeed;
		GetComponent<Rigidbody> ().velocity = velocity;
	}
}
