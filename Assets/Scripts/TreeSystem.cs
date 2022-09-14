using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSystem : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitpoints = 3;
    public HealtbarBehaviour Healtbar;
    private int cantRoca;


    private void Update()
    {
        cantRoca = Random.Range(3, 5);
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
            GameManager.instance.ShowText("+ "+cantRoca+" Madera", 50, Color.yellow, transform.position, Vector3.up * 50, 1.0f);
            GameManager.instance.madera = GameManager.instance.madera + cantRoca;
        }
    }
}
