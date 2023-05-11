using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcManager : MonoBehaviour
{
    [SerializeField] private GameObject[] productSpawn;
    [SerializeField] private Transform purchasedProductPoint;
    [SerializeField] private bool iBoughtSomeProduct = false;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private float inicioTime = 0f;

    private string input;
    private string input1;

    [SerializeField] private S_PlayerMove player;
    private void Start()
    {
    }


    private void Update()
    {
        waitTime += Time.deltaTime;

        // se compro un producto entonce esperas
        if (iBoughtSomeProduct == false && Input.GetKeyDown(player.buy))
        {
            buyProduct();
        }

        // tiempo de espera para comprar 
        if(inicioTime > waitTime && iBoughtSomeProduct == true)
        {
            iBoughtSomeProduct = false;
        }

    }
    
    // compra del producto y lo deja en la base
    void buyProduct()
    {
        var product =  Random.Range(0,productSpawn.Length);
        Instantiate(productSpawn[product], purchasedProductPoint);
        iBoughtSomeProduct = true;
        waitTime += Time.deltaTime;

    }

}
