using System.Collections.Generic;
using System.Linq;

namespace DefaultNamespace
{
    public static class GameManager
    {
        private static List<CharacterState> _characters = new List<CharacterState>();

        public static void ClearCharacters()
        {
            _characters.Clear();
        }
        
        public static void AddCharacter(CharacterState character)
        {
            _characters.Add(character);
        }

        public static CharacterState GetCharacter(EnumCharacter enumCharacter)
        {
            return _characters.First(character => character.EnumCharacter == enumCharacter);
        }

        public static void AttackCharacter(CharacterBattleView attackerView, CharacterBattleView targetView)
        {
            targetView.ReceiveDamage(attackerView.GetAttackDamage());
        }
    }
}