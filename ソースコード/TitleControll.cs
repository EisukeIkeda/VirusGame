using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class TitleControll : MonoBehaviour
{
    public GameObject FirstPanel;
    public GameObject stagePanel;
    public GameObject stagePanel2;
    public GameObject stagePanel3;
    public GameObject MugenPanel;
    public GameObject panel;
    public int mugenMode = 0;
    public GameObject stageInfo;
    public GameObject levelText;
    public GameObject normaText;
    public GameObject infoText;
    public GameObject gameStartImage;
    public GameObject scenePanel;
    public GameObject shopPanel;
    public GameObject StartPanel;
    public GameObject mugenGhangeButton;

     　 public AudioSource BGM1;
        public AudioSource BGM2;

    public Text mugenHiScore_text;
    public Text mugenHiLevel_text;

 　 public AudioClip sound1;
  　public AudioClip sound2;
  　public AudioClip sound3;
  　public AudioClip sound4; 
    public AudioClip mugenClick;

  　public GameObject risettoDebug;



    public void RESET()
    {
        risettoDebug.SetActive(true);
    }
    public void DateReset()///デバック用最後に消す
    {
　　　　　PlayerPrefs.DeleteAll();
        risettoDebug.SetActive(false);
    }
    public void MugenChange(){
        if(mugenMode == 0){
            MugenPanel.SetActive(true);
            mugenGhangeButton.SetActive(true);
            panel.SetActive(false);
            mugenMode = 1;
        }else if(mugenMode == 1){
            MugenPanel.SetActive(false);
            panel.SetActive(true);
            mugenGhangeButton.SetActive(false);
            mugenMode = 0;
        }
        BGMControllerStop();
        BGMControllerStart();
    }

    void Start(){
        Time.timeScale = 1;
        if(PlayerPrefs.GetInt("ThisStageLevel")!=100){
        PlayerPrefs.SetInt("Money" ,PlayerPrefs.GetInt("Money") + PlayerPrefs.GetInt("DisinfectionPoint"));}
        if(PlayerPrefs.GetInt("MugenGameOver")==1){
        PlayerPrefs.SetInt("MugenLevel",0);
        PlayerPrefs.SetInt("MugenLevelSave",0);
        PlayerPrefs.SetFloat("MugenRemainTime",0);
        PlayerPrefs.SetInt("MugenDisinfectionPoint",0);
        PlayerPrefs.SetInt("MugenNewVirus",0);
        PlayerPrefs.SetInt("MugenGameOver",0);
        }
               PlayerPrefs.SetInt("DisinfectionPoint" , 0);
               
               mugenHiScore_text.text = "" + PlayerPrefs.GetInt("MugenHiScore");
               mugenHiLevel_text.text = "" + PlayerPrefs.GetInt("MugenHiLevel");
               scenePanel.SetActive(false);

               BGMControllerStart();

    }

    public void MenuStart()
    {
        Transform tran = StartPanel.GetComponent<Transform>();
        CanvasGroup can = FirstPanel.GetComponent<CanvasGroup>();
        can.blocksRaycasts = false;
        tran.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        SceneSE();
        Debug.Log("メニュースタート");
    }

    public void StartButtonClick()
    {
        if(PlayerPrefs.GetInt("StageLevel") <= 5){
            SceneSE();
        stagePanel.SetActive(true);
        Transform tran = stagePanel.GetComponent<Transform>();
        tran.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        }else if(PlayerPrefs.GetInt("StageLevel") <= 10){
            SceneSE();
        stagePanel2.SetActive(true);
        Transform tran2 = stagePanel2.GetComponent<Transform>();
        tran2.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        }else{
            SceneSE();
        stagePanel3.SetActive(true);
        Transform tran3 = stagePanel3.GetComponent<Transform>();
        tran3.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        }
         
    }

    public void TitleBack()
    {
        Transform tran = stagePanel.GetComponent<Transform>();
        tran.DOScale (new Vector2(1f,0f),0.3f )
        .SetEase(Ease.InQuart);　　　　　//時間
        Transform tran2 = stagePanel2.GetComponent<Transform>();
        tran2.DOScale (new Vector2(1f,0f),0.3f )
        .SetEase(Ease.InQuart);　　　　　//時間
        Transform tran3 = stagePanel3.GetComponent<Transform>();
        tran3.DOScale (new Vector2(1f,0f),0.3f )
        .SetEase(Ease.InQuart);　
        EventControll();
        SceneSE();
        Debug.Log("タイトルバッくん");
    }

    public void InfoBuck()
    {
        Transform trana = stageInfo.GetComponent<Transform>();
        trana.DOScale (new Vector2(0f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　　//時間
        EventControll();
        SceneSE();
    }

    public void StageNext()
    {
        stagePanel2.SetActive(true);
        Transform tran = stagePanel2.GetComponent<Transform>();
        tran.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        SceneSE();
    }
    public void StageNext2()
    {
        stagePanel3.SetActive(true);
        Transform tran3 = stagePanel3.GetComponent<Transform>();
        tran3.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        SceneSE();
    }

        public void StageBack()
    {
        stagePanel2.SetActive(false);
        stagePanel.SetActive(true);
        stagePanel3.SetActive(false);
        Transform tran = stagePanel.GetComponent<Transform>();
        tran.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        SceneSE();
    }

    public void StageBack2()
    {
        stagePanel3.SetActive(false);
        stagePanel2.SetActive(true);
        stagePanel.SetActive(false);
        Transform tran2 = stagePanel2.GetComponent<Transform>();
        tran2.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        SceneSE();
    }

    public void ShopOpen()
        {
        Transform tran = shopPanel.GetComponent<Transform>();
        tran.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        SceneSE();
        PlayerPrefs.SetInt("ShopOpen",1);
        Debug.Log("ショップオープン");
        }

        public void ShopBack()
        {
        Transform tran = shopPanel.GetComponent<Transform>();
        tran.DOScale (new Vector2(0f,0f),0.3f )
        .SetEase(Ease.InQuart);　　　　
        EventControll();
        SceneSE();
        Debug.Log("しょっぷばっく");
        }





    public void GameStart()
    {
        Transform hanko = gameStartImage.GetComponent<Transform>();
        CanvasGroup can = gameStartImage.GetComponent<CanvasGroup>();
        CanvasGroup scenepanel = scenePanel.GetComponent<CanvasGroup>();
        can.DOFade(1,1);
        hanko.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　
        scenePanel.SetActive(true);
        scenepanel.blocksRaycasts = true;
        StartCoroutine ("Coroutine");         
    }

        IEnumerator Coroutine () {    

        for(int i=0;i<1;++i)
	　　　{
		   yield return coSub();
	　　　}
    	yield return new WaitForSeconds(1.0f);
        ///シーン
        SceneManager.LoadScene("GameScene");
           }

　　　IEnumerator coSub()
　　　{
    for(int i=0;i<1;++i)
	　　　{
		   yield return cocoSub();
	　　　}
    CanvasGroup scenepanel = scenePanel.GetComponent<CanvasGroup>();
    
	yield return new WaitForSeconds(2.0f);
    scenepanel.DOFade(1,1);
　　　}

　　　IEnumerator cocoSub()
　　　{
	yield return new WaitForSeconds(0.3f);
    AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
    audioSource.PlayOneShot(sound1);
　　　}




     public void MugenStart()
    {
        CanvasGroup scenepanel = scenePanel.GetComponent<CanvasGroup>();
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(mugenClick);
        scenePanel.SetActive(true);
        StartCoroutine ("MugenCoroutine");   
        scenepanel.blocksRaycasts = true;      
    }

    IEnumerator MugenCoroutine () {    

        for(int i=0;i<1;++i)
	　　　{
		   yield return coMugenSub();
	　　　}
    	yield return new WaitForSeconds(1.0f);
        ///シーン
        SceneManager.LoadScene("GameScene");
           }

　　　IEnumerator coMugenSub()
　　　{
    CanvasGroup scenepanel = scenePanel.GetComponent<CanvasGroup>();
	yield return new WaitForSeconds(0.5f);
    scenepanel.DOFade(1,1);
　　　}






　　　public void SceneSE()
      {
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound2);
      }


      public void EventControll()
      {
          scenePanel.SetActive(true);
          CanvasGroup scenepanel = scenePanel.GetComponent<CanvasGroup>();
          scenepanel.blocksRaycasts = true;
          StartCoroutine("ScenePanelCoroutine");
      }

    IEnumerator ScenePanelCoroutine () {    

    	yield return new WaitForSeconds(0.5f);
        ///シーン
        CanvasGroup scenepanel = scenePanel.GetComponent<CanvasGroup>();
        scenepanel.blocksRaycasts = false;
        scenePanel.SetActive(false);
           }

///BGM設定
           public void BGMControllerStart()
    {
        if(MugenPanel.activeSelf){
        BGM1.Play();
        }else{
        StartCoroutine("BGMCoroutine");
        }
    }

    IEnumerator BGMCoroutine()
　　　{
	yield return new WaitForSeconds(0.5f);
    BGM2.Play();}

    public void BGMControllerStop()
    {
        
        BGM1.Stop();
        BGM2.Stop();
        
    }



///難易度設定↓

public void LevelChange()
{
　　　　　Transform tran = stageInfo.GetComponent<Transform>();
        tran.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　　　　//時間
        SceneSE();
}

public void MugenLevel()
    {
        PlayerPrefs.SetInt("ThisStageLevel",100);
        PlayerPrefs.SetInt("TotalVirus",5);
        PlayerPrefs.SetInt("Clear",10);
        PlayerPrefs.SetFloat("TimeLimit",30);
        PlayerPrefs.SetFloat("SpawnLevel",1);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",0);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel1()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "清掃準備";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "消毒員は常に清潔な\n身体で仕事に取り組む\n出勤時には必ず自分の\n身体を消毒すること";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "10\n30秒";
        PlayerPrefs.SetInt("ThisStageLevel",1);
        PlayerPrefs.SetInt("TotalVirus",1);
        PlayerPrefs.SetInt("Clear",10);
        PlayerPrefs.SetFloat("TimeLimit",30);
        PlayerPrefs.SetFloat("SpawnLevel",1);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",0);
        PlayerPrefs.SetInt("VirusSpawner",0);
        if(PlayerPrefs.GetInt("StageLevel") > 1){
            }else{PlayerPrefs.SetInt("StageLevel" , 1);
            }///Level1のみ
    }

        public void Lavel2()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "社内清掃";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "清掃会社たるもの\n社内は清潔であるべき\n時間を無駄にしないように\n一気に除菌しよう";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "100\n40秒";
        PlayerPrefs.SetInt("ThisStageLevel",2);
        PlayerPrefs.SetInt("TotalVirus",5);
        PlayerPrefs.SetInt("Clear",150);
        PlayerPrefs.SetFloat("TimeLimit",40f);
        PlayerPrefs.SetFloat("SpawnLevel",1);//スポーンの間隔
        PlayerPrefs.SetInt("shit", 0 );
        PlayerPrefs.SetFloat("NewVirus", 0f );
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

        public void Lavel3()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "公衆トイレ";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "準備ができたら\nまずは公共の掃除だ\n汚物がはねてもくじけず\nがんばれ！";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "800\n45秒";
        PlayerPrefs.SetInt("ThisStageLevel",3);
        PlayerPrefs.SetInt("TotalVirus",20);
        PlayerPrefs.SetInt("Clear",800);
        PlayerPrefs.SetFloat("TimeLimit",45f);
        PlayerPrefs.SetFloat("SpawnLevel",0.6f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",10);
        PlayerPrefs.SetFloat("NewVirus",0f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

            public void Lavel4()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "未知の病原菌";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "未知のウイルスが確認\nされた\n消毒方法は現在のところ\n確立されていない\n";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "800\n60秒";
        PlayerPrefs.SetInt("ThisStageLevel",4);
        PlayerPrefs.SetInt("TotalVirus",20);
        PlayerPrefs.SetInt("Clear",800);
        PlayerPrefs.SetFloat("TimeLimit",60f);
        PlayerPrefs.SetFloat("SpawnLevel",0.5f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",6f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }


    public void Lavel5()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "遺言";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "未知のウイルスのせいで\n私はもうダメみたいだ\n最後にお前にこれを託す\n今までありがとう\n";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "5000\n100秒";
        PlayerPrefs.SetInt("ThisStageLevel",5);
        PlayerPrefs.SetInt("TotalVirus",50);
        PlayerPrefs.SetInt("Clear",5000);
        PlayerPrefs.SetFloat("TimeLimit",100f);
        PlayerPrefs.SetFloat("SpawnLevel",0.2f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",1f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel6()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "旅立ち";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "未知のウイルスを消毒する\nため、私は立ち上がった\n社長の仇は必ず\n";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "5000\n60秒";
        PlayerPrefs.SetInt("ThisStageLevel",6);
        PlayerPrefs.SetInt("TotalVirus",30);
        PlayerPrefs.SetInt("Clear",5000);
        PlayerPrefs.SetFloat("TimeLimit",60f);
        PlayerPrefs.SetFloat("SpawnLevel",0.2f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",4);
        PlayerPrefs.SetFloat("NewVirus",1f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel7()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "お引っ越し";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "独り立ちして初の仕事は\n新事務所の清掃だった\n隅までしっかり\n消毒しよう";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "15000\n60秒";
        PlayerPrefs.SetInt("ThisStageLevel",7);
        PlayerPrefs.SetInt("TotalVirus",50);
        PlayerPrefs.SetInt("Clear",15000);
        PlayerPrefs.SetFloat("TimeLimit",60f);
        PlayerPrefs.SetFloat("SpawnLevel",0.08f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",1f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel8()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "飲食店";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "飲食店の清掃は\n特に念入りに行う\n一見綺麗に見えても\n実は多くのウイルスが\n潜んでいる";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "8000\n60秒";
        PlayerPrefs.SetInt("ThisStageLevel",8);
        PlayerPrefs.SetInt("TotalVirus",0);
        PlayerPrefs.SetInt("Clear",8000);
        PlayerPrefs.SetFloat("TimeLimit",60f);
        PlayerPrefs.SetFloat("SpawnLevel",1f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",5f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel9()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "廃屋";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "老齢の女性からの依頼だ\n30年ほど手付かずらしい\nこれは消毒しがいが\nありそうだ";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "24000\n60秒";
        PlayerPrefs.SetInt("ThisStageLevel",9);
        PlayerPrefs.SetInt("TotalVirus",100);
        PlayerPrefs.SetInt("Clear",24000);
        PlayerPrefs.SetFloat("TimeLimit",60f);
        PlayerPrefs.SetFloat("SpawnLevel",0.1f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",2.5f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel10()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "アマゾン";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "[未知のウイルス]に関する\n研究をしている施設がある\nという噂を聞いて\n私はアマゾンの奥地へと\nやってきた。";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "20000\n100秒";
        PlayerPrefs.SetInt("ThisStageLevel",10);
        PlayerPrefs.SetInt("TotalVirus",60);
        PlayerPrefs.SetInt("Clear",20000);
        PlayerPrefs.SetFloat("TimeLimit",100f);
        PlayerPrefs.SetFloat("SpawnLevel",0.35f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",2f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel11()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "アマゾン２";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "なぜアマゾンの奥地で\n研究をしていたのか\n謎は深まるばかりである。";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "25000\n60秒";
        PlayerPrefs.SetInt("ThisStageLevel",11);
        PlayerPrefs.SetInt("TotalVirus",60);
        PlayerPrefs.SetInt("Clear",25000);
        PlayerPrefs.SetFloat("TimeLimit",60f);
        PlayerPrefs.SetFloat("SpawnLevel",0.2f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",8);
        PlayerPrefs.SetFloat("NewVirus",3f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel12()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "アマゾン３";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "原住民族に捕まり、私は今\n謎の儀式を受けている。\n私もおそらくここまでだ。\n最後に消毒しておこう。";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "30000\n60秒";
        PlayerPrefs.SetInt("ThisStageLevel",12);
        PlayerPrefs.SetInt("TotalVirus",10);
        PlayerPrefs.SetInt("Clear",30000);
        PlayerPrefs.SetFloat("TimeLimit",60f);
        PlayerPrefs.SetFloat("SpawnLevel",0.5f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",8);
        PlayerPrefs.SetFloat("NewVirus",2.5f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel13()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "脱出";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "命からがら\n脱走した私は\n研究所への道を急いだ";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "35000\n60秒";
        PlayerPrefs.SetInt("ThisStageLevel",13);
        PlayerPrefs.SetInt("TotalVirus",80);
        PlayerPrefs.SetInt("Clear",35000);
        PlayerPrefs.SetFloat("TimeLimit",60f);
        PlayerPrefs.SetFloat("SpawnLevel",0.4f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",3);
        PlayerPrefs.SetFloat("NewVirus",2f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

public void Lavel14()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "研究所";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "ついに研究所に\nたどり着いた私は\nその汚さに驚愕した\nどうやら[未知のウイルス]が\n暴走しているらしい。";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "50000\n100秒";
        PlayerPrefs.SetInt("ThisStageLevel",14);
        PlayerPrefs.SetInt("TotalVirus",5);
        PlayerPrefs.SetInt("Clear",50000);
        PlayerPrefs.SetFloat("TimeLimit",100f);
        PlayerPrefs.SetFloat("SpawnLevel",0.3f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",1f);
        PlayerPrefs.SetInt("VirusSpawner",0);
    }

    public void Lavel15()
    {
        LevelChange();
        Text level_text = levelText.GetComponent<Text> ();
        level_text.text = "試薬品";
        Text info_text = infoText.GetComponent<Text> ();
        info_text.text = "研究所の中には\n[未知のウイルス]についての\n研究成果が残されていた。\n[未知のウイルス]の\n発生を抑える薬も\n開発されていた。";
        Text norma_text = normaText.GetComponent<Text> ();
        norma_text.text = "100000\n100秒";
        PlayerPrefs.SetInt("ThisStageLevel",15);
        PlayerPrefs.SetInt("TotalVirus",0);
        PlayerPrefs.SetInt("Clear",100000);
        PlayerPrefs.SetFloat("TimeLimit",100f);
        PlayerPrefs.SetFloat("SpawnLevel",0.5f);//スポーンの間隔
        PlayerPrefs.SetInt("shit",0);
        PlayerPrefs.SetFloat("NewVirus",0.5f);
        PlayerPrefs.SetInt("VirusSpawner",0);
        if(PlayerPrefs.GetInt("MitikieruLevel") == 0){
        PlayerPrefs.SetString("Set" , "mitikieru");
        PlayerPrefs.SetInt("MitikieruLevel" , 1);}
    }






}
