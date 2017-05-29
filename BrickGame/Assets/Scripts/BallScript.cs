using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour 
{
	public AudioClip[] blipAudio;

	// Use this for initialization
	void Start () 
	{
		//GetComponent<Rigidbody> ().AddForce (0, 300f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Die()
	{
		Destroy (gameObject);

		GameObject paddleObject = GameObject.Find ("Paddle");
		PaddleScript paddleScript = paddleObject.GetComponent<PaddleScript> ();
		paddleScript.LoseLife ();
	}

	void OnCollisionEnter(Collision col)
	{
		AudioSource.PlayClipAtPoint (blipAudio [Random.Range (0, blipAudio.Length)], transform.position, .25f);
	}
}
