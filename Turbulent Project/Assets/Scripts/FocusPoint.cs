using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPoint : MonoBehaviour
{
    [SerializeField] private GameObject focusPoint;
    public Vector3 whereToFocus;

    void Start()
    {
        whereToFocus = focusPoint.transform.position;
    }
}
