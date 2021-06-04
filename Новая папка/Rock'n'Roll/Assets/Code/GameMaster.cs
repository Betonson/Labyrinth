using UnityEngine;
using UnityEngine.UI;

namespace RockAndRoll
{
    public class GameMaster : UpdatableObject
    {
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private GameObject _VictoryScreen;
        [SerializeField] private Text _displayBonusText;
        private float _essentialBonusesAmount;
        private void Awake()
        {
            _essentialBonusesAmount = GameObject.FindGameObjectsWithTag("EssentialBonus").Length;
            _displayBonusText.text = _essentialBonusesAmount.ToString();
        }
        public override void CustomUpdate()
        {
            
        }
    }
}