using UnityEngine;
using System.Collections;

public class ResourceGet : MonoBehaviour
{

	public string Resourcetype;
	public int ResourceAmount;
	public GameObject TargetNode;


	// Use this for initialization
	void Start ()
	{
		ResourceAmount = TargetNode.GetComponent<ResourceNode> ().ResourceAmt;
		Resourcetype = TargetNode.GetComponent<ResourceNode> ().ResourceType;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void GrabResources ()
	{
		if (ResourceAmount > 0) {
			Debug.Log ("It Worked");
			gameObject.GetComponent<Inventory> ().CheckLift ();
			if (gameObject.GetComponent<Inventory> ().CanHold == 1) {
				Debug.Log ("Can Hold the " + Resourcetype);
				TargetNode.GetComponent<ResourceNode> ().ResourceAmt = (TargetNode.GetComponent<ResourceNode> ().ResourceAmt - 1);

			}
		}
			
	}

}
