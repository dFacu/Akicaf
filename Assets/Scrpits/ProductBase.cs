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

[CreateAssetMenu(menuName = "product")]
public class ProductBase : ScriptableObject
{
    [SerializeField] private product TheProduct;
    [SerializeField] private float weight;
    [SerializeField] private float endTime;
    [SerializeField] private float purchasePrice;
    [SerializeField] private float salePrice;
    [SerializeField] private bool isPickable;
}
