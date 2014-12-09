using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public class EnemyStats
	{
		public int Health;
		public float Speed;
	}

	public EnemyStats enemyStats = new EnemyStats ();

	public void DamagePlayer (int damage)
	{
		enemyStats.Health -= damage;
		
		if (enemyStats.Health <= 0)
		{
			GameMaster.KillEnemy(this);
		}
		
	}
}
