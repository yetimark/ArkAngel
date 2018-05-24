using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRuleDecision : MonoBehaviour {

    public GameObject chosenOne;

	void Awake () 
    {
        this.chosenOne = GameObject.Find("Throne"); //find way of changing string based on what the user last played
        this.chosenOne.GetComponent<AWSDMove>().enabled = true;
	}
	
}
