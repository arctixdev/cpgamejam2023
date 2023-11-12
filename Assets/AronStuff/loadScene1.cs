using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneReward : MonoBehaviour
{
    [SerializeField]
    private string scene;

    public int reward;
    public GameObject astronuatController;
    public GameObject head;
    // Start is called before the first frame update
    public void load()
    {
        //head.GetComponent<singleFaseMonsterGeneration>().giveEndReward(reward, astronuatController.GetComponent<AstronautController>().remainingAstronauts, 20);
        SceneManager.LoadScene(scene);
    }
}
