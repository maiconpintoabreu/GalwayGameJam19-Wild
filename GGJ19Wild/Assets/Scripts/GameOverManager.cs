using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] bool isCheckingIfAlive;
    
    TopDownController playerController;
    RectTransform uiTransform;
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<TopDownController>();
        this.uiTransform = gameObject.GetComponent<RectTransform>();
    }
    void Update()
    {
        bool toActive = this.isCheckingIfAlive == playerController.isAlive;
        if(toActive)
        {
            this.uiTransform.anchoredPosition = Vector3.zero;
        }else{
            this.uiTransform.anchoredPosition = Vector3.down*9999;
        }
    }
    public void restartLevel()
    {
            SceneManager.LoadScene(SceneManager. GetActiveScene(). name);
    }

}
