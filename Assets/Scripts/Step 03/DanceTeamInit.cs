using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Functions to complete:
/// - Init Teams
/// </summary>
public class DanceTeamInit : MonoBehaviour
{
    public DanceTeam teamA, teamB; // A reference to our teamA and teamB DanceTeam instances.

    public GameObject dancerPrefab; // This is the dancer that gets spawned in for each team.

    /// <summary>
    /// Called to iniatlise the dance teams with some dancers :D
    /// Step 03: called when we press the play button.
    /// </summary>
    public void InitTeams()
    {
        // So for each team we have, we want to call two functions, one is SetTroupName and we need to pass in a team name; the other is SpawnTeam and need to pass in the dancer prefab
        for (int i = 0; i < teamA.characterSpawnPoints.Count; i++)
        {
            teamA.allDancers[i]=Instantiate(dancerPrefab, teamA.characterSpawnPoints[i]).GetComponent<Character>();
            teamB.allDancers[i] = Instantiate(dancerPrefab, teamB.characterSpawnPoints[i]).GetComponent<Character>();
            teamA.allDancers[i].myTeam = teamA;
            teamA.allDancers[i].team = 0;
            teamB.allDancers[i].myTeam = teamB;
            teamB.allDancers[i].team = 1;
        }

        for (int i = 0; i < 3; i++)
        {
            teamA.allDancers[i].loc = i;
            teamB.allDancers[i].loc = i;
        }

        GetComponent<CharacterNameGenerator>().FindSet();
    }

}
