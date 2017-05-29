using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		Destroy (GameObject.Find ("Canvas"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Restart()
	{
		//SceneManager.LoadScene ("level1", LoadSceneMode.Single);
		Application.Quit();
	}
}
