using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] protected int money;
    [SerializeField] protected UIManager moneyText;
    [SerializeField] protected List<string> months = new List<string> {"July", "August", "September", "October", "November", "December", "January", "February", "March", "April", "May", "June"};
    [SerializeField] protected EventStruct[] monthLengths;
    [SerializeField] protected int monthIndex = 0;
    [SerializeField] protected int monthEventNumber = 0;
    private static GameManager _instance;
    public static GameManager Instance {
        get {
            return _instance;
        }
    }

    [System.Serializable]
    public class EventStruct
    {
        public EventScriptableObject[] EventList;

    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } 
        else {
            _instance = this;
        }
    }

    public int GetMoney() {
        return money;
    }

    public void UpdateMoney(int changeAmount) {
        money += changeAmount;
        UIManager.Instance.UpdateMoneyText(money);
    }

    public void EventCounter() {
        monthEventNumber += 1;
        if (monthEventNumber >= monthLengths[monthIndex].EventList.Length) {
            monthIndex += 1;
            monthEventNumber = 0;
        }
        if (monthIndex > months.Count) {
            // create ending message function
        }
        UIManager.Instance.UpdateTimeText((months[monthIndex] + ", week " + (monthEventNumber + 1)));
        UIManager.Instance.CreateEvent(monthLengths[monthIndex].EventList[monthEventNumber]);
    }

    public void UpdateMonthEvent() {
       monthIndex += 1;
    }
}
