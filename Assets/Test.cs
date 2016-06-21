using UnityEngine;
using System;
using System.Collections.Generic;

public class Test : MonoBehaviour {

	void Awake(){
		//AddFirst ("Bob");
		//AddFirst ("Joe");


		//AddLast ("Henton");




	}

	void Main () {
		Statics.Items.Add (new ItemList { ItemID = Statics.Items.Count, Name = "Test", Volume = 2, Mass = 2 });

	}

	void AddFirst(string AddName){
		Statics.FirstNamesMale.Add (new NameList{ Name = AddName });
	}
	void AddLast(string AddName){
		Statics.LastNamesMale.Add (new NameList{ Name = AddName });
	}
}
