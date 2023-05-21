using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderGenerator : MonoBehaviour
{
    //  Tomar de la lista que scritable object toca y darle los datos a alguna linea 
    private Dictionary<int, int> OrderBase = new Dictionary<int, int>();
    [SerializeField] private int numberOfLines = 7;
    [SerializeField] private TextMeshProUGUI[] line;
    [SerializeField] private ScriptableObject[] products;
    [SerializeField] private int deliveryNumber;
    [SerializeField] private int amount;
    [SerializeField] private int idDictionary;

    private void Start()
    {
        NewOrder();
    }

    void NewOrder()
    {
        for(int i = 0; i <numberOfLines; i++)
        {
            int randomIndex = Random.Range(0, products.Length);  
            products[randomIndex].name = line[randomIndex].text;// que producto te toca
            amount = Random.Range(0, 11); // cantidad de producto

            Debug.Log(products[randomIndex].name);
            Debug.Log(amount);

        }

        deliveryNumber++;
        idDictionary++;
        AddOrderBase();
    }


    void AddOrderBase()
    {
        OrderBase.Add(deliveryNumber, idDictionary);
    }
}
