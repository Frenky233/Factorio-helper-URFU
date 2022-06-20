using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private bool fluidInCraft;
    [SerializeField] private float timeToCraft;
    [SerializeField] private int craftOutput;
    [SerializeField] private List<int> resourcesNeed;
    [SerializeField] private List<GameObject> amountCraftersDisplay;
    [SerializeField] private List<GameObject> amountResourcesDisplay;
    private float items;
    private string itemsInput;

    public void AssemblersCalc()
    {
        itemsInput = inputField.GetComponent<TMP_InputField>().text;
        if (itemsInput == "")
        {
            items = 1;
        } 
        else
        {
            items = float.Parse(itemsInput);
        }   
        if(!fluidInCraft)
        {
            amountCraftersDisplay[0].GetComponent<TextMeshProUGUI>().text = Math.Ceiling(items / (60 / (timeToCraft * 2 / craftOutput))).ToString();
        }
        else
        {
            amountCraftersDisplay[0].GetComponent<TextMeshProUGUI>().text = "FLUID!";
        }
        amountCraftersDisplay[1].GetComponent<TextMeshProUGUI>().text = Math.Ceiling(items / (60 / (timeToCraft * 1.5 / craftOutput))).ToString();
        amountCraftersDisplay[2].GetComponent<TextMeshProUGUI>().text = Math.Ceiling(items / (60 / (timeToCraft * 0.75 / craftOutput))).ToString();
        if (craftOutput % 2 ==0)
        {
            if (items % 2 != 0)
            {
                items += 1;
            }
        }           
        for(int i = 0; i < resourcesNeed.Count; i++)
        {
            amountResourcesDisplay[i].GetComponent<TextMeshProUGUI>().text = Math.Ceiling((items * resourcesNeed[i] / craftOutput)).ToString();
        }
    }

    public void ChemicalCalc()
    {
        itemsInput = inputField.GetComponent<TMP_InputField>().text;
        if (itemsInput == "")
        {
            items = 1;
        } 
        else
        {
            items = float.Parse(itemsInput);
        }
        amountCraftersDisplay[0].GetComponent<TextMeshProUGUI>().text = Math.Ceiling(items / (60 / (timeToCraft / craftOutput))).ToString();
        if (craftOutput % 2 ==0)
        {
            if (items % 2 != 0)
            {
                items += 1;
            }
        }        
        for(int i = 0; i < resourcesNeed.Count; i++)
        {
            amountResourcesDisplay[i].GetComponent<TextMeshProUGUI>().text = Math.Ceiling((items * resourcesNeed[i] / craftOutput)).ToString();
        }        
    }
}
