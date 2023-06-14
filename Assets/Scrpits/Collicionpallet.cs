using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collicionpallet : MonoBehaviour
{
    public GameObject currentPallet;
    public bool isHoldingPallet = false;
    [SerializeField] private Transform point;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isHoldingPallet == true)
            {

                DropPallet();
            }
            else if (isHoldingPallet == false)
            {
                GrabPallet();
            }
        }
    }
    public void GrabPallet()
    {
        if (currentPallet != null)
        {
            isHoldingPallet = true;
            currentPallet.transform.SetParent(point);
            currentPallet.transform.localPosition = Vector3.zero;
            currentPallet.transform.localRotation = Quaternion.identity;
            currentPallet.GetComponent<Rigidbody>().useGravity = false;
            currentPallet.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void DropPallet()
    {
        if (currentPallet != null)
        {
            isHoldingPallet = false;
            currentPallet.GetComponent<Rigidbody>().useGravity = true;
            currentPallet.GetComponent<Rigidbody>().isKinematic = false;
            currentPallet.transform.SetParent(null);
            currentPallet = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isHoldingPallet && other.CompareTag("Estan"))
        {
            currentPallet = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isHoldingPallet == false && other.CompareTag("Estan"))
        {
            currentPallet = null;
        }
    }
}
