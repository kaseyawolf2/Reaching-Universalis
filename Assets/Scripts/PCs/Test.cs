using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
bool temp = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(temp){
			gameObject.GetComponent<Inventory>().AddItem(Statics.Items[2].Item);
			gameObject.GetComponent<Inventory>().AddItem(Statics.Items[2].Item);
			gameObject.GetComponent<Inventory>().AddItem(Statics.Items[2].Item);
			gameObject.GetComponent<Inventory>().AddItem(Statics.Items[2].Item);
			gameObject.GetComponent<Inventory>().AddItem(Statics.Items[2].Item);


			temp = false;
		}
	}
}
