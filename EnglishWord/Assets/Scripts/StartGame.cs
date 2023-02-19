using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Panel1;

    public int c;
    public void Start()
    {
        c = PlayerPrefs.GetInt("col_start");
        if(c == 0)
        {
            Panel.SetActive(true);
            Panel1.SetActive(false);
            PlayerPrefs.SetInt("col_start",1);
        }
    }
    
}
