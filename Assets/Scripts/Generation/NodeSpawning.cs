using UnityEngine;
using System.Collections;

public class NodeSpawning : MonoBehaviour {
    public GameObject Node;
    public int Mapsize;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        while (Statics.Nodes < 5) {
            Instantiate (Node, new Vector3 (Random.Range (-Mapsize, Mapsize), 0.5f, Random.Range (-Mapsize, Mapsize)), Quaternion.identity);
            Statics.Nodes += 1;
        }
    }
}
