using UnityEngine;
using System.Collections;

public class Ai : MonoBehaviour {
	public int AiLevel;

	public Transform Player;
	public float PlayerDistance;
	public Vector3 other;

	//movement
	public Transform Goal;
	public float Distance;
	public float Speed = 1;

	//Teleportation
	float WaitTime;


	void Start(){
		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		InvokeRepeating("DistCheck", 10, 10);
		TeleportStart ();
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
