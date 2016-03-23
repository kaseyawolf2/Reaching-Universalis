using UnityEngine;
using System.Collections;

public class ResourceGet : MonoBehaviour {

	public string Resourcetype;
	public int ResourceAmount;
	public GameObject Test;
    


    // Use this for initialization
    void Start () {
        ResourceAmount = Test.GetComponent<ResourceNode>().ResourceAmt;
        Resourcetype = Test.GetComponent<ResourceNode>().ResourceType;
    }
	
	// Update is called once per frame
	void Update () {



    }
	
	void GrabResources () {
		if (ResourceAmount > 0) {
			Debug.Log ("It Worked");
			gameObject.GetComponent<>()
		}
			
	}
	
	
	
	
	
	
	
	
	
	
}
