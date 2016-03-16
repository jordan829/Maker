using UnityEngine;
using System.Collections;

public class DonutSpin : MonoBehaviour {

	Vector3 center;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		center = transform.GetChild (0).gameObject.GetComponent<Renderer> ().bounds.center;
		transform.RotateAround (center, new Vector3 (0.0f, 1.0f, 0.0f), 20 * Time.deltaTime);
	}
}
