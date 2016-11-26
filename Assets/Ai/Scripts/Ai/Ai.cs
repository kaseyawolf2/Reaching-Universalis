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

	//movement
	public Transform Goal;
	public float Distance;
	public float Speed = 1;

	//Teleportation
	float WaitTime;

	//Node Info
	GameObject[] NodeList;
	public GameObject TargetNode;
	GameObject TargetStorage;

	public float NodeDistance;
	GameObject PosNode;

	//Target
	public string TargetResource = "Stone";

	public int A;

	#endregion

	#region Name Randomization
	// just so the Ai has a name, not going to stay (atleast not in current form)
	void RandomizeName(){
		string FirstStr;
		string LastStr;
		int FirstNum;
		int LastNum;
		FirstNum = Random.Range (0, Statics.FirstNamesMale.Count - 1);
		Debug.Log ("# Of First Names: " + Statics.FirstNamesMale.Count);
		LastNum = Random.Range (0, Statics.LastNames.Count - 1);
		Debug.Log ("# Of Last Names: " + Statics.LastNames.Count);
		FirstStr = Statics.FirstNamesMale[FirstNum].Name;
		LastStr = Statics.LastNames[LastNum].Name;
		CharName = FirstStr + " " + LastStr;
	}
	#endregion


	void Start(){
		AiLevel = 1;
		RandomizeName();
		name = CharName;
		Player = GameObject.FindGameObjectWithTag("Player").transform;
        
	}
    int x = 0;
	void Update() {
        if (x == 0)
        {
            x = 1;
            print(Find("Resource Node", "Stone").name);
        }
	}
	#region Distance Check
	void DistCheck(){ 
		other = Player.position;
		PlayerDistance = Vector3.Distance(other, transform.position);
		Check ();
	}

	void Check(){
		if (PlayerDistance <= 10){
			AiLevel = 1;
		}
		if (PlayerDistance > 10 && PlayerDistance < 15 ){
			AiLevel = 2;
		}
		if (PlayerDistance >= 15 ){
			AiLevel = 3;
		}
	}
	#endregion
	#region Ai
	void DecisionAI(){

	}

    #region Basic Fuctions
    GameObject Find(string TagtoFind, string ItemNameToFind, int SearchStyle = 1) {
        //Search Styles #defaults to 1
        // 0 - All
        // 1 - Closest
        // 2 - Far
        // 3 - Largest ++ Not Implemted
        // 4 - Smallest ++ Not Implemted
        print("SearchStyle " + SearchStyle);

        GameObject CurrentItem = null;
        float CurrentDistance = 0;
        if (SearchStyle == 1) {
            CurrentDistance = Mathf.Infinity;
        }
        if (SearchStyle == 2) {
            CurrentDistance = -1;
        }
        GameObject[] IntialList = GameObject.FindGameObjectsWithTag(TagtoFind);
        GameObject[] FinalList = null;
        if (IntialList != null)
        {
            int Current = 0;
            int OtherList = 0;
            foreach (var Item in IntialList) {
                Current += 1;
                if (Item.name == ItemNameToFind) {
                    FinalList[OtherList] = Item;
                }
            }
            foreach (var Item in IntialList)
            {
                float Distance = Vector3.Distance(Item.transform.position, gameObject.transform.position);
                if (SearchStyle == 1) {
                    if (Distance < CurrentDistance)
                    {
                        CurrentItem = Item.gameObject;
                        NodeDistance = Distance;
                    }
                }
                if (SearchStyle == 2) {
                    if (Distance > CurrentDistance)
                    {
                        CurrentItem = Item.gameObject;
                        NodeDistance = Distance;
                    }
                }
            }
        }
        return CurrentItem;
        }

    void Get(GameObject Item) { 

    }
    void MoveTo() { 

    }
    void Use() { 

    }
    #endregion


	void CollectCheck() {
		gameObject.GetComponent<Inventory>();
		if (gameObject.GetComponent<Inventory>().Check(TargetNode.GetComponent<ResourceNode>().ItemID))
		{
			Collect();
		}
	}
	void Collect() {
		Goal = TargetNode.transform;
		UpdateNodeDis();
		if (NodeDistance > 2)
		{
			TeleportStart();
		}
	}

	void UpdateNodeDis()
	{
		NodeDistance = Vector3.Distance(TargetNode.transform.position, transform.position);
	}


	#endregion



	#region Movement
	void Movement(){
		if (Goal != null){
			TeleportStart();
		}
	}

	void TeleportStart(){
		Debug.Log ("Started Teleport");
		Distance = Vector3.Distance(Goal.position,gameObject.transform.position);
		WaitTime = Distance / Speed;
		Debug.Log ("Wait Time = " + WaitTime);
		StartCoroutine(TeleportWait ());

	}
	IEnumerator TeleportWait(){
		Debug.Log ("Started Teleport Wait");
		yield return new WaitForSeconds(WaitTime);
		Teleport ();
	}
	void Teleport(){
		Debug.Log ("Teleported");
		gameObject.transform.position = new Vector3(Goal.position.x+2, Goal.position.y+2, Goal.position.z+2);
	}
	#endregion




}
