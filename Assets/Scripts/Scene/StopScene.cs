using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopScene : MonoBehaviour
{
    public Button stopButton;
    public Button continueButton;

    void Start()
    {
        stopButton.onClick.AddListener(StopCurrentScene);

        continueButton.onClick.AddListener(ContinueScene);

        continueButton.gameObject.SetActive(false);
    }

    void StopCurrentScene()
    {
        Time.timeScale = 0; // Dừng game
        stopButton.gameObject.SetActive(false); 
        continueButton.gameObject.SetActive(true); 
        Debug.Log("Scene đã dừng lại.");
    }

    void ContinueScene()
    {
        Time.timeScale = 1; // Tiếp tục game
        continueButton.gameObject.SetActive(false); 
        stopButton.gameObject.SetActive(true); 
        Debug.Log("Scene đã tiếp tục.");
    }
}
