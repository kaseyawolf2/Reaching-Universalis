using UnityEngine;
using System.Collections;

public class Removestone : MonoBehaviour {
    GameObject Node;
    public int NumDel;

    // Use this for initialization
    void Start () {
        Node = this.gameObject;
    }

    

    // Update is called once per frame
    void Update () {
        if (Node.GetComponent<Inventory>().CheckforItem(2)) {
            NumDel += 1;
            Node.GetComponent<Inventory> ().RemoveItem (0, true);
            Node.GetComponent<Inventory> ().HoldInfo ();
        }
        

    }
}
