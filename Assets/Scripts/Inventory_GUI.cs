using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Inventory_GUI : MonoBehaviour {
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
	//List Declaerations
	List<Item> PlrItem;
	List<Item> TarItem;
	//Inventory Toggle
	bool InvTog = false;


	void Start(){
		GetLists ();
		MaxNumEntrys =  (int) ((((Screen.height / 1.5f) - InventoryBevel * 2) / FontHeight)-5);
	}

	void Update(){
		if(Input.GetButtonDown("Inventory")){
			InvTog = !InvTog;
			Statics.ShowMouse = !Statics.ShowMouse;
		}
	}


	void GetLists(){
		PlrItem = gameObject.GetComponent<Inventory>().HeldItems;
		TarItem = ItemsList.Items;
	}
	void UpdateLists(){
		gameObject.GetComponent<Inventory> ().HeldItems = PlrItem;

	}

	void OnGUI(){
	if (InvTog == true){
		//Background for inventory
			//Center Background Block
			GUI.Box(new Rect(Screen.width/6,(Screen.height/6)-FontHeight,Screen.width/1.5f,(Screen.height/1.5f)+FontHeight),"Center");
			//Left Background Box aka Player Items
			GUI.Box (new Rect ((Screen.width / 6) + InventoryBevel, (Screen.height / 6) + InventoryBevel, (Screen.width / 3) - InventoryBevel*2, (Screen.height / 1.5f) - InventoryBevel*2), "Left");
			//Right Background Box Aka Target's Items
			GUI.Box (new Rect ((Screen.width / 2) + InventoryBevel, (Screen.height / 6) + InventoryBevel, (Screen.width / 3) - InventoryBevel*2, (Screen.height / 1.5f) - InventoryBevel*2), "Right");
		
		//Page Up/Down Arrows
			//Player
				//Up
			if(GUI.Button (new Rect ((Screen.width / 2) - 25 - InventoryBevel * 3, (Screen.height / 6) + InventoryBevel * 3, 25, 25),"^")){
				MaxPagePlr = PlrItem.Count / MaxNumEntrys;
				if (PageNumPlr > 0 ) {
					PageNumPlr -= 1;
				}
			}
				//Down
			if(GUI.Button (new Rect ((Screen.width / 2) - 25 - InventoryBevel * 3, ((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6, 25, 25),"v")){
				MaxPagePlr = PlrItem.Count / MaxNumEntrys;
				if(PageNumPlr < MaxPagePlr){
					PageNumPlr += 1;
				}
			}
			//Target
				//Up
			if(GUI.Button (new Rect ((Screen.width / 2)+(Screen.width / 3) - InventoryBevel*8, (Screen.height / 6) + InventoryBevel * 3, 25, 25),"^")){
				MaxPageTar = PlrItem.Count / MaxNumEntrys;
				if (PageNumTar > 0 ) {
					PageNumTar -= 1;
				}
			}
				//Down
			if(GUI.Button (new Rect ((Screen.width / 2)+(Screen.width / 3) - InventoryBevel*8, ((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6, 25, 25),"v")){
				MaxPageTar = PlrItem.Count / MaxNumEntrys;
				if (PageNumTar > 0 ) {
					PageNumTar -= 1;
				}
			}

		//Display Items
			//PLayer Items
				//Keep Count
				int CountPlr = 0;
				//For each item display a line
				foreach (Item Plr in PlrItem) {
				if (CountPlr - ((1+MaxNumEntrys)*PageNumPlr) <= MaxNumEntrys) {
					if( (((Screen.height / 6) + (FontHeight * (CountPlr+2)) + InventoryBevel * 2)-((PageNumPlr*(MaxNumEntrys+1))*FontHeight)-25 > ((Screen.height / 6) + InventoryBevel * 3)) || (((Screen.height / 6) + (FontHeight * (CountPlr+2)) + InventoryBevel * 2)+((PageNumPlr*(MaxNumEntrys+1))*FontHeight) < (((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6 - FontHeight*1) )  ){
						//Display Items
						GUI.Label (new Rect ((Screen.width / 6) + InventoryBevel * 2, (Screen.height / 6) + (FontHeight * (CountPlr+2)) + InventoryBevel * 2 - ((PageNumPlr*(MaxNumEntrys+1))*FontHeight), (Screen.width / 3) - InventoryBevel * 2, FontHeight), CountPlr +" "  + Plr.ToString ());
						//Transfer Arrows Dont Do anything
						if(GUI.Button (new Rect ((Screen.width / 2) - 25 - InventoryBevel * 3, (Screen.height / 6) + (FontHeight * (CountPlr+2)) + InventoryBevel * 2 - ((PageNumPlr*(MaxNumEntrys+1))*FontHeight), FontHeight, FontHeight), ">")){
							int HeldID = CountPlr;
							Item TarID = gameObject.GetComponent<Inventory> ().HeldItems [HeldID];
							gameObject.GetComponent<Inventory> ().RemoveItem (HeldID);
							TarItem.Add (TarID);


						}
					}
				}
				//add one to the count so we know how much to displace the GUI.Label and know when to stop
				CountPlr += 1;
			}
			//Target Items
			int CountTar = 0;
			foreach(Item Tar in TarItem){
				if (CountTar - ((1+MaxNumEntrys)*PageNumTar) <= MaxNumEntrys) {
					if( (((Screen.height / 6) + (FontHeight * (CountTar+2)) + InventoryBevel * 2)-((PageNumTar*(MaxNumEntrys+1))*FontHeight)-25 > ((Screen.height / 6) + InventoryBevel * 3)) || (((Screen.height / 6) + (FontHeight * (CountTar+2)) + InventoryBevel * 2)+((PageNumTar*(MaxNumEntrys+1))*FontHeight) < (((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6 - FontHeight*1) )  ){
						//Display Items
						GUI.Label (new Rect ((Screen.width / 2) + InventoryBevel * 4 + 25, (Screen.height / 6) + (FontHeight * (CountTar+2)) + InventoryBevel * 2 - ((PageNumTar*(MaxNumEntrys+1))*FontHeight), (Screen.width / 3) - InventoryBevel * 2, FontHeight), CountTar +" "  + Tar.ToString ());
						//Transfer Arrows Dont Do anything
						if(GUI.Button (new Rect ((Screen.width / 2) + InventoryBevel * 4, (Screen.height / 6) + (FontHeight * (CountTar+2)) + InventoryBevel * 2 - ((PageNumTar*(MaxNumEntrys+1))*FontHeight), FontHeight, FontHeight), "<")){
							int ID = CountTar;




						}
					}
				}
				CountTar += 1;
			}
		}
	}
}