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
	public int PageNum = 1;
	public int MaxPage;
	//List Declaerations
	List<Item> HeldItem;
	//Inventory Toggle
	bool InvTog = true;


	void Start(){
		GetLists ();
		MaxNumEntrys =  (int) ((((Screen.height / 1.5f) - InventoryBevel * 2) / FontHeight)-5);
	}

	void Update(){
		if(Input.GetButtonDown("Inventory")){
			InvTog = !InvTog;
		}
	}


	void GetLists(){
		HeldItem = gameObject.GetComponent<Inventory>().HeldItems;
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
				MaxPage = HeldItem.Count / MaxNumEntrys;
				if (PageNum > 0 ) {
					PageNum -= 1;
				}
			}
				//Down
			if(GUI.Button (new Rect ((Screen.width / 2) - 25 - InventoryBevel * 3, ((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6, 25, 25),"v")){
				
				MaxPage = HeldItem.Count / MaxNumEntrys;
				if(PageNum < MaxPage){
					PageNum += 1;
				}
			}
			//Target
				//Up
				GUI.Button (new Rect ((Screen.width / 2)+(Screen.width / 3) - InventoryBevel*8, (Screen.height / 6) + InventoryBevel * 3, 25, 25),"^");
				//Down
				GUI.Button (new Rect ((Screen.width / 2)+(Screen.width / 3) - InventoryBevel*8, ((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6, 25, 25),"v");






		//Display Items
			//PLayer Items
				//Keep Count
				int Count = 0;
				//For each item display a line
				foreach (Item C in HeldItem) {
				if (Count - ((1+MaxNumEntrys)*PageNum) <= MaxNumEntrys) {
					if( (((Screen.height / 6) + (FontHeight * (Count+2)) + InventoryBevel * 2)-((PageNum*(MaxNumEntrys+1))*FontHeight)-25 > ((Screen.height / 6) + InventoryBevel * 3)) || (((Screen.height / 6) + (FontHeight * (Count+2)) + InventoryBevel * 2)+((PageNum*(MaxNumEntrys+1))*FontHeight) < (((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6 - FontHeight*1) )  ){
						//Display Items
						GUI.Label (new Rect ((Screen.width / 6) + InventoryBevel * 2, (Screen.height / 6) + (FontHeight * (Count+2)) + InventoryBevel * 2 - ((PageNum*(MaxNumEntrys+1))*FontHeight), (Screen.width / 3) - InventoryBevel * 2, FontHeight), Count +" "  + C.ToString ());
						//Transfer Arrows Dont Do anything
						GUI.Button (new Rect ((Screen.width / 2) - 25 - InventoryBevel * 3, (Screen.height / 6) + (FontHeight * (Count+2)) + InventoryBevel * 2 - ((PageNum*(MaxNumEntrys+1))*FontHeight), FontHeight, FontHeight), ">");
					}
				}
				//add one to the count so we know how much to displace the GUI.Label and know when to stop
				Count += 1;
			}
		}
	}
}