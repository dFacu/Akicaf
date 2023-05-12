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


    [SerializeField] private S_PlayerMove player;
    private Dictionary<string, int> ControlStock = new Dictionary<string, int>();

    private void Update()
    {
        inicioTime += Time.deltaTime;

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

        if (Input.GetKeyDown(KeyCode.N))
        {
            sale();
        }
    }
    
    // compra del producto y lo deja en la base
    void buyProduct()
    {
        for(int i = 0; i < productSpawn.Length; i++)
        {
            Instantiate(productSpawn[i], purchasedProductPoint);
            ControlStock.Add(productSpawn[i].name, i);
            int valor = ControlStock[productSpawn[i].name];
            Debug.Log("Estock modificado");

        }

        iBoughtSomeProduct = true;
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
