using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {

	public Transform enemy;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.tag == "MirrorPlayer")
			if(enemy) enemy.GetComponent<MoveTowards>().playerHitTrigger = true;
		if(collider.gameObject.tag == "Enemy")
		{
			if(enemy) enemy.GetComponent<MoveTowards>().enemyHitTrigger = true;
			if(enemy) enemy.GetComponent<MoveTowards>().playerHitTrigger = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
