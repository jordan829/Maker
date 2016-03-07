using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetGridY : MonoBehaviour {
	public Transform line;
	List<Transform> hLines;

	// Use this for initialization
	void Start () {
		hLines = new List<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		GameObject grid = transform.parent.gameObject;
		int gWidth = grid.GetComponent<GridParams> ().gridWidth;
		int gHeight = grid.GetComponent<GridParams> ().gridHeight;
		int gLength = grid.GetComponent<GridParams> ().gridLength;

		// delete any old lines
		for (int i = 0; i < hLines.Count; i++) {
			GameObject y = hLines [0].gameObject;
			hLines.RemoveAt (0);
			Destroy (y);
		}

		// create new lines
		for (int x = 0; x <= gWidth; x++) {
			for (int z = 0; z <= gLength; z++) {
				GameObject y = GameObject.Instantiate (line).gameObject;
				Vector3[] positions = new Vector3[2];
				positions [0] = new Vector3 (x, 0, z);
				positions [1] = new Vector3 (x, gHeight, z);
				y.name = "(" + x + ",0," + z + "), (" + x + "," + gHeight + "," + z + ")";
				y.GetComponent<LineRenderer> ().SetPositions (positions);
				y.transform.SetParent (transform);
				hLines.Add (y.transform);
			}
		}
	}
}
