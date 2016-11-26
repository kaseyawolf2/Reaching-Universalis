using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Random.InitState(Statics.Seed);
		if (Statics.ImportFinished == false)
		{
			SceneManager.LoadScene("Loading");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
