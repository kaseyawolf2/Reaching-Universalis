using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	#region Initial Statements
	public float VolumeHeld;
	public float MaxVolume;
	public float AvlVolume;
	public float MassHeld;
	public float MaxMass;
	public float AvlMass;
	public bool CanHold;
	//Resource Statements
	float ResourceVol;
	float ResourceMas;
	string ResourceName;
	//Item Addtion/Removeal
	string Name = "Stone";
	//Inventorys
	public List<Item> HeldItems = new List<Item> ();
	//Target
	public GameObject TarObj;

	#endregion
	
	void start(){
		
	}

	void Update (){
	}


	#region Checking

	public void Check(int ID){
		ResourceVol = ItemsList.Items[ID].Volume;
		ResourceMas = ItemsList.Items[ID].Mass;
		ResourceName = ItemsList.Items[ID].Name;
		CheckLift ();
		CheckMass ();
		CheckVolume ();
	}

	public void CheckLift () {
		CheckRoom ();
		if (AvlMass < ResourceMas || AvlVolume < ResourceVol) {
			CanHold = false;
		} else {
			CanHold = true;
		}
	}

	void CheckRoom () {
		AvlMass = MaxMass - MassHeld;
		AvlVolume = MaxVolume - VolumeHeld;
	}

	public void CheckMass(){
		MassHeld = 0;
		foreach(Item c in HeldItems){
			MassHeld += c.Mass;
		}
	}
	public void CheckVolume(){
		VolumeHeld = 0;
		foreach(Item c in HeldItems){
			VolumeHeld += c.Volume;
		}
	}

	public void CheckInv () {
		CheckRoom ();
		Debug.Log ("Number of items in Inventory: " + HeldItems.Count);
		foreach (Item c in HeldItems)
			Debug.Log (c);
	}

	#endregion

	public void AddItem (int ID) {
		HeldItems.Add (ItemsList.Items [ID]);
		Check (ID);
	}

	public void RemoveItem (int ID) {
		//not finished
		Debug.Log ("Removed Item");
		HeldItems.Remove(HeldItems[ID]);
		Check (ID);
		
	}

}
