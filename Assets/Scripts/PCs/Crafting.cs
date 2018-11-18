using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ListSpace;

public class Crafting : MonoBehaviour {

	void Start (){

	}

	bool CanCraft(Recipe recipe) {
		Inventory Inv = gameObject.GetComponent<Inventory>();
		foreach(ItemList Req in recipe.CraftingItems){
			if(Inv.CheckforItem(Req.Item)){
				if(Req.Amount <= Inv.CheckItemCount(Req.Item)) {
					continue;
				} else {
					Debug.Log("Not Enough : " + Req.Item.Name + " | Need : " + Req.Amount + " | Have : " + Inv.CheckItemCount(Req.Item));
					return false;
				}
			} else {
				Debug.Log("Inventory Does Not Contain : " + Req.Item.Name);
				return false;
			}
		}
		return true;
	}
	public void Craft(Recipe recipe) {
		if(!CanCraft(recipe)){ Debug.Log("Can't Craft " + recipe.ResultingItem.Name); return;}
		
		foreach(ItemList Comp in recipe.CraftingItems){
			for (int i = 0; i < Comp.Amount; i++)
			{	
				gameObject.GetComponent<Inventory>().RemoveItem(Comp.Item);
			}
		}
		for (int i = 0; i < recipe.ResultingAmount; i++)
		{	
			gameObject.GetComponent<Inventory>().AddItem(recipe.ResultingItem);
		}		
	}
}
