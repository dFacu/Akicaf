using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class stockManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> product;

    private void Awake()
    {

    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.K)) 
        {
            myproduct();    
        }
    }

    private GameObject myproduct()
    {
        if(product.Count > 0)
        {
            var  my_producto = product[0];
            Debug.Log(my_producto.name);
            product.RemoveAt(0);
            return my_producto;
        }
        return default;
    }
    // SI EL PLAYER SE ACERC CON UNA CAJA Y TOCA LA F LA CAJA ENTRA A LA STANTERIA OCUPANDO UN LUGAR DE EL ARRAY
}
