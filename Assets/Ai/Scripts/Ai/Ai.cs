using UnityEngine;
using System.Collections;

public class Ai : MonoBehaviour {
	public int AiLevel;

	public Transform Player;
	public float PlayerDistance;
	public Vector3 other;


	void Start(){
		InvokeRepeating("DistCheck", 10, 10);
	}
	void DistCheck(){ 
		other = Player.position;
		PlayerDistance = Vector3.Distance(other, transform.position);
		Check ();
	}

	void Check(){
		if (PlayerDistance <= 10){
			CloseAi ();
			if (AiLevel != 1){
				ChangeAiLevel ();
			}
		}
		if (PlayerDistance > 10 && PlayerDistance < 15 ){
			MidAi ();
			if (AiLevel != 2){
				ChangeAiLevel ();
			}

		}
		if (PlayerDistance >= 15 ){
			FarAi ();
			if (AiLevel != 3){
				ChangeAiLevel ();
			}
		}
	}

	void ChangeAiLevel(){
		
	}


	void CloseAi(){
		Debug.Log ("Invoked the Close Ai");
		AiLevel = 1;
	}
	void MidAi(){
		Debug.Log ("Invoked the Mid Ai");
		AiLevel = 2;
	}
	void FarAi(){
		Debug.Log ("Invoked the Far Ai");
		AiLevel = 3;
	}










}
