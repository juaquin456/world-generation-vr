using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Xml.Linq;

public class inventory_item : MonoBehaviour
{
    private int counter = 0;
    private int goal = 10;
    public float timeIncrement = 5f;
    public TMP_Text text;
    public Timer timer;

    private void generate_new_goal()
    {
        goal = Random.Range(10, 20);
    }

    void Start()
    {
        update_text(); 
    }

    private void update_text()
    {
        text.text = counter.ToString() + "/" + goal.ToString();
    }

    public void add()
    {
        counter++;
        timer.IncreaseTime(timeIncrement);
        if (counter == goal)
        {
            counter = 0;
            generate_new_goal();
            timer.IncreaseCountdownSpeed();
        }
        update_text();
    }
}
