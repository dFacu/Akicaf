using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using System;
using UnityEditor;
using UnityEngine.Rendering.Universal;
using UnityEditor.UIElements;

public class PostProcess : MonoBehaviour
{
    [SerializeField] private Volume postProcesst;

    public void action()
    {
        if(postProcesst.sharedProfile.TryGet(out ColorAdjustments color))
        {
            color.colorFilter.Override(Color.red);
        }
    }
    public void desability()
    {
        if (postProcesst.sharedProfile.TryGet(out ColorAdjustments color))
        {
            color.colorFilter.Override(Color.white);
        }
    }

}
