using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CharacterBattleView: MonoBehaviour
    {
        [SerializeField] private Dropdown _characterDropdown;
        [SerializeField] private Text _hpText;

        private void Awake()
        {
            _characterDropdown.onValueChanged.AddListener(OnCharacterDropdownValueChanged);
        }

        private void OnCharacterDropdownValueChanged(int characterValue)
        {
            var enumCharacter = (EnumCharacter) characterValue;
            var character = GameManager.GetCharacter(enumCharacter);

            _hpText.text = character.Hp.ToString();
        }

        private void Start()
        {
            _characterDropdown.ClearOptions();
            var dropOptions = new List<string>
            {
                EnumCharacter.Warrior.ToString(),
                EnumCharacter.Wizard.ToString(),
                EnumCharacter.Assasin.ToString(),
                EnumCharacter.Archer.ToString()
            };
		
            _characterDropdown.AddOptions(dropOptions);
            OnCharacterDropdownValueChanged(0);
        }
    }
}