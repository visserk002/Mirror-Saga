using UnityEngine;
using System.Collections;

public class CubeLogic : MonoBehaviour {

	public bool buildAble;
	// Use this for initialization
	void Start () {
		UpdateCube();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateCube()
	{
		if(tag == "WorldCubeStatic" || tag == "WorldCubeFull")
		{
			renderer.material.color = Color.red;
			buildAble = false;
		}
		else if(tag == "WorldCubeEmpty")
		{
			renderer.material.color = Color.gray;
			buildAble = true;
		}
	}
}
