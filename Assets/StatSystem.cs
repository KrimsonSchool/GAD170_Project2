using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditorInternal;
using UnityEngine.UI;

public class StatSystem : MonoBehaviour
{
    public int level;
    public int xp;
    public int xpThreshold;
    public int strength, agility, intelligence;
    public int statTotal;

    public float rythm, style, luck;

    public TMPro.TextMeshProUGUI outputText;
    public TMPro.TextMeshProUGUI sliderText;
    public TMPro.TextMeshProUGUI slider2Text;

    public Slider aLSlider;
    public Slider tmrSlider;

    bool autolevel;

    bool error;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        statTotal = 15;
        xpThreshold = 100;


    }

    // Update is called once per frame
    void Update()
    {
        if(outputText!=null && sliderText != null && slider2Text != null && aLSlider != null && tmrSlider != null)
        {
            outputText.text = "Level: " + level + "\n Xp: " + xp + "/" + xpThreshold + "\n Stats: \n Strength: " + strength + "\n Agility: " + agility + "\n Intelligence: " + intelligence + "\n \n R.S.L.: \n Rythm: " + rythm + "\n Style: " + style + "\n Luck: " + luck + "\n \n Power Level: " + GetComponent<PowerSystem>().powerLevel;

            sliderText.text = "Xp per " + tmrSlider.value + " second(s): " + aLSlider.value + "/" + aLSlider.maxValue;
            slider2Text.text = "Xp every " + tmrSlider.value + " second(s)";
            if (autolevel)
            {
                timer += Time.deltaTime;

                //print(timer);

                if (timer >= tmrSlider.value)
                {
                    xp += Mathf.RoundToInt(aLSlider.value);
                    timer = 0;
                }
            }
        }
        else
        {
            //error = true;
            if (error)
            {
                GameObject cnv = new GameObject();
                cnv.AddComponent<Canvas>();
                cnv.AddComponent<CanvasScaler>();
                cnv.AddComponent<GraphicRaycaster>();
                cnv.name = "ERROR CANVAS";

                cnv.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                cnv.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

                GameObject txt = new GameObject();
                txt.AddComponent<CanvasRenderer>();
                txt.AddComponent<TextMeshProUGUI>();

                txt.transform.SetParent(cnv.transform);

                txt.GetComponent<TMPro.TextMeshProUGUI>().text = "ERROR";
                txt.GetComponent<TMPro.TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector2(0, 0);
                //TMPro.TextMeshProUGUI txt = Instantiate(new TMPro.TextMeshProUGUI(), cnv.transform.position, Quaternion.identity);

                //txt.text = "ERROR!";

                error = false;
            }
        }
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

        rythm = Mathf.Round(1.2f * strength);
        style = Mathf.Round(2.2f * agility);
        luck = Mathf.Round(0.6f * intelligence);
    }

    public void autoLeveler()
    {
        if (autolevel)
        {
            autolevel = false;
        }
        else
        {
            autolevel = true;
        }
    }
}
