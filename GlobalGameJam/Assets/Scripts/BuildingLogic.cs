using UnityEngine;
using System.Collections;

public class BuildingLogic : MonoBehaviour {

	public BuildController.Buildings buildingType;
	public float speed = 0;
	public float step;

	private Vector3 originalPosition;
	private bool makeMove;
	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		step = speed * Time.fixedDeltaTime;
		if(buildingType == BuildController.Buildings.Crusher)
		{
			if(transform.position.y >= originalPosition.y)
				makeMove = true;
			if(transform.position.y <= (originalPosition.y - 3))
				makeMove = false;
		
			if(makeMove)
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,originalPosition.y - 3,transform.position.z), step);
			else if(!makeMove)
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,originalPosition.y,transform.position.z), step/4);
		}
	}
}
