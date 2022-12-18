using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.iOS;

public class LevelController : MonoBehaviour
{
  　public GameObject FirstPanel;
  public GameObject startPanel;
    public GameObject stagePanel;
    public GameObject nextPageButton;
    public GameObject nextPageButton2;
    public GameObject stagePanel2;
    public GameObject stagePanel3;
    public GameObject scenePanel;
    public GameObject shopButton;
    public GameObject mugenChangeButton;
    public GameObject eventPanel;
    public Text event_text;
    public AudioClip sound1;
    public GameObject Level1;
    public GameObject Level1C;
    public GameObject Level2;
    public GameObject Level2C;
    public GameObject Level3;
    public GameObject Level3C;
    public GameObject Level4;
    public GameObject Level4C;
    public GameObject Level5;
    public GameObject Level5C;
    public GameObject Level6;
    public GameObject Level6C;
    public GameObject Level7;
    public GameObject Level7C;
    public GameObject Level8;
    public GameObject Level8C;
    public GameObject Level9;
    public GameObject Level9C;
    public GameObject Level10;
    public GameObject Level10C;
    public GameObject Level11;
    public GameObject Level11C;
    public GameObject Level12;
    public GameObject Level12C;
    public GameObject Level13;
    public GameObject Level13C;
    public GameObject Level14;
    public GameObject Level14C;
    public GameObject Level15;
    public GameObject Level15C;
    public GameObject x = null;

    // Start is called before the first frame update
    void Start()
    {   
              ///ステージセット
              if(PlayerPrefs.GetInt("StageLevel") >= 2){
                  Level1C.SetActive(true);
                  Level2.SetActive(true);
              }else{
                PlayerPrefs.SetInt("IceLevel",0);
                PlayerPrefs.SetInt("SpawnerLevel",0);
                PlayerPrefs.SetInt("ItemInPossession",0);
                }if(PlayerPrefs.GetInt("StageLevel") >= 3){
                  Level2C.SetActive(true);
                  Level3.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 4){
                  Level3C.SetActive(true);
                  Level4.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 5){
                  Level4C.SetActive(true);
                  Level5.SetActive(true);
              }else{
                shopButton.SetActive(false);
                nextPageButton.SetActive(false);
              }
              if(PlayerPrefs.GetInt("StageLevel") >= 6){
                  shopButton.SetActive(true);
                  Level5C.SetActive(true);
                  Level6.SetActive(true);
                  nextPageButton.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 7){
                  Level6C.SetActive(true);
                  Level7.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 8){
                  Level7C.SetActive(true);
                  Level8.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 9){
                  Level8C.SetActive(true);
                  Level9.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 10){
                  Level9C.SetActive(true);
                  Level10.SetActive(true);
              }else{
                 nextPageButton2.SetActive(false);
              }
              if(PlayerPrefs.GetInt("StageLevel") >= 11){
                  Level10C.SetActive(true);
                  Level11.SetActive(true);
                  nextPageButton2.SetActive(true);
                  mugenChangeButton.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 12){
                  Level11C.SetActive(true);
                  Level12.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 13){
                  Level12C.SetActive(true);
                  Level13.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 14){
                  Level13C.SetActive(true);
                  Level14.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 15){
                  Level14C.SetActive(true);
                  Level15.SetActive(true);
              }if(PlayerPrefs.GetInt("StageLevel") >= 16){
                  Level15C.SetActive(true);
              }

              Debug.Log( "現在解放されているステージの数" +PlayerPrefs.GetInt("StageLevel")); 
              Debug.Log("直近のステージレヴェル"　+ PlayerPrefs.GetInt("ThisStageLevel"));
              Debug.Log("イベントフラグ" + PlayerPrefs.GetInt("EventFlag"));

              if(PlayerPrefs.GetInt("EventFlag") == 1){
                CanvasGroup can = FirstPanel.GetComponent<CanvasGroup>();
                can.blocksRaycasts = false;
                Transform tran = startPanel.GetComponent<Transform>();
                tran.DOScale (new Vector2(1f,1f),0f );
              }


              if(PlayerPrefs.GetInt("EventFlag") == 1 & PlayerPrefs.GetInt("StageLevel") <= 5){
                stagePanel.SetActive(true);
        Transform tran = stagePanel.GetComponent<Transform>();
        tran.DOScale (new Vector2(1f,1f),0.1f )
        .SetEase(Ease.InQuart);　
        EventControll();
              }else if(PlayerPrefs.GetInt("EventFlag") == 1 & PlayerPrefs.GetInt("StageLevel") > 5 
              & PlayerPrefs.GetInt("StageLevel") <= 10){
                stagePanel2.SetActive(true);
        Transform tran2 = stagePanel2.GetComponent<Transform>();
        tran2.DOScale (new Vector2(1f,1f),0.1f )
        .SetEase(Ease.InQuart);　
        EventControll();
        if(PlayerPrefs.GetInt("StageLevel")==6){
          StartCoroutine("ShopCoroutine");
        }
              }else if(PlayerPrefs.GetInt("EventFlag") == 1){
                stagePanel3.SetActive(true);
        Transform tran3 = stagePanel3.GetComponent<Transform>();
        tran3.DOScale (new Vector2(1f,1f),0.1f )
        .SetEase(Ease.InQuart);　
        EventControll();
        if(PlayerPrefs.GetInt("StageLevel")==11){
          StartCoroutine("MugenCoroutine");
        }
              }
        


　　　　　　　　　///ステージ解放
              if(PlayerPrefs.GetInt("StageLevel") == 2 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level2);
              }if(PlayerPrefs.GetInt("StageLevel") == 3 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level3);
              }if(PlayerPrefs.GetInt("StageLevel") == 4 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level4);
                PlayerPrefs.SetString("Set" , "ice");
              }if(PlayerPrefs.GetInt("StageLevel") == 5 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level5);
                PlayerPrefs.SetInt("ItemInPossession",1);
           　　　PlayerPrefs.SetInt("IceLevel",1);
          　　　 PlayerPrefs.SetInt("SpawnerLevel",0);
              }if(PlayerPrefs.GetInt("StageLevel") == 6 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level6);
              }if(PlayerPrefs.GetInt("StageLevel") == 7 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level7);
              }if(PlayerPrefs.GetInt("StageLevel") == 8 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level8);
              }if(PlayerPrefs.GetInt("StageLevel") == 9 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level9);
              }if(PlayerPrefs.GetInt("StageLevel") == 10 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level10);
              }if(PlayerPrefs.GetInt("StageLevel") == 11 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level11);
              }if(PlayerPrefs.GetInt("StageLevel") == 12 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level12);
              }if(PlayerPrefs.GetInt("StageLevel") == 13 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level13);
              }if(PlayerPrefs.GetInt("StageLevel") == 14 & PlayerPrefs.GetInt("EventFlag") == 1){
                StageOpen(Level14);
              }if(PlayerPrefs.GetInt("StageLevel") >= 15 & PlayerPrefs.GetInt("EventFlag") == 1){
                PlayerPrefs.SetInt("EventFlag",0);
              }
 
    }

    IEnumerator ShopCoroutine(){
      yield return new WaitForSeconds(1.5f);
      AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound1);
      eventPanel.SetActive(true);
      CanvasGroup eventcan = eventPanel.GetComponent<CanvasGroup>();
      eventcan.blocksRaycasts = true;
      Transform shoptran = eventPanel.GetComponent<Transform>();
        shoptran.DOScale (new Vector2(1f,1f),0.1f )
        .SetEase(Ease.InQuart);　
        event_text.text = "ショップが\n解放されました！";
        EventControll();
    }

    IEnumerator MugenCoroutine(){
      yield return new WaitForSeconds(1.5f);
      AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound1);
      eventPanel.SetActive(true);
      CanvasGroup eventcan = eventPanel.GetComponent<CanvasGroup>();
      eventcan.blocksRaycasts = true;
      Transform shoptran = eventPanel.GetComponent<Transform>();
        shoptran.DOScale (new Vector2(1f,1f),0.1f )
        .SetEase(Ease.InQuart);　
        event_text.text = " ムゲンモードが\n解放されました！";
        EventControll();
        StartCoroutine("ReviewCoroutine");
    }

    IEnumerator ReviewCoroutine(){
      yield return new WaitForSeconds(1.5f);
      ShowReview();
    }

    public void EventClose(){
      AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
      Transform eventtran = eventPanel.GetComponent<Transform>();
        eventtran.DOScale (new Vector2(0f,0f),0.1f )
        .SetEase(Ease.InQuart);　
      CanvasGroup eventcan = eventPanel.GetComponent<CanvasGroup>();
      eventcan.blocksRaycasts = false;
        EventControll();
    }

    

    public void StageOpen(GameObject x)
    {
        Transform y = x.GetComponent<Transform>();
    y.DOScale(new Vector2(50f,50f),0f );
    y.DOScale (new Vector2(10f,10f),1.5f )
        .SetEase(Ease.InExpo);　
     PlayerPrefs.SetInt("EventFlag",0);
     EventControll();
     }



      public void EventControll()
      {
          CanvasGroup scenepanel = scenePanel.GetComponent<CanvasGroup>();
          scenepanel.blocksRaycasts = true;
          StartCoroutine("ScenePanelCoroutine");
      }

    IEnumerator ScenePanelCoroutine () {    

    	yield return new WaitForSeconds(1.5f);
        ///シーン
        CanvasGroup scenepanel = scenePanel.GetComponent<CanvasGroup>();
        scenepanel.blocksRaycasts = false;
           }

           public void ShowReview()
          {

          #if UNITY_IOS
            if (Device.RequestStoreReview())
            {
                //iOSのレビュー依頼機能呼び出し
            }
           #else
       // Androidは自前でレビュー依頼画面作成
           #endif

    }



}
                 // PlayerPrefs.GetInt("StageLevel")現在解放されているステージの数
                // PlayerPrefs.GetInt("ThisStageLevel")直近でプレイしたステージ
                //PlayerPrefs.GetInt("EventFlag")1だとタイトル画面でEvent発生0だと何もなし