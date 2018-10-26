using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ItemSpace;

public class Crafting : MonoBehaviour {




	void Start (){
		Item Stone = Item.NewItem( 1, "Stone", 1, 1 );
		Item Wood = Item.NewItem( 0, "Wood", 1, 1 );
		
		
		List<ItemList> CraftList = new List<ItemList>();
		Statics.Items.Add( new ItemList { Item = Wood } );
		Statics.Items.Add( new ItemList { Item = Stone } );

		CraftList.Add( new ItemList { Item = Wood, Amount = 1 } );
		CraftList.Add( new ItemList { Item = Stone, Amount = 1 } );
		
		Item Sticks = Item.NewItem( 2, "Sticks", 1, 1, CraftList );

		gameObject.GetComponent<Inventory>().HeldItems.Add( new ItemList { Item = Wood } );
		gameObject.GetComponent<Inventory>().HeldItems.Add( new ItemList { Item = Stone } );

		Statics.Items.Add( new ItemList { Item = Sticks } );

		Craft(Sticks);


	}

	bool CanCraft(Item item) {
		var Inv = gameObject.GetComponent<Inventory> ();
		foreach(ItemList ReqItem in item.CraftingItems){
			for (int i = 0; i < ReqItem.Amount; i++) {	
				if (!Inv.CheckforItem(ReqItem.Item)){
					return false;
				}
			}
		}
		return true;
	}
	void Craft(Item item) {
		if(!CanCraft(item)){ Debug.Log("Can't Craft " + item.Name); return;}
		foreach(ItemList Comp in item.CraftingItems){
			for (int i = 0; i < Comp.Amount; i++)
			{	
				gameObject.GetComponent<Inventory>().RemoveItem(Comp.Item);
			}
		}
		gameObject.GetComponent<Inventory>().AddItem(item);
	}

}
