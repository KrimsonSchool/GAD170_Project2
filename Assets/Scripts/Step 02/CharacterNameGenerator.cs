using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions to complete:
/// - Create Names
/// - Set Individual Name
/// - Set Team Character Names
/// </summary>
public class CharacterNameGenerator : MonoBehaviour
{
 
    [Header("Possible first names")]
    private List<string> firstNames = new List<string>(); // a list of all possible first names for us to use.
    [Header("Possible last names")]
    private List<string> lastNames = new List<string>(); // a list of all possible last names for us to use.
    [Header("Possible nicknames")]
    private List<string> nicknames = new List<string>(); // a list of all possible nick names for us to use.


    private void Awake()
    {
        // call the create names function
        CreateNames();
    }

    /// <summary>
    /// Creates a list of names for all our characters to potentiall use.
    /// Step 02: Called when we press play.
    /// Step 03: Called when we press play.
    /// </summary>
    public void CreateNames()
    {
        // So here we would ideally want to be able to add some names to our first names, last names and nick names lists.

    }

    /// <summary>
    /// set a characters name to a random name
    /// Step 02: Called when we press the test step 02 button and sets each dancer to have a name.
    /// </summary>
    /// <param name="character"></param>
    public void SetIndividualCharacter(CharacterName character)
    {
        // So here rather than each character being called Blanky Blank Blank, we probably want it to be a random first,last and nickname

    }

    /// <summary>
    /// Same as an individual...but this time it's more than one dancer.
    /// Step 03: Called from the Spawn function.
    /// </summary>
    /// <param name="namesNeeded"></param>
    /// <returns></returns>
    public void SetTeamCharacterNames(List<CharacterName> teamCharacters)
    {
        // so here we have a list of character names coming in.
        // we should probably loop over that list of charcter names, and then for each chacter set thei first, last and nickname a random one from our lists
        // if you want to get fancy you could use another function within this script to help out here.

    }
}