﻿// using UnityEngine;
// using System.Collections;

// public class oldAi : MonoBehaviour {

//     public int NumIteminInv;

//     #region Intial Declerations
//     UnityEngine.AI.NavMeshAgent Agent;

   
   

//     //Personality
//     public string CharName;


//     //Attributes
//     int Range = 3;

//     //Survival
//     public float Hunger;
//     public float Thirst;


//     #endregion

//     #region Name Randomization
//     // just so the Ai has a name, not going to stay (atleast not in current form)
//     void RandomizeName () {
//         string FirstStr;
//         string LastStr;
//         int FirstNum;
//         int LastNum;
//         FirstNum = Random.Range (0, Statics.FirstNamesMale.Count - 1);
//         if (Statics.Debug) { Debug.Log ("# Of First Names: " + Statics.FirstNamesMale.Count); }
//         LastNum = Random.Range (0, Statics.LastNames.Count - 1);
//         if (Statics.Debug) { Debug.Log ("# Of Last Names: " + Statics.LastNames.Count); }
//         FirstStr = Statics.FirstNamesMale[FirstNum].Name;
//         LastStr = Statics.LastNames[LastNum].Name;
//         CharName = FirstStr + " " + LastStr;
//     }
//     #endregion



//     void GrabResources (GameObject TargetNode) {

//     }



//     void Start () {


//         return;
//         //old start
//         SetAttributes ();

//         Agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
//         Agent.stoppingDistance = Range - 1;
        


//         RandomizeName ();
//         name = CharName;
//         //Player = GameObject.FindGameObjectWithTag ("Player").transform;




//     }

//     void SetAttributes () {
//         gameObject.GetComponent<Attributes> ().Agility = Random.Range (1, 10);
//         gameObject.GetComponent<Attributes> ().Strength = Random.Range (1, 10);
//         gameObject.GetComponent<Attributes> ().Charisma = Random.Range (1, 10);
//         gameObject.GetComponent<Attributes> ().Intelligence = Random.Range (1, 10);
//         gameObject.GetComponent<Attributes> ().Luck = Random.Range (1, 10);
//         gameObject.GetComponent<Attributes> ().Constitution = Random.Range (1, 10);







//         gameObject.GetComponent<Attributes> ().AgilityUpdate ();
//         gameObject.GetComponent<Attributes> ().StrengthUpdate ();
//         gameObject.GetComponent<Attributes> ().CharismaUpdate ();
//         gameObject.GetComponent<Attributes> ().IntelligenceUpdate ();
//         gameObject.GetComponent<Attributes> ().LuckUpdate ();
//         gameObject.GetComponent<Attributes> ().ConstitutionUpdate ();
//     }

//     // void Update () {
//     //     Hunger -= 0.0005f;
//     //     Thirst -= 0.0005f;
//     //     Survive ();
//     // }

//     // #region Ai
//     // void DecisionAI () {
//     // }

//     // #region Basic Fuctions
//     // GameObject Find (string TagtoFind, string ItemNameToFind, int SearchStyle = 1) {
//     //     //Search Styles #defaults to 1
//     //     // 0 - No Item
//     //     // 1 - Closest
//     //     // 2 - Far
//     //     // 3 - Smallest
//     //     // 4 - Largest

//     //     GameObject CurrentItem = null;
//     //     float Store = 0;
//     //     if (SearchStyle == 1 || SearchStyle == 3) {
//     //         Store = Mathf.Infinity;
//     //     }
//     //     if (SearchStyle == 2 || SearchStyle == 4) {
//     //         Store = -1;
//     //     }
//     //     GameObject[] List = GameObject.FindGameObjectsWithTag (TagtoFind);
//     //     if (List != null) {
//     //         foreach (var Item in List) {
//     //             if (Item.name == ItemNameToFind) {
//     //                 float Distance = Vector3.Distance (Item.transform.position, gameObject.transform.position);
//     //                 if (SearchStyle == 1) {
//     //                     if (Distance < Store) {
//     //                         CurrentItem = Item.gameObject;
//     //                         Store = Distance;
//     //                     }
//     //                 }
//     //                 if (SearchStyle == 2) {
//     //                     if (Distance > Store) {
//     //                         CurrentItem = Item.gameObject;
//     //                         Store = Distance;
//     //                     }
//     //                 }
//     //                 if (SearchStyle == 3) {
//     //                     if (Item.GetComponent<ResourceNode> ().ResourceAmt < Store) {
//     //                         CurrentItem = Item.gameObject;
//     //                         Store = Item.GetComponent<ResourceNode> ().ResourceAmt;
//     //                     }
//     //                 }
//     //                 if (SearchStyle == 4) {
//     //                     if (Item.GetComponent<ResourceNode> ().ResourceAmt > Store) {
//     //                         CurrentItem = Item.gameObject;
//     //                         Store = Item.GetComponent<ResourceNode> ().ResourceAmt;
//     //                     }
//     //                 }
//     //             }
//     //         }
//     //     }
//     //     return CurrentItem;
//     // }

//     // void Get (GameObject Item) {
//     //     if (Vector3.Distance (Item.transform.position, gameObject.transform.position) <= Range) {
//     //         if (gameObject.GetComponent<Inventory> ().Check (Item.GetComponent<ResourceNode> ().ItemID)) {
//     //             print ("Can pick up");
//     //             if (Item.GetComponent<ResourceNode> ().ResourceAmt > 0) {
//     //                 Debug.Log ("It has Resources");
//     //                 if (gameObject.GetComponent<Inventory> ().Check (Item.GetComponent<ResourceNode> ().ItemID) == true) {
//     //                     Debug.Log ("Can Hold the " + Statics.Items[Item.GetComponent<ResourceNode> ().ItemID].Name);
//     //                     Item.GetComponent<ResourceNode> ().ResourceAmt = (Item.GetComponent<ResourceNode> ().ResourceAmt - 1);
//     //                     gameObject.GetComponent<Inventory> ().AddItem (Item.GetComponent<ResourceNode> ().ItemID);
//     //                     Item.GetComponent<ResourceNode> ().EmptyCheck ();
//     //                     Agent.ResetPath ();
//     //                 }
//     //                 else {
//     //                     Debug.Log ("Cant Hold The " + Statics.Items[Item.GetComponent<ResourceNode> ().ItemID].Name);
//     //                 }
//     //             }

//     //         }
//     //         else {
//     //             gameObject.GetComponent<Inventory> ().HoldInfo ();
//     //             float Mass = Item.GetComponent<ResourceNode> ().ResourceMas - gameObject.GetComponent<Inventory> ().AvlMass;
//     //             float Volume = Item.GetComponent<ResourceNode> ().ResourceVol - gameObject.GetComponent<Inventory> ().AvlVolume;
//     //             Item.GetComponent<ResourceNode> ().EmptyCheck ();
//     //             print ("Cant Hold Need " + Volume + " More Volume and " + Mass + " More Mass");
//     //         }
//     //     }
//     //     else {
//     //         MoveTo (Item);
//     //     }
//     //     return;


//     //     //if in range - Done
//     //     //  if have room - Done
//     //     //      pick up 
//     //     //  else tell player cant pick up - 
//     //     //else invoke moveto - Done
//     //     //
//     // }

//     // void MoveTo (GameObject Goal) {        
        
//     //     Agent.destination = Goal.transform.position;
//     //     //find path to target - Done
//     //     //follow path - Done
//     // }

//     // void Use (int ItemID) {
//     //     if (gameObject.GetComponent<Inventory> ().CheckforItem (ItemID)) {
//     //         Hunger += Statics.Items[ItemID].HungerChange;
//     //         Thirst += Statics.Items[ItemID].ThirstChange;
//     //         gameObject.GetComponent<Inventory> ().RemoveItem (gameObject.GetComponent<Inventory> ().GetItemPos (ItemID));
//     //     }
//     //     else {
//     //         print ("Can't use Item");
//     //     }


//     //     return;
//     //     //is object useable
//     //     //  is the objest useable this selceted item
//     //     //  else alert player
//     //     //else alert player
//     // }

//     // void Equip (int ItemID, int SlotID) {
//     //     //pull requirements from item

//     //     //if meet requrements
//     //     // check if it has a slot to go in to
//     //     //equip
//     // }

//     // void Unequip (int SlotID) {
//     //     //see if item is in slot
//     //     //if there is move to inventory if theres room
//     // }

//     // void Drop () {
//     //     //

//     // }

//     // void Transfer (GameObject Goal, int ItemID) {
//     //     if (Goal == null) {
//     //         print ("No Goal");
//     //         return;
//     //     }
//     //     if (Vector3.Distance (Goal.transform.position, gameObject.transform.position) <= Range) {
//     //         if (Goal.GetComponent<Inventory> ().Check (ItemID)) {
//     //             Agent.ResetPath();
//     //             Goal.GetComponent<Inventory> ().AddItem (ItemID);
//     //             gameObject.GetComponent<Inventory> ().RemoveItem (ItemID);
//     //         }
//     //         else {
//     //             print ("Goal cant hold item");
//     //         }            
//     //     }
//     //     else {
//     //         MoveTo (Goal);
//     //     }
//     // }
//     // #endregion

//     // #region Mid Fuctions

//     // void GetFood (int Type) {
//     //     // 0 - Food
//     //     // 1 - Drink
//     //     if (Type == 0) {
//     //         GameObject Node = Find ("Resource Node", "MRE", 1);
//     //         int ItemID = Node.GetComponent<ResourceNode> ().ItemID;
//     //         if (gameObject.GetComponent<Inventory> ().Check(ItemID)) {
//     //             Get (Node);
//     //         }
//     //         else {
                
//     //         }
//     //         if (gameObject.GetComponent<Inventory> ().CheckforItem(ItemID)) {
//     //             Use (ItemID);
//     //         }
//     //     }
//     //     if (Type == 1) {
//     //         GameObject Node = Find ("Resource Node", "Water", 1);
//     //         int ItemID = Node.GetComponent<ResourceNode> ().ItemID;
//     //         if (gameObject.GetComponent<Inventory> ().Check (ItemID)) {
//     //             Get (Node);
//     //         }
//     //         else {
                
//     //         }
//     //         if (gameObject.GetComponent<Inventory> ().CheckforItem (ItemID)) {
//     //             Use (ItemID);
//     //         }
//     //     }
//     // }

//     // void MakeMoney () {
//     //     GameObject Node = Find ("Resource Node", "Stone", 1);
//     //     int ID = Node.GetComponent<ResourceNode> ().ItemID;
//     //     if (gameObject.GetComponent<Inventory> ().Check (ID)) {
//     //         Get (Node);
//     //     }
//     //     foreach (ItemList Item in gameObject.GetComponent<Inventory> ().HeldItems) {
//     //         if (Item.ItemID == ID) {
//     //             Transfer (Find ("Storage", "Ai Storage"), ID);
//     //         }
//     //     }
//     // }



//     // #endregion

//     // #region End Fuctions




//     // void Survive () {
//     //     NumIteminInv = gameObject.GetComponent<Inventory> ().HeldItems.Count;
//     //     if (Thirst < 15) {
//     //         GetFood (1);

//     //     }
//     //     else if (Hunger < 15) {
//     //         GetFood (0);
//     //     }
//     //     else {
//     //         MakeMoney ();
//     //     }

//     // }

//     // #endregion

//     // #endregion
// }