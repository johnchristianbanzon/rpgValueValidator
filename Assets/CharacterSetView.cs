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


    public void CreateCharacter()
    {
        var str =float.Parse(_strInputField.text) ;
        var inte =float.Parse(_intInputField.text) ;
        var cons =float.Parse(_constInputField.text) ;
        
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