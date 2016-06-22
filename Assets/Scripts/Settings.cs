using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Random.seed = Statics.Seed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
