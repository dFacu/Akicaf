using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class OrderGenerator : MonoBehaviour
{
    //  Tomar de la lista que scritable object toca y darle los datos a alguna linea 
    private Dictionary<int, int> OrderBase = new Dictionary<int, int>();
    [SerializeField] private int numberOfLines = 7;
    [SerializeField] private TextMeshProUGUI[] lineName;
    [SerializeField] private TextMeshProUGUI[] lineQuantity;
    [SerializeField] private ProductBase[] products;
    [SerializeField] private int deliveryNumber;
    [SerializeField] private int amount;
    [SerializeField] private int idDictionary;
    [SerializeField] private TextMeshProUGUI ID;

    [SerializeField] private DiaControl DControl;

    private void Start()
    {
        DControl.eventNewOrder += NewOrder;
    }
    public void NewOrder()
    {
        for(int i = 0; i <numberOfLines; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, products.Length); // que producto
            amount = UnityEngine.Random.Range(0, 11); // cantidad de producto

            lineName[i].text = products[randomIndex].TheProduct.ToString();
            lineQuantity[i].text = amount.ToString();

        }

        deliveryNumber++;
        idDictionary++;
        OrderBase.Add(deliveryNumber, idDictionary);
        Debug.Log("EVENTO es llamdo por (DiaControl) y lo recibio de (OrderGenerator)");
        AddOrderBase();
    }


    void AddOrderBase()
    {
        foreach (KeyValuePair<int, int> kvp in OrderBase)
        {
            ID.text = "REMITO: " + kvp.Key.ToString();
          
        }
    }
}
