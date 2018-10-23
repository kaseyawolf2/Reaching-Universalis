using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemSpace;

public class Crafting : MonoBehaviour {

	Item Craft(Item item) {
		foreach(ItemList req in item.CraftingItems){
			if (!Inventory.CheckForItem(req)){
				return null;
			}
		}
	}

}
