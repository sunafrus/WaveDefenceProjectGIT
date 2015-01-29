using UnityEngine;
using System.Collections;

public class GUIcreator : MonoBehaviour
{
	GameObject player;
	GameMaster gm;

	void Update()
	{
		if (player == null)
		{			
			player = GameObject.FindGameObjectWithTag ("Player");
		}

		gm = GetComponentInParent<GameMaster> ();

	}

	void OnGUI()
	{
		GUI.Label (new Rect (50, 50, 200, 100), "Health: " + player.GetComponent<Player>().getHealth());

		GUI.Label (new Rect (55, 65, 200, 100), "Lives Remaining: " + gm.numberOfLivesLeft());

	}

}

