using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRuleDecision : MonoBehaviour
{
    //selects a starting character.. currently string must be changed manually
    public GameObject chosenOne;
    public string chosen;

	void Awake () 
    {
        this.chosen = "Throne"; //default start
        this.chosenOne = GameObject.Find(this.chosen); //find way of changing string based on what the user last played
        //this.chosenOne.GetComponent<AWSDMove>().enabled = true;
	}

    void Update()
    {
        CheckForClassChoice();
    }

    void CheckForClassChoice()
    {
        this.chosen = GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().chosen;
        this.chosenOne = GameObject.Find(this.chosen);
        if (GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().gate)
        {
            this.chosenOne.GetComponent<AWSDMove>().enabled = true;
        }
    }

}
