using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string shipName;
    public string weaponName;

    private int energy = 0;
    private float progress = 0f;

    public Text energyTxt;
    public Text progressTxt;

    void Start()
    {
        energy = 100;
        energyTxt.text = energy.ToString();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (energy == 100)
        {
            progress += Time.fixedDeltaTime * 1.2f;

            progressTxt.text = ((int)progress).ToString();
        }
        else if (energy <= 120 && energy >= 80)
        {
            progress += Time.fixedDeltaTime * 0.4f;

            progressTxt.text = ((int)progress).ToString();
        }
        else if (energy <= 200 && energy >= 0)
        {
            progress += Time.fixedDeltaTime * 0.1f;

            progressTxt.text = ((int)progress).ToString();
        }
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void SetEnergy(int e)
    {
        energy = e;

        energyTxt.text = energy.ToString();
    }
}
