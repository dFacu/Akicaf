using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class OrderGenerator : MonoBehaviour
{
    //  Tomar de la lista que scritable object toca y darle los datos a alguna linea 
    [SerializeField] private int numberOfLines = 7;
    [SerializeField] private TextMeshProUGUI[] lineName;
    [SerializeField] private TextMeshProUGUI[] lineQuantity;
    [SerializeField] private ProductBase[] products;
    [SerializeField] private int deliveryNumber;
    [SerializeField] private int amount;
    [SerializeField] private int idDictionary;
    [SerializeField] private TextMeshProUGUI ID;

    [SerializeField] private DiaControl DControl;


    [SerializeField] private Button following;
    [SerializeField] private Button back;


    private List<OrderData> orders = new List<OrderData>(); // Lista para almacenar las órdenes generadas
    private int currentOrderIndex = -1; // Índice de la orden actual mostrada en pantalla
    private void Start()
    {
        DControl.eventNewOrder += NewOrder;
    }
    public void NewOrder()
    {
        OrderData orderData = new OrderData();

        for (int i = 0; i <numberOfLines; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, products.Length); // que producto
            amount = UnityEngine.Random.Range(0, 11); // cantidad de producto

            lineName[i].text = products[randomIndex].TheProduct.ToString();
            lineQuantity[i].text = amount.ToString();

            orderData.lineNames.Add(products[randomIndex].TheProduct.ToString());
            orderData.lineQuantities.Add(amount);
        }
        orders.Add(orderData); // Agregar la orden completa a la lista de órdenes
        currentOrderIndex = orders.Count - 1; // Actualizar el índice de la orden actual

        ShowCurrentOrder();
    }


    public void NextOrder()
    {
        currentOrderIndex++;

        if (currentOrderIndex >= orders.Count)
        {
            currentOrderIndex = 0;
        }

        ShowCurrentOrder();
    }

    public void ShowCurrentOrder()
    {
        if (currentOrderIndex >= 0 && currentOrderIndex < orders.Count)
        {
            OrderData currentOrder = orders[currentOrderIndex];

            for (int i = 0; i < numberOfLines; i++)
            {
                lineName[i].text = currentOrder.lineNames[i];
                lineQuantity[i].text = currentOrder.lineQuantities[i].ToString();
            }
        }
        else
        {
            Debug.Log("No hay órdenes para mostrar.");
        }
    }
    public void PreviousOrder()
    {
        currentOrderIndex--;
        if (currentOrderIndex < 0)
        {
            currentOrderIndex = 0;
        }

        ShowCurrentOrder();
    }

    [System.Serializable]
    public class OrderData
    {
        public List<string> lineNames = new List<string>(); // Nombres de los productos de cada línea
        public List<int> lineQuantities = new List<int>(); // Cantidades de cada producto de cada línea
    }

}
