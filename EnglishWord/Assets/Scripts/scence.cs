using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scence : MonoBehaviour
{

    public void NextScene(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }

    public void GameExite()
    {
        Application.Quit();
    }
}
