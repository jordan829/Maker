using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetGridZ : MonoBehaviour {

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
			GameObject z = hLines [0].gameObject;
			hLines.RemoveAt (0);
			Destroy (z);
		}

		// create new lines
		for (int y = 0; y <= gHeight; y++) {
			for (int x = 0; x <= gWidth; x++) {
				GameObject z = GameObject.Instantiate (line).gameObject;
				Vector3[] positions = new Vector3[2];
				positions [0] = new Vector3 (x, y, 0);
				positions [1] = new Vector3 (x, y, gLength);
				z.name = "(" + x + "," + y + ",0), (" + x + "," + y + "," + gLength + ")";
				z.GetComponent<LineRenderer> ().SetPositions (positions);
				z.transform.SetParent (transform);
				hLines.Add (z.transform);
			}
		}
	}
}
