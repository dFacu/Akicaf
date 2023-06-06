using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.Rendering.Universal;

public class DiaControl : MonoBehaviour
{
    //[SerializeField] private Product pro;
    [SerializeField] private S_PlayerMove player;

    [SerializeField] private float seconds = 0;
    [SerializeField] private int minutes = 0;
    [SerializeField] private int hours = 7;
    [SerializeField] private int days = 0;
    [SerializeField] private TextMeshProUGUI clock;
    [SerializeField] private TextMeshProUGUI dia;
    [SerializeField] private int velocity;
    [SerializeField] private int endTime;
    [SerializeField] private int truckArrivalTime = 25;
    [SerializeField] private float waitTime;
    [SerializeField] private int timeNewOrder = 300;

    public event Action eventNewOrder;
    public event Action eventBrokenBox;
    public event Action eventTruck;

    private bool ud;
    [SerializeField] PostProcess post;

    void Update()
    {
        seconds  += Time.deltaTime * velocity;
        waitTime += Time.deltaTime * velocity;
        Clock();
        TextClock();

        // manda el pedido
        if(waitTime >= timeNewOrder && eventNewOrder != null)
        {
            eventNewOrder?.Invoke();
            waitTime = 0;
            ud = true;
        }
        if(seconds >= truckArrivalTime)
        {
            eventTruck?.Invoke();
        }

        if(waitTime >= 3 && ud == true)
        {
            post.desability();
            ud= false;
        }
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
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
