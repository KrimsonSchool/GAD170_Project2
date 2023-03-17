using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystem : MonoBehaviour
{
    public int level;
    public int xp;
    public int xpThreshold;
    public int strength, agility, intelligence;
    public int statTotal;

    public float rythm, style, luck;
    // Start is called before the first frame update
    void Start()
    {
        statTotal = 15;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initialiseStatSystem()
    {
        level = 1;
        xp = 0;
        xpThreshold = level * 100;
    }

    public void testStatSystem()
    {
        for (int i = 0; i < statTotal; i++)
        {
            int rng = Random.Range(0, 3);

            if(rng == 0)
            {
                strength += 1;
            }
            else if(rng == 1)
            {
                agility += 1;
            }
            else
            {
                intelligence += 1;
            }
        }
        statTotal = 0;

        rythm = 1.2f * strength;
        style = 2.2f * agility;
        luck = 0.6f * intelligence;
    }
}
