using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class LevelSystem : MonoBehaviour
{
    StatSystem stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<StatSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void testLevelSystem()
    {
        stats.xp += 25;

        if (stats.xp >= stats.xpThreshold)
        {
            stats.level += 1;
            stats.xp -= stats.xpThreshold;
            stats.xpThreshold = Mathf.RoundToInt(stats.xpThreshold * 1.2f);

            stats.statTotal += 5;

            stats.testStatSystem();
        }
    }
}
