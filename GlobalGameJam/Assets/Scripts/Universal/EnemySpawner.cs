using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public Transform spawnLocation;
	public float interval = 5.0f;

	private float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(timer >= interval)
		{
			GameObject teddy = (GameObject)Instantiate(enemy,spawnLocation.transform.position,enemy.transform.rotation);
			teddy.GetComponent<MoveTowards>().targetObject = GameObject.FindWithTag("Player");
			timer = 0;
		}else
			timer += Time.deltaTime;
	}
}
