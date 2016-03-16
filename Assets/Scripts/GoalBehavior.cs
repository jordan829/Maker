using UnityEngine;
using System.Collections;

public class GoalBehavior : MonoBehaviour {

	float startTime;
	public static Transform winText;

	// Use this for initialization
	void Start () {
		startTime = -20.0f;
		if (winText == null) {
			winText = GameObject.FindGameObjectWithTag ("WinText").transform;
			winText.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GameParams.gameInPlay) {
			if (Time.time - startTime < 3.0) {
				winText.gameObject.SetActive (true);
			} else {
				winText.gameObject.SetActive (false);
				if (GameParams.win && Time.time - startTime < 10.0) {
					GameParams.win = false;
					startTime = -20.0f;

					print ("Stopping..");
					GameParams.StoppingPlay ();
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			// setup win

			// display game over for 5 seconds
			startTime = Time.time;

			GameParams.win = true;

			/*Destroy (GetComponent<DonutSpin> ());
			for (int i = 0; i < transform.childCount; i++) {
				transform.GetChild (i).gameObject.SetActive (false);
			}*/
		}
	}

}
