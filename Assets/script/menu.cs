using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject over;
    public GameObject panellogin;
    public GameObject rigis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void login()
    {
        panellogin.SetActive(true);
        rigis.SetActive(false);



    }
    public void playagain()
    {
        over.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);


    }
}
