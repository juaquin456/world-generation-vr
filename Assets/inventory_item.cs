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
    public TextMeshPro textObject;

    // Start is called before the first frame update

    private void generate_new_goal()
    {
        goal = Random.Range(10, 20);
    }

    void Start()
    {
        update_text(); // Obtener el componente TextMeshProUGUI
    }

    private void update_text()
    {
        textObject.text = counter.ToString() + "/" + goal.ToString();
        // textObject.GetComponent<inventory_item>().text = counter.ToString() + "/" + goal.ToString();
    }

    public void add()
    {
        counter++;
        if (counter == goal)
        {
            counter = 0;
            generate_new_goal();
        }
        update_text();
    }
}
