using UnityEngine;
using System.Collections;

public class ResourceNode : MonoBehaviour
{
	public int ResourceAmt;
	public string ResourceType;

	void Start ()
	{
		ItemsList.Items.Add (new Item { Name = ResourceType, Volume = 2, Mass = 4 });



		Debug.Log (ItemsList.Items.Count);
		foreach (Item c in ItemsList.Items)
			Debug.Log ("Name: " + "'" + c.Name + "'" + " Volume: " + c.Volume + " Mass: " + c.Mass);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	
	

}
