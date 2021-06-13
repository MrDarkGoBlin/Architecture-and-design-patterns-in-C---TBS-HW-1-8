

namespace TBS
{
    public class MathOfUnits
    {
        
        public int MinusOneStep(int step) 
        {
            var _step = step - 1;
            return _step; 
        }
        public float MinusHP(float hp, float defance, float attak, AttackType typeAttack)
        {
            float value = 0;
            switch (typeAttack)
            {
                case AttackType.Melle:
                    value = hp - (attak * (100 / (defance + 100)));
                    break;
                case AttackType.Magick:
                    value = hp - (attak * (100 / (defance/2 + 100)));
                    break;
                case AttackType.Cure:
                    value = hp + attak;
                    break;
                default:
                    break;
            }
            if (value < 1)
            {
                value = 0;
            }
            return value;
        }

    }
}
