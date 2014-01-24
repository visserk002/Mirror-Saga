using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	// speed is the rate at which the object will rotate
	public float rotateSpeed;
	public bool Knight, Dude;


	private Animator anim;
	private Quaternion lookTowards;


	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void FixedUpdate () 
	{
		/*
		transform.position.Set(transform.position.x, transform.position.y, 0);

		// Generate a plane that intersects the transform's position with an upwards normal.
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		
		// Generate a ray from the cursor position
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Determine the point where the cursor ray intersects the plane.
		// This will be the point that the object must look towards to be looking at the mouse.
		// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
		//   then find the point along that ray that meets that distance.  This will be the point
		//   to look at.
		float hitdist = 0.0f;
		// If the ray is parallel to the plane, Raycast will return false.
		if (playerPlane.Raycast (ray, out hitdist)) 
		{
			// Get the point along the ray that hits the calculated distance.
			Vector3 targetPoint = ray.GetPoint(hitdist);
			
			// Determine the target rotation.  This is the rotation if the transform looks at the target point.
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

			Quaternion lookTowards = new Quaternion();

			if(targetRotation.y > 0)
			{
				lookTowards = Quaternion.Euler(new Vector3(0,90,0));
				transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards , speed * Time.fixedTime);
			}
			else if(targetRotation.y < 0)
			{
				lookTowards = Quaternion.Euler(new Vector3(0,-90,0));
				transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards, speed * Time.fixedTime);
			}
		}
		*/
	}
	
	void Update ()
	{
		if(Knight)
		{
			//Animation handling
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) )
			{
				if(Input.GetKey(KeyCode.D))
				{
					lookTowards = Quaternion.Euler(new Vector3(0,90,0));
					transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards , rotateSpeed * Time.fixedTime);
				}
				else if(Input.GetKey(KeyCode.A))
				{
					lookTowards = Quaternion.Euler(new Vector3(0,-90,0));
					transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards , rotateSpeed * Time.fixedTime);
				}

				if(Input.GetKey(KeyCode.LeftShift))
					anim.SetFloat("Speed", 1.0f);
				else
					anim.SetFloat("Speed", 0.5f);
			}
		}

		if(Dude)
		{
			//Animation handling
			if(Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.Keypad4) )
			{
				if(Input.GetKey(KeyCode.Keypad4))
				{
					lookTowards = Quaternion.Euler(new Vector3(0,90,0));
					transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards , rotateSpeed * Time.fixedTime);
				}
				else if(Input.GetKey(KeyCode.Keypad6))
				{
					lookTowards = Quaternion.Euler(new Vector3(0,-90,0));
					transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards , rotateSpeed * Time.fixedTime);
				}
				
				if(Input.GetKey(KeyCode.LeftShift))
					anim.SetFloat("Speed", 1.0f);
				else
					anim.SetFloat("Speed", 0.5f);
			}
		}
		
	}
}
