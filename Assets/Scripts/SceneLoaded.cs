using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaded : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
