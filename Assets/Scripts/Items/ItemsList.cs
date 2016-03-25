using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemsList : MonoBehaviour
{
	public List<ItemClass> Items = new List<ItemClass> ();




	// Use this for initialization
	void Start ()
	{
		Items.Add (new ItemClass { Name = "Test", Volume = 2, Mass = 4 });
	
	
	
	
	
	
	}
}
