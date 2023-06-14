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
    [SerializeField] private TextMeshProUGUI header;
    public TextMeshProUGUI[] lineName;
    public TextMeshProUGUI[] lineQuantity;
    [SerializeField] private ProductBase[] products;
    [SerializeField] private int deliveryNumber;
    public int amount;

    [SerializeField] private DiaControl DControl;
    [SerializeField] PostProcess post;
    [SerializeField] private S_PlayerMove player;

    [SerializeField] private Button following;
    [SerializeField] private Button back;


    public GameObject palletObject;
    private PalletControler palletScript;
    private List<OrderData> orders = new List<OrderData>(); // Lista para almacenar las órdenes generadas
    private int currentOrderIndex = -1; // Índice de la orden actual mostrada en pantalla
    private void Start()
    {
        DControl.eventNewOrder += NewOrder;
        palletScript = palletObject.GetComponent<PalletControler>();
        player.thisPallet += ThisPallet;
    }
    private void Update()
    {

    }
    public void NewOrder()
    {
        OrderData orderData = new OrderData();

        for (int i = 0; i <numberOfLines; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, products.Length); // que producto
            amount = UnityEngine.Random.Range(0, 3); // cantidad de producto

            if(amount > 0)
            {
                lineName[i].text = products[randomIndex].TheProduct.ToString();
                lineQuantity[i].text = amount.ToString();

                int existing = orderData.lineNames.IndexOf(products[randomIndex].TheProduct.ToString());
                if(existing >= 0)
                {
                    // Sumar la cantidad al producto existente
                    orderData.lineQuantity[existing] += amount;
                }
                else
                {
                    // Agregar el nuevo producto al pedido
                    orderData.lineNames.Add(products[randomIndex].TheProduct.ToString());
                    orderData.lineQuantity.Add(amount);
                }

            }
            else
            {
                // Si amount es 0, no se muestra la línea
                lineName[i].text = string.Empty;
                lineQuantity[i].text = string.Empty;
            }
        }
        orders.Add(orderData); // Agregar la orden completa a la lista de órdenes
        currentOrderIndex = orders.Count - 1; // Actualizar el índice de la orden actual
        ShowCurrentOrder();
        post.action();
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
            header.text = "Remito: " + currentOrderIndex;
            OrderData currentOrder = orders[currentOrderIndex];
            int linesToShow = (int)MathF.Min(numberOfLines, currentOrder.lineNames.Count);
            for(int i = 0; i < linesToShow; i++)
            {
                lineName[i].text = currentOrder.lineNames[i];
                lineQuantity[i].text = currentOrder.lineQuantity[i].ToString();
            }
            for (int i = linesToShow; i < numberOfLines; i++)
            {
                lineName[i].text = string.Empty;
                lineQuantity[i].text = string.Empty;
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
    public void ThisPallet()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (currentOrderIndex >= 0 && currentOrderIndex < orders.Count)
            {
                OrderData currentOrder = orders[currentOrderIndex];

                palletScript.AddOrderData(currentOrder);
                orders.RemoveAt(currentOrderIndex);
                if (currentOrderIndex < orders.Count - 1)
                {
                    currentOrderIndex++;
                    ShowCurrentOrder();
                }
                else
                {
                    header.text = "Pedidos finalizados";
                }
            }
        }
    }
    [System.Serializable]
    public class OrderData
    {
        public List<string> lineNames = new List<string>(); // Nombres de los productos de cada línea
        public List<int> lineQuantity = new List<int>(); // Cantidades de cada producto de cada línea
    }

}
