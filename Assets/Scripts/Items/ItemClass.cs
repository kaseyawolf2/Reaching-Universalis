using UnityEngine;
using System;
using System.Collections.Generic;

public class Item : IEquatable<Item> {
	public int ItemID { get; set; }
	
	public string Name { get; set; }

	public float Volume { get; set; }

	public float Mass { get; set; }

	public override string ToString()
	{
		return "ID #: " + ItemID + " Name: " + "'" + Name + "'" + " Volume: " + Volume + " Mass: " + Mass;
	}

	public override int GetHashCode()
	{
		return ItemID;
	}

	public override bool Equals(object obj)
	{
		if (obj == null) return false;
		Item objAsPart = obj as Item;
		if (objAsPart == null) return false;
		else return Equals(objAsPart);
	}

	public bool Equals(Item other)
	{
		if (other == null) return false;
		return (this.Name.Equals(other.Name));
	}
}

