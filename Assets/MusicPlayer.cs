using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
        Invoke("LoadFirstLevel", 5);
    }

    // Update is called once per frame
    void Update () {
    	
    }

    void LoadFirstLevel() { 
    SceneManager.LoadScene(1);
    }
}
