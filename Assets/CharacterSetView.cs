using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetView : MonoBehaviour
{

    [SerializeField] private EnumCharacter _enumCharacter;
    [SerializeField] private InputField _strInputField;
    [SerializeField] private InputField _intInputField;
    [SerializeField] private InputField _constInputField;
    [SerializeField] private Dropdown _skillDropdown;
    
    private void Start()
    {
        _skillDropdown.ClearOptions();
        var dropOptions = new List<string>
        {
            EnumSkill.ThornsAura.ToString(),
            EnumSkill.Vigor.ToString(),
            EnumSkill.Pierce.ToString(),
            EnumSkill.SoulStrike.ToString(),
            EnumSkill.Enfeeble.ToString(),
            EnumSkill.Curse.ToString(),
            EnumSkill.Enrage.ToString(),
            EnumSkill.ArcaneSoul.ToString()
        };
		
        _skillDropdown.AddOptions(dropOptions);
    }

    public void SetDefault()
    {
        switch (_enumCharacter)
        {
            case EnumCharacter.Warrior:
                _strInputField.text = "3";
                _intInputField.text = "1";
                _constInputField.text = "8";
                _skillDropdown.value = 1;
                break;
            case EnumCharacter.Wizard:
                _strInputField.text = "1";
                _intInputField.text = "8";
                _constInputField.text = "3";
                _skillDropdown.value = 7;
                break;
            case EnumCharacter.Assasin:
                _strInputField.text = "8";
                _intInputField.text = "1";
                _constInputField.text = "3";
                _skillDropdown.value = 2;
                break;
            case EnumCharacter.Archer:
                _strInputField.text = "4";
                _intInputField.text = "4";
                _constInputField.text = "3";
                _skillDropdown.value = 6;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void CreateCharacter()
    {
        var str = 0f;
        float.TryParse(_strInputField.text,out str) ;
        var inte = 0f;
        float.TryParse(_intInputField.text,out inte) ;
        var cons = 0f;
        float.TryParse(_constInputField.text,out cons) ;
        
        var hPFromCons = StatsManager.GetHPFromCons(cons);
        var pdefFromCons= StatsManager.GetPdefFromCons(cons);
        var pdefFromStr= StatsManager.GetPdefFromStr(str);
        var pdmgFromStr= StatsManager.GetPdmgFromStr(str);
        var mdmgFromInte= StatsManager.GetMdmgFromInte(inte);
        var mdefFromInte= StatsManager.GetMdefFromInte(inte);
		
        var character = new CharacterState(_enumCharacter, hPFromCons, pdmgFromStr, mdmgFromInte, pdefFromCons + pdefFromStr, mdefFromInte, (EnumSkill)_skillDropdown.value);
        GameManager.AddCharacter(character);
    }
	
    
    
}