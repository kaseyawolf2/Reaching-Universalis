using UnityEngine;
using System.Collections;

public class Ai : MonoBehaviour {

    #region Intial Declerations
    public int AiLevel;

    //Personality
    public string CharName;

    public Transform Player;
    public float PlayerDistance;
    public Vector3 other;

    //Movement
    public Transform Goal;
    public float Distance;
    public float Speed = 1;

    //Attributes
    int Range = 3;

    //Teleportation
    float WaitTime;

    //Node Info
    public GameObject TargetNode;

    public float NodeDistance;


    #endregion

    #region Name Randomization
    // just so the Ai has a name, not going to stay (atleast not in current form)
    void RandomizeName () {
        string FirstStr;
        string LastStr;
        int FirstNum;
        int LastNum;
        FirstNum = Random.Range (0, Statics.FirstNamesMale.Count - 1);
        if (Statics.Debug) { Debug.Log ("# Of First Names: " + Statics.FirstNamesMale.Count); }
        LastNum = Random.Range (0, Statics.LastNames.Count - 1);
        if (Statics.Debug) { Debug.Log ("# Of Last Names: " + Statics.LastNames.Count); }
        FirstStr = Statics.FirstNamesMale[FirstNum].Name;
        LastStr = Statics.LastNames[LastNum].Name;
        CharName = FirstStr + " " + LastStr;
    }
    #endregion


    void Start () {
        AiLevel = 1;
        RandomizeName ();
        name = CharName;
        Player = GameObject.FindGameObjectWithTag ("Player").transform;

        
        Get (Find ("Resource Node", "Stone", 4));

    }

    void Update () {
    }
    #region Distance Check
    void DistCheck () {
        other = Player.position;
        PlayerDistance = Vector3.Distance (other, transform.position);
        Check ();
    }

    void Check () {
        if (PlayerDistance <= 10) {
            AiLevel = 1;
        }
        if (PlayerDistance > 10 && PlayerDistance < 15) {
            AiLevel = 2;
        }
        if (PlayerDistance >= 15) {
            AiLevel = 3;
        }
    }
    #endregion
    #region Ai
    void DecisionAI () {
    }

    #region Basic Fuctions
    GameObject Find (string TagtoFind, string ItemNameToFind, int SearchStyle = 1) {
        //Search Styles #defaults to 1
        // 0 - All == Cant do need new fuction
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
                        if (Item.GetComponent<ResourceNode> ().ResourceAmt < Store) {
                            CurrentItem = Item.gameObject;
                            Store = Item.GetComponent<ResourceNode> ().ResourceAmt;
                        }
                    }
                    if (SearchStyle == 4) {
                        if (Item.GetComponent<ResourceNode> ().ResourceAmt > Store) {
                            CurrentItem = Item.gameObject;
                            Store = Item.GetComponent<ResourceNode> ().ResourceAmt;
                        }
                    }
                }
            }
        }
        return CurrentItem;
    }

    void Get (GameObject Item) {
        if (Vector3.Distance (Item.transform.position, gameObject.transform.position) <= Range) {
            if (gameObject.GetComponent<Inventory> ().Check (Item.GetComponent<ResourceNode> ().ItemID)) {
                print ("Can pick up");
                // Code in picking up items

            }
            else {
                gameObject.GetComponent<Inventory> ().HoldInfo ();
                float Mass = Item.GetComponent<ResourceNode> ().ResourceMas - gameObject.GetComponent<Inventory> ().AvlMass;
                float Volume = Item.GetComponent<ResourceNode> ().ResourceVol - gameObject.GetComponent<Inventory> ().AvlVolume;

                print ("Cant Hold Need " + Volume + " More Volume and " + Mass + " More Mass");
            }
        }
        else {
            MoveTo (Item);
        }


        //if in range - Done
        //  if have room - Done
        //      pick up 
        //  else tell player cant pick up - 
        //else invoke moveto - Done
        //
    }
    void MoveTo (GameObject Goal) {
        NavMeshAgent Agent = GetComponent<NavMeshAgent> ();
        Agent.stoppingDistance = Range;
        Agent.destination = Goal.transform.position;        
            //find path to target - Done
            //follow path - Done
        }
    void Use () {
        //is object useable
        //  is the objest useable this selceted item
        //  else alert player
        //else alert player
    }
    void Equip (int ItemID, int SlotID) {
        //pull requirements from item

        //if meet requrements
        // check if it has a slot to go in to
        //equip
    }
    void UnEquip (int SlotID) {
        //see if item is in slot
           //if there is move to inventory if theres room
    }
    void Drop () {

    }
    void Transfer () {

    }
    #endregion


    void CollectCheck () {
        gameObject.GetComponent<Inventory> ();
        if (gameObject.GetComponent<Inventory> ().Check (TargetNode.GetComponent<ResourceNode> ().ItemID)) {
            Collect ();
        }
    }
    void Collect () {
        Goal = TargetNode.transform;
        UpdateNodeDis ();
        if (NodeDistance > Range) {
            TeleportStart ();
        }
    }

    void UpdateNodeDis () {
        NodeDistance = Vector3.Distance (TargetNode.transform.position, transform.position);
    }


    #endregion



    #region Movement
    void Movement () {
        if (Goal != null) {
            TeleportStart ();
        }
    }

    void TeleportStart () {
        Debug.Log ("Started Teleport");
        Distance = Vector3.Distance (Goal.position, gameObject.transform.position);
        WaitTime = Distance / Speed;
        Debug.Log ("Wait Time = " + WaitTime);
        StartCoroutine (TeleportWait ());

    }
    IEnumerator TeleportWait () {
        Debug.Log ("Started Teleport Wait");
        yield return new WaitForSeconds (WaitTime);
        Teleport ();
    }
    void Teleport () {
        Debug.Log ("Teleported");
        gameObject.transform.position = new Vector3 (Goal.position.x + 2, Goal.position.y + 2, Goal.position.z + 2);
    }
    #endregion




}
