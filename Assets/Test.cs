using UnityEngine;
using System;
using System.Collections.Generic;

public class Test : MonoBehaviour {
	void Awake(){

	}

	void Main () {
		//Statics.Items.Add (new ItemList { ItemID = Statics.Items.Count, Name = "Test", Volume = 2, Mass = 2 });

	}

	void Update() {
		
	}


	void AddFirst(string AddName){
		Statics.FirstNamesMale.Add (new NameList{ Name = AddName });
	}
	void AddLast(string AddName){
		Statics.LastNames.Add (new NameList{ Name = AddName });
	}
}
