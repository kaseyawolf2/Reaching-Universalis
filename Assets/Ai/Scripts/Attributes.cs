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
    int BaseCarryMass = 100;
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
        return Mathf.Pow(SkillCurve (AttributeLevel), 2);
    }
    #endregion


    public void AgilityUpdate () {
        UnityEngine.AI.NavMeshAgent Agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ();
        Agent.speed = Mathf.Clamp( SkillCurve (Agility) * BaseSpeed , 1 , Mathf.Infinity);
    }

    public void StrengthUpdate () {
        Inventory Inventory = gameObject.GetComponent<Inventory> ();
        Inventory.MaxMass = SkillCurve (Strength) * BaseCarryMass;
    }

    public void CharismaUpdate () {

    }

    public void IntelligenceUpdate () {

    }

    public void LuckUpdate () {

    }

    public void ConstitutionUpdate () {

    }




}
