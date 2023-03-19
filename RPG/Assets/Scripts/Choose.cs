using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Choose : MonoBehaviour
{
    public GameObject[] characters;
    private int p = 0;
    public Text playerName;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void next()
    {
        if (p < characters.Length - 1)
        {
            characters[p].SetActive(false);
            p++;
            characters[p].SetActive(true);
        }
    }

    public void back()
    {
        if (p >0)
        {
            characters[p].SetActive(false);
            p--;
            characters[p].SetActive(true);
        }
    }

    public void accept()
    {
        SaveScript.pchar = p;
        SaveScript.pname = playerName.text;
        SceneManager.LoadScene(1);
    }
}
