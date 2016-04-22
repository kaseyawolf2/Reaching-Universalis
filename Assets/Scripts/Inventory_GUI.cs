using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Inventory_GUI : MonoBehaviour {
	//Background Formanting
	float InventoryBevel = 5;
	float FontHeight = 20;

	//List Formating
	float ListOffset;


	//List Declaerations
	List<Item> HeldItem;



	void Start(){
		GetLists ();
	}


	void GetLists(){
		HeldItem = gameObject.GetComponent<Inventory>().HeldItems;
		int NumbofITems = HeldItem.Count;
	}

	void OnGUI(){
	//Background for inventory
		//Center Background Block
		GUI.Box(new Rect(Screen.width/6,(Screen.height/6)-FontHeight,Screen.width/1.5f,(Screen.height/1.5f)+FontHeight),"Center");
		//Left Background Box aka Player Items
		GUI.Box (new Rect ((Screen.width / 6) + InventoryBevel, (Screen.height / 6) + InventoryBevel, (Screen.width / 3) - InventoryBevel*2, (Screen.height / 1.5f) - InventoryBevel*2), "Left");
		//Right Background Box Aka Target's Items
		GUI.Box (new Rect ((Screen.width / 2) + InventoryBevel, (Screen.height / 6) + InventoryBevel, (Screen.width / 3) - InventoryBevel*2, (Screen.height / 1.5f) - InventoryBevel*2), "Right");
	//Display Items
		//PLayer Items
		int Count = 0;
		foreach(Item C in HeldItem){
			Count += 1;
			GUI.Label (new Rect ((Screen.width / 6) + InventoryBevel*2, (Screen.height / 6)+(FontHeight*(Count)) + InventoryBevel*2 + FontHeight, (Screen.width / 3) - InventoryBevel * 2, FontHeight), C.ToString());
		}


	}








}
