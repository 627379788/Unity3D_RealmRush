using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TMP_Text tmpText;
    public int CurrentBalance{get {return currentBalance;}}
    void Start()
    {
        currentBalance = startBalance;
        UpdateTMPText();
    }
    public void Deposit(int count) {
        currentBalance += Mathf.Abs(count);
        UpdateTMPText();
    }

    public void WithDraw(int count) {
        currentBalance -= Mathf.Abs(count);
        if (currentBalance < 0) {
            ReloadScene();
        }
        UpdateTMPText();
    }

    void UpdateTMPText() {
        tmpText.text = "Gold: " + currentBalance;
    }

    void ReloadScene() {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }
}
