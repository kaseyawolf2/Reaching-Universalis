using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {
	// Use this for initialization
<<<<<<< HEAD
	void Awake () {
		Random.InitState(Statics.Seed);
=======
	void Start () {
        Random.InitState(Statics.Seed);
>>>>>>> origin/master
		if (Statics.ImportFinished == false)
		{
            Debug.LogError("Swaping to Loading Scene");
			SceneManager.LoadScene("Loading");
		}
	}
}