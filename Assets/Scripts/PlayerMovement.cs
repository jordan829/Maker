using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Rigidbody rb;
	float forceScale = 10.0f;
	public float jumpScale = 1.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// TODO: SETUP SO PLAYER'S FORWARD VECTOR IS THE SAME AS MOUNTCAMERA'S FORWARD VECTOR

	}

	public void MoveTo(Vector3 moveToPoint)
	{
		// Set move to y position ot be equal to player objects current elevation in the map. This makes it so that the 
		// player cannot magically float up to a higher level
		float yPos = transform.position.y;
		moveToPoint = new Vector3(moveToPoint.x, yPos, moveToPoint.z);

		// Move player towards point using force
		rb.velocity = ((moveToPoint - transform.position)); //* forceScale);
		if (rb.velocity.magnitude < 0.5) {
			rb.velocity = new Vector3 (0.0f, 0.0f, 0.0f);
		}
	}

	public void Jump() {
		rb.AddForce (new Vector3 (0.0f, 260.0f * jumpScale, 0.0f));
	}
}
