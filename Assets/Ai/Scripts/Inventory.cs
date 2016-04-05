using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	//Initial Statements
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
	string Name = Stone;
	int ID;


	//Inventorys
	List<Item> HeldItems = new List<Item> ();

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
			RemoveItem ();
		}
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

	void GetMV () {
		ResourceVol = gameObject.GetComponent<ResourceGet> ().ResourceVol;
		ResourceMas = gameObject.GetComponent<ResourceGet> ().ResourceMas;
		ResourceName = gameObject.GetComponent<ResourceGet> ().Resourcetype;
	}

	void CheckRoom () {
		AvlMass = MaxMass - Mass;
		AvlVolume = MaxVolume - Volume;
	}

	public void CheckInv () {
		CheckRoom ();
		Debug.Log ("Number of items in Inventory: " + HeldItems.Count);
		foreach (Item c in HeldItems)
			Debug.Log (c);
	}

	public void AddItem () {
		ID = ItemsList.Items.Find (x => x.Name.Contains (ResourceName)).ItemID;
		HeldItems.Add (ItemsList.Items [ID]);
		Mass = Mass + ResourceMas;
		Volume = Volume + ResourceVol;
		CheckInv ();
	}

	void RemoveItem () {
		Debug.Log ("Removed Item");
		HeldItems.Remove(new Item{Name = Name});
		
	}

}
