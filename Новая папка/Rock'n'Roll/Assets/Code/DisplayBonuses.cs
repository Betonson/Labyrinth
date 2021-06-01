using UnityEngine;
using UnityEngine.UI;

namespace RockAndRoll
{
    public class DisplayBonuses
    {
        private GameObject _bonusDisplayText;
        private Text _text;
        public DisplayBonuses()
        {
            _bonusDisplayText = GameObject.FindGameObjectWithTag("BonusDisplayText");
            _text = _bonusDisplayText.GetComponent<Text>();
        }
        public void Display(int value)
        {
            //Debug.Log($"Вы набрали {value}");
            _text.text = $"Points: {value}";
        }
    }
}