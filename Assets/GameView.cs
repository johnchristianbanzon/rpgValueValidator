using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour 
{

	// Use this for initialization
	[SerializeField] private Button _startButton;
	[SerializeField] private GameObject _characterSetGroup;
	[SerializeField] private GameObject _characterBattleGroup;
	
	[SerializeField] private CharacterSetView[] _characterSetViews;

	private void Awake()
	{
		_startButton.onClick.AddListener(OnClickStartButton);
		_characterSetGroup.SetActive(true);
		_characterBattleGroup.SetActive(false);
	}
	
	private void OnClickStartButton()
	{
		GameManager.ClearCharacters();

		foreach (var characterSetView in _characterSetViews)
		{
			characterSetView.CreateCharacter();
		}
		
		_characterSetGroup.SetActive(false);
		_characterBattleGroup.SetActive(true);
	}

}
