using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// - Initial Stats
/// - Return Battle Points
/// - Deal Damage
/// </summary>
public class Character : MonoBehaviour
{
    public StatSystem StatSystem;
    public LevelSystem LevelSystem;
    public PowerSystem PowerSystem;
    public HealthSystem HealthSystem;
    public DanceTeam myTeam; // This holds a reference to the characters current dance team instance they are assigned to.
    public int team;
    public int loc;
    [HideInInspector] public bool isSelected; // This is used for determining if this character is selected in a battle.
    [HideInInspector] public AnimationController animController; // A reference to the animationController, is used to switch dancing states.

    public GameObject l;

    // This is called once, this then calls Initial Stats function
    void Start()
    {
        animController = GetComponent<AnimationController>();
        StatSystem.initialiseStatSystem();
        StatSystem.testStatSystem();
        LevelSystem.testLevelSystem();
        PowerSystem.testPowerSystem();
    }

    public void Update()
    {
        //print(GameObject.Find("TeamA").GetComponent<DanceTeam>().allDancers[loc]);
        //print(GameObject.Find("TeamB").GetComponent<DanceTeam>().allDancers[loc]);
        if (GetComponent<HealthSystem>().Health <= 0)
        {
            RemoveFromTeam();
        }
    }
    public void RemoveFromTeam()
    {
        if(team == 0)
        {
            GameObject.Find("TeamA").GetComponent<DanceTeam>().allDancers.Remove(this);
        }
        else
        {
            GameObject.Find("TeamB").GetComponent<DanceTeam>().allDancers.Remove(this);
        }

        Destroy(gameObject);
    }

}
