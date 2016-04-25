using UnityEngine;
using System.Collections;

public class ResourceNode : MonoBehaviour {
	public int ResourceAmt;
	public string ResourceType;
	public int ResourceVol;
	public int ResourceMas;

	public int ItemID;

	void Start () {
		if (ItemsList.Items.Contains(new Item {Name = ResourceType})) {
			Debug.Log ("There is already an item that has this name");
		} else{
			Debug.Log ("Added Item to List");
			ItemsList.Items.Add (new Item { ItemID = ItemsList.Items.Count, Name = ResourceType, Volume = ResourceVol, Mass = ResourceMas });
		}
		ItemID = ItemsList.Items.Find (x => x.Name.Equals (ResourceType)).ItemID;


	}
	
	// Update is called once per frame
	void Update () {

	}
	
	

}