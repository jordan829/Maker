using UnityEngine;
using System.Collections;

public class GridParams : MonoBehaviour {

	public int gridWidth; // X direction
	public int gridHeight; // Y direction
	public int gridLength; // Z direction

	// Use this for initialization
	void Start () {
		gridWidth = 5;
		gridHeight = 5;
		gridLength = 5;
		GameObject mountCam = GameObject.FindGameObjectWithTag ("MountCamera");
		mountCam.GetComponent<MountCamera> ().init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
