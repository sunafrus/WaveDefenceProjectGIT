using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public class PlayerStats
	{
		public int Health = 100;
	}

	public PlayerStats playerStats = new PlayerStats ();

	public int fallBoundary = -20;

	void Update ()
	{
		if (transform.position.y <= fallBoundary)
		{
			DamagePlayer (9999999);

		}

	}

	public void DamagePlayer (int damage)
	{
		playerStats.Health -= damage;

		if (playerStats.Health <= 0)
		{
			GameMaster.KillPlayer(this);
		}

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