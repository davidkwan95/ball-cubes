using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Play : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Button> ().onClick.AddListener (PlayGame);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayGame(){
		SceneManager.LoadScene(1);
	}
}
