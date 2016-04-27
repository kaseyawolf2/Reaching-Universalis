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

	}
}
