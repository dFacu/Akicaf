using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public enum products
{
    Municion,
    Pomelas,
    Pestañas,
    Libro,
    nothing
}

[CreateAssetMenu(menuName = "product")]
public class ProductBase : ScriptableObject
{
    public products TheProduct;
    public string ProductName;
    public float weight;
    public float endTime;
    public float purchasePrice;
    public float salePrice;
    public bool isPickable;

}
