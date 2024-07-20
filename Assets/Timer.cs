using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private float countdownSpeed = 1f;

    [SerializeField] float timeSurvived;
    [SerializeField] string timeString;


    [SerializeField] public GameObject canvas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime * countdownSpeed;
            timeSurvived += Time.deltaTime;
        } else if (remainingTime <= 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
            
            timeString = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timeSurvived / 60), Mathf.FloorToInt(timeSurvived % 60));


            // Appear canvas
            StartCoroutine(EnableCanvasBeforeDelay(3f));


            SceneManager.LoadScene("1 Start Scene");

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


    private IEnumerator EnableCanvasBeforeDelay(float delay)
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
        }


        yield return new WaitForSeconds(delay);
    }
}
