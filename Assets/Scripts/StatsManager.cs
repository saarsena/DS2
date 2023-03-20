using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StatsManager : MonoBehaviour
{
    private UnityEngine.UIElements.Button spnBtn, spnBtn2, atkBtnR;
    public UIDocument theDoc;
    public Enemy[] enemyR, enemyL;
    Enemy spawnedEnemyL;
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
        spnBtn = theDoc.rootVisualElement.Q("SpawnButton") as UnityEngine.UIElements.Button;
        spnBtn2 = theDoc.rootVisualElement.Q("SpawnButton2") as UnityEngine.UIElements.Button;
        atkBtnR = theDoc.rootVisualElement.Q("AttackR") as UnityEngine.UIElements.Button;
        menuSelect = theDoc.rootVisualElement.Q("MenuSelect") as DropdownField;
        menuSelect2 = theDoc.rootVisualElement.Q("MenuSelect2") as DropdownField;
        healthL = theDoc.rootVisualElement.Q("HealthL") as Label;
        healthR = theDoc.rootVisualElement.Q("HealthR") as Label;
        hLR = theDoc.rootVisualElement.Q("HealthLabelRight") as Label;
   
        menuSelect2.SetEnabled(false);
        menuSelect2.visible = false;
        spnBtn2.SetEnabled(false);
        spnBtn2.visible = false;
        atkBtnR.SetEnabled(false);
        atkBtnR.visible = false;
        healthR.SetEnabled(false);
        healthR.visible = false;
        hLR.SetEnabled(false);
        hLR.visible = false;
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
        
        spnBtn.RegisterCallback<ClickEvent>(OnButtonClickSpwnBtn);
    }

    void Update()
    {

    }
    public void OnButtonClickSpwnBtn(ClickEvent click)
    {
        if (spawnedEnemyL)
        {
            spawnedEnemyL.GetComponent<SpriteRenderer>().enabled = false;
            spawnedEnemyL = null;
        }

        spawnedEnemyL = enemyL[menuSelect.index];
        spawnedEnemyL.GetComponent<SpriteRenderer>().enabled = true;
        healthL.text = spawnedEnemyL.Health.ToString();
        
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
