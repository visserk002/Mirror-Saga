using UnityEngine;
using System.Collections;

public class AnimationHandler : MonoBehaviour {

	// speed is the rate at which the object will rotate
	public float rotateSpeed = 100.0f;
	public float walkSpeed = 4.0f, runSpeed = 8.0f;
	public float zPosition, jumpHeight;
	public bool Knight, Dude;	

	private Animator anim;
	private Quaternion lookTowards;
	private float resetZpos;
	private bool falling;
	private float speed;
	private CharacterMotor charMotor;

	void Start()
	{
		charMotor = GetComponent<CharacterMotor>();
		anim = GetComponent<Animator>();
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
					if(Input.GetKey(KeyCode.A))
					{
						lookTowards = Quaternion.Euler(new Vector3(0,-90,0));
						transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards , rotateSpeed * Time.fixedTime);
					}

					if(Input.GetKey(KeyCode.LeftShift))
					{
						anim.SetFloat("Speed", 1.0f);
						charMotor.movement.maxForwardSpeed = runSpeed;
					}
					else
					{
						anim.SetFloat("Speed", 0.5f);
						charMotor.movement.maxForwardSpeed = walkSpeed;
					}	
					
				}
				else if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) )
				{
					anim.SetFloat("Speed", 0.0f);
				}
			}

			if(Dude)
			{
				//Animation handling
				if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) )
				{
				if(Input.GetKey(KeyCode.RightArrow))
					{
						lookTowards = Quaternion.Euler(new Vector3(0,90,0));
						transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards , rotateSpeed * Time.fixedTime);
					}
				if(Input.GetKey(KeyCode.LeftArrow))
					{
						lookTowards = Quaternion.Euler(new Vector3(0,-90,0));
						transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards , rotateSpeed * Time.fixedTime);
					}
					
					if(Input.GetKey(KeyCode.L))
					{
						anim.SetFloat("Speed", 1.0f);
						charMotor.movement.maxForwardSpeed = runSpeed;
					}
					else
					{
						anim.SetFloat("Speed", 0.5f);
						charMotor.movement.maxForwardSpeed = walkSpeed;
					}	
				}
			else if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) )
				{
					anim.SetFloat("Speed", 0.0f);
				}
			}

	}
}
