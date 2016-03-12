using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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

			case "Rot+":
				if (selectedCell != null) {
					if (selectedCell.GetComponent<CellParams> ().rotationY < 270) {
						selectedCell.GetComponent<CellParams> ().rotationY += 90;
					} else {
						selectedCell.GetComponent<CellParams> ().rotationY = 0;
					}
					//selectedCell.transform.Rotate (new Vector3 (0.0f, 90.0f, 0.0f));
				}
				break;

			case "Delete":
				if (selectedCell != null) {
					stylus.GetComponent<Stylus2> ().lastCellSelected = null;

					//Deleting from list of transforms
					List<Transform> transformList = MasterBehavior.allCells;

					for (int i = 0; i < transformList.Count; i++) {
						if (transformList [i].gameObject.GetInstanceID () == selectedCell.GetInstanceID ()) {
							transformList.RemoveAt (i);
							break;
						}
					}
						
					MasterBehavior.allCells = transformList;

					Destroy (selectedCell);
				}
				break;

			case "Play":
				print ("Playing..");
				stylus.GetComponent<Stylus2> ().lastCellSelected = null;
				GameParams.SetupPlay ();
				break;

			case "Stop":
				print ("Stopping..");
				stylus.GetComponent<Stylus2> ().lastCellSelected = null;
				GameParams.StoppingPlay ();
				break;

			case "CamRot+":
				GameObject mountCam = GameObject.FindGameObjectWithTag ("MountCamera");
				if (mountCam.GetComponent<MountCamera> ().rotationY < 270) {
					mountCam.GetComponent<MountCamera> ().rotationY += 90;
					} else {
					mountCam.GetComponent<MountCamera> ().rotationY = 0;
					}
					//selectedCell.transform.Rotate (new Vector3 (0.0f, 90.0f, 0.0f));
				break;

			default:
				break;
			}

			acting = false;
		}
	}
}
