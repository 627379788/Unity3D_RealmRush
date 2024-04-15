using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goladReward = 25;
    [SerializeField] int goladPenalty = 25;
    Bank bank;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold() {
        if (bank == null) return;
        bank.Deposit(goladReward);
    }

    public void StealGold() {
        if (bank == null) return;
        bank.WithDraw(goladPenalty);
    }
}
