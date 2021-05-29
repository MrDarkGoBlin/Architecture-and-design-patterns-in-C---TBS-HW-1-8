using UnityEngine;
using UnityEngine.UI;

namespace TBS
{
    public class ListenerHitShowDamage
    {
        private Text _outputText;
        public ListenerHitShowDamage()
        {
            viewHit gameObject = Object.FindObjectOfType<viewHit>();
            _outputText = gameObject.GetText();

        }
        public void Add(IHit value)
        {
            value.OnHitChange += ValueOnOnHitChange;
        }

        public void Remove(IHit value)
        {
            value.OnHitChange -= ValueOnOnHitChange;
        }

        private void ValueOnOnHitChange(float damage)
        {
            _outputText.text = $"{damage} HP";
            Debug.Log(damage);
        }

    }
}
