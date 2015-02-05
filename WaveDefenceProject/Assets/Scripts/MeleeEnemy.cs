using UnityEngine;
using System.Collections;

public class MeleeEnemy : Enemy {

	public Transform target;

	public Collider2D targetCollider;

	bool attacking = false;
	int normalDamage = 0;
	float nextTimeToAttack = 0f;
	

	void Start ()
	{
		enemyStats.Health = 100;
		enemyStats.Speed = 3;
		enemyStats.jumpSpeed = 5;
		enemyStats.attackTime = 0.5f;
		enemyStats.knockbackMultiplier = 10f;
	}

	// Update is called once per frame
	void Update ()
	{
		if (target == null)
		{			
			target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		}

		bool targetIsRight = (target.position.x > transform.position.x) ? true : false;

		bool nextToPlayer = (Vector3.Distance (transform.position, target.position) < 1f) ? true : false;

		if (nextTimeToAttack <= Time.time)
		{
			attacking = false;
		}


		//move towards the player

		if(!enemyStats.beingKnockedBack)
		{
			if (targetIsRight)
			{
				rigidbody2D.velocity = new Vector2(enemyStats.Speed, rigidbody2D.velocity.y);
			}
			else
			{
				rigidbody2D.velocity = new Vector2(-enemyStats.Speed, rigidbody2D.velocity.y);
			}
		
		
			if (rigidbody2D.velocity.x < 0.3f)
			{
			
				if (rigidbody2D.velocity.x > -0.3f)
				{
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, enemyStats.Speed);
				}
			}
		}




	
	}

	public void AttackPlayer ()
	{
		if (attacking == false)
		{
			target.GetComponent<Player> ().DamagePlayer (normalDamage);

			nextTimeToAttack = Time.time + enemyStats.attackTime;

			attacking = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground")
		{
			enemyStats.beingKnockedBack = false;

			Debug.Log (gameObject + " has recovered from knockback.");
		}

	}




















	
}
