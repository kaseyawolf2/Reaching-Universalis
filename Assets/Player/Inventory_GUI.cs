using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Inventory_GUI : MonoBehaviour {
	#region Declerations
	//Background Formanting
	float InventoryBevel = 5;
	float FontHeight = 20;
	//List Formating
	float ListOffset;
	int MaxNumEntrys;
	int PageNumPlr = 0;
	int PageNumTar = 0;
	int MaxPagePlr;
	int MaxPageTar;
	//Keybinds
	KeyCode KbInventory = KeyCode.I;

	//List Declaerations
	List<ItemList> PlrItem;
	List<ItemList> TarItem;
	//Inventory Toggle
	bool InvTog = false;
	//Target
	public GameObject Target;
	//Inventory info
	//Player
	float AvlMassPlr;
	float AvlVolPlr;
	float MaxMassPlr;
	float MaxVolPlr;
	//Target
	float AvlMassTar;
	float AvlVolTar;
	float MaxMassTar;
	float MaxVolTar;
	#endregion

	void Start(){
		MaxNumEntrys =  (int) ((((Screen.height / 1.5f) - InventoryBevel * 2) / FontHeight)-5);
	}

	void Update(){
		if(Input.GetKeyDown(KbInventory)){
            ShowInventory ();
        }
	}

    void ShowInventory () {
        InvTog = !InvTog;
        Statics.ShowMouse = !Statics.ShowMouse;
        GetTarget ();
    }

	public void GetTarget(){
        gameObject.GetComponent<Player> ().RaycastTarget ();
		Target = gameObject.GetComponent<Inventory> ().TarObj;
		GetLists ();
	}
	#region Inventory Info
	void UpdateInvInfo(){

		gameObject.GetComponent<Inventory> ().HoldInfo ();

		AvlMassPlr = gameObject.GetComponent<Inventory> ().AvlMass;
		AvlVolPlr = gameObject.GetComponent<Inventory> ().AvlVolume;
		MaxMassPlr = gameObject.GetComponent<Inventory> ().MaxMass;
		MaxVolPlr = gameObject.GetComponent<Inventory> ().MaxVolume;

        Target.GetComponent<Inventory>().HoldInfo ();

		AvlMassTar = Target.GetComponent<Inventory> ().AvlMass;
		AvlVolTar = Target.GetComponent<Inventory> ().AvlVolume;
		MaxMassTar = Target.GetComponent<Inventory> ().MaxMass;
		MaxVolTar = Target.GetComponent<Inventory> ().MaxVolume;
	}

	void GetLists(){
		PlrItem = gameObject.GetComponent<Inventory>().HeldItems;
		if (Target != null && Target.GetComponent<Inventory> () != null) {
			TarItem = Target.GetComponent<Inventory> ().HeldItems;
			UpdateInvInfo ();
		}
	}
	#endregion
	void OnGUI(){
		if (InvTog == true){
				#region Background for inventory
				//Center Background Block
				GUI.Box(new Rect(Screen.width/6,(Screen.height/6)-FontHeight,Screen.width/1.5f,(Screen.height/1.5f)+FontHeight),"Inventory");
				//Left Background Box aka Player Items
				GUI.Box (new Rect ((Screen.width / 6) + InventoryBevel, (Screen.height / 6) + InventoryBevel, (Screen.width / 3) - InventoryBevel*2, (Screen.height / 1.5f) - InventoryBevel*2), "Player Inventory");
				//Right Background Box Aka Target's Items
			if (Target != null && Target.GetComponent<Inventory> () != null) {
				GUI.Box (new Rect ((Screen.width / 2) + InventoryBevel, (Screen.height / 6) + InventoryBevel, (Screen.width / 3) - InventoryBevel * 2, (Screen.height / 1.5f) - InventoryBevel * 2), Target.name + " Inventory");
			}
				#endregion
				#region Page Up/Down Arrows
				#region Player
					//Up
				if(GUI.Button (new Rect ((Screen.width / 2) - 25 - InventoryBevel * 3, (Screen.height / 6) + InventoryBevel * 3, 25, 25),"^")){
					MaxPagePlr = PlrItem.Count / MaxNumEntrys;
					if (PageNumPlr > 0 ) {
						PageNumPlr -= 1;
					}
				}
					//Down
				if(GUI.Button (new Rect ((Screen.width / 2) - 25 - InventoryBevel * 3, ((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6, 25, 25),"v")){
					MaxPagePlr = Mathf.CeilToInt (PlrItem.Count / MaxNumEntrys) - 1;
					if(PageNumPlr < MaxPagePlr){
						PageNumPlr += 1;
					}
				}
				#endregion
				#region Target
			if (Target != null && Target.GetComponent<Inventory> () != null) {
				//Up
				if (GUI.Button (new Rect ((Screen.width / 2) + (Screen.width / 3) - InventoryBevel * 8, (Screen.height / 6) + InventoryBevel * 3, 25, 25), "^")) {
					MaxPageTar = Mathf.CeilToInt (TarItem.Count / MaxNumEntrys) - 1;
					if (PageNumTar > 0) {
						PageNumTar -= 1;
					}
				}
				//Down
				if (GUI.Button (new Rect ((Screen.width / 2) + (Screen.width / 3) - InventoryBevel * 8, ((Screen.height / 1.5f) - InventoryBevel * 2) + (Screen.height / 6) - InventoryBevel * 6, 25, 25), "v")) {
					MaxPageTar = TarItem.Count / MaxNumEntrys;
					if (PageNumTar < MaxPageTar) {
						PageNumTar += 1;
					}
				}
			}
				#endregion
				#endregion
				#region Display Items
					#region PLayer Items
					//Keep Count
					int CountPlr = 0;
					//For each item display a line
					foreach (ItemList Plr in PlrItem) {
					if (CountPlr - ((1+MaxNumEntrys)*PageNumPlr) <= MaxNumEntrys) {
						if( (((Screen.height / 6) + (FontHeight * (CountPlr+2)) + InventoryBevel * 2)-((PageNumPlr*(MaxNumEntrys+1))*FontHeight)-25 > ((Screen.height / 6) + InventoryBevel * 3)) || (((Screen.height / 6) + (FontHeight * (CountPlr+2)) + InventoryBevel * 2)+((PageNumPlr*(MaxNumEntrys+1))*FontHeight) < (((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6 - FontHeight*1) )  ){
							//Display Items
							GUI.Label (new Rect ((Screen.width / 6) + InventoryBevel * 2, (Screen.height / 6) + (FontHeight * (CountPlr+2)) + InventoryBevel * 2 - ((PageNumPlr*(MaxNumEntrys+1))*FontHeight), (Screen.width / 3) - InventoryBevel * 2, FontHeight), CountPlr +" "  + Plr.ToString ());
							//Transfering Out of PLayers inventory
							if(GUI.Button (new Rect ((Screen.width / 2) - 25 - InventoryBevel * 3, (Screen.height / 6) + (FontHeight * (CountPlr+2)) + InventoryBevel * 2 - ((PageNumPlr*(MaxNumEntrys+1))*FontHeight), FontHeight, FontHeight), ">")){
								UpdateInvInfo ();
								int HeldID = CountPlr;
								ItemList TarID = gameObject.GetComponent<Inventory> ().HeldItems [HeldID];
								//Check if it can hold the item
								if(Target.GetComponent<Inventory>().Check(TarID.ItemID)) {
									gameObject.GetComponent<Inventory> ().RemoveItem (HeldID);
									Target.GetComponent<Inventory>().AddItem (HeldID);
									GetLists ();
									UpdateInvInfo ();
								}
							}
						}
					}
					//add one to the count so we know how much to displace the GUI.Label and know when to stop
					CountPlr += 1;
				}
					#endregion
					#region Target Items
				int CountTar = 0;
			if (Target != null && Target.GetComponent<Inventory> () != null) {
				foreach (ItemList Tar in TarItem) {
					if (CountTar - ((1 + MaxNumEntrys) * PageNumTar) <= MaxNumEntrys) {
						if ((((Screen.height / 6) + (FontHeight * (CountTar + 2)) + InventoryBevel * 2) - ((PageNumTar * (MaxNumEntrys + 1)) * FontHeight) - 25 > ((Screen.height / 6) + InventoryBevel * 3)) || (((Screen.height / 6) + (FontHeight * (CountTar + 2)) + InventoryBevel * 2) + ((PageNumTar * (MaxNumEntrys + 1)) * FontHeight) < (((Screen.height / 1.5f) - InventoryBevel * 2) + (Screen.height / 6) - InventoryBevel * 6 - FontHeight * 1))) {
							//Display Items
							GUI.Label (new Rect ((Screen.width / 2) + InventoryBevel * 4 + 25, (Screen.height / 6) + (FontHeight * (CountTar + 2)) + InventoryBevel * 2 - ((PageNumTar * (MaxNumEntrys + 1)) * FontHeight), (Screen.width / 3) - InventoryBevel * 2, FontHeight), CountTar + " " + Tar.ToString ());
							//Transfering out of Target Inventory
							if (GUI.Button (new Rect ((Screen.width / 2) + InventoryBevel * 4, (Screen.height / 6) + (FontHeight * (CountTar + 2)) + InventoryBevel * 2 - ((PageNumTar * (MaxNumEntrys + 1)) * FontHeight), FontHeight, FontHeight), "<")) {
								UpdateInvInfo ();
								int ID = CountTar;
								ItemList TarID = Target.GetComponent<Inventory> ().HeldItems [ID];
								//Check if it can hold the item
								if (gameObject.GetComponent<Inventory> ().Check(TarID.ItemID)) {
									Target.GetComponent<Inventory> ().RemoveItem (ID);
									gameObject.GetComponent<Inventory> ().AddItem (ID);
									GetLists ();
									UpdateInvInfo ();
								}
							}
						}
					}
					CountTar += 1;
				}
			}
					#endregion
					#region Inventory Stats
				//Player Inventory Stats
				GUI.Label (new Rect((Screen.width / 6) + InventoryBevel*3, (Screen.height / 6) + InventoryBevel + FontHeight, (Screen.width / 3) - InventoryBevel*2, (Screen.height / 1.5f) - InventoryBevel*2), "Avl Mass: " + AvlMassPlr + " Avl Volume: " +AvlVolPlr + " Max Mass: " + MaxMassPlr + " Max Volume: " + MaxVolPlr);
				//Target Inventory Stats
			if (Target != null && Target.GetComponent<Inventory>() != null) {
				GUI.Label (new Rect((Screen.width / 2) + InventoryBevel*3, (Screen.height / 6) + InventoryBevel + FontHeight, (Screen.width / 3) - InventoryBevel*2, (Screen.height / 1.5f) - InventoryBevel*2), "Avl Mass: " + AvlMassTar + " Avl Volume: " +AvlVolTar + " Max Mass: " + MaxMassTar + " Max Volume: " + MaxVolTar);
			}
				#endregion
				#endregion
			}
		}
}