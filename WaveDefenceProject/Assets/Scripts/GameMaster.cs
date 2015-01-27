using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
	public static GameMaster gm;
	public ParticleSystem ps;

	void Start ()
	{
		//find the GM object
		if (gm == null)
		{
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}

		//set the particle system to the correct layer
		ps.renderer.sortingLayerName = "UI";
	}

	public Transform playerPrefab;
	public Transform spawnPoint;
	public float spawnDelay = 2.0f;
	public int LivesRemaining = 3;

	public IEnumerator RespawnPlayer ()
	{
		if (HasLives())
		{
			Debug.Log ("TO DO: Add respawn timer");
			yield return new WaitForSeconds (spawnDelay);
	
			Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
			Instantiate (ps, new Vector3(spawnPoint.position.x, spawnPoint.position.y + 0.5f, spawnPoint.position.z), spawnPoint.rotation);
		}
		else
		{
			//load the game over scene
			Application.LoadLevel("GameOverScene");
		}
	}

	public static void KillPlayer (Player player)
	{
		Destroy (player.gameObject);

		AddLives (-1);

		gm.StartCoroutine(gm.RespawnPlayer ());

	}

	public static void KillEnemy (Enemy enemy)
	{
		Destroy (enemy.gameObject);
	}

	public static void AddLives (int number)
	{
		gm.LivesRemaining += number;
	}
	
	public static bool HasLives ()
	{
		return (gm.LivesRemaining > 0) ? true : false;
	}

	public static int numberOfLivesLeft ()
	{
		return gm.LivesRemaining;
	}

}
