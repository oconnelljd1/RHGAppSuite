using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DireFleetCalc
{
    public class DireFleetManager : MonoBehaviour
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
            float value = 0;
            float.TryParse(inputDisplay.text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out value);

            for(int i = 0; i < 4; i++)
            {
                if(value == 0)
                    break;

                value = Mathf.Floor(value * 2 / 3);
            }
            outputDisplay.text = value + "";
        }
    }
}