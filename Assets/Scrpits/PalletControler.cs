using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PalletControler : MonoBehaviour
{
    [SerializeField] private List<GameObject> isProductList = new List<GameObject>();
    private Product product;

    public void AddProduct(GameObject gameObject)
    {
        isProductList.Add(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        product = other.GetComponent<Product>();
        if (other.gameObject.CompareTag("product"))
        {
            if (product._isPickable == true)
            {
                AddProduct(other.gameObject);
            }

        }
    }

}
