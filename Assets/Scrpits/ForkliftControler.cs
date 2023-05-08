using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ForkliftControler : MonoBehaviour
{
    [SerializeField] private GameObject playerUpCar;
    [SerializeField] private GameObject playerDownCar;
    [SerializeField] private S_PlayerMove player;
    [SerializeField] private GameObject PlayerCam;
    [SerializeField] private GameObject forkliftCam;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movX;
    [SerializeField] private float movY;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotarionSpeed;

    public bool getIn;
    void Start()
    {
        playerUpCar.SetActive(false);
        forkliftCam.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        if(player.inTheCar == true)
        {
            Move();
            OutCar();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           getIn = true;
        }
        
        
    }

    void OutCar()
    {
        if (Input.GetKeyDown(player.increase))
        {
            playerUpCar.SetActive(false);
            playerDownCar.SetActive(true);
            PlayerCam.SetActive(true);
            forkliftCam.SetActive(false);
            player.inTheCar = false;
        }
    }
    private void Move()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        transform.Translate(0, 0, movY * Time.deltaTime * moveSpeed);

        if (movY != 0)
        {
           transform.Rotate(0, movX * Time.deltaTime * rotarionSpeed, 0);
        }
    }
}
