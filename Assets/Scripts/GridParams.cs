using UnityEngine;
using System.Collections;

public class GridParams : MonoBehaviour {

	public int gridWidth = 2; // X direction
	public int gridHeight = 2; // Y direction
	public int gridLength = 2; // Z direction

	// Use this for initialization
	void Start () {
		gridWidth = 5;
		gridHeight = 5;
		gridLength = 5;
		GameObject mountCam = GameObject.FindGameObjectWithTag ("MountCamera");
		mountCam.GetComponent<MountCamera> ().init ();
		GameObject lava = GameObject.FindGameObjectWithTag ("Lava");
		lava.GetComponent<LavaSetup> ().init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
