using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

	public Vector3 camPosTargetOffset;
	public Transform followTarget;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 camPosTarget;
		camPosTarget = followTarget.transform.position + camPosTargetOffset;
			
		//transform.LookAt(followTarget.transform.position);
		transform.position = Vector3.Lerp(transform.position, camPosTarget, Time.fixedDeltaTime * 10);

	
	}
}
