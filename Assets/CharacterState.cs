namespace DefaultNamespace
{
    public class CharacterState
    {
        public EnumCharacter EnumCharacter;
        public float Hp;
        public float Pdmg;
        public float Mdmg;
        public float Pdef;
        public float Mdef;
        public EnumSkill EnumSkill;

        public CharacterState(EnumCharacter enumCharacter, float hp, float pdmg, float mdmg,float pdef,float mdef,
            EnumSkill enumSkill)
        {
            EnumCharacter = enumCharacter;
            Hp = hp;
            Pdmg = pdmg;
            Mdmg = mdmg;
            Pdef = pdef;
            Mdef = mdef;
            EnumSkill = enumSkill;
        }
    }
}

