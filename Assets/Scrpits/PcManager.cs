using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PcManager : MonoBehaviour
{
    [SerializeField] private GameObject[] productSpawn;
    [SerializeField] private Transform purchasedProductPoint;
    [SerializeField] private bool iBoughtSomeProduct = false;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private float inicioTime = 0f;

    [SerializeField] private ButtonC button;
    [SerializeField] private S_PlayerMove player;
    private Dictionary<string, int> ControlStock = new Dictionary<string, int>();

    private void Awake()
    {
        button.OnButtonPressed.AddListener(buyProduct);
    }
    private void Update()
    {
        inicioTime += Time.deltaTime;

        // tiempo de espera para comprar 
        if(inicioTime > waitTime)
        {
            button.n_isPressed = false;
        }
        if(inicioTime > waitTime && iBoughtSomeProduct == true)
        {
            iBoughtSomeProduct = false;

        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            sale();
        }
    }
    
    // compra del producto y lo deja en la base
    public void buyProduct()
    {
        for(int i = 0; i < 4; i++)
        {
            Instantiate(productSpawn[i], purchasedProductPoint);
        }
        Debug.Log("Estock modificado");
        iBoughtSomeProduct = true;
        Debug.Log("Lo llama (buttonC) y lo recibe (PcManager)");
        inicioTime = 0;

    }



    void sale()
    {
        foreach (KeyValuePair<string, int> kvp in ControlStock)
        {
            Debug.Log("Nombre del producto: " + kvp.Key + " Ubicacion del stock: " + kvp.Value);
        }
    }

}
