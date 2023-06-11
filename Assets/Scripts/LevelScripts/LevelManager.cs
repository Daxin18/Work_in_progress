using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;
    public GameObject startLevel;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            int level = PlayerPrefs.GetInt("Level");
            if (level != 0)
            {
                Instantiate(levels[level]);
                Destroy(startLevel);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
