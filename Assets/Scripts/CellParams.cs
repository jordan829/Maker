using UnityEngine;
using System.Collections;
using System;

public class CellParams : MonoBehaviour {

	GameObject baseObject;
	public int cellWidth;
	public int cellLength;
	public int cellHeight;
	public Vector3 gridPosition;	// closest cell to the origin
	public int rotationY;
	public bool initialized = false;

	// Use this for initialization
	void Start () {
		if (!initialized) {
			cellWidth = 1;
			cellLength = 1;
			cellHeight = 1;
			gridPosition = new Vector3 (-1, 0, 0);
			transform.position = new Vector3 (-0.5f, 0.5f, 0.5f);
			rotationY = 0;
			initialized = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject stylus = GameObject.FindGameObjectWithTag ("Stylus");

		if (!stylus.GetComponent<Stylus2> ().moving) {
			Vector3 position = gridPosition;
			position.y += cellHeight / 2.0f;
			if (rotationY == 0 || rotationY == 180) {
				position.x += cellWidth / 2.0f;
				position.z += cellLength / 2.0f;
			} else {
				position.x += cellLength / 2.0f;
				position.z += cellWidth / 2.0f;
			}

			transform.position = position;
		}

		/*
		cellWidth = Convert.ToInt32 (transform.lossyScale.x);
		cellHeight = Convert.ToInt32 (transform.lossyScale.y);
		cellLength = Convert.ToInt32 (transform.lossyScale.z);
		Vector3 scale = new Vector3 (cellWidth, cellHeight, cellLength);
		transform.lossyScale = scale;
		*/
	}
}
