using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Statics.Items = gameObject.GetComponent<Reader>().LoadItemList("/Lists/Test.xml");
		Statics.Recipes = gameObject.GetComponent<Reader>().LoadCraftingList("/Lists/Test.xml");







        Statics.ImportFinished = true;
        SceneManager.LoadScene("MainMenu");
    }
}
