using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Color : MonoBehaviour
{
    [SerializeField] private TMP_Text _display;
    [SerializeField] private GameObject _minusButton;
    private int count;
    
    void Start()
    {
        Reset();
    }
    
    public void Increase()
    {
        _minusButton.SetActive(true);
        count++;
        UpdateDisplay();
    }

    public void Decrease()
    {
        count--;
        if(count == 0)
        {
            _minusButton.SetActive(false);
        }
        UpdateDisplay();
    }

    public void Reset()
    {
        count = 0;
        _minusButton.SetActive(false);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _display.text = count + "";
    }
}
