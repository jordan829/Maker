using UnityEngine;
using System.Collections;

/* This object handles the rotation of the camera around the workspace */
public class MountCamera : MonoBehaviour {

	Transform camera;
	GameObject grid;
	public int rotationY;

	// Use this for initialization
	void Start () {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: SETUP SO PLAYER'S FORWARD VECTOR IS THE SAME AS THIS ONE
		transform.rotation = Quaternion.identity;
		transform.Rotate(new Vector3(0.0f, rotationY * 1.0f, 0.0f));
	}

	public void init() {
		camera = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		grid = GameObject.FindGameObjectWithTag ("Grid");
		transform.rotation = Quaternion.identity;
		rotationY = 0;
		transform.position = new Vector3 (grid.GetComponent<GridParams> ().gridWidth / 2.0f, 
			grid.GetComponent<GridParams> ().gridHeight / 2.0f, 
			grid.GetComponent<GridParams> ().gridLength / 2.0f);

		camera.position = new Vector3 (transform.position.x, transform.position.y, -15.0f);
		camera.SetParent (transform);
	}
}
