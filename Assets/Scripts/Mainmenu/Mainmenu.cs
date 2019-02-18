using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Statics.ShowMouse = true;
    }

    void OnGUI(){
        if(
            GUI.Button(
                new Rect(
                    (Screen.width / 2f)-100,
                    150,
                    200, 20
                ),
            "Windows")
        ){
        SceneManager.LoadScene("Test");
        }
        if(
            GUI.Button(
                new Rect(
                    (Screen.width / 2f)-100,
                    180,
                    200, 20
                ),
            "Linux")
        ){
        SceneManager.LoadScene("Test-Linux");
        }
        if(
            GUI.Button(
                new Rect(
                    (Screen.width / 2f)-100,
                    210,
                    200, 20
                ),
            "Test Generated")
        ){
        SceneManager.LoadScene("Test-Linux-Generated");
        }
    }



}
