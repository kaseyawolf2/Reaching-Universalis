﻿using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
	
	//Initial Statements
	public float Volume;
	public float MaxVolume;
	public float Weight;
	public float MaxWeight;
	public bool CanHold;
	
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void CheckLift ()
	{
		if (MaxWeight < Weight) {
			CanHold = false;
		} else {
			CanHold = true;
		}
		if (MaxVolume < Volume) {
			CanHold = false;
		} else {
			CanHold = true;
		}
	}

	public class Items
	{
		public string Name { set; get; }

		public float Volume { set; get; }

		public float Mass { set; get; }
	}
	
	
	
	
	
	
	
	
	
	
	
}
