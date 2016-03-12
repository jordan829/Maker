using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MasterBehavior : MonoBehaviour {

	public bool acting;
	private static Transform lastInstantiated;
	private Transform playerTransform;

	public Transform groundMaster;
	public Transform powerUpObjMaster;
	public Transform wallMaster;
	public Transform tMaster;
	public Transform treeMaster;
	public Transform rampMaster;
	public Transform platformMaster;
	public Transform playerMaster;

	public static List<Transform> allCells;

	// Use this for initialization
	void Start () {
		acting = false;
		lastInstantiated = null;
		playerTransform = null;
		allCells = new List<Transform> ();
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
					allCells.Add (lastInstantiated);
				}
				break;

			case "PowerUpObjMaster":
				if (lastInstantiated == null || (lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x >= 0 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x < -1 ||
				    lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y < 0 ||
				    lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z < 0)) {
					lastInstantiated = Instantiate (powerUpObjMaster);
					allCells.Add (lastInstantiated);
				}
				break;

			case "WallObjMaster":
				if (lastInstantiated == null || (lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x >= 0 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x < -1 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y < 0 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z < 0)) {
					lastInstantiated = Instantiate (wallMaster);
					allCells.Add (lastInstantiated);
				}
				break;

			case "TObjMaster":
				if (lastInstantiated == null || (lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x >= 0 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x < -1 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y < 0 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z < 0)) {
					lastInstantiated = Instantiate (tMaster);
					allCells.Add (lastInstantiated);
				}
				break;

			case "TreeObjMaster":
				if (lastInstantiated == null || (lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x >= 0 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x < -1 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y < 0 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z < 0)) {
					lastInstantiated = Instantiate (treeMaster);
					allCells.Add (lastInstantiated);
				}
				break;

			case "RampObjMaster":
				if (lastInstantiated == null || (lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x >= 0 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x < -1 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y < 0 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z < 0)) {
					lastInstantiated = Instantiate (rampMaster);
					allCells.Add (lastInstantiated);
				}
				break;

			case "PlatformObjMaster":
				if (lastInstantiated == null || (lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x >= 0 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x < -1 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y < 0 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z < 0)) {
					lastInstantiated = Instantiate (platformMaster);
					allCells.Add (lastInstantiated);
				}
				break;

			case "PlayerObjMaster":
				if (lastInstantiated == null || (lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x >= 0 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.x < -1 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.y < 0 ||
					lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z >= 1 || lastInstantiated.gameObject.GetComponent<CellParams> ().gridPosition.z < 0)) {
					if (playerTransform == null) {
						lastInstantiated = Instantiate (playerMaster);
						playerTransform = lastInstantiated;
						allCells.Add (lastInstantiated);
					}
				}
				break;

			default:
				break;
			}

			acting = false;
		}
	
	}
}
