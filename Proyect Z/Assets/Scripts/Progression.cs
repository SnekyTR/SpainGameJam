using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Progression : MonoBehaviour
{
    [HideInInspector]
    public int progress;
    private RealUpgrades upgradesMenu;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (GameObject.Find("Upgrades"))
        {
            upgradesMenu = GameObject.Find("Upgrades").GetComponent<RealUpgrades>();
        }
        
    }
    private void LoadProgression()
    {
        ProgressionData progressionData = SaveSystem.LoadProgression(this);

        progress = progressionData.progression;
        upgradesMenu.GetProgression(progress);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
