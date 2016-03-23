using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	
	//Initial Statements
	public float Volume;
	public float MaxVolume;
	public float Weight;
	public float MaxWeight;
	public bool CanGrab;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (MaxWeight < Weight) {
			CanGrab = false;
		} else {
			CanGrab = true;
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
