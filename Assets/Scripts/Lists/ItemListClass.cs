using UnityEngine;
using System;
using System.Collections.Generic;

namespace ItemSpace {
	public struct Item {
		public int ID;
		public string Name;
		public int Mass;
		public int Volume;
		public List<ItemList> CraftingItems;

		public static void NewItem(int nID, string nName, int nMass, int nVolume, List<ItemList> nCraftingItems){
			return new Item { 
				ID = nID,
				Name = nName,
				Mass = nMass,
				Volume = nVolume,
				CraftingItems = nCraftingItems
			};
		}	
		public static Item NewItem(int nID, string nName, int nMass, int nVolume){
			return new Item { 
				ID = nID,
				Name = nName,
				Mass = nMass,
				Volume = nVolume,
				CraftingItems = new List<ItemList> ()
			};
		}		

		public bool Equals(Item other)	
		{	
			if(this.ID == other.ID){return true;}
			else{return false;}

		}
		public static bool operator ==(Item i1,Item i2){
			return i1.Equals(i2);
		}
		public static bool operator !=(Item i1,Item i2){
			return !i1.Equals(i2);
		}
	}

	public class ItemList : IEquatable<ItemList> {

		public Item Item;
		public int Amount;

		public override string ToString()
		{
			return "ID #: " + Item.ID + " Name: " + "'" + Item.Name + "'" + " Volume: " + Item.Volume + " Mass: " + Item.Mass;
		}

		public override int GetHashCode()
		{	
			return Item.ID;	
		}	
		public override bool Equals(object obj)	
		{	
			if (obj == null) return false;	
			ItemList objAsPart = obj as ItemList;	
			if (objAsPart == null) return false;	
			else return Equals(objAsPart);	
		}	
		public bool Equals(ItemList other)	
		{	
			if (other == null) return false;	
			return (this.Item.Equals(other.Item));	
		}
}
}