using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awaken : MonoBehaviour
{
    // makes the character "wakeUp"
    public bool allowedToFill = true;
    public float filled = 1f;
    public float unfilled = 0f;
    public float timeToChange = 5f; //change this val to affect speed of animation
    public Color lerpedColor;

    private void Awake()
    {
        this.lerpedColor = this.GetComponent<Image>().color;
        Debug.Log("a is.." + this.GetComponent<Image>().color.a);
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.allowedToFill = true;
        }
        if (allowedToFill)
        {
            Debug.Log("we got in");
            this.allowedToFill = false;
            StartCoroutine(WakeUp(this.unfilled, this.filled));
            Debug.Log("We did someting");
        }

        if(this.lerpedColor.a >= 0.99)
        {
            StartCoroutine(WakeUp(this.filled, this.unfilled));
        }
    }


    IEnumerator WakeUp(float start, float end)
    {
        //changes "WakeUp" panel from black.a = 1 to black.a = 0
        for (float t = 0.0f; t < 1.0; t += Time.deltaTime / this.timeToChange)
        {
            this.lerpedColor = new Color(0, 0, 0, Mathf.Lerp(start, end, t));
            Debug.Log(lerpedColor);
            this.GetComponent<Image>().color = this.lerpedColor;
            yield return null;
        }
    }
}
