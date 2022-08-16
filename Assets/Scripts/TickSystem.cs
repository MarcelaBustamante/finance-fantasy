using System;
using UnityEngine;

namespace FinanceFantasy.Tick {
  public class TickSystem : MonoBehaviour {

    public struct TickEvent {
      public int TotalTicks { get; set; }
    }
    
    public static EventHandler<TickEvent> OnTick;

    private int totalTicks = 0; 
    private float currentTickTime = 0f;
    private const float TICK_TIME = 1f;

    private void Update() {
      var currentTime = Time.deltaTime;
      if (currentTickTime >= TICK_TIME) {
        currentTickTime -= TICK_TIME;

        totalTicks++;
        OnTick?.Invoke(this,new TickEvent { TotalTicks = totalTicks });
      } else {
        currentTickTime += currentTime;
      }
    }
  }
}