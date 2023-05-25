using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMove : Entity
{
    [SerializeField] private DiaControl DControl;

    public KeyCode grab;
    public KeyCode buy;
  
    private Animator anim;                          

    // Agarrar objecto-------------------------------------
    public Transform handsPoint;
    [SerializeField] private float distanceMax;
    [SerializeField] private LayerMask layerMaskGrabe;
    [SerializeField] private LayerMask layerMaskLeave;
    [SerializeField] private Hands hand;
    [SerializeField] private Transform handBox;
    public bool loAgarre;
    public Product boxProduct;
    // Tiempo de cargar peso
    public float gripTime;
    public float exhausted;
    [SerializeField] private float productWeight;


    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inTheCar = false;
        gripTime += Time.deltaTime;

        Move(); 
        Grab();
        OrderTablet();

        GetInTheCar();
        hand.Hand();


        anim.SetFloat("movX", movX);
        anim.SetFloat("movY", movY);
 
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

        if(loAgarre == true && gripTime >= exhausted)
        {
            Debug.Log("lpm ********");
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Forklift"))
        {
            getIn = true;
           
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
                boxProduct = hit.transform.GetComponent<Product>();

                hit.transform.position = handBox.transform.position;
                hit.transform.rotation = handBox.transform.rotation;
                hit.transform.SetParent(handBox.transform);
                hit.rigidbody.useGravity = false;
                hit.rigidbody.isKinematic = true;
                loAgarre = true;
                gripTime = 0;
                boxProduct._isPickable = false;
                exhausted = boxProduct._endTime;
            }


        }
        if (Input.GetKeyDown(grab) && loAgarre == true)
        {
            bool whatToLeave = Physics.Raycast(handsPoint.position, handsPoint.forward, out hit, distanceMax, layerMaskLeave);
            if (whatToLeave == true)
            {

                handBox.transform.GetChild(0).gameObject.transform.position = transform.position;
                handBox.transform.GetChild(0).transform.SetParent(hit.transform); 
                boxProduct._isPickable = true;
                loAgarre = false;
                exhausted = 0;
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
    