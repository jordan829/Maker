using UnityEngine;
using System.Collections;

public class LavaSetup : MonoBehaviour {

	Transform camera;
	GameObject grid;

	// Use this for initialization
	void Start () {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init() {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		grid = GameObject.FindGameObjectWithTag ("Grid");

		transform.position = new Vector3 (grid.GetComponent<GridParams> ().gridWidth / 2.0f, 
			-10.0f,
			grid.GetComponent<GridParams> ().gridLength / 2.0f);

		transform.localScale = new Vector3 (grid.GetComponent<GridParams> ().gridWidth * 100,
			0.3f,
			grid.GetComponent<GridParams> ().gridLength * 100);
			
	}
}
