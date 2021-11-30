using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorController : MonoBehaviour
{
    public static event Action onValidPoint;

    private void OnMouseDown()
    {
        Debug.Log(GroupController.indexPlayer);
        onValidPoint?.Invoke();
    }
}
