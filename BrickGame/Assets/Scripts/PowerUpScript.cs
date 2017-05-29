using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	int point = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetComponent<Rigidbody> ().AddTorque (Vector3.forward * 10f);
	}

	void OnCollisionEnter(Collision col)
	{
		PaddleScript paddleScript = GameObject.Find ("Paddle").GetComponent<PaddleScript> ();
		paddleScript.AddPoint (point);

		Destroy (gameObject);
	}
}
