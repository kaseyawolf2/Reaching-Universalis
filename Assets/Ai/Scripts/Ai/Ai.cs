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
	GameObject TargetNode;
	GameObject TargetStorage;


	#endregion

	#region Name Randomization
	// just so the Ai have name not perminate
	void RandomizeName(){
		string FirstStr;
		string LastStr;
		int FirstNum;
		int LastNum;
		FirstNum = Random.Range (0, Statics.FirstNamesMale.Count - 1);
		LastNum = Random.Range (0, Statics.LastNames.Count - 1);
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
		
	}


	#region Mining Ai
	void MiningAI() {


		if(TargetNode == null){
			ClosestNode();
		}



	
	}

	void ClosestNode() {
		NodeList = GameObject.FindGameObjectsWithTag("Resource Node");
		float NodeDistance;
		GameObject PosNode;
		foreach (var Node in NodeList)
		{
			float Distance = Vector3.Distance(Node.transform.position, transform.position);
			if(Distance < NodeDistance) {
				PosNode = Node.gameObject;
				NodeDistance = Distance;
			}
		}
	}






	#endregion
	#endregion



	#region Movement
	void Movement(){
	
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
		gameObject.transform.position = Goal.position;
	}
	#endregion




}
