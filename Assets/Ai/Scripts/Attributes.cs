using UnityEngine;
using System;

public class Attributes : MonoBehaviour {

    
   
    

    //Attributes
    int BaseExp;

    // Agility
    public int Agility;

    int BaseSpeed = 5;

    //Strength
    public int Strength;
    int BaseCarryMass;
    //int BaseCarryVolume; i dont want it to be tied to strength


    //Charisma
    public int Charisma;


    //Intelligence
    public int Intelligence;


    //Luck
    public int Luck;


    //Constuitution
    public int Constitution;




    void Start () {
        
    }
    
    #region Curves
    public float SkillCurve (int AttributeLevel) {
        return  (float) AttributeLevel/10;
    }

    public float ExperienceCurve (int AttributeLevel) {
        
        return (float)(( AttributeLevel / 10) ^ 2);
    }
    #endregion


    public void AgilityUpdate () {
        NavMeshAgent Agent = gameObject.GetComponent<NavMeshAgent> ();
        Agent.speed = Mathf.Clamp( SkillCurve (Agility) * BaseSpeed , 1 , Mathf.Infinity);
        print (SkillCurve (Agility));

    }





}
