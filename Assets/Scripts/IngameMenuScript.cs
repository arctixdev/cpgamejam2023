using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class IngameMenuScript : MonoBehaviour
{
    public GameObject menuObject;

    public AudioClip clickSound;
    public AudioSource audioSource;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timerText;

    void Start()
    {
        menuObject.SetActive(false);
        click();
        levelText.text = "Stage: 0";
    }

    void Update() {
        timerText.text = "Time: " + Mathf.FloorToInt(Time.timeSinceLevelLoad*10).ToString();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleMenu();
        }
    }

    public void click() {
        audioSource.clip = clickSound;
        audioSource.Play();
    }

    public void Restart() {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnterMenu() {
        click();
        Debug.Log("Entering Menu");
        SceneManager.LoadScene(0);
    }

    public void ToggleMenu() {
        Debug.Log("Toggle menu");
        if (menuObject.activeSelf) {
            Time.timeScale = 1;
            menuObject.SetActive(!menuObject.activeSelf);
        } else {
            Time.timeScale = 0;
            menuObject.SetActive(!menuObject.activeSelf);
        }
    }

    public void ExitGame() {
        Debug.Log("Exiting game");
        Application.Quit();
    }

    public void stage(int stageNumber) {
        levelText.text = "Stage: " + stageNumber.ToString();
    }
}
