

namespace TBS
{
    class MathOfUnits
    {
        internal int MinusOneStep(int step) 
        {
            var _step = step - 1;
            return _step; 
        }
        internal float MinusHP(float hp, float defance, float attak, string typeAttack)
        {
            float value = 0;
            switch (typeAttack)
            {
                case "Melee":
                    value = hp - (attak * (100 / (defance + 100)));
                    break;
                case "Magic":
                    value = hp - (attak * (100 / (defance/2 + 100)));
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
