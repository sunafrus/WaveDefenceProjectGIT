using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public class EnemyStats
	{
		public int Health;
		public float Speed;
		public float jumpSpeed;
		public float attackTime;
		public float knockbackMultiplier;
	}

	public EnemyStats enemyStats = new EnemyStats ();
		
	public void Jump ()
	{
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, enemyStats.jumpSpeed);
	}

	public void DamageEnemy (int damage, Vector2 origin)
	{
		enemyStats.Health -= damage;
		
		if (enemyStats.Health <= 0)
		{
			GameMaster.KillEnemy(this);
		}

		knockback (damage, origin);
		
	}

	public void knockback(int damage, Vector2 origin)
	{
		Vector2 knockbackHeading = transform.position;
		Vector2 knockbackDirection = knockbackHeading / knockbackHeading.magnitude;

		ForceMode2D mode = ForceMode2D.Impulse;
		Vector2 knockbackVector = knockbackDirection * enemyStats.knockbackMultiplier;

		Debug.Log (gameObject + " has had knockback applied to it in direction: " + knockbackDirection);

		rigidbody2D.AddForce (knockbackVector, mode);

	} 
}
