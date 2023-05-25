using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    [SerializeField] private ButtonC button;

    private void Awake()
    {
        button.OnButtonPressed.AddListener(openGate);
    }
    public void openGate()
    {
       transform.Translate(new Vector3(0, 0, -150 * Time.deltaTime));
        Debug.Log("Lo llama (openGate) y lo recibe (Button)");
    }

}
