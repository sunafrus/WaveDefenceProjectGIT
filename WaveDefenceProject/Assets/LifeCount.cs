using UnityEngine;
using System.Collections;

public class LifeCount : MonoBehaviour {
	
	float nextTimeToCheck = 0f;
	public GUIText lifeCounter;
	public static int livesRemaining;

	void Start ()
	{
		lifeCounter.transform.position = new Vector2 (Screen.width / 2, Screen.height / 2);
	}

	void Update ()
	{
		if (nextTimeToCheck <= Time.time)
		{
			lifeCounter.text = "Lives: " + livesRemaining.ToString();
			
			nextTimeToCheck = Time.time + 0.5f;

			Debug.Log(livesRemaining.ToString());
		}
	}
}
