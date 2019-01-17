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
	bool InvTranTog = false;
	bool CraftTog = false;
	bool InteractTog = false;
	bool FullBackground = false;
	
	//Other
	string MenuString;

	//Inventory 
	List<ItemList> PlrItem;
	List<ItemList> NPOItem;
	public int MaxNumEntrys = 0;

	Vector2 PCScroll;
	Vector2 NPOScroll;
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
	}
	void HideOthers(){
		FullBackground = false;
		InvTog = false;
		InvTranTog = false;
		CraftTog = false;
		InteractTog = false;
	}

	public void ShowInv() {
		HideOthers();
		MenuTog = true;
		FullBackground = true;
		InvTog = true;
		MenuString = "Inventory";
	}
	
	public void ShowInvTran() {
		HideOthers();
		MenuTog = true;
		FullBackground = true;
		InvTranTog = true;
		MenuString = "Transfer";
	}
	
	public void ShowCraft() {
		HideOthers();
		MenuTog = true;
		FullBackground = true;
		CraftTog = true;
		MenuString = "Crafting";
	}

	public void ShowInteract(GameObject Obj) {
		HideOthers();
		MenuTog = true;
		InteractTog = true;
		MenuString = Obj.name;
		NPOItem = Obj.GetComponent<Inventory>().HeldItems;
	}

	void OnGUI(){
		if(MenuTog) {
			Statics.ShowMouse = true;
			if(FullBackground) {
				GUI.Box (
					new Rect (
						Screen.width/6,
						(Screen.height/6)-FontHeight,
						Screen.width/1.5f,
						(Screen.height/1.5f)+FontHeight
					),MenuString
				);
			}
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
				int Count = 0;

				PCScroll = GUI.BeginScrollView(
					new Rect(
						(Screen.width / 6) + InventoryBevel,
						(Screen.height / 6) + InventoryBevel, 
						(Screen.width / 1.5f) - InventoryBevel*2, 
						(Screen.height / 1.5f) - InventoryBevel*2
					), PCScroll,
					new Rect(
						0,
						0,
						500,
						PlrItem.Count*FontHeight
					)
					);
					//For each item display a line
					foreach (ItemList item in PlrItem) {
						GUI.Label(
							new Rect(
								InventoryBevel,
								(FontHeight * (Count)),
								(Screen.width / 3) - InventoryBevel * 2,
								FontHeight
							)
							,
							Count + " "  + item.ToString ()
						);
					//add one to the count so we know how much to displace the GUI.Label and know when to stop
					Count += 1;
					}	
				GUI.EndScrollView();

			}
#endregion
#region Transfer Inventory
			if (InvTranTog)
			{
				#region PC Inv
				GUI.Box(
					new Rect(
						(Screen.width / 6) + InventoryBevel + (Screen.width / 3),
						(Screen.height / 6) + InventoryBevel, 
						(Screen.width / 1.5f) - InventoryBevel*2 - (Screen.width / 3), 
						(Screen.height / 1.5f) - InventoryBevel*2
					),
					""
				);

				int PcCount = 0;
				PCScroll = GUI.BeginScrollView(
					new Rect(
						(Screen.width / 6) + InventoryBevel + (Screen.width / 3),
						(Screen.height / 6) + InventoryBevel, 
						(Screen.width / 1.5f) - InventoryBevel*2 - (Screen.width / 3), 
						(Screen.height / 1.5f) - InventoryBevel*2
					),
					PCScroll,
					new Rect(
						0,
						0,
						500,
						PlrItem.Count*FontHeight
					)
				);
				//For each item display a line
				foreach (ItemList item in PlrItem) {
					GUI.Label(
						new Rect(
							25,
							(FontHeight * (PcCount)),
							(Screen.width / 3) - InventoryBevel * 2,
							FontHeight
						),
						PcCount + " "  + item.ToString ()
					);
					if(
						GUI.Button(
							new Rect(
								0,
								(FontHeight * (PcCount)),
								20, 20
							),
						"<")
					){
						PlrItem.Remove(item);
						NPOItem.Add(item);
					}
				//add one to the count so we know how much to displace the GUI.Label and know when to stop
				PcCount += 1;
				}
				GUI.EndScrollView();
				#endregion
				#region Npo Inv
				
				GUI.Box(
					new Rect(
						(Screen.width / 6) + InventoryBevel,
						(Screen.height / 6) + InventoryBevel, 
						(Screen.width / 1.5f) - InventoryBevel*2 - (Screen.width / 3), 
						(Screen.height / 1.5f) - InventoryBevel*2
					),
					""
				);
				int NPOCount = 0;

				NPOScroll = GUI.BeginScrollView(
					new Rect(
						(Screen.width / 6) + InventoryBevel,
						(Screen.height / 6) + InventoryBevel, 
						(Screen.width / 1.5f) - InventoryBevel*2 - (Screen.width / 3), 
						(Screen.height / 1.5f) - InventoryBevel*2
					),
					NPOScroll,
					new Rect(
						0,
						0,
						500,
						NPOItem.Count*FontHeight
					)
				);
				//For each item display a line
				foreach (ItemList item in NPOItem) {
					GUI.Label(
						new Rect(
							0,
							(FontHeight * (NPOCount)),
							(Screen.width / 3) - InventoryBevel * 2,
							FontHeight
						),
						NPOCount + " "  + item.ToString ()
					);
					if(
						GUI.Button(
							new Rect(
								(Screen.width / 1.5f) - InventoryBevel*2 - (Screen.width / 3) - 20,
								(FontHeight * (NPOCount)),
								20, 20
							),
						">")
					){
						PlrItem.Add(item);
						NPOItem.Remove(item);
					}
				//add one to the count so we know how much to displace the GUI.Label and know when to stop
				NPOCount += 1;
				}
				GUI.EndScrollView();
				#endregion

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
				Count += 1;
				}
			}
#endregion
#region Interaction Menu
			if(InteractTog) {
				GUI.Box (
					new Rect (
						Screen.width/2.5f,
						(Screen.height/3)-FontHeight,
						Screen.width/6,
						(Screen.height/2.5f)+FontHeight
					),MenuString
				);
				GUI.Box (
					new Rect (
						Screen.width/2.5f + InventoryBevel,
						(Screen.height/3) + InventoryBevel,
						Screen.width/6 - InventoryBevel*2,
						(Screen.height/2.5f) - InventoryBevel*2
					),""
				);
				if(
					GUI.Button(
						new Rect(
							(Screen.width / 2.5f) + InventoryBevel*2,
							(Screen.height / 3) + InventoryBevel*2,
							(Screen.width / 6) - InventoryBevel*4,
							FontHeight
						),
						"Inventory" 
					)
				){
					ShowInvTran();
				}
			}
#endregion

		}else{
			Statics.ShowMouse = false;
		}
	}
}
