using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float currentTime = 0f;
    public float startTime = 30f;
    [SerializeField] Text timer;

    public GameObject winPanel;
    public GameObject retryPanel;

    public GameObject found1;
    public GameObject found2;
    public GameObject found3;
    public Text scoreText;

    bool win;
    int highScore;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        win = false;
        highScore = PlayerPrefs.GetInt("HighScore");
        
    }

    int GetScoreFromTime(float time)
    {
        return 100 + (int)(time * 30);
    }

    IEnumerator DelayOnPopup(GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        obj.gameObject.SetActive(true);
        LeanTween.scale(obj, new Vector3(1.5f, 1.5f, 1.5f), 1f).setEase(LeanTweenType.easeOutBack);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= 0
            && found1.gameObject.GetComponent<Image>().enabled == true
            && found2.gameObject.GetComponent<Image>().enabled == true
            && found3.gameObject.GetComponent<Image>().enabled == true
            && !win
            )
        {

            int score = GetScoreFromTime(currentTime);
            win = true;

            if (score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
                
                Debug.Log("HighScore = " + PlayerPrefs.GetInt("HighScore"));
            }

            scoreText.text = score.ToString();

            StartCoroutine(DelayOnPopup(winPanel));

            
        }

        if (currentTime >= 0 && !win)
        {
            currentTime -= 1 * Time.deltaTime;
            timer.text = (currentTime / 60f).ToString("00") + ":" + currentTime.ToString("00");
        }
        
        if(currentTime <= 0)
        {
            currentTime = 0;
            timer.text = "00:" + currentTime.ToString("00");
            StartCoroutine(DelayOnPopup(retryPanel));

        }



    }
}
