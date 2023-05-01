using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ForkliftControler : MonoBehaviour
{
    [SerializeField] GameObject playerAboveTheCar;
    [SerializeField] GameObject playerDownTheCar;
    [SerializeField] S_PlayerMove player;
    public bool getIn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        var playerCol = other.CompareTag("Player");

        if (playerCol)
        {
           getIn = true;
        }
        
        
    }

    void OutCar()
    {
        if (Input.GetKey(player.increase))
        {
            playerAboveTheCar.SetActive(false);
            playerDownTheCar.SetActive(true);
            player.inTheCar = false;
        }
    }
}
