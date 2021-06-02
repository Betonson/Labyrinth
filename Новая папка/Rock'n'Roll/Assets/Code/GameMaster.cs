using UnityEngine;
using UnityEngine.UI;

namespace RockAndRoll
{
    public class GameMaster : UpdatableObject
    {
        private Text _displayBonusText;
        private float _essentialBonusesAmount;
        private void Awake()
        {
            _displayBonusText = GameObject.FindGameObjectWithTag("BonusDisplayText").GetComponent<Text>();
            _essentialBonusesAmount = GameObject.FindGameObjectsWithTag("EssentialBonus").Length;
            _displayBonusText.text = _essentialBonusesAmount.ToString();
        }
        public override void CustomUpdate()
        {
            
        }
    }
}