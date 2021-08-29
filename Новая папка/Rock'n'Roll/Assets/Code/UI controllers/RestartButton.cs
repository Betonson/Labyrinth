using UnityEngine;
using UnityEngine.UI;

namespace RockAndRoll
{
	public class RestartButton : MonoBehaviour
	{
		private Button _button;
		private SceneSwitcher _sceneSwitcher;
		void Awake()
		{
			_sceneSwitcher = FindObjectOfType<SceneSwitcher>();
			_button = GetComponent<Button>();
			_button.onClick.AddListener(TaskOnClick);
		}

		void TaskOnClick()
		{
			Time.timeScale = 1.0f;
			_sceneSwitcher.RestartLevel();
		}
	}
}