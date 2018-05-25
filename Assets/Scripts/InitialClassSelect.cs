using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialClassSelect : MonoBehaviour
{
    //selects a starting character.. currently string must be changed manually
    //starting character should be inherited from last play
    public GameObject chosenOne;
    public string chosen;


    void Update()
    {
        CheckForClassChoice();
    }

    void CheckForClassChoice()
    {
        if (GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().gate)
        {
            this.chosen = GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().chosen;
            this.chosenOne = GameObject.Find(this.chosen);
            this.chosenOne.GetComponent<AWSDMove>().enabled = true;
            this.chosenOne.GetComponent<Collider>().isTrigger = false; //recently added.. issues with trigger
            GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().gate = false;
        }
    }

}
