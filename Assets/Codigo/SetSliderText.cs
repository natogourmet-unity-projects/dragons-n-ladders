using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSliderText : MonoBehaviour {
    public Slider slider;
    public string campo;
    public string extra;

    private void Start()
    {
        GetComponent<Text>().text = campo + "     " + slider.minValue + extra;
    }

    public void CambiarTexto()
    {
        GetComponent<Text>().text = campo + "     " + slider.value + extra;
    }
}
