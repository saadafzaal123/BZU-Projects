using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BrickScript : MonoBehaviour 
{

	static int numBricks = 0;
	public int point = 1;
	public int hitPoints = 1;
	public int powerUpChance = 3;

	public GameObject[] powerUpPrefabs;

	// Use this for initialization
	void Start () 
	{
		numBricks++;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision col)
	{
		hitPoints--;

		if(hitPoints <= 0)
		{
			Die ();
		}
	}

	void Die()
	{
		Destroy (gameObject);

		PaddleScript paddleScript = GameObject.Find ("Paddle").GetComponent<PaddleScript> ();
		paddleScript.AddPoint (point);

		numBricks--;

		//if ( Random.Range(0, powerUpChance) == 0 ) 
		//{
			Instantiate( powerUpPrefabs[ Random.Range(0, powerUpPrefabs.Length) ] , transform.position, Quaternion.identity );
		//}

		if (paddleScript.BonusLife == 0) 
		{
			if (paddleScript.Score > 100) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		else if (paddleScript.BonusLife == 1) 
		{
			if (paddleScript.Score > 200) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		else if (paddleScript.BonusLife == 2) 
		{
			if (paddleScript.Score > 300) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		else if (paddleScript.BonusLife == 3) 
		{
			if (paddleScript.Score > 400) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		else if (paddleScript.BonusLife == 4) 
		{
			if (paddleScript.Score > 500) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		else if (paddleScript.BonusLife == 5) 
		{
			if (paddleScript.Score > 600) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		else if (paddleScript.BonusLife == 6) 
		{
			if (paddleScript.Score > 700) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		else if (paddleScript.BonusLife == 7) 
		{
			if (paddleScript.Score > 800) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		else if (paddleScript.BonusLife == 8) 
		{
			if (paddleScript.Score > 900) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		else if (paddleScript.BonusLife == 9) 
		{
			if (paddleScript.Score > 1000) 
			{
				paddleScript.gainLife ();
				paddleScript.BonusLife++;
			}
		}

		if (numBricks <= 0) 
		{
			//Application.LoadLevel ("level2");

			paddleScript.NextLevel ();

			if (paddleScript.Level == 2) {
				paddleScript.ballSpeed = 550f;
				SceneManager.LoadScene ("level2", LoadSceneMode.Single);
			}

			if (paddleScript.Level == 3) {
				paddleScript.ballSpeed = 600f;
				SceneManager.LoadScene ("level3", LoadSceneMode.Single);
			}

			if (paddleScript.Level == 4) {
				paddleScript.ballSpeed = 650f;
				SceneManager.LoadScene ("level4", LoadSceneMode.Single);
			}

			if (paddleScript.Level == 5) {
				paddleScript.ballSpeed = 700f;
				SceneManager.LoadScene ("level5", LoadSceneMode.Single);
			}

			if (paddleScript.Level == 6) {
				paddleScript.ballSpeed = 750f;
				SceneManager.LoadScene ("level6", LoadSceneMode.Single);
			}

			if (paddleScript.Level == 7) {
				paddleScript.ballSpeed = 800f;
				SceneManager.LoadScene ("level7", LoadSceneMode.Single);
			}

			if (paddleScript.Level == 8) {
				paddleScript.ballSpeed = 850f;
				SceneManager.LoadScene ("level8", LoadSceneMode.Single);
			}

			if (paddleScript.Level == 9) {
				paddleScript.ballSpeed = 900f;
				SceneManager.LoadScene ("level9", LoadSceneMode.Single);
			}

			if (paddleScript.Level == 10) {
				paddleScript.ballSpeed = 1000f;
				SceneManager.LoadScene ("level10", LoadSceneMode.Single);
			}

			if (paddleScript.Level == 11) {
				SceneManager.LoadScene ("gameWining", LoadSceneMode.Single);
			}
		} 
	}
}