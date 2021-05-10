

namespace TBS

{
    class MathOfUnits
    {
        internal int MinusOneStep(int step) 
        {
            var _step = step - 1;
            return _step; 
        }
        internal float MinusHP(float hp, float defance, float attak)
        {
            var value = hp - (attak * (100 / (defance + 100)));
            if (value < 1)
            {
                value = 0;
            }
            return value;
        }
    }
}
