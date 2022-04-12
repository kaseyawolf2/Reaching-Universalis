using UnityEngine;
using System.Collections;

public class Ai : MonoBehaviour {
    
#region Intial Declerations
    UnityEngine.AI.NavMeshAgent AiAgent;


#endregion
    void Start() {
        AiAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
    }

    void Update() {
        
    }


#region Basic Functions
    GameObject Find (string TagtoFind, string ItemNameToFind, int SearchStyle = 1) {
        //Search Styles #defaults to 1
        // 0 - No Item
        // 1 - Closest
        // 2 - Far
        // 3 - Smallest
        // 4 - Largest

        GameObject CurrentItem = null;
        float Store = 0;
        if (SearchStyle == 1 || SearchStyle == 3) {
            Store = Mathf.Infinity;
        }
        if (SearchStyle == 2 || SearchStyle == 4) {
            Store = -1;
        }
        GameObject[] List = GameObject.FindGameObjectsWithTag (TagtoFind);
        if (List != null) {
            foreach (var Item in List) {
                if (Item.name == ItemNameToFind) {
                    float Distance = Vector3.Distance (Item.transform.position, gameObject.transform.position);
                    if (SearchStyle == 1) {
                        if (Distance < Store) {
                            CurrentItem = Item.gameObject;
                            Store = Distance;
                        }
                    }
                    if (SearchStyle == 2) {
                        if (Distance > Store) {
                            CurrentItem = Item.gameObject;
                            Store = Distance;
                        }
                    }
                    if (SearchStyle == 3) {
                        // if (Item.GetComponent<ResourceNode> ().ResourceAmt < Store) {
                        //     CurrentItem = Item.gameObject;
                        //     Store = Item.GetComponent<ResourceNode> ().ResourceAmt;
                        // }
                    }
                    if (SearchStyle == 4) {
                        // if (Item.GetComponent<ResourceNode> ().ResourceAmt > Store) {
                        //     CurrentItem = Item.gameObject;
                        //     Store = Item.GetComponent<ResourceNode> ().ResourceAmt;
                        // }
                    }
                }
            }
        }
        return CurrentItem;
    }

    void MoveTo (GameObject Goal) {        
        AiAgent.destination = Goal.transform.position;
        //find path to target - Done
        //follow path - Done
    }
    
#endregion
#region Mid Level Functions






#endregion


}
