using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ItemSpace;

public class Crafting : MonoBehaviour {

	void Start (){

	}

	bool CanCraft(Item item) {
		var Inv = gameObject.GetComponent<Inventory> ();
		foreach(ItemList ReqItem in item.CraftingItems){
			if ( ReqItem.Amount > Inv.CheckItemCount(ReqItem.Item)){
				Debug.Log("Not Enough : " + ReqItem.Item.Name + " | Need : " + ReqItem.Amount + " | Have : " + Inv.CheckItemCount(ReqItem.Item));
				return false;
			}
		}
		return true;
	}
	public void Craft(Item item) {
		if(!CanCraft(item)){ Debug.Log("Can't Craft " + item.Name); return;}
		foreach(ItemList Comp in item.CraftingItems){
			for (int i = 0; i < Comp.Amount; i++)
			{	
				gameObject.GetComponent<Inventory>().RemoveItem(Comp.Item);
			}
		}
		for (int i = 0; i < item.CraftingAmount; i++)
		{	
			gameObject.GetComponent<Inventory>().AddItem(item);
		}
	}

}
