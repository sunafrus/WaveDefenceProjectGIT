using UnityEngine;
using System.Collections;

public class MeleeEnemy : Enemy {

	public Transform target;

	void Start ()
	{
		enemyStats.Speed = 3;
	}

	// Update is called once per frame
	void Update ()
	{
		if (target == null)
		{			
			target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();;
		}

		bool targetIsRight = (target.position.x > transform.position.x) ? true : false;

		bool nextToPlayer = (Vector3.Distance (transform.position, target.position) < 1f) ? true : false;

		Debug.Log (rigidbody2D.velocity.x);

		//move towards the player
		if (!nextToPlayer)
		{

			if (targetIsRight)
			{
				rigidbody2D.velocity = new Vector2(enemyStats.Speed, rigidbody2D.velocity.y);
			}
			else
			{
				rigidbody2D.velocity = new Vector2(-enemyStats.Speed, rigidbody2D.velocity.y);
			}

			if (rigidbody2D.velocity.x < 0.3f && rigidbody2D.velocity.x > -0.3f)
			{
				Debug.Log("Should be jumping");
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, enemyStats.Speed);
			}

		}

	
	}
}
