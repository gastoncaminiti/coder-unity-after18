using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text LabelUnits;
    [SerializeField] private TextMeshProUGUI LabelResources;
    void Start()
    {
        LabelUnits.text = "2";
        LabelResources.text = "6";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
