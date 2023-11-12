using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    [SerializeField]
    private string scene;
    // Start is called before the first frame update
    public void load()
    {
        SceneManager.LoadScene(scene);
    }
}
