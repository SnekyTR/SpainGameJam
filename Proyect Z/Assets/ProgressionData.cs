 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ProgressionData
{
    public int progression;

    public ProgressionData(Progression pro)
    {
        progression = pro.progress;
    }
}
