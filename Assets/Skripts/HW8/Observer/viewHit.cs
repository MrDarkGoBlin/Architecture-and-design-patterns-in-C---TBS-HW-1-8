using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class viewHit : MonoBehaviour
{
    private Text _outputText;
    void Start()
    {
        _outputText = gameObject.GetComponent<Text>();
    }

    public Text GetText()
    {
        return _outputText;
    }
}
