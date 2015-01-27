using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {

	public bool jumpRight;
	public bool jumpLeft;

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("Collision entered");

		GameObject target = other.gameObject;

		if (target.tag == "MeleeEnemy" || target.tag == "Enemy")
		{
			if (target.rigidbody2D.velocity.x > 0 && jumpRight)
				target.GetComponent<MeleeEnemy> ().Jump ();

			if (target.rigidbody2D.velocity.x < 0 && jumpLeft)
				target.GetComponent<MeleeEnemy> ().Jump ();
		}
	}
}
