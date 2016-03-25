using UnityEngine;
using System.Collections;

public class ResourceNode : MonoBehaviour {
	public int ResourceAmt;
	public string ResourceType;
	public int ResourceVol;
	public int ResourceMas;

	void Start () {
		ItemsList.Items.Add (new Item { Name = ResourceType, Volume = ResourceVol, Mass = ResourceMas });
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	

}
