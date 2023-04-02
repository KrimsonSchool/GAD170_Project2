using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Functions to complete:
/// - DecideWinner
/// </summary>
public class FightManager : MonoBehaviour
{
    public Color drawCol = Color.gray; // A colour you might want to set the battle log message to if it's a draw.
    public GameObject[] Characters;

    public float chances;
    public float chancesT;

    public TMPro.TextMeshProUGUI winChanceText;
    public Character tA;
    public Character tB;
    public float[] winChances;

    public TMPro.TextMeshPro winnerText;
    public string winner;
    public void Start()
    {
        if (FindObjectOfType<CharacterNameGenerator>() != null)
        {
            Characters = FindObjectOfType<CharacterNameGenerator>().Characters;
        }
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tA.l.SetActive(false);
            tB.l.SetActive(false);
            TestImplementation();
        }
        if (tA == null)
        {
            tA = GetComponent<DanceTeamInit>().teamA.allDancers[Random.Range(0, 3)].GetComponent<Character>();
        }
        if(tB== null)
        {
            tB = GetComponent<DanceTeamInit>().teamB.allDancers[Random.Range(0, 3)].GetComponent<Character>();
        }

        if(GetComponent<DanceTeamInit>().teamA.allDancers[0] == null && GetComponent<DanceTeamInit>().teamA.allDancers[1] == null && GetComponent<DanceTeamInit>().teamA.allDancers[2] == null)
        {
            winner = "Team A Wins!!!";
            winnerText.enabled = true;
            winnerText.text = winner;
        }
        else if (GetComponent<DanceTeamInit>().teamB.allDancers[0] == null && GetComponent<DanceTeamInit>().teamB.allDancers[1] == null && GetComponent<DanceTeamInit>().teamB.allDancers[2] == null)
        {
            winner = "Team B Wins!!!";
            winnerText.enabled = true;
            winnerText.text = winner;
        }
    }

    public void SimFight()
    {
        for (int i = 0; i < Characters.Length; i++)
        {
            chancesT += Characters[i].GetComponent<PowerSystem>().powerLevel;
        }

        for (int i = 0; i < Characters.Length; i++)
        {

            chances = 100 / chancesT * Characters[i].GetComponent<PowerSystem>().powerLevel;

            print("Player " + i + " chances of winning = " + chances + "%");

            winChances[i] = chances;
        }
        chances = 0;
        chancesT = 0;
        //print(chances);

        winChanceText.text = "Win Chances: " + winChances[0] + "% VS " + winChances[1] +"%";

        if (winChances[0] > winChances[1])
        {
            Characters[1].GetComponent<HealthSystem>().Health -= 0.1f;
            Characters[0].GetComponent<StatSystem>().xp += 25; 
            print(Characters[0].name);
        }
        else if(winChances[1] > winChances[0])
        {
            Characters[0].GetComponent<HealthSystem>().Health -= 0.1f;
            Characters[1].GetComponent<StatSystem>().xp += 25;
            print(Characters[1].name);
        }
    }

    /// <summary>
    /// This function takes in two characters and we need to decide who wins the fight.
    /// Step 02: Called when the test step 02 button is pressed and passes in the two dancers from the test implementation function.
    /// Step 03: Called from the BattleSystem once it selects two random characters.
    /// </summary>


    #region No Modifications Required.

    public void Fight(Character teamACharacter, Character teamBCharacter)
    {
        if(teamACharacter.GetComponent<PowerSystem>().powerLevel > teamBCharacter.GetComponent<PowerSystem>().powerLevel)
        {
            teamACharacter.GetComponent<StatSystem>().xp += 25;
            teamBCharacter.GetComponent<HealthSystem>().Health -= 0.1f;
        }
        else if(teamBCharacter.GetComponent<PowerSystem>().powerLevel > teamACharacter.GetComponent<PowerSystem>().powerLevel)
        {
            teamBCharacter.GetComponent<StatSystem>().xp += 25;
            teamACharacter.GetComponent<HealthSystem>().Health -= 0.1f;
        }
    }

    public void TestImplementation()
    {
        tA = GetComponent<DanceTeamInit>().teamA.allDancers[Random.Range(0, GetComponent<DanceTeamInit>().teamA.allDancers.Count)].GetComponent<Character>();
        tB = GetComponent<DanceTeamInit>().teamB.allDancers[Random.Range(0, GetComponent<DanceTeamInit>().teamB.allDancers.Count)].GetComponent<Character>();

        tA.l.SetActive(true);
        tB.l.SetActive(true);

        Fight(tA, tB);
    }

     #endregion  
}
