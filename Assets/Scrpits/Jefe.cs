using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Jefe : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private  float distanceToChase= 5f;

    [SerializeField] private Transform jefePoint;
    [SerializeField] private float distanceMax;
    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followTheWorker();
    }

    void followTheWorker()
    {
        var diferente = Player.position - transform.position;

        if (distanceToChase > diferente.magnitude)
        {
            findOut();

        }
    }

    void Move(Vector3 direction)
    {
        transform.position += direction * (1 * Time.deltaTime);
        transform.LookAt(Player.position);
    }


    private void findOut()
    {
        bool whatToGrab = Physics.CheckSphere(jefePoint.position, distanceMax, layerMask);
        var diferente = Player.position - transform.position;

        if (whatToGrab == true) 
        {
            Move(diferente.normalized);
            Debug.Log("Vuelve al trabajo");
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(jefePoint.position, distanceMax);
    }
}
