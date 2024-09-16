using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected int money;
    [SerializeField] protected UIManager moneyText;
    [SerializeField] protected List<string> months = new List<string> {"July", "August", "September", "October", "November", "December", "January", "February", "March", "April", "May", "June"};
    [SerializeField] protected int monthIndex = 0;
    [SerializeField] protected int monthEventNumber = 0;
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
    
    public void UpdateMoney(int changeAmount) {
        money += changeAmount;
        UIManager.Instance.UpdateMoneyText(money);
    }
}
