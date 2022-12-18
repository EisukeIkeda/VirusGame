using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Pause : MonoBehaviour
{
    public GameObject sceneChange;
    public GameObject pausePanel;
    public Text title_back;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("ThisStageLevel") == 100){
            title_back.text = "セーブして戻る";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void PauseCancel()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void TitleBackOnClick()
    {
      Time.timeScale = 1;
    　CanvasGroup scene = sceneChange.GetComponent<CanvasGroup>();
   　 scene.blocksRaycasts = true;
    　scene.DOFade(1,1);
    PlayerPrefs.SetInt("AddPoint",0);
    　//StartCoroutine ("SceneChange");
    SceneManager.LoadScene("TitleScene");
    
    }

    IEnumerator SceneChange () 
    {    
    	yield return new WaitForSeconds(1f);
        ///シー
        Debug.Log("処理！！！！");
        
    }

}
