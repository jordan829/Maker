using UnityEngine;
using System.Collections;

public class LavaBehavior : MonoBehaviour {

	float startTime;
	public Transform gameOverText;

	// Use this for initialization
	void Start () {
		startTime = -20.0f;
		gameOverText.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameParams.gameInPlay) {
			if (Time.time - startTime < 3.0) {
				gameOverText.gameObject.SetActive (true);
			} else {
				gameOverText.gameObject.SetActive (false);
				if (GameParams.gameOver) {
					GameParams.gameOver = false;
					startTime = -20.0f;
					print ("Stopping..");
					GameParams.StoppingPlay ();
				}
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			// setup game over
			if (!GameParams.win) {
				GameParams.gameOver = true;

				// display game over for 5 seconds
				startTime = Time.time;
			}
		}
	}
}
