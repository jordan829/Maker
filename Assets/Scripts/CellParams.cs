using UnityEngine;
using System.Collections;
using System;

public class CellParams : MonoBehaviour {

	GameObject baseObject;
	public int cellWidth;
	public int cellLength;
	public int cellHeight;
	public Vector3 gridPosition;	// closest cell to the origin

	// Use this for initialization
	void Start () {
		cellWidth = 1;
		cellLength = 1;
		cellHeight = 1;
		gridPosition = new Vector3 (-1, 0, 0);
		transform.position = new Vector3 (-0.5f, 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject stylus = GameObject.FindGameObjectWithTag ("Stylus");

		if (!stylus.GetComponent<Stylus2> ().moving) {
			Vector3 position = gridPosition;
			position.x += cellWidth / 2.0f;
			position.y += cellHeight / 2.0f;
			position.z += cellLength / 2.0f;

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
