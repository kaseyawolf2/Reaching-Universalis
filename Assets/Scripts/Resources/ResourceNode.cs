// using UnityEngine;
// using System.Collections;

// public class ResourceNode : MonoBehaviour {
//     public int ResourceAmt;
//     public string ResourceType;
//     public float ResourceVol;
//     public float ResourceMas;

//     public float HungerAdd;
//     public float ThirstAdd;




//     public int ItemID;

//     void Start () {
//         if (Statics.Items.Contains (new ItemList { Name = ResourceType })) {
//             Debug.Log ("There is already an item that has this name, cant add: '" + ResourceType + "' To Itemlist");
//         }
//         else {
//             Debug.Log ("Added Item to List: " + ResourceType);
//             Statics.Items.Add (new ItemList { ItemID = Statics.Items.Count, Name = ResourceType, Volume = ResourceVol, Mass = ResourceMas, HungerChange = HungerAdd, ThirstChange = ThirstAdd });
//         }
//         ItemID = Statics.Items.Find (x => x.Name.Equals (ResourceType)).ItemID;
//         gameObject.name = ResourceType;

//     }

//     public void EmptyCheck () {
//         if (ResourceAmt <= 0) {
//             Statics.Nodes -= 1;
//             Destroy (this.gameObject);
//         }
//     }
//     // Update is called once per frame
//     void Update () {

//     }




// }