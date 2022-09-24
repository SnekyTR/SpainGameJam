using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    [HideInInspector]
    public int progress;
    private UpgradesMenu upgradesMenu;
    private void Awake()
    {
        upgradesMenu = GameObject.Find("Upgrades").GetComponent<UpgradesMenu>();
        if(System.IO.File.Exists(Application.persistentDataPath + "/progression.data")){
            LoadProgression();
            
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
