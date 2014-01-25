using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

	public GameObject targetObject;
	public float speed = 10;
	public float stopAtDistance = 0;
	public bool playerHitTrigger, enemyHitTrigger;
	public GameObject instantFlashParticles;
		
	private Animator anim;
	private Vector3 originalPosition;
	private Quaternion targetRotation;
	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if(playerHitTrigger)
		{
			if(Vector3.Distance(transform.position,targetObject.transform.position) >= stopAtDistance && speed > 0)
			{
				transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, speed * Time.deltaTime);
				anim.SetFloat("Speed", speed);
				anim.SetBool("Attack", false);
			}else
			{
				anim.SetFloat("Speed", 0);
				anim.SetBool("Attack", true);
			}
		}else if(enemyHitTrigger)
		{
			enemyHitTrigger = false;
			anim.SetFloat("Speed", 0);
			Instantiate(instantFlashParticles, transform.position, Quaternion.Euler(new Vector3(-90,0,0)));
			StartCoroutine(WaitToFlash(1.2f));
		}
	}

	IEnumerator WaitToFlash(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		transform.position = originalPosition;
	}
}
