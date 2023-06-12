using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            int level = PlayerPrefs.GetInt("Level");
            Debug.Log(level);
            Instantiate(levels[level]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
