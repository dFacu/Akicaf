using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using TMPro;
using static OrderGenerator;
using System.Drawing;

public class PalletControler : MonoBehaviour
{
    [SerializeField] private List<GameObject> isProductList = new List<GameObject>();
    private Product product;
    [SerializeField]private List<string> palletLineName = new List<string>();
    [SerializeField]private List<int> palletLineQuantity = new List<int>();
    [SerializeField] private Collicionpallet pointCol;

    public void AddProduct(GameObject gameObject)
    {
        isProductList.Add(gameObject);
    }
    public void AddOrderData(OrderData orderData)
    {
        for(int i = 0; i < orderData.lineNames.Count; i++)
        {
            string lineName = orderData.lineNames[i];
            int lineQuantity = orderData.lineQuantity[i];

            palletLineName.Add(lineName);
            palletLineQuantity.Add(lineQuantity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
            product = other.GetComponent<Product>();

        if (other.gameObject.CompareTag("product"))
        {

            if (product._isPickable == true && product._isPicking == false)
            {
                AddProduct(other.gameObject);
            }
        }
    }

}
