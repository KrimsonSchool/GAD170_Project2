using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Playables;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.MessageBox;

public class PowerSystem : MonoBehaviour
{
    public float powerLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void testPowerSystem()
    {
        powerLevel = 2.2f * GetComponent<StatSystem>().strength + 1.8f * GetComponent<StatSystem>().agility + 1.6f * GetComponent<StatSystem>().intelligence;
    }
}
