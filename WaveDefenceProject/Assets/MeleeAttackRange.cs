using UnityEngine;
using System.Collections;

public class MeleeAttackRange : MonoBehaviour
{

	bool attacking;
	int damage;
	Player player;

	void Start()
	{
		player = GetComponentInParent<Player>();
	}

	void Update()
	{
		attacking = player.isAttacking ();
		damage = player.getNormalAttackDamage();
	}

	void OnTriggerStay2D (Collider2D other)
	{
		//If the player is attacking, Call the damage on any enemies within the hitbox
		if (attacking)
		{

			//Find only collisions with enemies
			GameObject target = other.gameObject;
		
			if (target.tag == "MeleeEnemy" || target.tag == "Enemy")
			{
				target.GetComponent<Enemy>().DamageEnemy(damage, GetComponent<Transform>().position);
			}

			//Set the player's attack timer to prevent them from attacking multiple times within one animation.
			player.NextTimeToAttack = Time.time + player.playerStats.attackTime;

			Debug.Log(other + " was attacked for " + damage + " damage.");

		}
	}
}
