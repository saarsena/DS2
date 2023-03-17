using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UnityEngine.UIElements.Button spnBtn, spnBtn2;
    public UIDocument theDoc;
    public Enemy[] enemyR, enemyL;
    Enemy spawnedEnemyR, spawnedEnemyL;
    DropdownField menuSelect, menuSelect2;
    TextMeshProUGUI tHealth, tMana, tarmorValue, tattackValue, tStrength, tDexterity, tConsitution, tIntelligence, tWisdom;


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
        menuSelect = theDoc.rootVisualElement.Q("MenuSelect") as DropdownField;
        menuSelect2 = theDoc.rootVisualElement.Q("MenuSelect2") as DropdownField;

        if (currentScene.name == "Stats")
        {
            tHealth = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
            tMana = GameObject.Find("Mana").GetComponent<TextMeshProUGUI>();
            tarmorValue = GameObject.Find("ArmorValue").GetComponent<TextMeshProUGUI>();
            tattackValue = GameObject.Find("AttackValue").GetComponent<TextMeshProUGUI>();
            tStrength = GameObject.Find("Strength").GetComponent<TextMeshProUGUI>();
            tDexterity = GameObject.Find("Dexterity").GetComponent<TextMeshProUGUI>();
            tConsitution = GameObject.Find("Constitution").GetComponent<TextMeshProUGUI>();
            tIntelligence = GameObject.Find("Intelligence").GetComponent<TextMeshProUGUI>();
            tWisdom = GameObject.Find("Wisdom").GetComponent<TextMeshProUGUI>();
        }

        menuSelect.choices = choices;
        menuSelect.value = choices[0];
        menuSelect2.choices = choices;
        menuSelect2.value = choices[0];

        for (int i = 0; i < enemyL.Length; i++)
        {
            enemyL[i] = Instantiate(enemyL[i], new Vector3(-5, -1, 0), Quaternion.identity) as Enemy;
            enemyL[i].GetComponent<SpriteRenderer>().enabled = false;
            enemyR[i] = Instantiate(enemyR[i], new Vector3(5, -1, 0), Quaternion.identity) as Enemy;
            enemyR[i].GetComponent<SpriteRenderer>().enabled = false;
        }

        spnBtn.RegisterCallback<ClickEvent>(OnButtonClickSpwnBtn);
        spnBtn2.RegisterCallback<ClickEvent>(OnButtonClickSpwnBtn2);
    }
    
    void Update()
    {

    }

    void GetEnemyR(Enemy enemy)
    {
        spawnedEnemyR = enemy;
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

        GetEnemyR(enemyR[menuSelect2.index]);
        spawnedEnemyR.GetComponent<SpriteRenderer>().enabled = true;
    }
}
