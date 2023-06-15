using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [SerializeField] private float rotarionSpeed;
    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.None : CursorLockMode.Confined;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    public void Hand()
    {
        float yR = Input.GetAxis("Mouse Y") * Time.deltaTime * rotarionSpeed;
        this.transform.Rotate(yR,0,0);
    }

}
