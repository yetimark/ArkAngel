using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awaken : MonoBehaviour
{
    // makes the character "wakeUp"
    public bool allowedToFill;
    public float filled = 1f;
    public float unfilled = 0f;
    public float timeToChange = 5f; //change this val to affect speed of animation
    public Color lerpedColor;

    public GameObject currAngel;

    void Awake()
    {
        this.lerpedColor = this.GetComponent<Image>().color;
        //Debug.Log("a is.." + this.GetComponent<Image>().color.a);
        this.allowedToFill = false;
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))//remove eventually
        {
            this.allowedToFill = true;
        }

        if (allowedToFill &&
            GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().pauseCounter > 0)
        {
            this.allowedToFill = false;
            StartCoroutine(WakeUp(this.unfilled, this.filled));//ctrl z away
            this.currAngel = GameObject.Find("Main Camera").GetComponent<CameraFollow>().currAngel;//turn off movement script for new angel
            this.currAngel.GetComponent<AWSDMove>().enabled = false;//should this be done here?
        }

        if(this.lerpedColor.a >= 0.99)
        {
            StartCoroutine(WakeUp(this.filled, this.unfilled));
            if(GameObject.Find("UI Controller").GetComponent<UIButtonFunctions>().pauseCounter > 0)
            {
                this.currAngel.GetComponent<AWSDMove>().enabled = true;
            }
        }
    }


    IEnumerator WakeUp(float start, float end)
    {
        //changes "WakeUp" panel from black.a = 1 to black.a = 0
        for (float t = 0.0f; t < 1.0; t += Time.deltaTime / this.timeToChange)
        {
            this.lerpedColor = new Color(0, 0, 0, Mathf.Lerp(start, end, t));
            //Debug.Log(lerpedColor);
            this.GetComponent<Image>().color = this.lerpedColor;
            yield return null;
        }
    }
}
