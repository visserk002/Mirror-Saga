using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public int maxHealth;
	public bool applyRagdollEffect;
	public bool ragdollWhenDying;
	public Transform ragdoll;

	public int currentHealth;
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(applyRagdollEffect)
		{
			Instantiate(ragdoll,transform.position,transform.rotation);
			Destroy(this.gameObject);
		}
	}

	public void ApplyDamage(int damage)
	{
		currentHealth -= damage;
		if(currentHealth <= 0)
			Die();
	}

	private void Die()
	{
		if(ragdollWhenDying)
		{
			Instantiate(ragdoll,transform.position,transform.rotation);
			Destroy(this.gameObject);
		}
	}
}
