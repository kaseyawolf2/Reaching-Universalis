using UnityEngine;
using System;
using System.Collections.Generic;

public class Test : MonoBehaviour {



	void Main () {
		ItemsList.Items.Add (new Item { ItemID = ItemsList.Items.Count, Name = "Test", Volume = 2, Mass = 2 });
	}


	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		if(Input.GetKeyDown("r")){
			foreach (Item c in ItemsList.Items)
				Debug.Log ("Master " + c);
		}
		if(Input.GetKeyDown("e")){
			Debug.Log ("Contains(\"Name = Stone\"): " + ItemsList.Items.Contains(new Item {Name = "Stone"}));
			Debug.Log (" " + ItemsList.Items.Find(x => x.Name.Contains("Stone")));


		}

	}
}
