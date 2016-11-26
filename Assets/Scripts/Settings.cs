using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {
	// Use this for initialization
	void Awake () {
		Random.InitState(Statics.Seed);
		if (Statics.ImportFinished == false)
		{
            Debug.LogError("Swaping to Loading Scene");
			SceneManager.LoadScene("Loading");
		}
	}
}