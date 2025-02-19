using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PoolFloaties
{
    public class FloatiesController : MonoBehaviour
    {
        [SerializeField] private GameObject _blackout;
        [SerializeField] private List<ColorTracker> _colors;
        [SerializeField] private List<Toggle> _toggles;

        private void Start() {
            Screen.sleepTimeout  = SleepTimeout.NeverSleep;
            Screen.orientation = ScreenOrientation.Portrait;
            
            _blackout.SetActive(false);
        }

        public void UpdateColors()
        {
            Debug.Log($"<color=orange>Update Colors</color>");
            for(int i = 0; i < _toggles.Count; i++)
            {
                _colors[i].gameObject.SetActive(_toggles[i].isOn);
            }
        }

        public void ToggleBlackout()
        {
            _blackout.SetActive(!_blackout.activeInHierarchy);
        }

        public void Reset()
        {
            foreach(var toggle in _toggles)
            {
                toggle.isOn = true;
            }
            foreach (var color in _colors)
            {
                color.Reset();
            }
        }
    }
}