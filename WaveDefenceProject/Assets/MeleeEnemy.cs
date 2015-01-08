using UnityEngine;
using System.Collections;

public class MeleeEnemy : Enemy {

	public Transform target;

	public Collider2D targetCollider;

	//bool inCollision = false;

	void Start ()
	{
		enemyStats.Speed = 3;
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

		Debug.Log ("Enemy Speed: " + rigidbody2D.velocity.x);

		Debug.Log ("Next to player?: " + nextToPlayer);

		//Debug.Log ("In Collision?: " + inCollision);

		//move towards the player
		if (nextToPlayer == false)
		{

			//if (inCollision == false)
			//{
				if (targetIsRight)
				{
					rigidbody2D.velocity = new Vector2(enemyStats.Speed, rigidbody2D.velocity.y);
				}
				else
				{
					rigidbody2D.velocity = new Vector2(-enemyStats.Speed, rigidbody2D.velocity.y);
				}
			//}

			if (rigidbody2D.velocity.x < 0.3f)
			{
				Debug.Log("STAGE ONE");

				if (rigidbody2D.velocity.x > -0.3f)
				{
					Debug.Log("STAGE TWO");
					rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, enemyStats.Speed);
				}
			}

		}

	
	}

	/*void onCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall")
		{
			inCollision = true;
			Debug.Log ("Entered collision");
		}
	}

	void onCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall")
		{
			inCollision = false;
			Debug.Log ("Exited collision");
		}
	}*/
}
