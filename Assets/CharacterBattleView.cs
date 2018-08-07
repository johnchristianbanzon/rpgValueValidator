using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CharacterBattleView: MonoBehaviour
    {
        [SerializeField] private Text _hpText;
        [SerializeField] private Text _physDamageText;
        [SerializeField] private Text _physDefText;
        [SerializeField] private Text _magicDamageText;
        [SerializeField] private Text _magicDefText;
        [SerializeField] private Text _skillType;
        [SerializeField] private Text _winRate;
        [SerializeField] private EnumCharacter characterValue;
        public CharacterState CurrentCharacterState = new CharacterState();
        private CharacterState character;
        private List<CharacterBattleView> _charaterTargets;
        private int numberOfWins = 0;
        private int numberOfBattles = 0;
        private int targetCounter = 0;
        public bool IsDead = false;
        private void Awake()
        {
            character = GameManager.GetCharacter(characterValue);
            //
            CurrentCharacterState.EnumCharacter = character.EnumCharacter;
            CurrentCharacterState.EnumSkill = character.EnumSkill;
            CurrentCharacterState.Hp = character.Hp;
            CurrentCharacterState.Pdmg = character.Pdmg;
            CurrentCharacterState.Pdef = character.Pdef;
            CurrentCharacterState.Mdmg = character.Mdmg;
            CurrentCharacterState.Mdef = character.Mdef;
            _winRate.text = "0%";
            //
            _hpText.text = character.Hp.ToString();
            _physDamageText.text = character.Pdmg.ToString();
            _physDefText.text = character.Pdef.ToString();
            _magicDamageText.text = character.Mdmg.ToString();
            _magicDefText.text = character.Mdef.ToString();
            _skillType.text = character.EnumSkill.ToString();
            CallibrateSkillBonus();
        }

        private void CallibrateSkillBonus()
        {
            switch (character.EnumSkill)
            {
                case EnumSkill.ThornsAura:
                    break;
                case EnumSkill.Vigor:
                    break;
                case EnumSkill.Pierce:
                    break;
                case EnumSkill.SoulStrike:
                    break;
                case EnumSkill.Enfeeble:
                    break;
                case EnumSkill.Curse:
                    break;
                case EnumSkill.Enrage:
                    _physDamageText.text += "(+ " + character.Pdmg * 0.3f + ")";
                    break;
                case EnumSkill.ArcaneSoul:
                    _magicDamageText.text += "(+ " + character.Mdmg * 0.3f + ")";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        
        public void SetCharaterTarget(List<CharacterBattleView> characterTargets)
        {
            for (var i = 0; i < characterTargets.Count; i++)
            {
                Debug.Log(characterTargets[i].characterValue);
            }
            _charaterTargets = characterTargets;
        }

        private bool selfAttackTurn = true;
        public void AttackCharacter()
        {
            if (IsDead)
            {
                return;
            }
            
            if (selfAttackTurn == false)
            {
                GameManager.AttackCharacter(_charaterTargets[targetCounter],this);
                selfAttackTurn = true;
                return;
            }

            selfAttackTurn = false;
            GameManager.AttackCharacter(this,_charaterTargets[targetCounter]);
            if (_charaterTargets[targetCounter].IsDead)
            {
                Reset();
                if (numberOfWins < 2)
                {
                    
                    targetCounter++;
                    selfAttackTurn = true;
                    numberOfBattles++;
                    numberOfWins++;
                    _winRate.text = ((numberOfWins / numberOfBattles) * 100).ToString();
                    Debug.Log(numberOfWins);
                }
                else
                {
                    for (var i = 0; i < _charaterTargets.Count; i++)
                    {
                        _charaterTargets[i].Reset();
                    }
                }
            }
        }

        public void Reset()
        {
            CurrentCharacterState.EnumCharacter = character.EnumCharacter;
            CurrentCharacterState.EnumSkill = character.EnumSkill;
            CurrentCharacterState.Hp = character.Hp;
            CurrentCharacterState.Pdmg = character.Pdmg;
            CurrentCharacterState.Pdef = character.Pdef;
            CurrentCharacterState.Mdmg = character.Mdmg;
            CurrentCharacterState.Mdef = character.Mdef;
            
            _hpText.text = character.Hp.ToString();
            _physDamageText.text = character.Pdmg.ToString();
            _physDefText.text = character.Pdef.ToString();
            _magicDamageText.text = character.Mdmg.ToString();
            _magicDefText.text = character.Mdef.ToString();
            _skillType.text = character.EnumSkill.ToString();
        }

        public float GetAttackDamage()
        {
            if (CurrentCharacterState.EnumCharacter == EnumCharacter.Wizard)
            {
                return CurrentCharacterState.Mdmg;
            }

            return CurrentCharacterState.Pdmg;
        }

        public void ReceiveDamage(float damage)
        {
            CurrentCharacterState.Hp = CurrentCharacterState.Hp - damage;
            if (CurrentCharacterState.Hp <= 0)
            {
                CurrentCharacterState.Hp = 0;
                numberOfBattles++;
            }
            _hpText.text = CurrentCharacterState.Hp.ToString();
            IsDead = CurrentCharacterState.Hp <= 0;
        }
    }
}