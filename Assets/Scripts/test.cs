using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    private i_GameEvent gainXp;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 1000)
        {
            gainXp.Raise(13);
            counter = 0;
        }

        counter++;
    }
}
