using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform target;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, target.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
	}
}
