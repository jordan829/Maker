using UnityEngine;
using System.Collections;

public class TextWidgetBehavior : MonoBehaviour {

	public bool acting;

	// Use this for initialization
	void Start () {
		acting = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (acting) {
			GameObject stylus = GameObject.FindGameObjectWithTag ("Stylus");
			GameObject selectedCell = stylus.GetComponent<Stylus2> ().lastCellSelected;

			//switch
			switch (name) {
			case "X+":
				if (selectedCell != null &&
					selectedCell.GetComponent<CellParams>().cellWidth < GameObject.FindGameObjectWithTag("Grid").GetComponent<GridParams>().gridLength) {
					selectedCell.GetComponent<CellParams> ().cellWidth += 1;
					selectedCell.transform.localScale = new Vector3(selectedCell.transform.localScale.x + 1, 
						selectedCell.transform.localScale.y,
						selectedCell.transform.localScale.z);
				}
				break;
			case "X-":
				if (selectedCell != null &&
					selectedCell.GetComponent<CellParams>().cellWidth > 1) {
					selectedCell.GetComponent<CellParams> ().cellWidth -= 1;
					selectedCell.transform.localScale = new Vector3(selectedCell.transform.localScale.x - 1, 
						selectedCell.transform.localScale.y,
						selectedCell.transform.localScale.z);
				}
				break;
			case "Y+":
				if (selectedCell != null &&
					selectedCell.GetComponent<CellParams>().cellHeight < GameObject.FindGameObjectWithTag("Grid").GetComponent<GridParams>().gridHeight) {
					selectedCell.GetComponent<CellParams> ().cellHeight += 1;
					selectedCell.transform.localScale = new Vector3(selectedCell.transform.localScale.x, 
						selectedCell.transform.localScale.y + 1,
						selectedCell.transform.localScale.z);
				}
				break;
			case "Y-":
				if (selectedCell != null &&
					selectedCell.GetComponent<CellParams>().cellHeight > 1) {
					selectedCell.GetComponent<CellParams> ().cellHeight -= 1;
					selectedCell.transform.localScale = new Vector3(selectedCell.transform.localScale.x, 
						selectedCell.transform.localScale.y - 1,
						selectedCell.transform.localScale.z);
				}
				break;
			case "Z+":
				if (selectedCell != null &&
					selectedCell.GetComponent<CellParams>().cellLength < GameObject.FindGameObjectWithTag("Grid").GetComponent<GridParams>().gridLength) {
					selectedCell.GetComponent<CellParams> ().cellLength += 1;
					selectedCell.transform.localScale = new Vector3(selectedCell.transform.localScale.x, 
						selectedCell.transform.localScale.y,
						selectedCell.transform.localScale.z + 1);
				}
				break;
			case "Z-":
				if (selectedCell != null &&
					selectedCell.GetComponent<CellParams>().cellLength > 1) {
					selectedCell.GetComponent<CellParams> ().cellLength -= 1;
					selectedCell.transform.localScale = new Vector3(selectedCell.transform.localScale.x, 
						selectedCell.transform.localScale.y,
						selectedCell.transform.localScale.z - 1);
				}
				break;





			default:
				break;
			}

			acting = false;
		}
	}
}
