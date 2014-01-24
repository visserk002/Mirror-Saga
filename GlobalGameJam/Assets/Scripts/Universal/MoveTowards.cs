using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

	public GameObject targetObject;
	public float speed = 10;
	public float stopAtDistance = 0;
		
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position,targetObject.transform.position) >= stopAtDistance && speed > 0)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, speed * Time.deltaTime);
			anim.SetFloat("Speed", speed);
		}else
			anim.SetFloat("Speed", 0);

	}
}
