using UnityEngine;
using UnityEngine.UI;


namespace TBS
{
    public class UIOutputNumbersInterpritator : MonoBehaviour
    {
        private NumbersInterpritator _numbersInterpritator;
        [SerializeField] private Text _outputText;
        void Start()
        {
            _numbersInterpritator = new NumbersInterpritator(10000000000);
        }

        void Update()
        {
            _outputText.text = _numbersInterpritator.InterpritatoNumbers();
        }
    }
}
