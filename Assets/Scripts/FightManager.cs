using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Reflection.Emit;
using Unity.VisualScripting;

public class FightManager : MonoBehaviour
{
    private UnityEngine.UI.Button lAttack, rAttack;
    public UIDocument theDoc;
    public Enemy[] enemyR, enemyL;
    Enemy spawnedEnemyR, spawnedEnemyL;
    TextMeshProUGUI rHealth, rArmorValue, rNumberOfAttacks, rStrength, rDexterity, rConstitution, rIntelligence,
        rWisdom, rCharisma, lHealth, lArmorValue, lNumberOfAttacks, lStrength, lDexterity, lConstitution, 
        lIntelligence, lWisdom, lCharisma;
    ChatController chatBox;

    [SerializeField]
    private TMP_Dropdown rDD, lDD = null;

    readonly List<string> choices = new()
    { "Abomination", "Archer", "Bat", "Bear", "Blob", "Camel", "Centaur", 
        "Centipede","Crab", "Cricket", "Cultist", "Devil", "Djinn", "Donkey", 
        "Eyeball", "Fighter", "Gascloud", "Horse", "Lich", "Lizard", 
        "Lizardman", "Lizardninja", "Monkey", "Mosquitoman", "Mule", "Pegasus", 
        "Rat", "Shade", "Skeleton", "Snake", "Snakeman", "Unicorn", "Wolf" };

    void Awake()
    {
        chatBox = GameObject.Find("Chat Controller").GetComponent<ChatController>();

        rDD = GameObject.Find("DropdownR").GetComponent<TMP_Dropdown>() as TMP_Dropdown;
        rDD.options.Clear();
        rDD.AddOptions(choices);
        lDD = GameObject.Find("DropdownL").GetComponent<TMP_Dropdown>() as TMP_Dropdown;
        lDD.options.Clear();
        lDD.AddOptions(choices);
    
        lHealth = GameObject.Find("LHealth").GetComponent<TextMeshProUGUI>();
        lArmorValue = GameObject.Find("LArmorValue").GetComponent<TextMeshProUGUI>();
        lNumberOfAttacks = GameObject.Find("LNumberOfAttacks").GetComponent<TextMeshProUGUI>();
        lStrength = GameObject.Find("LStrength").GetComponent<TextMeshProUGUI>();
        lDexterity = GameObject.Find("LDexterity").GetComponent<TextMeshProUGUI>();
        lConstitution = GameObject.Find("LConstitution").GetComponent<TextMeshProUGUI>();
        lIntelligence = GameObject.Find("LIntelligence").GetComponent<TextMeshProUGUI>();
        lWisdom = GameObject.Find("LWisdom").GetComponent<TextMeshProUGUI>();
        lCharisma = GameObject.Find("LCharisma").GetComponent<TextMeshProUGUI>();
        lAttack = GameObject.Find("LAttack").GetComponent<UnityEngine.UI.Button>();
        lAttack.onClick.AddListener(LAttack);

        rHealth = GameObject.Find("RHealth").GetComponent<TextMeshProUGUI>();
        rArmorValue = GameObject.Find("RArmorValue").GetComponent<TextMeshProUGUI>();
        rNumberOfAttacks = GameObject.Find("RNumberOfAttacks").GetComponent<TextMeshProUGUI>();
        rStrength = GameObject.Find("RStrength").GetComponent<TextMeshProUGUI>();
        rDexterity = GameObject.Find("RDexterity").GetComponent<TextMeshProUGUI>();
        rConstitution = GameObject.Find("RConstitution").GetComponent<TextMeshProUGUI>();
        rIntelligence = GameObject.Find("RIntelligence").GetComponent<TextMeshProUGUI>();
        rWisdom = GameObject.Find("RWisdom").GetComponent<TextMeshProUGUI>();
        rCharisma = GameObject.Find("RCharisma").GetComponent<TextMeshProUGUI>();
        rAttack = GameObject.Find("RAttack").GetComponent<UnityEngine.UI.Button>();
        rAttack.onClick.AddListener(RAttack);
        
        for (int i = 0; i < enemyL.Length; i++)
        {
            enemyL[i] = Instantiate(enemyL[i], new Vector3(-3, 2, 0), Quaternion.identity) as Enemy;
            enemyL[i].GetComponent<SpriteRenderer>().enabled = false;
            enemyR[i] = Instantiate(enemyR[i], new Vector3(3, 2, 0), Quaternion.identity) as Enemy;
            enemyR[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        
        rDD.onValueChanged.AddListener(delegate { OnButtonClickSpwnBtnR(rDD); });
        lDD.onValueChanged.AddListener(delegate { OnButtonClickSpwnBtnL(lDD); });
    }
    public void OnButtonClickSpwnBtnL(TMPro.TMP_Dropdown change)
    {
        if (spawnedEnemyL)
        {
            spawnedEnemyL.GetComponent<SpriteRenderer>().enabled = false;
            spawnedEnemyL = null;
        }

        spawnedEnemyL = enemyL[lDD.value];
        spawnedEnemyL.GetComponent<SpriteRenderer>().enabled = true;

        lHealth.text = spawnedEnemyL.Health.ToString();
        lArmorValue.text = spawnedEnemyL.ArmorValue.ToString();
        lNumberOfAttacks.text = spawnedEnemyL.NumberOfAttacks.ToString();
        lStrength.text = spawnedEnemyL.Str.ToString();
        lDexterity.text = spawnedEnemyL.Dex.ToString();
        lConstitution.text = spawnedEnemyL.Con.ToString();
        lIntelligence.text = spawnedEnemyL.Int.ToString();
        lWisdom.text = spawnedEnemyL.Wis.ToString();
        lCharisma.text = spawnedEnemyL.Cha.ToString();
    }
    public void OnButtonClickSpwnBtnR(TMPro.TMP_Dropdown change)
    {
        if (spawnedEnemyR)
        {
            spawnedEnemyR.GetComponent<SpriteRenderer>().enabled = false;
            spawnedEnemyR = null;
        }

        spawnedEnemyR = enemyR[rDD.value];
        spawnedEnemyR.GetComponent<SpriteRenderer>().enabled = true;

        rHealth.text = spawnedEnemyR.Health.ToString();
        rArmorValue.text = spawnedEnemyR.ArmorValue.ToString();
        rNumberOfAttacks.text = spawnedEnemyR.NumberOfAttacks.ToString();
        rStrength.text = spawnedEnemyR.Str.ToString();
        rDexterity.text = spawnedEnemyR.Dex.ToString();
        rConstitution.text = spawnedEnemyR.Con.ToString();
        rIntelligence.text = spawnedEnemyR.Int.ToString();
        rWisdom.text = spawnedEnemyR.Wis.ToString();
        rCharisma.text = spawnedEnemyR.Cha.ToString();
    }
    public void RAttack()
    {
        var tempChanceToHit = ChanceToHit(spawnedEnemyR, spawnedEnemyL);
        chatBox.AddToChatOutput("The " + spawnedEnemyR.name.Replace("(Clone)", "").Trim() + "'s Chance To Hit is " + tempChanceToHit.ToString());
        Debug.Log("The attacker's Chance To Hit is " + tempChanceToHit.ToString());
    }
    public void LAttack()
    {
        var tempChanceToHit = ChanceToHit(spawnedEnemyL, spawnedEnemyR);
        chatBox.AddToChatOutput("The " + spawnedEnemyL.name.Replace("(Clone)", "").Trim() + "'s Chance To Hit is " + tempChanceToHit.ToString());
        Debug.Log("The attacker's ChanceToHit is " + tempChanceToHit.ToString());
    }
    public float ChanceToHit(Enemy p, Enemy t)
    {
        Debug.Log("The attacker's AttackValue is " + p.AbilityModifier.ToString());
        return (21 - (t.ArmorValue - p.AbilityModifier)) / 20 * 100;
    }
}

