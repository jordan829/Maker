using UnityEngine;
using System.Collections;
using System;

public class GridSnap : MonoBehaviour {

	public Transform grid;
	public bool snapping;
	int gWidth;
	int gHeight;
	int gLength;

	// Use this for initialization
	void Start () {
		snapping = false;
		grid = GameObject.FindGameObjectWithTag ("Grid").transform;
	}
	
	// Update is called once per frame
	void Update () {
		gWidth = grid.gameObject.GetComponent<GridParams> ().gridWidth;
		gHeight = grid.gameObject.GetComponent<GridParams> ().gridHeight;
		gLength = grid.gameObject.GetComponent<GridParams> ().gridLength;

		/*******************************************************************************/
		if(!GameObject.FindGameObjectWithTag("Stylus").GetComponent<Stylus2>().moving)
			Snap ();
		/*******************************************************************************/
	}

	void FixedUpdate() {
		//Snap ();
	}

	void Snap() {
		Vector3 position = GetComponent<CellParams>().gridPosition;
		position = position + new Vector3 (0.5f, 0.5f, 0.5f);
		if (position.x >= 0 && position.x <= gWidth &&
			position.y >= 0 && position.y <= gHeight &&
			position.z >= 0 && position.z <= gLength) {
			// turn off other movement
			snapping = true;



			// snap in the x direction into the grid
			//float xTrunc = position.x - (float)Math.Floor (position.x);
			/*if (xTrunc < 0.05 || xTrunc > 0.95) {
				// don't snap x; dead zone
			} else {
				position.x = (float)Math.Floor (position.x) + 0.5f;
			}

			// snap in the y direction into the grid
			float yTrunc = position.y - (float)Math.Floor (position.y);
			if (yTrunc < 0.05 || yTrunc > 0.95) {
				// don't snap y; dead zone
			} else {
				position.y = (float)Math.Floor (position.y) + 0.5f;
			}

			// snap in the x direction into the grid
			float zTrunc = position.z - (float)Math.Floor (position.z);
			if (zTrunc < 0.05 || zTrunc > 0.95) {
				// don't snap z; dead zone
			} else {
				position.z = (float)Math.Floor (position.z) + 0.5f;
			}*/

			position.x = (float)Math.Floor (position.x);
			position.y = (float)Math.Floor (position.y);
			position.z = (float)Math.Floor (position.z);


			// set the values of the transform
			GameObject stylus = GameObject.FindGameObjectWithTag("Stylus");
			if (!stylus.GetComponent<Stylus2> ().moving) {
				GetComponent<CellParams> ().gridPosition = position;
				transform.rotation = Quaternion.identity;
				transform.Rotate(new Vector3(0.0f, GetComponent<CellParams>().rotationY * 1.0f, 0.0f));
			}

		} else {
			snapping = false;
		}
	}
}
