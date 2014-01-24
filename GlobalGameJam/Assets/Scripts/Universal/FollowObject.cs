using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

	public int boundLeft, boundRight;
	public Transform followTarget;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 camPosTarget;
		camPosTarget = followTarget.transform.position + new Vector3(0,4,-8);
			
		transform.LookAt(followTarget.transform.position);
		transform.position = Vector3.Lerp(transform.position, camPosTarget, Time.fixedDeltaTime * 10);

	
	}
}
