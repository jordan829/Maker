using UnityEngine;
using System.Collections;

//Stylus2: Simple example with a raycast hover function, that highlights objects pointed to,
//			no matter how far away. 

public class Stylus2 : MonoBehaviour
{
	public GameObject lastCellSelected;
	public bool firstWidgetPress;

	private GameObject contactPoint;
	private class LastHoveredGO {
		public GameObject GO;
		public Color originalColor;
	};
	private LastHoveredGO lastHoveredGO;
	
	private Quaternion initialRotation = new Quaternion();
	private Vector3 initialPosition = new Vector3();
	private ZSCore _zsCore;
	private ZSCore.TrackerTargetType _targetType = ZSCore.TrackerTargetType.Primary;

	/****************************/
	bool initialHit = true;
	public bool moving = false;
	Transform prevParent;
	Transform currentlyHeld;
	/****************************/
	protected void Start ()
	{
		_zsCore = GameObject.Find ("ZSCore").GetComponent<ZSCore> ();
		_zsCore.Updated += new ZSCore.CoreEventHandler (OnCoreUpdated);
		initialRotation = transform.rotation;
		initialPosition = transform.position;

		contactPoint = GameObject.Find("ContactPoint");
		contactPoint.SetActive(false);
		lastHoveredGO = null;
		firstWidgetPress = false;
	}
	
	public void Update(){
		RaycastHit hit;
		Debug.DrawRay(transform.position,transform.forward);
		if (Physics.Raycast (transform.position,
		                     transform.forward,
		                     out hit)){
			contactPoint.SetActive(true);
			if(currentlyHeld == null)
				contactPoint.transform.position = hit.point;
			if (lastHoveredGO != null){
				lastHoveredGO.GO.GetComponent<Renderer>().material.color = lastHoveredGO.originalColor;
			}
			else {
				lastHoveredGO = new LastHoveredGO();
			}
			lastHoveredGO.GO = hit.collider.gameObject;
			lastHoveredGO.originalColor = hit.collider.gameObject.GetComponent<Renderer>().material.color;

			/*******************************************************************************/

			if (initialHit && hit.collider.gameObject.tag == "Cell")
				prevParent = hit.transform.parent;
				
			Transform contactPt = GameObject.FindGameObjectWithTag ("ContactPoint").transform;

			if (GameParams.gameInPlay) {
				if (_zsCore.IsTrackerTargetButtonPressed (ZSCore.TrackerTargetType.Primary, 0) && hit.collider.gameObject.layer == 8 && !firstWidgetPress && !moving
					&& hit.collider.gameObject.name.Equals("Stop", System.StringComparison.OrdinalIgnoreCase)) {
					firstWidgetPress = true;
					hit.collider.gameObject.GetComponent<TextWidgetBehavior> ().acting = true;
				} else if (!_zsCore.IsTrackerTargetButtonPressed (ZSCore.TrackerTargetType.Primary, 0)) {
					firstWidgetPress = false;
				}
			}
			else if (_zsCore.IsTrackerTargetButtonPressed (ZSCore.TrackerTargetType.Primary, 0) && hit.collider.gameObject.tag == "Cell") {
				if (currentlyHeld == null) {
					currentlyHeld = hit.transform;
				}

				moving = true;
				//currentlyHeld.gameObject.GetComponent<Renderer> ().material.color = new Color (0f, 1f, 0f, .5f);

				currentlyHeld.parent = contactPt;

				// calculate the gridposition
				GameObject cell = currentlyHeld.gameObject;
				Vector3 offset = new Vector3 (cell.GetComponent<CellParams> ().cellWidth / (-2.0f), 
					                 cell.GetComponent<CellParams> ().cellHeight / (-2.0f),
					                 cell.GetComponent<CellParams> ().cellLength / (-2.0f));
				cell.GetComponent<CellParams> ().gridPosition = currentlyHeld.position + offset;

				lastCellSelected = cell;

				initialHit = false;
			} else if (hit.collider.gameObject.tag == "Cell") {
				moving = false;
				hit.transform.parent = prevParent;
				contactPt.DetachChildren ();
				currentlyHeld = null;
			} else if (_zsCore.IsTrackerTargetButtonPressed (ZSCore.TrackerTargetType.Primary, 0) && hit.collider.gameObject.layer == 8 && !firstWidgetPress && !moving) {
				firstWidgetPress = true;
				hit.collider.gameObject.GetComponent<TextWidgetBehavior> ().acting = true;
			} else if (_zsCore.IsTrackerTargetButtonPressed (ZSCore.TrackerTargetType.Primary, 0) && hit.collider.gameObject.layer == 9 && !firstWidgetPress && !moving) {
				firstWidgetPress = true;
				hit.collider.gameObject.GetComponent<MasterBehavior> ().acting = true;
			}
			else  if (!_zsCore.IsTrackerTargetButtonPressed (ZSCore.TrackerTargetType.Primary, 0)) {
				firstWidgetPress = false;
				contactPt.DetachChildren ();
				currentlyHeld = null;
			}




			/*******************************************************************************/
		}
		else{
			contactPoint.SetActive(false);
			if (lastHoveredGO != null){
				lastHoveredGO.GO.GetComponent<Renderer>().material.color = lastHoveredGO.originalColor;
				lastHoveredGO = null;
			}
		}
		
	}

	/// called by ZSCore after each input update.
	private void OnCoreUpdated (ZSCore sender)
	{
		UpdateStylusPose ();
	}		
	
	private void UpdateStylusPose ()
	{
		Matrix4x4 pose = _zsCore.GetTrackerTargetWorldPose (_targetType);
		transform.position = new Vector3 (pose.m03 + initialPosition.x,
		                                               pose.m13 + initialPosition.y,
		                                               pose.m23 + initialPosition.z);
		transform.rotation = Quaternion.LookRotation(pose.GetColumn(2), pose.GetColumn(1))
			* initialRotation;
	}
}

