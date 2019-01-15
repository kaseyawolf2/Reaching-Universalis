using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ListSpace;

public class PlayerMenuGui : MonoBehaviour {
	//Background Formanting
	int InventoryBevel = 5;
	int FontHeight = 20;

	//Keybinds
	KeyCode KbInv = Statics.KbInv;
	KeyCode KbCraft = Statics.KbCraft;

	//Toggles
	bool MenuTog = false;
	bool InvTog = false;
	bool CraftTog = false;
	
	//Other
	string MenuString;

	//Inventory 
	List<ItemList> PlrItem;
	int MaxNumEntrys = 0;
	int MaxPage = 0;
	int PageNum = 0;
	//Crafting 
	List<CraftList> CraftingList;
	void Start(){
		PlrItem = gameObject.GetComponent<Inventory>().HeldItems;
		
		MaxNumEntrys =  (int) ((((Screen.height / 1.5f) - InventoryBevel * 2) / FontHeight)-1);
	}

	void Update(){
		if(Input.GetKeyDown(KbInv)){
			//PlrItem = Statics.Items;
            ShowInv ();
        }
		if(Input.GetKeyDown(KbCraft)){
			CraftingList = Statics.Recipes;
            ShowCraft ();
        }
		if(Input.GetKeyDown(KeyCode.Escape)){
            MenuTog = false;
        }
		if(Input.GetKeyDown(KeyCode.Insert)){
            gameObject.GetComponent<Inventory>().HeldItems.Add(new ItemList { Item = Statics.Items[1].Item});
        }
	}
	void HideOthers(){
		InvTog = false;
		CraftTog = false;
	}

	public void ShowInv() {
		HideOthers();
		MenuTog = true;
		InvTog = true;
		MenuString = "Inventory";
	}

	public void ShowCraft() {
		HideOthers();
		MenuTog = true;
		CraftTog = true;
		MenuString = "Crafting";
	}

	void OnGUI(){
		if(MenuTog){
			GUI.Box(
				new Rect (
					Screen.width/6,
					(Screen.height/6)-FontHeight,
					Screen.width/1.5f,
					(Screen.height/1.5f)+FontHeight
				),MenuString
			);
#region Player Inventory	
			if (InvTog)
			{
				GUI.Box(
					new Rect(
						(Screen.width / 6) + InventoryBevel,
						(Screen.height / 6) + InventoryBevel, 
						(Screen.width / 1.5f) - InventoryBevel*2, 
						(Screen.height / 1.5f) - InventoryBevel*2
					),
					""
				);
				//Up
				if(
					GUI.Button(
						new Rect(
							(Screen.width / 1.25f) - InventoryBevel * 2,
							(Screen.height / 6) + InventoryBevel * 3, 25, 25
						),"^"
					)
				){
					MaxPage = PlrItem.Count / MaxNumEntrys;
					if (PageNum > 0 ) {
						PageNum -= 1;
					}
				}
				//Down
				if(
					GUI.Button(
						new Rect(
							(Screen.width / 1.25f) - InventoryBevel * 2,
							((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6,
							25, 25
						),
					"v")
				){
					MaxPage = Mathf.CeilToInt (PlrItem.Count / MaxNumEntrys) - 1;
					if(PageNum < MaxPage){
						PageNum += 1;
					}
				}
				int Count = 0;
				//For each item display a line
				foreach (ItemList item in PlrItem) {
					if (Count - ((1+MaxNumEntrys)*PageNum) <= MaxNumEntrys) {
						if( (((Screen.height / 6) + (FontHeight * (Count+2)) + InventoryBevel * 2)-((PageNum*(MaxNumEntrys+1))*FontHeight)-25 > ((Screen.height / 6) + InventoryBevel * 3)) || (((Screen.height / 6) + (FontHeight * (Count+2)) + InventoryBevel * 2)+((PageNum*(MaxNumEntrys+1))*FontHeight) < (((Screen.height / 1.5f) - InventoryBevel*2)+(Screen.height / 6)-InventoryBevel*6 - FontHeight*1) )  ){
							GUI.Label(
								new Rect(
									(Screen.width / 6) + InventoryBevel * 2,
									(Screen.height / 6) + InventoryBevel + (FontHeight * (Count)) - ((PageNum*(MaxNumEntrys+1))*FontHeight) ,
									(Screen.width / 3) - InventoryBevel * 2,
									FontHeight
								),
								Count + " "  + item.ToString ()
							);
						}
					}
				//add one to the count so we know how much to displace the GUI.Label and know when to stop
				Count += 1;
				}

			}
#endregion
#region Crafting
			if (CraftTog){
				GUI.Box(
					new Rect(
						(Screen.width / 6) + InventoryBevel,
						(Screen.height / 6) + InventoryBevel, 
						(Screen.width / 1.5f) - InventoryBevel*2, 
						(Screen.height / 1.5f) - InventoryBevel*2
					),
					""
				);


				int Count = 0;
				foreach (CraftList recipe in CraftingList) {
					if (Count - ((1+MaxNumEntrys)*PageNum) <= MaxNumEntrys) {
						GUI.Label(
							new Rect(
								(Screen.width / 6) + InventoryBevel * 2,
								(Screen.height / 6) + InventoryBevel + (FontHeight * (Count)) ,
								(Screen.width / 3) - InventoryBevel * 2,
								FontHeight
							),
							recipe.Recipe.ResultingItem.Name
						);
						if(
							GUI.Button(
								new Rect(
									(Screen.width / 2),
									(Screen.height / 6) + InventoryBevel + (FontHeight * (Count)) ,
									(Screen.width / 3) - InventoryBevel * 2,
									FontHeight
								),
								"Craft" 
							)
						){
							gameObject.GetComponent<Crafting>().Craft(recipe.Recipe);
						}
					}
				Count += 1;
				}
			}
#endregion
		}
	}
}
