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
	public List<ItemList> HeldItems = new List<ItemList> ();
	//Target
	public GameObject TarObj;

	#endregion
	
	void start(){
		
	}

	void Update (){
	}


	#region Checking

	public void Check(int ID){
		ResourceVol = Statics.Items[ID].Volume;
		ResourceMas = Statics.Items[ID].Mass;
		ResourceName = Statics.Items[ID].Name;
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
		foreach(ItemList c in HeldItems){
			MassHeld += c.Mass;
		}
		CheckRoom ();
	}
	public void CheckVolume(){
		VolumeHeld = 0;
		foreach(ItemList c in HeldItems){
			VolumeHeld += c.Volume;
		}
		CheckRoom ();
	}

	public void CheckInv () {
		CheckRoom ();
		Debug.Log ("Number of items in Inventory: " + HeldItems.Count);
		foreach (ItemList c in HeldItems)
			Debug.Log (c);
	}

	#endregion

	public void AddItem (int ID) {
		HeldItems.Add(Statics.Items [ID]);
		Check (ID);
	}

	public void RemoveItem (int ID) {
		HeldItems.Remove(HeldItems[ID]);
		Check (ID);
		
	}

}
