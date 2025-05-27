using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private CanvasGroup caughtBackgroundImageCanvasGroup;
    private bool isPlayerCaught;


    private float fadeDuration;
    private float displayImageDuration;
    private float timer;
    private bool isPlayerAtExit;


    // Start is called before the first frame update
    void Start()
    {
        fadeDuration = 1.0f;
        displayImageDuration = 1.0f;
    }


    // Update is called once per frame
    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }


    void EndLevel(CanvasGroup image, bool restartGame)
    {
        timer += Time.deltaTime;
        image.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            if (restartGame)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }

}
