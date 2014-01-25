using UnityEngine;
using System.Collections;

public class EnemyDamageDealer : MonoBehaviour {
	
	public int damage;
	public float attackCooldown = 1.0f;

	public bool attacked = false;
	private float attackTimer;
	
	void OnTriggerEnter(Collider collider)
	{
		if(!attacked && collider.gameObject.tag == "MirrorPlayer")
		{
			collider.gameObject.GetComponent<HealthController>().SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
			attacked = true;
			attackTimer = 0;
		}
	}
	
	// Use this for initialization
	void Start () {
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
