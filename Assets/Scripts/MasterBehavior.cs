using UnityEngine;
using System.Collections;

public class MasterBehavior : MonoBehaviour {

	public bool acting;
	private Transform lastInstantiated;

	public Transform groundMaster;

	// Use this for initialization
	void Start () {
		acting = false;
		lastInstantiated = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (acting) {
			GameObject stylus = GameObject.FindGameObjectWithTag ("Stylus");
			GameObject selectedCell = stylus.GetComponent<Stylus2> ().lastCellSelected;

			//switch
			switch (name) {
			case "GroundObjMaster":
				if (lastInstantiated == null || (lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x >= 0 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x < -1 ||
												lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y < 0 ||
												lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z < 0)) {
					lastInstantiated = Instantiate (groundMaster);
				}
				break;

			default:
				break;
			}

			acting = false;
		}
	
	}
}
