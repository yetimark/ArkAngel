using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Awaken : MonoBehaviour
{
    // makes the character "wakeUp"
    public Color changeMe;
    public Color filled = new Vector4(0, 0, 0, 1);
    public Color unfilled = new Vector4(0, 0, 0, 0);
    public Color lerpedColor = Color.white;

    private void Awake()
    {
        //this.changeMe = this.GetComponent<Image>().color;
    }

    void Update ()
    {
        lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        Debug.Log(lerpedColor);
    }


    public void WakeUp()
    {
        //changes "WakeUp" panel from black.a = 1 to black.a = 0
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(this.changeMe);
            this.changeMe = this.filled;
            Debug.Log(this.changeMe);
        }
    }
	
}
