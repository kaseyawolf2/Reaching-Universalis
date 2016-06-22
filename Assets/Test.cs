using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour {

	void Start () {
		
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
