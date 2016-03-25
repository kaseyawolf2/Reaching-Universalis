using UnityEngine;
using System.Collections;

public class ResourceGet : MonoBehaviour {

	public string Resourcetype;
	public int ResourceAmount;
	public GameObject TargetNode;
	public int ResourceVol;
	public int ResourceMas;


	// Use this for initialization
	void Start () {
		GrabResources ();
		GrabResources ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GrabResources () {
		GetNodeInfo ();
		if (ResourceAmount > 0) {
			Debug.Log ("It has Resources");
			gameObject.GetComponent<Inventory> ().CheckLift ();
			if (gameObject.GetComponent<Inventory> ().CanHold == true) {
				Debug.Log ("Can Hold the " + Resourcetype);
				TargetNode.GetComponent<ResourceNode> ().ResourceAmt = (TargetNode.GetComponent<ResourceNode> ().ResourceAmt - 1);
				gameObject.GetComponent<Inventory>().AddItem ();
			}
		}
		GetNodeInfo ();
	}

	void GetNodeInfo () {
		ResourceAmount = TargetNode.GetComponent<ResourceNode> ().ResourceAmt;
		Resourcetype = TargetNode.GetComponent<ResourceNode> ().ResourceType;
		ResourceMas = TargetNode.GetComponent<ResourceNode> ().ResourceMas;
		ResourceVol = TargetNode.GetComponent<ResourceNode> ().ResourceVol;
	}
}
