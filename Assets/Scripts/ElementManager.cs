using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElementManager : MonoBehaviour
{
    [SerializeField] string damageType;

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        //When something enters this object's trigger collider, check if it is the ball GameObject.
        if (otherObject.name == "Player")
        {
            var playerController = otherObject.GetComponent<TopDownController>();
            playerController.GetDamage(this.damageType);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
