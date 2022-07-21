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
            FindObjectOfType<AudioManager>().PlayOneShot("GoalSFX");
            StartCoroutine(WaitForSound());
            // SceneManager.LoadScene(this.nextLevel);


        }
        IEnumerator WaitForSound()
        {

            //yield on a new YieldInstruction that waits for 2 seconds.
            yield return new WaitForSeconds(0.7f);
            SceneManager.LoadScene(this.nextLevel);
        }
    }
}

