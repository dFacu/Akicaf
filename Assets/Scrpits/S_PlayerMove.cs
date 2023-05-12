    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMove : MonoBehaviour
{

    //Controles de juego
    public KeyCode increase;
    public KeyCode grab;
    public KeyCode buy;

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
    [SerializeField] private LayerMask layerMaskGrabe;
    [SerializeField] private LayerMask layerMaskLeave;
    [SerializeField] private Hands hand;
    [SerializeField] private Transform handBox;
    public bool loAgarre;
    public BoxControler boxControler;
         



    // Tiempo de cargar peso
    [SerializeField] private float startTime;
    [SerializeField] private float productWeight;


    private stockManager stock;

    void Start()
    {
        anim= GetComponent<Animator>();
        stock = GetComponent<stockManager>();
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
        bool whatToGrab = Physics.Raycast(handsPoint.position, handsPoint.forward, out hit, distanceMax, layerMaskGrabe);
        if (Input.GetKeyDown(grab) && loAgarre == false)
        {
            if (whatToGrab == true) 
            {
                boxControler = hit.transform.GetComponent<BoxControler>();

                hit.transform.position = handBox.transform.position;
                hit.transform.rotation = handBox.transform.rotation;
                hit.transform.SetParent(handBox.transform);
                hit.rigidbody.useGravity = false;
                hit.rigidbody.isKinematic = true;
                loAgarre = true;
                boxControler.isPickable= false;
                stock.myproduct();
            }


        }
        if (Input.GetKeyDown(grab) && loAgarre == true)
        {
            bool whatToLeave = Physics.Raycast(handsPoint.position, handsPoint.forward, out hit, distanceMax, layerMaskLeave);
            if (whatToLeave == true)
            {

                handBox.transform.GetChild(0).gameObject.transform.position = transform.position;
                handBox.transform.GetChild(0).transform.SetParent(hit.transform); 
                boxControler.isPickable = true;
                loAgarre = false;
            }
        }
    }
   

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(handsPoint.position, handsPoint.position + handsPoint.forward * distanceMax);
    }


   // funcion para agarrar objecto de la estanteria y eliminarla de la lista 
   
        
}
    