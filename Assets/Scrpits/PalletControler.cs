using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PalletControler : MonoBehaviour
{
    [SerializeField] private List<GameObject> isProductList = new List<GameObject>();
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddProduct(GameObject gameObject)
    {
        isProductList.Add(gameObject);
    }
}
