using UnityEngine;
using System.Collections;

public class TextDisplays : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject stylus = GameObject.FindGameObjectWithTag ("Stylus");

		switch (name) {

		case "X Scale":
			if (stylus.GetComponent<Stylus2> ().lastCellSelected != null) {
				GetComponent<TextMesh> ().text = name + " " + stylus.GetComponent<Stylus2>().lastCellSelected.GetComponent<CellParams>().cellWidth;
			} else {
				GetComponent<TextMesh> ().text = name + " ";
			}
			break;
		case "Y Scale":
			if (stylus.GetComponent<Stylus2> ().lastCellSelected != null) {
				GetComponent<TextMesh> ().text = name + " " + stylus.GetComponent<Stylus2>().lastCellSelected.GetComponent<CellParams>().cellHeight;
			} else {
				GetComponent<TextMesh> ().text = name + " ";
			}
			break;
		case "Z Scale":
			if (stylus.GetComponent<Stylus2> ().lastCellSelected != null) {
				GetComponent<TextMesh> ().text = name + " " + stylus.GetComponent<Stylus2>().lastCellSelected.GetComponent<CellParams>().cellLength;
			} else {
				GetComponent<TextMesh> ().text = name + " ";
			}
			break;
		default:
			break;

		}
	}
}
