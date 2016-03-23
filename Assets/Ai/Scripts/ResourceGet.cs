using UnityEngine;
using System.Collections;

public class ResourceGet : MonoBehaviour {

	public string Resource;


    


    // Use this for initialization
    void Start () {
	
	
	
	}
	
	// Update is called once per frame
	void Update () {



    }
	
	void GrabResources () {
		if (true) {
			Collision.gameObject.ResourceAmt = Collision.gameObject.ResourceAmt - 1;
			Resource = Collision.gameObject.ResourceType;
		}
			
	}
	
	
	
	
	
	
	
	
	
	
}
