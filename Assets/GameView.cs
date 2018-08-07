using System.Collections.Generic;
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
	[SerializeField] private CharacterBattleView[] _characterBattleViews;
	
	private void Awake()
	{
		_startButton.onClick.AddListener(OnClickStartButton);
		_characterSetGroup.SetActive(true);
		_characterBattleGroup.SetActive(false);
		SetCharacterTargets();
	}

	private void SetCharacterTargets()
	{
		for (var i = 0; i < _characterBattleViews.Length; i++)
		{
			var characters = new List<CharacterBattleView>();
			for (var j = 0; j < _characterBattleViews.Length; j++)
			{
				if (i != j)
				{
					characters.Add(_characterBattleViews[j]);
				}
			}
			_characterBattleViews[i].SetCharaterTarget(characters);
		}
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

	public void OnClickDefault()
	{
		foreach (var characterSetView in _characterSetViews)
		{
			characterSetView.SetDefault();
		}
	}
}
