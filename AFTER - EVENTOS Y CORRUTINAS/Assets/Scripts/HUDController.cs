using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text LabelUnits;
    [SerializeField] private TextMeshProUGUI LabelResources;
    void Start()
    {
        LabelUnits.text = "1";
        LabelResources.text = "0";
        GroupController.onResource += OnResourceHandler;
        GroupController.onPlayerUnits += OnPlayerUnitsHandler;
    }

    private void OnPlayerUnitsHandler(int playerUnits)
    {
        LabelUnits.text = playerUnits.ToString();
    }

    private void OnResourceHandler(int resources)
    {
        LabelResources.text = resources.ToString();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
