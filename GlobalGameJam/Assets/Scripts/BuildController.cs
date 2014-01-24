using UnityEngine;
using System.Collections;

public class BuildController : MonoBehaviour {

	public enum Buildings{
		none,
		Crusher
	}

	Buildings chosenBuilding = Buildings.none;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit)) {
				if(hit.transform.tag == "WorldCubeEmpty" && chosenBuilding != Buildings.none)
				{
					hit.transform.tag = "WorldCubeFull";
					hit.transform.SendMessage("UpdateCube",SendMessageOptions.DontRequireReceiver);
					if(chosenBuilding == Buildings.Crusher)
						Instantiate(Resources.Load ("Crusher"),hit.transform.position + new Vector3(0,5,0), Quaternion.identity);
					chosenBuilding = Buildings.none;
				}
			}
		}
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(10,10,160,60), "Stamper"))
		{
			chosenBuilding = Buildings.Crusher;
		}
	}
}
