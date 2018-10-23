using UnityEngine;
using System;
using System.Collections.Generic;

struct Item {
    int ID;
	string Name;
    int Mass;
    int Volume;
	ItemList CraftingItems;
}

public class ItemList : IEquatable<ItemList> {

	public Item Item;

    public override string ToString()
	{
		return "ID #: " + Item.ID + " Name: " + "'" + Item.Name + "'" + " Volume: " + Item.Volume + " Mass: " + Item.Mass;
	}
}