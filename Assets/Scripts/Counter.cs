using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text counterText;
    public string description;
    public int counter;

    // Update is called once per frame
    void Update()
    {
       counter = Manager.spotCount;
       counterText.text = description + counter.ToString();     
    }
}
