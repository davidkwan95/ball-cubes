using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scoreUI : MonoBehaviour {

	public GameObject gameController;
	public Text textComponent;

	private int currentScore;
	private int highScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentScore = gameController.GetComponent<GameController> ().score;
		highScore = gameController.GetComponent<GameController> ().highScore;
		textComponent.text = "Score: " + currentScore + " (Best: " + highScore + ")";
	}
}
