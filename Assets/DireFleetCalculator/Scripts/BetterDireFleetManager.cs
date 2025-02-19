using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DireFleetCalc
{
    public class BetterDireFleetManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField lifeInput;
        [SerializeField] private TMP_InputField triggersInput;

        [SerializeField] private TMP_Text outputDisplay;
        
        private string inputString;

        void Start()
        {
            ClearInput();
        }

        public void ClearInput()
        {
            lifeInput.text = "40";
            triggersInput.text = "3";
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
            float life = 0;
            float.TryParse(lifeInput.text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out life);

            float triggers = 0;
            float.TryParse(triggersInput.text, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out triggers);

            for(int i = 0; i < triggers; i++)
            {
                if(life == 0)
                    break;

                life = Mathf.Floor(life * 2 / 3);
            }
            outputDisplay.text = life + "";
        }
    }
}