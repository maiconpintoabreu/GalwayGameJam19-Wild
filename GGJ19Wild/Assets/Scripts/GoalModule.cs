using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalModule : MonoBehaviour
{
    [SerializeField] string nextLevel;

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        //When something enters this object's trigger collider, check if it is the ball GameObject.
        if (otherObject.name == "Player")
        {
            FindObjectOfType<AudioManager>().PlayOneShot("UIStartSFX");
            SceneManager.LoadScene(this.nextLevel);
        }
    }
}
