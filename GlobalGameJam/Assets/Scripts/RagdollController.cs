using UnityEngine;
using System.Collections;

public class RagdollController : MonoBehaviour {

	public bool useForceOnCreate;
	public int forceStrength = 500;
	private bool forceApplied = false;

	// Use this for initialization
	void Start () {
		//Destroy instance after 5 seconds.
		Destroy (gameObject, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ApplyForce(Vector3 position)
	{
		Destroy(GetComponent<CapsuleCollider>().collider);
		Debug.Log ("Applying force to rigids");
		if(!forceApplied && useForceOnCreate)
		{
			Rigidbody[] rigids = GetComponents<Rigidbody>();
			for(int i = 0; i< rigids.Length; i++)
			{
				Debug.Log ("Applying force to rigids");
				rigids[i].AddExplosionForce(forceStrength,position,10);
			}
		}


	}
}
