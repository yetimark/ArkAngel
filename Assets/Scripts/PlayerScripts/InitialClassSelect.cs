﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialClassSelect : MonoBehaviour
{
    //selects a starting character.. based on character select button
    //desire to have a default instead
    //starting character should be inherited from last play
    public GameObject chosenOne;
    public string chosen;


    void Update()
    {
        CheckForClassChoice();
    }

    void CheckForClassChoice()//name of button clicked makes that class the starting character
    {
        if (GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().gate) //true once SelectClass() is run in UIButtonFunctions
        {
            this.chosen = GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().chosen;
            this.chosenOne = GameObject.Find(this.chosen);

            this.chosenOne.GetComponent<AWSDMove>().enabled = true;
            this.chosenOne.GetComponent<Collider>().isTrigger = false; 

            GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().gate = false;//turns off function
        }
    }

}
