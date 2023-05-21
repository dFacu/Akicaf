using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class ForkliftControler : Entity
{
    [SerializeField] private Rigidbody rb;
    void Update()
    {
        if (movY != 0)
        {
            transform.Rotate(0, movX * Time.deltaTime * rotarionSpeed, 0);
        }

        if (inTheCar == true)
        {
            Move();
            OutCar();
        }
        GetInTheCar();
        OrderTablet();
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            getIn = true;
        }
    }

}
