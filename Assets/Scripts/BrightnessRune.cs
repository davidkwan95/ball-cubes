using UnityEngine;
using System.Collections;

public class BrightnessRune : MonoBehaviour {

	public Transform DirectionalLight;
	public float brightness = 25.0f;

	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter(){
		DirectionalLight = GameObject.Find ("Directional Light").transform;
		DirectionalLight.Rotate (brightness, 0, 0);
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {

	}
		
}
