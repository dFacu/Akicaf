    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotarionSpeed;
    private Animator anim;
    [SerializeField] float movX, movY;
    private bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();


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
        
    }

    void Move()
    {
        isMove = true;
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        transform.Rotate(0,movX * Time.deltaTime * rotarionSpeed, 0);
        transform.Translate(0, 0, movY * Time.deltaTime * moveSpeed);

        anim.SetFloat("velX", movX);
        anim.SetFloat("velY", movY);
    }
}
    