using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeatherManager : MonoBehaviour
{
    [SerializeField] private TMP_Text inputDisplay;
    [SerializeField] private TMP_Text outputDisplay;
    
    private string inputString;

    void Start()
    {
        ClearInput();
    }

    public void AddDigit(string digit)
    {
        if(inputDisplay.text == "0")
        {
            inputDisplay.text = digit;
        }
        else
        {
            inputDisplay.text = inputDisplay.text + digit;
        }
        UpdateDisplay();
    }

    public void ClearInput()
    {
        inputDisplay.text = "0";
        UpdateDisplay();
    }

    public void ClearLastDigit()
    {
        inputDisplay.text = inputDisplay.text.Remove(inputDisplay.text.Length - 1);
        if(inputDisplay.text == "")
        {
            inputDisplay.text = "0";
        }
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        int iValue = 0;
        int fValue = 0;
        int.TryParse(inputDisplay.text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out iValue);

        while(iValue > 0)
        {
            fValue += iValue;
            iValue--;
        }
        outputDisplay.text = fValue + "";
    }
}
