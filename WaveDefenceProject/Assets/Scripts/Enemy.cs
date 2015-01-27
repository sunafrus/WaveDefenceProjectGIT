using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public class EnemyStats
	{
		public int Health;
		public float Speed;
		public float jumpSpeed;
		public float attackTime;
	}

	public EnemyStats enemyStats = new EnemyStats ();
		
	public void Jump ()
	{
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, enemyStats.jumpSpeed);
	}
}
