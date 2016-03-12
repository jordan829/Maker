using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameParams : MonoBehaviour {

	public static bool gameInPlay;
	public static bool gameOver;
	public static bool win;

	public static List<Transform> levelInit;

	// Use this for initialization
	void Start () {
		gameInPlay = false;
		gameOver = false;
		win = false;
		levelInit = new List<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void SetupPlay()
	{
		gameInPlay = true;

		for (int i = 0; i < MasterBehavior.allCells.Count; i++) {
			// create a copied list of current objects in our workspace
			Transform former = MasterBehavior.allCells[i];
			Transform current = Instantiate(former);
			current.gameObject.SetActive (false);
			levelInit.Add (current);

			// set the objects as non-trigger, kinematic objects (except for player)
			for (int j = 0; j < MasterBehavior.allCells [i].childCount; j++) {
				former.GetChild (j).gameObject.GetComponent<Collider> ().isTrigger = false;
			}
			if (former.GetChild(0).CompareTag ("Player")) {
				former.GetChild(0).gameObject.GetComponent<Rigidbody> ().useGravity = true;
			}
			Destroy(former.GetComponent<Rigidbody>());
			Destroy(former.GetComponent<Collider>());
			Destroy(former.GetComponent<MeshFilter>());
			Destroy(former.GetComponent<MeshRenderer>());
		}

		//TODO: make sure clicking is disabled except for new widget "stop"

		//TODO: initialized controls for player (i.e. allow them)
	}

	public static void StoppingPlay()
	{
		gameInPlay = false;
		gameOver = false;
		win = false;

		for (int i = 0; i < levelInit.Count; i++) { 
			
			// NOTE: IF PLAY CREATES OBJECTS, FIND A DIFFERENT WAY TO DELETE

			Transform toDelete = MasterBehavior.allCells [0];
			Transform current = levelInit [i];
			current.gameObject.SetActive (true);
			current.gameObject.GetComponent<CellParams>().cellWidth = toDelete.gameObject.GetComponent<CellParams>().cellWidth;
			current.gameObject.GetComponent<CellParams>().cellLength = toDelete.gameObject.GetComponent<CellParams>().cellLength;
			current.gameObject.GetComponent<CellParams>().cellHeight = toDelete.gameObject.GetComponent<CellParams>().cellHeight;
			current.gameObject.GetComponent<CellParams>().gridPosition = toDelete.gameObject.GetComponent<CellParams>().gridPosition;
			current.gameObject.GetComponent<CellParams>().rotationY = toDelete.gameObject.GetComponent<CellParams>().rotationY;
			current.gameObject.GetComponent<CellParams> ().initialized = true;

			MasterBehavior.allCells.RemoveAt(0);
			Destroy (toDelete.gameObject);
		}

		MasterBehavior.allCells = levelInit;
		levelInit = new List<Transform> ();

		//TODO: reset camera to inital position

		//TODO: disable control's for player
	}
}
