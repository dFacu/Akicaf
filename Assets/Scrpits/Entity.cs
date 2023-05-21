using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotarionSpeed;
    public Animator anim;


    public float GetMoveSpeed() => moveSpeed;
    public float GetRotationSpeed() => rotarionSpeed;


}
