﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ForceLoading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
     if(!Statics.ImportFinished){
        SceneManager.LoadScene("Start");
     }   
    }
}
