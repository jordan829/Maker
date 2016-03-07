using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetGridX : MonoBehaviour {

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
			GameObject x = hLines [0].gameObject;
			hLines.RemoveAt (0);
			Destroy (x);
		}

		// create new lines
		for (int y = 0; y <= gHeight; y++) {
			for (int z = 0; z <= gLength; z++) {
				GameObject x = GameObject.Instantiate (line).gameObject;
				Vector3[] positions = new Vector3[2];
				positions [0] = new Vector3 (0, y, z);
				positions [1] = new Vector3 (gWidth, y, z);
				x.name = "(0," + y + "," + z + "), (" + gWidth + "," + y + "," + z + ")";
				x.GetComponent<LineRenderer> ().SetPositions (positions);
				x.transform.SetParent (transform);
				hLines.Add (x.transform);
			}
		}
	}
}
