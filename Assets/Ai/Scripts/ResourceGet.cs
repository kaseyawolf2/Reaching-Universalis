using UnityEngine;
using System.Collections;

public class ResourceGet : MonoBehaviour {

	public int ResourceAmount;
	public GameObject TargetNode;
	public int ItemID;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetButtonDown("Harvest")) {
			TargetNode = gameObject.GetComponent<Inventory>().TarObj;
			if (TargetNode != null && TargetNode.GetComponent <ResourceNode> ()) {
				GrabResources ();
			}
		}
	}

	public void GrabResources () {
		GetNodeInfo ();
		ItemID = TargetNode.GetComponent<ResourceNode> ().ItemID;
		if (ResourceAmount > 0) {
			Debug.Log ("It has Resources");
			gameObject.GetComponent<Inventory> ().Check (ItemID);
			if (gameObject.GetComponent<Inventory> ().CanHold == true) {
				Debug.Log ("Can Hold the " + ItemsList.Items[ItemID].Name);
				TargetNode.GetComponent<ResourceNode> ().ResourceAmt = (TargetNode.GetComponent<ResourceNode> ().ResourceAmt - 1);
				gameObject.GetComponent<Inventory> ().AddItem (ItemID);
			} else {
				Debug.Log ("Cant Hold The " + ItemsList.Items[ItemID].Name);
			}
		}
		GetNodeInfo ();
	}

	void GetNodeInfo () {
		ResourceAmount = TargetNode.GetComponent<ResourceNode> ().ResourceAmt;
	}
}
