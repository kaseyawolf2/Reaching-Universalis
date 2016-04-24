using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	#region Initial Statements
	public float Volume;
	public float MaxVolume;
	public float AvlVolume;
	public float Mass;
	public float MaxMass;
	public float AvlMass;
	public bool CanHold;
	//Resource Statements
	int ResourceVol;
	int ResourceMas;
	string ResourceName;
	//Item Addtion/Removeal
	string Name = "Stone";
	//Inventorys
	public List<Item> HeldItems = new List<Item> ();
	#endregion
	
	void start(){
		
	}

	void Update (){
		if(Input.GetKeyDown("f")){
			foreach (Item c in HeldItems)
				Debug.Log (gameObject.name + " " +c);
		}
		if(Input.GetKeyDown("w")){
			Debug.Log (gameObject.name +" "+ HeldItems.Find(x => x.Name.Contains("Stone")));
		}
		if(Input.GetKeyDown("s")){
			RemoveItem (0);
		}
	}


	#region Checking

	public void Check(){
		CheckLift ();
		CheckMass ();
		CheckVolume ();
	}

	public void CheckLift () {
		CheckRoom ();
		GetMV ();
		if (AvlMass < ResourceMas || AvlVolume < ResourceVol) {
			CanHold = false;
		} else {
			CanHold = true;
		}
	}

	void CheckRoom () {
		AvlMass = MaxMass - Mass;
		AvlVolume = MaxVolume - Volume;
	}

	void CheckMass(){
		Mass = 0;
		foreach(Item c in HeldItems){
			Mass += c.Mass;
		}
	}
	void CheckVolume(){
		Volume = 0;
		foreach(Item c in HeldItems){
			Volume += c.Volume;
		}
	}

	public void CheckInv () {
		CheckRoom ();
		Debug.Log ("Number of items in Inventory: " + HeldItems.Count);
		foreach (Item c in HeldItems)
			Debug.Log (c);
	}

	#endregion

	void GetMV () {
		ResourceVol = gameObject.GetComponent<ResourceGet> ().ResourceVol;
		ResourceMas = gameObject.GetComponent<ResourceGet> ().ResourceMas;
		ResourceName = gameObject.GetComponent<ResourceGet> ().Resourcetype;
	}


	public void AddItem () {
		//not finished Does not have a way to find the ID that you want
		int ID = ItemsList.Items.Find (x => x.Name.Contains (ResourceName)).ItemID;
		HeldItems.Add (ItemsList.Items [ID]);
		Check ();
	}

	public void RemoveItem (int ID) {
		//not finished
		Debug.Log ("Removed Item");
		HeldItems.Remove(HeldItems[ID]);
		Check ();
		
	}

}
