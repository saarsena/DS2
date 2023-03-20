using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UnityEngine.UIElements.Button spnBtn, spnBtn2, atkBtnR, atkBtnL, lStats, lFight;
    public UIDocument theDoc;
    public Enemy[] enemyR, enemyL;
    Enemy spawnedEnemyR, spawnedEnemyL;
    DropdownField menuSelect, menuSelect2;
    TextMeshProUGUI tHealth, tMana, tarmorValue, tattackValue, tStrength, tDexterity, tConsitution, tIntelligence, tWisdom;
    Label healthR, healthL, hLR;


    List<string> choices = new List<string> { "Abomination", "Archer", "Bat", "Bear", "Blob",
            "Camel", "Centaur", "Centipede","Crab", "Cricket", "Cultist", "Devil", "Djinn",
            "Donkey", "Eyeball", "Fighter", "Gascloud", "Horse", "Lich", "Lizard", "Lizardman",
            "Lizardninja", "Monkey", "Mosquitoman", "Mule", "Pegasus", "Rat", "Shade",
            "Skeleton", "Snake", "Snakeman", "Unicorn", "Wolf" };

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        spnBtn = theDoc.rootVisualElement.Q("SpawnButton") as UnityEngine.UIElements.Button;
        spnBtn2 = theDoc.rootVisualElement.Q("SpawnButton2") as UnityEngine.UIElements.Button;
        atkBtnL = theDoc.rootVisualElement.Q("AttackL") as UnityEngine.UIElements.Button;
        atkBtnR = theDoc.rootVisualElement.Q("AttackR") as UnityEngine.UIElements.Button;
        lStats = theDoc.rootVisualElement.Q("LoadStats") as UnityEngine.UIElements.Button;
        lFight = theDoc.rootVisualElement.Q("LoadFight") as UnityEngine.UIElements.Button;
        menuSelect = theDoc.rootVisualElement.Q("MenuSelect") as DropdownField;
        menuSelect2 = theDoc.rootVisualElement.Q("MenuSelect2") as DropdownField;
        healthL = theDoc.rootVisualElement.Q("HealthL") as Label;
        healthR = theDoc.rootVisualElement.Q("HealthR") as Label;
        hLR = theDoc.rootVisualElement.Q("HealthLabelRight") as Label;

        Debug.Log(currentScene.name);

        if (currentScene.name == "Stats")
        {
            menuSelect2.SetEnabled(false);
            menuSelect2.visible = false;
            spnBtn2.SetEnabled(false);
            spnBtn2.visible= false;
            atkBtnR.SetEnabled(false);
            atkBtnR.visible= false;
            healthR.SetEnabled(false);
            healthR.visible= false;
            hLR.SetEnabled(false);
            hLR.visible= false;
            lStats.SetEnabled(false);
            lStats.visible= false;
            lFight.SetEnabled(true);
            lFight.visible= true;
            tHealth = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
            tMana = GameObject.Find("Mana").GetComponent<TextMeshProUGUI>();
            tarmorValue = GameObject.Find("ArmorValue").GetComponent<TextMeshProUGUI>();
            tattackValue = GameObject.Find("AttackValue").GetComponent<TextMeshProUGUI>();
            tStrength = GameObject.Find("Strength").GetComponent<TextMeshProUGUI>();
            tDexterity = GameObject.Find("Dexterity").GetComponent<TextMeshProUGUI>();
            tConsitution = GameObject.Find("Constitution").GetComponent<TextMeshProUGUI>();
            tIntelligence = GameObject.Find("Intelligence").GetComponent<TextMeshProUGUI>();
            tWisdom = GameObject.Find("Wisdom").GetComponent<TextMeshProUGUI>();

            menuSelect.choices = choices;
            menuSelect.value = choices[0];
            for (int i = 0; i < 33; i++)
            {
                enemyL[i] = Instantiate(enemyL[i], new Vector3(-5, -1, 0), Quaternion.identity) as Enemy;
                enemyL[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (currentScene.name == "Fight")
        {
            menuSelect2.SetEnabled(true);
            menuSelect2.visible = true;
            spnBtn2.SetEnabled(true);
            spnBtn2.visible = true;
            atkBtnR.SetEnabled(true);
            atkBtnR.visible = true;
            healthR.SetEnabled(true);
            healthR.visible = true;
            hLR.SetEnabled(true);
            hLR.visible = true;
            lStats.visible = true;
            lFight.visible = false;

            menuSelect.choices = choices;
            menuSelect.value = choices[0];
            menuSelect2.choices = choices;
            menuSelect2.value = choices[0];

            for (int i = 0; i < 33; i++)
            {
                enemyL[i] = Instantiate(enemyL[i], new Vector3(-5, -1, 0), Quaternion.identity) as Enemy;
                enemyL[i].GetComponent<SpriteRenderer>().enabled = false;
                enemyR[i] = Instantiate(enemyR[i], new Vector3(5, -1, 0), Quaternion.identity) as Enemy;
                enemyR[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        spnBtn.RegisterCallback<ClickEvent>(OnButtonClickSpwnBtn);
        spnBtn2.RegisterCallback<ClickEvent>(OnButtonClickSpwnBtn2);
        atkBtnR.RegisterCallback<ClickEvent>(OnButtonClickatkR);
        atkBtnL.RegisterCallback<ClickEvent>(OnButtonClickatkL);

    }

    void Update()
    {

    }
    public void OnButtonClickSpwnBtn(ClickEvent click)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (spawnedEnemyL)
        {
            spawnedEnemyL.GetComponent<SpriteRenderer>().enabled = false;
            spawnedEnemyL = null;
        }

        spawnedEnemyL = enemyL[menuSelect.index];
        spawnedEnemyL.GetComponent<SpriteRenderer>().enabled = true;
        healthL.text = spawnedEnemyL.Health.ToString();

        if (currentScene.name == "Stats")
        {
            tHealth.text = spawnedEnemyL.Health.ToString();
            tMana.text = spawnedEnemyL.Mana.ToString();
            tarmorValue.text = spawnedEnemyL.ArmorValue.ToString();
            tattackValue.text = spawnedEnemyL.AttackValue.ToString();
            tStrength.text = spawnedEnemyL.Str.ToString();
            tDexterity.text = spawnedEnemyL.Dex.ToString();
            tConsitution.text = spawnedEnemyL.Con.ToString();
            tIntelligence.text = spawnedEnemyL.Int.ToString();
            tWisdom.text = spawnedEnemyL.Wis.ToString();
        }
    }
    public void OnButtonClickSpwnBtn2(ClickEvent click)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (spawnedEnemyR)
        {
            spawnedEnemyR.GetComponent<SpriteRenderer>().enabled = false;
            spawnedEnemyR = null;
        }

        spawnedEnemyR = enemyR[menuSelect2.index];
        spawnedEnemyR.GetComponent<SpriteRenderer>().enabled = true;
        healthR.text = spawnedEnemyR.Health.ToString();
    }
    public void OnButtonClickatkR(ClickEvent click)
    {
        var tempChanceToHit = ChanceToHit(spawnedEnemyR, spawnedEnemyL);
        Debug.Log(tempChanceToHit.ToString());
    }
    public void OnButtonClickatkL(ClickEvent click)
    {
        var tempChanceToHit = ChanceToHit(spawnedEnemyL, spawnedEnemyR);
        Debug.Log(tempChanceToHit.ToString());
    }
    public float ChanceToHit(Enemy p, Enemy t)
    {
        var temppAV = PlayerAttackValue(p, t);
        Debug.Log(temppAV.ToString());
        return 21 - ((t.ArmorValue - temppAV) / 20) * 100;
    }
    public float PlayerAttackValue(Enemy p, Enemy t)
    {
        return p.AttackValue * (p.Str / 4) - t.ArmorValue;
    }
    public void OnButtonClickLoadStats(ClickEvent click)
    {
        SceneManager.LoadScene("Stats", LoadSceneMode.Single);
    }
    public void OnButtonClicLoadFight(ClickEvent click)
    {
        SceneManager.LoadScene("Fight", LoadSceneMode.Single);
    }
}
