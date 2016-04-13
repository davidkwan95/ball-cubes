using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public int score;
	public float prevAngle;
	public GameObject currentPlatform, prevPlatform;
	public GameObject platform;
	public Transform sphere;
	public float deathHeight = 0.5f;
	public GameObject GameOverCanvas;
	public GameObject darknessRune;
	public GameObject lightRune;

	private bool isGameOver;
	public int highScore;

	// Use this for initialization
	void Start () {
		score = 0;
		highScore = PlayerPrefs.GetInt ("highscore", 0);
		isGameOver = false;
		prevAngle = 0;
	}

	public void SpawnNewPlatform(){
		GameObject instance = Instantiate (platform);

		// Random the distance between 16.0f and 20.0f and degree
		float dist  = Random.Range(16.0f, 20.0f);
		float angle = Random.Range (-1.0f, 1.0f);
		if (angle - prevAngle < -0.5f) {
			angle = -0.5f - angle;
		} else if (angle - prevAngle > 0.5f) {
			angle = 0.5f - angle;
		}
		prevAngle = angle;

		Debug.Log (angle + " " + dist);

		instance.transform.position = new Vector3 (currentPlatform.transform.position.x +  dist * Mathf.Sin (angle), 
													currentPlatform.transform.position.y, 
													currentPlatform.transform.position.z +  dist * Mathf.Cos (angle));

		Destroy (prevPlatform);
		prevPlatform = currentPlatform;

		// Spawn rune randomly (1/3 chance)
		if (Random.Range(1,4) == 1) { // Spawn rune
			GameObject rune;
			if (Random.Range (1, 3) == 1) { //Spawn darkness rune
				rune = Instantiate (darknessRune);
			} else {
				rune = Instantiate (lightRune);
			}

			rune.transform.parent = instance.gameObject.transform;
			rune.transform.localPosition =  new Vector3 (Random.Range (-0.3f, 0.3f), 1.0f, Random.Range (-0.3f, 0.3f));
		}
	}


	IEnumerator GameOver(){
		isGameOver = true;

		// Play the gameover sound
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play ();

		if (score > highScore)
			PlayerPrefs.SetInt ("highscore", score);

		// Show the gameOver UI
		Image panelImage = GameOverCanvas.transform.FindChild ("Panel").gameObject.GetComponent<Image> ();
		Color temp = panelImage.color;
		temp.a = 255;
		panelImage.color = temp;
		Text gameOverText = GameOverCanvas.transform.FindChild ("Game Over Text").gameObject.GetComponent<Text> ();
		Text finalScoreText = GameOverCanvas.transform.FindChild ("Final Score Text").gameObject.GetComponent<Text> ();
		temp = gameOverText.color;
		temp.a = 255;
		finalScoreText.text = "Score: " + score;
		gameOverText.color = temp;
		finalScoreText.color = temp;


		// Delay for 6 seconds, then go to another scene
		yield return new WaitForSeconds (6);
		SceneManager.LoadScene (0);
	}

	// Update is called once per frame
	void Update () {
		

		if (sphere.position.y < deathHeight && !isGameOver)
			StartCoroutine(GameOver ());
	}
}
