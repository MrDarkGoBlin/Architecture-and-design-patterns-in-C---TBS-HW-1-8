using System;
namespace TBS
{

    public class NumbersInterpritator
    {
        private Random _random;
        private readonly decimal _startNumber;
        private decimal _number;
        private string _outputNumber;
        public NumbersInterpritator(decimal startNumber)
        {
            _startNumber = startNumber;
            _number = _startNumber;
            _random = new Random();
        }
        public string InterpritatoNumbers()
        {
            _number = _number - (_random.Next(1,40) / 3);
            if (_number <= 0)
            {
                _number = _startNumber;                
            }
            if (_number >= 1000000000)  _outputNumber = $"{Decimal.Round(_number / 1000000000)} Мил-ард"; 
            else if (_number >= 1000000)  _outputNumber = $"{Decimal.Round(_number / 1000000)} мил-он";
            else if (_number >= 1000)  _outputNumber = $"{Decimal.Round(_number / 1000)} т";
            else if (_number >= 100)  _outputNumber = $"{Decimal.Round(_number / 100)} с";
            else if (_number >= 10)  _outputNumber = $"{Decimal.Round(_number / 10)} д";
            else if (_number >= 1)  _outputNumber = $"{Decimal.Round(_number)} ед";
            return _outputNumber;
        }
    }
}
