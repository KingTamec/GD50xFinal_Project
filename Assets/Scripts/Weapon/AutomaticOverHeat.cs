using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticOverHeat : MonoBehaviour
{
    public int maxHeat = 100;
    public float coolDownRate = 10f;
    public GameObject overHeatBar;

    private float heat = 0f;
    private ProgressBar heatBar;

    [HideInInspector] public bool overHeated = false;

    
    void Start()
    {
        heatBar = overHeatBar.GetComponent<ProgressBar>();
        heatBar.SetMaxValue(maxHeat);
    }

    public void RaiseHeat(float amount)
    {
        heat += amount;
    }

    void Update()
    {
        if (transform.GetChild(1).gameObject.activeSelf)
        {
            overHeatBar.SetActive(true);
        }
        else
        {
            overHeatBar.SetActive(false);
        }


        heatBar.SetValue(heat);

        if (heat >= maxHeat)
        {
            overHeated = true;
        }
        else if (heat <= 0)
        {
            overHeated = false;
        }


        if (heat > 0 && !overHeated)
        {
            heat -= coolDownRate * Time.deltaTime;
        }
        else if (heat > 0 && overHeated)
        {
            heat -= coolDownRate/2 * Time.deltaTime;
        }
    }
}
