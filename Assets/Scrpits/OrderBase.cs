using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBase : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] products;



    [SerializeField] private int deliveryNumber;
    [SerializeField] private string customerName;
    [SerializeField] private ScriptableObject firstLine;
    [SerializeField] private int amountFirstL;
    [SerializeField] private ScriptableObject secondLine;
    [SerializeField] private int amountSecondL;
    [SerializeField] private ScriptableObject thirdLine;
    [SerializeField] private int amountThirdL;
    [SerializeField] private ScriptableObject fourthLine;
    [SerializeField] private int amountFourL;
    [SerializeField] private ScriptableObject fifthLine;
    [SerializeField] private int amountFiveL;
    [SerializeField] private ScriptableObject sixthLine;
    [SerializeField] private int amountSixL;
}
