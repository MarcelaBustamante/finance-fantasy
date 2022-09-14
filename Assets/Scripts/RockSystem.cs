using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSystem : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitpoints = 3;
    public HealtbarBehaviour Healtbar;
    private int cantRoca;


    private void Update()
    {
       cantRoca = Random.Range(3, 10);
    }

    void Start()
    {
        HitPoints = MaxHitpoints;
        Healtbar.SetHealth(HitPoints, MaxHitpoints);
        
    }


    public void TakeHit(float damage)
    {
        HitPoints -= damage;
        Healtbar.SetHealth(HitPoints, MaxHitpoints);

        if (HitPoints <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.ShowText("+ "+cantRoca+" Piedra", 50, Color.yellow, transform.position, Vector3.up * 50, 1.0f);
            GameManager.instance.roca = GameManager.instance.roca + cantRoca;
        }
    }
}
