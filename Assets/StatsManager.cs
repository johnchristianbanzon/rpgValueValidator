namespace DefaultNamespace
{
    public static class StatsManager
    {
        
        public static float GetHPFromCons(float cons)
        {
            var hp = cons * 3f;
            return hp;
        }
        
        public static float GetPdefFromCons(float cons)
        {
            var pdef = cons * 1f;
            return pdef;
        }
        
        public static float GetPdmgFromStr(float str)
        {
            var pdmg = str * 2f;
            return pdmg;
        }
        
        public static float GetPdefFromStr(float str)
        {
            var pdef = str * 0.5f;
            return pdef;
        }
        
        public static float GetMdmgFromInte(float inte)
        {
            var mdmg = inte * 3f;
            return mdmg;
        }
        
        public static float GetMdefFromInte(float inte)
        {
            var mdef = inte * 1f;
            return mdef;
        }
    }
}