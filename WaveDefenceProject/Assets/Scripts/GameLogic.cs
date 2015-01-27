using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour
{

	public GameMaster gm;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log (gm.LivesRemaining);
	}
}
