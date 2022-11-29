using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Timer Infomation")]
    public TextMesh timerText;
    public static float timer;
    public float scoretimer = 120f;
    float t;

    public bool timerstart = false;

    // Start is called before the first frame update
    void Start()
    {
        t = scoretimer;

        timerText.text = "00 00 00";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            timerstart = true;            
        }

        if (timerstart)
        {
            t -= Time.deltaTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            string zero = "0";
            timerText.text = zero + zero + " " + zero + minutes + " " + seconds;
        }
    }
}
