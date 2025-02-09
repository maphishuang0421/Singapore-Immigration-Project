using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected int money;
    [SerializeField] protected UIManager moneyText;
    [SerializeField] protected List<string> months = new List<string> {"July", "August", "September", "October", "November", "December", "January", "February", "March", "April", "May", "June"};
    [SerializeField] protected int monthIndex = 0;
    [SerializeField] protected int monthEventNumber = 0;
    [SerializeField] private RegionInformationScriptableObject selectedRegionInfo;
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
    }
    public void UpdateNpcChecklist(int NPCindex) {
        npcChecklist[NPCindex] = true;
        if (AllNpcTrue) {

        }
    }
    public bool AllNpcTrue() {
        for(int i = 0; i < npcChecklist.Length; i++) {
            if (!npcChecklist[i]) {
                return false;
            }
        }
        return true;
    }
    public void UpdateMoney(int changeAmount) {
        money += changeAmount;
        UIManager.Instance.UpdateMoneyText(money);
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
