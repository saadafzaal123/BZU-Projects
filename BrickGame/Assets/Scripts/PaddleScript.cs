using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PaddleScript : MonoBehaviour 
{

	float paddleSpeed = 15f;
	public GameObject ballObject;
	GameObject attachBall = null;
	int Lives = 3;
	public int Level = 0;
	public int BonusLife = 0;
	UnityEngine.UI.Text guiLives;
	UnityEngine.UI.Text gameLevels;
	public int Score = 0;
	public GUISkin ScoreBoardSkin;
	public float ballSpeed = 500f;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (GameObject.Find ("Canvas"));

		guiLives = GameObject.Find ("GUILives").GetComponent<UnityEngine.UI.Text>();
		gameLevels = GameObject.Find ("GameLevels").GetComponent<UnityEngine.UI.Text>();

		NextLevel ();

		guiLives.text = "Lives: " + Lives;

		spawnBall ();
	}

	public void OnLevelWasLoaded(int level)
	{
		spawnBall ();
	}

	// Update is called once per frame
	void Update () 
	{
		/*if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			Debug.Log ("Left!");
		}

        if (Input.GetButtonDown ("Jump")) 
		{
			Debug.Log ("Jump!");
		}

		if (Input.GetAxis ("Horizontal") < 0) 
		{
			Debug.Log ("Left!");

			transform.Translate (-10f * Time.deltaTime, 0, 0);
		}

		if (Input.GetAxis ("Horizontal") > 0) 
		{
			Debug.Log ("Right!");

			transform.Translate (10f * Time.deltaTime, 0, 0);
		}*/

		transform.Translate (paddleSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"), 0, 0);

		if (transform.position.x > 7.4f) 
		{
			transform.position = new Vector3 (7.4f, transform.position.y, transform.position.z);
		}

		if (transform.position.x < -7.4f) 
		{
			transform.position = new Vector3 (-7.4f, transform.position.y, transform.position.z);
		}

		if (attachBall) 
		{
			Rigidbody ballRigidBody = attachBall.GetComponent<Rigidbody>();

			ballRigidBody.position = transform.position + new Vector3 (0, 0.75f, 0);

			if (Input.GetButtonDown ("Jump"))
			{
				ballRigidBody.isKinematic = false;
				ballRigidBody.AddForce (400f * Input.GetAxis ("Horizontal"), ballSpeed, 0);
				attachBall = null;
			}
		}
	}

	void OnGUI()
	{
		GUI.skin = ScoreBoardSkin;
		GUI.Label (new Rect (50, 0, 300, 100), "Score: " + Score);
	}

	public void AddPoint(int p)
	{
		Score += p;
	}

	public void LoseLife()
	{
		Lives--;

		guiLives.text = "Lives: " + Lives;

		if (Lives > 0) 
		{
			spawnBall ();
		} 

		else 
		{
			Destroy (gameObject);
			SceneManager.LoadScene ("gameOver");
		}
	}

	public void gainLife()
	{
		Lives++;

		guiLives.text = "Lives: " + Lives;
	}

	public void NextLevel()
	{
		Level++;

		gameLevels.text = "Level: " + Level;
	}

	public void spawnBall()
	{
		if (ballObject == null) 
		{
			Debug.Log ("You missed to add Ball Object!");
			return;
		}

		Vector3 ballPosition = transform.position + new Vector3 (0, 0.75f, 0);
		Quaternion ballRotation = Quaternion.identity;

		attachBall = (GameObject)Instantiate (ballObject, ballPosition, ballRotation);
	}

	void OnCollisionEnter(Collision col)
	{
		foreach (ContactPoint contact in col.contacts) 
		{
			if (contact.thisCollider == GetComponent<Collider>()) 
			{
				float english = contact.point.x - transform.position.x;

				contact.otherCollider.GetComponent<Rigidbody> ().AddForce (300f * english, 0, 0);
			}
		}
	}
}