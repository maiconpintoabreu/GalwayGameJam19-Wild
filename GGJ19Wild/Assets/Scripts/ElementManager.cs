using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElementManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        //When something enters this object's trigger collider, check if it is the ball GameObject.
        if (otherObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager. GetActiveScene(). name);
        }
    }
}
