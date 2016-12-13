using UnityEngine;
using System.Collections;

public class Removestone : MonoBehaviour {
    GameObject Node;


    // Use this for initialization
    void Start () {
        Node = this.gameObject;
    }

    

    // Update is called once per frame
    void Update () {
        Node.GetComponent<Inventory> ().RemoveItem (0,true);
        Node.GetComponent<Inventory> ().HoldInfo ();

    }
}
