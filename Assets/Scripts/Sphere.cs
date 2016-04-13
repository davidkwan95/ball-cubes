using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {

	public Vector3 jumpForce = new Vector3 (0, 350, 0);
	public float groundPosition = 0.9f;
	public float rotationSpeed = 60f;
	private bool onGround = false;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(){
		onGround = true;
	}
	void OnCollisionExit(){
		onGround = false;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("space") && onGround){
			GetComponent<Rigidbody>().AddForce(jumpForce);
		}

		transform.Rotate (new Vector3 (0, 1, 0) * Input.GetAxis ("Horizontal") * Time.deltaTime * rotationSpeed);
		float rotationY = transform.rotation.eulerAngles.y;
		if (rotationY >= 270)
			rotationY = Mathf.Max (360 - 45, rotationY);
		else
			rotationY = Mathf.Min (45, rotationY);
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, rotationY, transform.rotation.eulerAngles.z);
	}
}
