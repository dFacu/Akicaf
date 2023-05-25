using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private ProductBase product;
    [SerializeField] private products _TheProduct;
    [SerializeField] private float _weight;
    public float _endTime;
    [SerializeField] private float _purchasePrice;
    [SerializeField] private float _salePrice;
    public bool _isPickable;

    private void Start()
    {
        _TheProduct = product.TheProduct;
        _weight = product.weight;
        _endTime = product.endTime;
        _purchasePrice = product.purchasePrice;
        _salePrice = product.salePrice;
        _isPickable = product.isPickable;

    
    }

}
