using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum product
{
    Municion,
    Pomelas,
    Pestañas,
    Libro
}
public class BoxControler : MonoBehaviour
{
    [SerializeField] private product TheProduct;
    public float weight;
    public float endTime;
    public float purchasePrice;
    public float salePrice;
    public bool isPickable;


    void Start()
    {
        isPickable = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (TheProduct)
        {
            case product.Libro:
                weight = 4.5f;
                endTime = 30f;
                purchasePrice = 6.3f;
                salePrice = 12.6f;
                break;
            case product.Pomelas:
                weight = 7f;
                endTime = 24f;
                purchasePrice = 8.5f;
                salePrice = 18f;
                break;
            case product.Pestañas:
                weight = 5.3f;
                endTime = 25f;
                purchasePrice = 6.8f;
                salePrice = 15f;
                break;
            case product.Municion:
                weight = 12.8f;
                endTime = 15f;
                purchasePrice = 20.2f;
                salePrice = 45f;
                break;
        }

        if(isPickable == false)
        {
            Debug.Log("dsdf");
        }
    }


}
