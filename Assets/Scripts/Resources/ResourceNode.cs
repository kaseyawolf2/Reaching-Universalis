using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceNode : MonoBehaviour
{
	public int ResourceAmt;
	public string ResourceType;

	// Use this for initialization
	void Start ()
	{
		List<Item> Items = new List<Item> ();
		Items.Add (new Item { Name = "Test", Volume = 2, Mass = 4 });
		Debug.Log (Items.Count);
		Debug.Log (Items);

	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	
	

}

public class Item
{
	public string Name { set; get; }

	public float Volume { set; get; }

	public float Mass { set; get; }
}
