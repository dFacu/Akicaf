using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiaControl : MonoBehaviour
{
    [SerializeField] private float seconds = 0;
    [SerializeField] private int minutes = 0;
    [SerializeField] private int hours = 7;
    [SerializeField] private int days = 0;
    [SerializeField] private TextMeshProUGUI clock;
    [SerializeField] private TextMeshProUGUI dia;
    [SerializeField] private int velocity;
    [SerializeField] private int endTime;
    [SerializeField] private int truckArrival;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        seconds  += Time.deltaTime * velocity;

        Clock();
        TextClock();
    }

    void NextDay()
    {
        dia.text = "Days: " + days.ToString();
    }

    void TextClock()
    {
        clock.text = AddZero(hours) + ":" + AddZero(minutes) + ":" + AddZero(Mathf.FloorToInt(seconds));
    }
    void Clock()
    {
        if (seconds > 60)
        {
            minutes += 1;
            seconds = 0;
        }
        if (minutes > 60)
        {
            hours += 1;
            minutes = 0;
        }
        if (hours > 17)
        {
            hours = 7;
            days += 1;
            NextDay();
        }
    }

    private string AddZero(int n)
    {
        if(n < 10) return "0" + n.ToString();
        else return n.ToString();
    }
}
