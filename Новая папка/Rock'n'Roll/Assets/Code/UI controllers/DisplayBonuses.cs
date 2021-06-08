using UnityEngine;
using UnityEngine.UI;

namespace RockAndRoll
{
    public class DisplayBonuses
    {
        private Text _text;
        public DisplayBonuses()
        {
            _text = GameObject.Find("BonusDisplayText").GetComponent<Text>();
        }
        public void Display(int value)
        {
            //Debug.Log($"Вы набрали {value}");
            _text.text = $"Points: {value}";
        }
    }
}