using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour {

	public int damage;
	public float attackCooldown = 2.0f;
	
	public bool attacked = false;
	private float attackTimer;

	//Collision for traps and other physics related stuff
	void OnCollisionEnter(Collision collision) {
		if(!attacked)
		{
			if(collision.transform.tag == "Enemy")
			{
				collision.gameObject.GetComponent<HealthController>().SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
			}
			if(collision.transform.tag == "EnemyRagdoll")
			{
				RagdollController ragdollController = collision.gameObject.GetComponent<RagdollController>();
				ragdollController.forceStrength = damage * 20;
				ragdollController.SendMessage("ApplyForce", transform.position, SendMessageOptions.DontRequireReceiver);
			}
		}

	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "Enemy")
			collider.gameObject.GetComponent<HealthController>().SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
		if(collider.gameObject.tag == "EnemyRagdoll")
		{
			collider.collider.enabled = false;
		}
	}

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player.collider) Physics.IgnoreCollision(player.collider, collider);
	}
	
	// Update is called once per frame
	void Update () {
		if(attacked)
		{
			if(attackTimer >= attackCooldown)
			{
				attackTimer = 0;
				attacked = false;
			}
			else 
				attackTimer += Time.deltaTime;
		}
	}
}
