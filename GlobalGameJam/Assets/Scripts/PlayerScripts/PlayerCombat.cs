using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {

	static int basicAttackState = Animator.StringToHash("Base Layer.SwingAttack"); 

	public Transform weapon;
	public float attackCooldown;

	private Animator anim;
	private AnimatorStateInfo currentBaseState;
	private bool canAttack;
	private float attackCooldownTimer;

	void Start()
	{
		attackCooldownTimer = 0;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
		if(currentBaseState.nameHash == basicAttackState)
		{
			weapon.collider.enabled = true;
		}
		else
		{
			weapon.collider.enabled = false;
		}

		if(attackCooldownTimer >= attackCooldown)
			canAttack = true;
		else
		{
			attackCooldownTimer += Time.deltaTime;
			canAttack = false;
		}

		CheckInputs();

	}

	private void CheckInputs()
	{		
		if(Input.GetMouseButtonDown(0) && canAttack)
		{
			attackCooldownTimer = 0;
			anim.SetBool("Attack", true);
		}
		else
			anim.SetBool("Attack", false);
	}

}
