using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result1 : MonoBehaviour
{
    public int result11;
    public int bestresult11;
    public Text BestText;

    void Start()
    {
        bestresult11 = PlayerPrefs.GetInt("bst1");
        BestText.text = bestresult11.ToString();
    }

    public void OnClic()
    {
        bestresult11 = PlayerPrefs.GetInt("bst1");
        result11 = PlayerPrefs.GetInt("st1");
        
        if (bestresult11 < result11)
        {
            bestresult11 = result11;
        }
        BestText.text = bestresult11.ToString();
    }

    void Update()
    {
        PlayerPrefs.SetInt("bst1", bestresult11);
        PlayerPrefs.SetInt("st1", result11);
    }
}
