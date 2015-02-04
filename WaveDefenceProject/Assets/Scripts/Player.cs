using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public class PlayerStats
	{
		public int Health = 100;
		public int normalAttackDamage = 30;
		public float attackTime = 0.3f;
	}

	public PlayerStats playerStats = new PlayerStats ();

	public int fallBoundary = -20;

	bool attacking = false;
	private float nextTimeToAttack = 0f;

	
	public float NextTimeToAttack
	{
		get{ return nextTimeToAttack; }
		
		set{ nextTimeToAttack = value; }
	}

	void Update ()
	{
		if (transform.position.y <= fallBoundary)
		{
			DamagePlayer (9999999);

		}

		if (nextTimeToAttack <= Time.time)
		{
			attacking = false;
		}

		if (Input.GetMouseButtonDown (0) && attacking == false)
						attacking = true;
										     

		
	}
	
	public void DamagePlayer (int damage)
	{
		playerStats.Health -= damage;

		if (playerStats.Health <= 0)
		{
			GameMaster.KillPlayer(this);
		}

	}

	public int getHealth()
	{
		return playerStats.Health;
	}

	public int getNormalAttackDamage()
	{
		return playerStats.normalAttackDamage;
	}

	public bool isAttacking()
	{
		return attacking;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//If the player hits a melee enemy have them attack/harm the player
		if (other.gameObject.tag == "MeleeEnemy")
		{
			other.gameObject.GetComponent<MeleeEnemy>().AttackPlayer();
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		//If the player stays in contact with a melee enemy have them attack/harm the player repeatedly
		if (other.gameObject.tag == "MeleeEnemy")
		{
			Debug.Log ("In collision");
			other.gameObject.GetComponent<MeleeEnemy>().AttackPlayer();
		}
	}
	

}