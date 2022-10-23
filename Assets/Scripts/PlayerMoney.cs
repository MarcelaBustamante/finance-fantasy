using System;
using UnityEngine;

namespace FinanceFantasy.Player {
  public class PlayerMoney : MonoBehaviour {

    public static Action<float> PlayerMoneyChanged;

    //private float _currentMoney = 1000f;
    private float _currentMoney;  

    private void Awake() {
            // NOT NEED CAN BE REMOVED
      _currentMoney = GameManager.instance.pesos;
      PlayerMoneyChanged?.Invoke(_currentMoney);
    }

    public void TakeMoney(float quantity) {
      if (_currentMoney < quantity) {
        print($"Something is weird, the {quantity} is greater than current player's money = {_currentMoney}");
        _currentMoney = 0;
        return;
      }

      _currentMoney -= quantity;
      PlayerMoneyChanged?.Invoke(_currentMoney);
    }

    public void GiveMoney(float quantity) {
      _currentMoney += quantity;
      PlayerMoneyChanged?.Invoke(_currentMoney);
    }
  }
}