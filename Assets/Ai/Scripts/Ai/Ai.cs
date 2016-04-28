using UnityEngine;
using System.Collections;

public class Ai : MonoBehaviour {
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





	void RandomizeName(){
		string FirstStr;
		string LastStr;
		int FirstNum;
		int LastNum;
		FirstNum = Random.Range (0, Statics.FirstNamesMale.Count - 1);
		LastNum = Random.Range (0, Statics.LastNamesMale.Count - 1);
		FirstStr = Statics.FirstNamesMale[FirstNum].Name;
		LastStr = Statics.LastNamesMale[LastNum].Name;
		CharName = FirstStr + " " + LastStr;
	}




	void Start(){
		RandomizeName();
		name = CharName;
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		InvokeRepeating("DistCheck", 10, 10);
	}
	void Update(){
		
	}

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
		
	void ai(){

		if(AiLevel != 3){
			if(AiLevel == 1){
				Movement ();
			}


		}


	}





//Movement
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





}
