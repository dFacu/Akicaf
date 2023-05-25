using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckControler : MonoBehaviour
{
    [SerializeField] private DiaControl DControl;

    void Start()
    {
        DControl.eventTruck += FirstMessage;
    }

    void FirstMessage()
    {
        Debug.Log("El camion esta terminado de descargar en otra fabrica, su horario de llagada sera: " + 2 + "hs");
        Debug.Log("EVENTO es llamdo por (DiaControl) y lo recibio de (TrckControler)");

    }
}
