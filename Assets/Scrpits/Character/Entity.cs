using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public KeyCode increase;
    public KeyCode lower;
    [SerializeField] private KeyCode activateTablet;
    [SerializeField] private GameObject tablet;



    public bool inTheCar;
    public bool isMove;
    public bool getIn;


    public GameObject playerUpCar;
    public GameObject playerDownCar;
    public GameObject PlayerCam;
    public GameObject forkliftCam;
    public float movX, movY;
    [SerializeField] private float moveSpeed;
    public float rotarionSpeed;


    private void Start()
    {
        playerUpCar.SetActive(false);
        forkliftCam.SetActive(false);
        inTheCar = false;
        getIn = false;

        lower = increase;

    }
    public void Move()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        transform.Translate(0, 0, movY * Time.deltaTime * moveSpeed);
        transform.Rotate(0, movX * Time.deltaTime * rotarionSpeed, 0);
        isMove = true;

    }

    public void GetInTheCar()
    {
        if (Input.GetKeyDown(increase) && getIn == true)
        {
            playerDownCar.SetActive(false);
            playerUpCar.SetActive(true);
            PlayerCam.SetActive(false);
            forkliftCam.SetActive(true);
            inTheCar = true;
            getIn = false;
            isMove = false;
        }
    }


    public void OutCar()
    {
        if (Input.GetKeyDown(lower) && inTheCar == true)
        {
            playerUpCar.SetActive(false);
            playerDownCar.SetActive(true);
            PlayerCam.SetActive(true);
            forkliftCam.SetActive(false);
            inTheCar = false;
            isMove = false;
        }
    }



    public void OrderTablet()
    {
        if (Input.GetKey(activateTablet))
        {
            tablet.SetActive(true);
        }
        else
        {
            tablet.SetActive(false);
        }

    }
}
