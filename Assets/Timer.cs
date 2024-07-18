using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private float countdownSpeed = 1f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime * countdownSpeed;
        } else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void IncreaseTime(float amount)
    {
        remainingTime += amount;
    }

    public void DecreaseTime(float amount)
    {
        if (remainingTime - amount > 0) { remainingTime -= amount; }
        else { remainingTime = 0; }
    }

    public void IncreaseCountdownSpeed()
    {
        countdownSpeed += 2;
    }
}
