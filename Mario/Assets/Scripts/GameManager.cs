using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance
    {
        get;
        set; //get => SceneManager.GetActiveScene().GetRootGameObjects().First(t => t.GetType() == typeof(GameManager))
    }



    public void GameOver()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
