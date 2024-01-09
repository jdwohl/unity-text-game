using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public static Manager manager;

    bool gameStart;

    void Awake()
    {
        if (!gameStart)
        {
            manager = this;

            SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);

            gameStart = true;
        }
    }
}
