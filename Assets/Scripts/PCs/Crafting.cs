using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ItemSpace;

public class Crafting : MonoBehaviour {

	void Start (){
		Item Stone = Item.NewItem( 1, "Stone", 1, 1 );
		Item Wood = Item.NewItem( 0, "Wood", 1, 1 );
		List<ItemList> Craft = new List<ItemList>();
		Statics.Items.Add( new ItemList { Item = Wood } );
		Statics.Items.Add( new ItemList { Item = Stone } );

		Craft.Add( new ItemList { Item = Wood } );
		Craft.Add( new ItemList { Item = Stone } );

		Statics.Items.Add( new ItemList { Item = Item.NewItem( 2, "Sticks", 1, 1, Craft ) } );
	}

	bool CanCraft(Item item){
		var Inv = gameObject.GetComponent<Inventory> ();
		foreach(ItemList ReqItem in item.CraftingItems){
			if (!Inv.CheckforItem(ReqItem.Item)){
				return false;
			}
		}
		return true;
	}
	Item Craft(Item item) {
		return item;		
	}

}
