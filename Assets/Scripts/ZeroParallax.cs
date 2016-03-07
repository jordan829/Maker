using UnityEngine;
using System.Collections;

public class ZeroParallax : MonoBehaviour {

	ZSCore zs;
	// Use this for initialization
	void Start () {
		zs = GameObject.Find ("ZSCore").GetComponent<ZSCore>();

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = zs.CurrentCamera.transform.position + zs.CurrentCamera.transform.forward * zs.ViewerScale * zs.GetCameraOffset ().magnitude;
		transform.up = zs.CurrentCamera.transform.up;
		transform.rotation = zs.CurrentCamera.transform.rotation;
		GameObject stylus = GameObject.FindGameObjectWithTag ("Stylus");
	}
}
