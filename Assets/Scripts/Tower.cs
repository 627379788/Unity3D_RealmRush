using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    public bool CreatTower(Tower tower, Vector3 position) {
        Bank bank = FindObjectOfType<Bank>();
        if(bank == null || bank.CurrentBalance < cost) {
            return false;
        }
        bank.WithDraw(cost);
        Instantiate(tower.gameObject, position, Quaternion.identity);
        return true;
    }
}
