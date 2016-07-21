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
	// just so the Ai have name not perminate
	void RandomizeName(){
		string FirstStr;
		string LastStr;
		int FirstNum;
		int LastNum;
		FirstNum = Random.Range (0, Statics.FirstNamesMale.Count - 1);
		Debug.Log (Statics.FirstNamesMale.Count);
		LastNum = Random.Range (0, Statics.LastNames.Count - 1);
		Debug.Log (Statics.LastNames.Count);
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
		//InvokeRepeating("DistCheck", 10, 10);
		DecisionAI();
	}

	void Update(){
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
		MiningAI();
	}


	#region Mining Ai
	void MiningAI() {

		if (TargetNode != null)
		{
			print("There is a target Node");
		}
		if(TargetNode == null){
			print("There is no Target Node");
			ClosestNode();
		}

		CollectCheck();

		DecisionAI();
	}




	void ClosestNode() {
		print("Searching For a Node");
		NodeList = GameObject.FindGameObjectsWithTag("Resource Node");
		NodeDistance = Mathf.Infinity;
		foreach (var Node in NodeList)
		{
			print("Node " + A + " - " + Node.GetComponent<ResourceNode>().ResourceType);
			A = A + 1;
			float PosDistance = Vector3.Distance(Node.transform.position, transform.position);
			if (string.Equals(Node.GetComponent<ResourceNode>().ResourceType, TargetResource))
			{
				print("Found a Node");
				if (PosDistance < NodeDistance)
				{
					print("Found a Closer Node");
					PosNode = Node.gameObject;
					NodeDistance = PosDistance;
				}
			}
		}
		if(PosNode != null){
			print("Targeted a Node");
			TargetNode = PosNode;	
		}
	}
	void CollectCheck() {
		gameObject.GetComponent<Inventory>().Check(TargetNode.GetComponent<ResourceNode>().ItemID);
		if (gameObject.GetComponent<Inventory>().CanHold == true)
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
