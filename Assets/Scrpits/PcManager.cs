using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PcManager : MonoBehaviour
{
    [SerializeField] private GameObject[] productSpawn;
    [SerializeField] private Transform purchasedProductPoint;
    [SerializeField] private Transform[] purchasedProductPointMunicion;
    [SerializeField] private Transform[] purchasedProductPointLibro;
    [SerializeField] private Transform[] purchasedProductPointPomela;
    [SerializeField] private Transform[] purchasedProductPointPestaña;





    [SerializeField] private S_PlayerMove player;
    private Dictionary<string, int> ControlStock = new Dictionary<string, int>();
    [SerializeField] GameObject Shop;
    // compra del producto y lo deja en la base

    private void Update()
    {
    }
    private void Awake()
    {
        Shop.SetActive(false);
    }
    public void buyProductLibro()
    {
        for (int i = 0; i < purchasedProductPointLibro.Length; i++)
        {
             Instantiate(productSpawn[0], purchasedProductPointLibro[i]);
             Debug.Log("Estock modificado");

        }

    }
    public void buyProductoMunicion()
    {
        for (int i = 0; i < purchasedProductPointMunicion.Length; i++)
        {
            Instantiate(productSpawn[0], purchasedProductPointMunicion[i]);
            Debug.Log("Estock modificado");

        }
    }
    public void buyProductoPestaña()
    {
        for (int i = 0; i < purchasedProductPointPestaña.Length; i++)
        {
            Instantiate(productSpawn[0], purchasedProductPointPestaña[i]);
            Debug.Log("Estock modificado");

        }
    }
    public void buyProductoPomela()
    {
        for (int i = 0; i < purchasedProductPointPomela.Length; i++)
        {
            Instantiate(productSpawn[0], purchasedProductPointPomela[i]);
            Debug.Log("Estock modificado");

        }
    }
    public void buyProductoPallet()
    {
        Instantiate(productSpawn[4], purchasedProductPoint);
        Debug.Log("Estock modificado");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Shop.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Shop.SetActive(false);
        }
    }
    void sale()
    {
        foreach (KeyValuePair<string, int> kvp in ControlStock)
        {
            Debug.Log("Nombre del producto: " + kvp.Key + " Ubicacion del stock: " + kvp.Value);
        }
    }

}
