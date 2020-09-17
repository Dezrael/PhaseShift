using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    private Text energyText;

    private void Awake()
    {
        energyText = GetComponent<Text>();
    }

    public void SetEnergy(float energy)
    {
        energyText.text = string.Format("Energy: {0}", energy);
    }
}
