using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemsList : MonoBehaviour {
	static public List<Item> Items = new List<Item> ();

	void Main () {
		ItemsList.Items.Add (new Item { IDNum = 0 + ItemsList.Count, Name = Test, Volume = 2, Mass = 2 });
	}

}
