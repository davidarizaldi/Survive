using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    private TMP_Text timerText;
    private static float startTime;
    [HideInInspector] public static int elapsedTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        timerText = transform.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isAlive)
        {
            elapsedTime = (int)(Time.time - startTime);
            timerText.text = String.Format("Time Survived : {0:mm\\:ss}", new TimeSpan(0, 0, elapsedTime));
        }
    }

    public static void ResetTime()
    {
        startTime = Time.time;
    }
}
