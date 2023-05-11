    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMove : MonoBehaviour
{

    //Controles de juego
    public KeyCode increase;
    public KeyCode grab;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotarionSpeed;
    private Animator anim;
    [SerializeField] float movX, movY;
    private bool isMove;
    public bool inTheCar;

    [SerializeField] private ForkliftControler forkliftControler;
    [SerializeField] private GameObject playerUpCar;
    [SerializeField] private GameObject playerDownCar;
    [SerializeField] private GameObject PlayerCam;
    [SerializeField] private GameObject forkliftCam;
   
    // Agarrar objecto
    public Transform handsPoint;
    [SerializeField] private float distanceMax;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Hands hand;
    [SerializeField] private Transform handBox;
    public bool loAgarre;
    public BoxControler boxControler;
         



    // Tiempo de cargar peso
    [SerializeField] private float startTime;
    [SerializeField] private float productWeight;

    void Start()
    {
        anim= GetComponent<Animator>();
        inTheCar = false;
    }

    // Update is called once per frame
    void Update()
    {
        Grab();
        hand.Hand();
        if(inTheCar == false)
        {
            Move();
        }
        GetInTheCar();

        if (movY == 0)
        {
            isMove = false;
        }
        if(isMove == false)
        {
            anim.SetBool("isMove", false);
        }
        else
        {
            anim.SetBool("isMove", true);
        }

        startTime += Time.deltaTime;

        if(loAgarre == true)
        {
            startTime = 0;
        }
    }

    void Move()
    {
        isMove = true;
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        transform.Rotate(0,movX * Time.deltaTime * rotarionSpeed, 0);
        transform.Translate(0, 0, movY * Time.deltaTime * moveSpeed);

        anim.SetFloat("movX", movX);
        anim.SetFloat("movY", movY);
    }

    void GetInTheCar()
    {
        if (Input.GetKeyDown(increase) && forkliftControler.getIn == true)
        {
            playerDownCar.SetActive(false);
            playerUpCar.SetActive(true);
            PlayerCam.SetActive(false);
            forkliftCam.SetActive(true);
            inTheCar = true;
        }
    }

    void Grab()
    {
        RaycastHit hit;
        bool whatToGrab = Physics.Raycast(handsPoint.position, handsPoint.forward, out hit, distanceMax, layerMask);
        if (Input.GetKeyDown(grab) && loAgarre == false)
        {
            if (whatToGrab == true) 
            {
                boxControler = hit.transform.GetComponent<BoxControler>();

                hit.transform.position = handBox.transform.position;
                hit.transform.SetParent(handBox.transform);
                loAgarre = true;
                boxControler.isPickable= false;
            }

        }
   /*     if(Input.GetKeyDown(grab) && loAgarre == true)
        {
            if (whatToGrab == true)
            {

                hit.transform.position = palet.transform.position;
                hit.transform.SetParent(palet.transform);
            }
   */
    }
   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(handsPoint.position, handsPoint.position + handsPoint.forward * distanceMax);
    }


   /* funcion para agarrar objecto de la estanteria y eliminarla de la lista 
   
    
    
    <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<*/
}
    