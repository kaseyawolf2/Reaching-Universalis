﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (Statics.ImportFinished == true)
        {
            if (Statics.Debug) {
                Debug.Log ("Swaping to Main Scene");
            }
            SceneManager.LoadScene("Main");
		}
	}
}