using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Statics.ImportFinished == true){
			SceneManager.LoadScene("Main");
		}
	}
}
