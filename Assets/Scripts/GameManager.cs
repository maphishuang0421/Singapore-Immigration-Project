using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected int money;
    [SerializeField] protected UIManager moneyText;
    [SerializeField] protected List<string> months = new List<string> {"July", "August", "September", "October", "November", "December", "January", "February", "March", "April", "May", "June"};
    [SerializeField] protected int monthIndex = 0;
    [SerializeField] protected int monthEventNumber = 0;
    [SerializeField] private RegionInformationScriptableObject selectedRegionInfo;
    public Dictionary<string, double> upgradesDict = new Dictionary<string, double> {
        ["Increase money gained"] = 0.05, ["Decrease money lost"] = 0.05, ["Increase character speed"] = 0.1
        };
    public List<int> upgradesGotten = new List<int> {0, 0, 0};
    public List<int> upgradesBasePrice = new List<int> {2500, 2500, 1000};
    public List<double> upgradesScale = new List<double> {0.1, 0.1, 0.1};
    public List<TextMeshProUGUI> shopTexts;
    public TextMeshProUGUI shopDialogue;
    public transform playerTransform;
    public Vector2 teleportLocation;
    public Vector2 teleportOrigin;
    public double timerBaseTime = 120;
    private double timerCurrentTime;
    public bool timerStarted = false;
    public int npcNumber = 0;
    public int totalNpc = 0;
    public bool[] npcChecklist;
    public SimulationPortal portal;
    private string currentSceneName;
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            return _instance;
        }
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } 
        else {
            _instance = this;
        }
    }
    public void SetSimulationPortal(SimulationPortal simportal) {
        portal = simportal;
    }
    public void SetUpSimluation(int npc) {
        totalNpc = npc;
        npcChecklist = new bool[totalNpc];
        UIManager.Instance.UpdateSimQuestText(0, totalNpc);
    }
    public void UpdateNpcChecklist(int NPCindex) {
        npcChecklist[NPCindex] = true;
        int count = NumNpcTrue();
        if (count == totalNpc) {
            portal.gameObject.SetActive(true);
        }
        UIManager.Instance.UpdateSimQuestText(count, totalNpc);
    }
    public int NumNpcTrue() {
        int count = 0;
        for(int i = 0; i < npcChecklist.Length; i++) {
            if (npcChecklist[i]) {
                count++;
            }
        }
        return count;
    }
    public void UpdateMoney(int changeAmount) {
        if (changeAmount > 0) {
            int scaleChangeAmount = (int) (changeAmount * (1 + upgradesDict["Increase money gained"] * upgradesGotten[0]));
        }
        if (changeAmount < 0) {
            int scaleChangeAmount = (int) (changeAmount * (1 - upgradesDict["Decrease money lost"] * upgradesGotten[1]));
        }
        money += changeAmount;
        UIManager.Instance.UpdateMoneyText(money);
    }
    public void BuyFromShop(int itemIndex) {
        int price = (int)(upgradesBasePrice[itemIndex] * (1+ upgradesScale[itemIndex] * upgradesGotten[itemIndex]));
        if (price > money) {    
            shopDialogue.text = "You do not have enough money to buy this upgrade.";
        } else {
            shopDialogue.text = "You have bought this upgrade.";
            money -= price;
            UIManager.Instance.UpdateMoneyText(money);
            upgradesGotten[itemIndex] += 1;
            UpdateShopText(itemIndex);
        }
    }
    public void UpdateShopText(int textIndex = -1) {
        if (textIndex > 0) {
            shopTexts[textIndex].text = "$" + ((int) (upgradesBasePrice[textIndex] * (1+ upgradesScale[textIndex] * upgradesGotten[textIndex]))).ToString();
        } else {
            for (int i=0; i < shopTexts.Count-1; i++) {
                shopTexts[i].text = "$" + ((int)(upgradesBasePrice[i] * (1+ upgradesScale[i] * upgradesGotten[i]))).ToString();
            }
        }
        shopTexts[3].text = money.ToString();
    }
    public void TeleportPlayer() {
        playerTransform.position = teleportLocation;
        timerCurrentTime = timerBaseTime;
        timerStarted = true;
        // start timer
        // track what the player has done (correct items) (store as boolean: true = selected, false = not selected)
        // if default false is correct, -0. if default false is wrong, -penalty. 
        // if toggled to true and is wrong, -smaller penalty. if toggled to true and is correct, +money.
    }
    void FixedUpdate() {
        if (timerStarted == true) {
            timerCurrentTime -= Time.fixedDeltaTime;
            if (timerCurrentTime <= 0) {
                Debug.Log("timer ran out");
                // when timer runs out or player clicks done, dialoge shows "inspector has come to check your work"
        // calculate score and give/subtract money
            }
        }
    }
    public void setTeleportVariables(transform playerTransform1, Vector2 teleportLocation1) {
        playerTransform = playerTransform1;
        teleportLocation = teleportLocation1;
    }
    public void SetRegionName(RegionInformationScriptableObject regionInfo) {
        selectedRegionInfo = regionInfo;
    }
    public void MonthDeduction() {
        UpdateMoney(-selectedRegionInfo.livingExpenses);
        if (money <= 0) {
            money = 0;
            UIManager.Instance.Finished("You lost. You have no more money. Thank you for playing.");
        }
    }
    public void ReloadScene() {
        currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    
}
