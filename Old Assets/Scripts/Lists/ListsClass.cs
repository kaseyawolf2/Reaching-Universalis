using UnityEngine;
using System;
using System.Collections.Generic;

namespace ListSpace {
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
	public struct Item {
		public int ID;
		public string Name;
		public int Mass;
		public int Volume;
		public static Item NewItem(int nID, string nName, int nMass, int nVolume){
			return new Item { 
				ID = nID,
				Name = nName,
				Mass = nMass,
				Volume = nVolume,
			};
		}		

		public bool Equals(Item other)	
		{	
			if(this.Name == other.Name){return true;}
			else{return false;}

		}
		public static bool operator ==(Item i1,Item i2){
			return i1.Equals(i2);
		}
		public static bool operator !=(Item i1,Item i2){
			return !i1.Equals(i2);
		}
	}

	public class CraftList : IEquatable<CraftList> {

		public Recipe Recipe;



		public override int GetHashCode()
		{	
			return 0;	
		}	
		public override bool Equals(object obj)	
		{	
			if (obj == null) return false;	
			CraftList objAsPart = obj as CraftList;	
			if (objAsPart == null) return false;	
			else return Equals(objAsPart);	
		}	
		public bool Equals(CraftList other)	
		{	
			return false;
		}
	}
	public struct Recipe {
		public List<ItemList> CraftingItems;
		public Item ResultingItem;
		public int ResultingAmount;
		public int CraftingTime; 
	}

	public struct Stats {
		public float Strength;
		public float Intelligence;
		public float Agility;
		public float Charisma;
		public float Constitution;

	}
}