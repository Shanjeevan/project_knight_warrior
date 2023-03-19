using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{

    public static int pchar=6;
    public static string pname = "Player";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player name : " + pname);
        Debug.Log("Character index" + pchar);
    }
}
