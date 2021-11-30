using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwtichController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OTHER");
    }
}
