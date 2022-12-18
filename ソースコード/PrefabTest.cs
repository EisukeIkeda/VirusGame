using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
 
public class PrefabTest : MonoBehaviour {
        public GameObject prefab;
        public GameObject ready;
        public GameObject RetryButton;
        public GameObject TitleBuckButton;
        public int retryFrag = 0;
        public GameObject MugenLevelPanel;
        public GameObject mugenLevelText;
        public GameObject ThisMugenScore;
        public int mugenFrag = 0;
        public int mugenLevelControl;
        public GameObject shit;
        public GameObject newVirus;
        public GameObject mouse;
        public int mouseFrag;
        public GameObject mush;
        public GameObject bird;
        public GameObject bird2;
        public float birdX;
        public float birdY;
        public int birdFrag;
        public float remainTimeAdd;
        
        private float R = 1f;
        private float B = 1f;
        private float G = 1f;
        private float x;
        private int z;

        public TextMeshProUGUI textMeshPro;

        public GameObject main;

        public GameObject goText;
        public GameObject clearPanel;
        public GameObject gameOverPanel;
        
        public GameObject tutorialPanel;
        public Image tutorial_image;
        public Text tutorial_text;
        public Sprite tutorial1;
        public Sprite tutorial2;
        public Sprite tutorial3;
        public Sprite tutorial4;
        public Sprite tutorial5;
        
        public GameObject buttonTopPlease;
        public GameObject itemUseButton;
        public GameObject virusFull;
        public int fullText;
        public Transform parentTran;
        public Transform parentTran2;
        public Transform disturbPanel;
        public GameObject Level12Panel;
        public GameObject disinfectionPoint = null; // Textオブジェクト
        public GameObject remainingPoint = null; // Textオブジェクト
        public GameObject remainTimeText = null; // Textオブジェクト 
        public GameObject addPointText = null;
        public int clearPoint;
        public int remaining;
        private int eventNow;
        public float remainTime;
        public float mugenColor;
        public bool startEnd = false;

        int truePoint;

        public AudioClip sound1;
  　    public AudioClip sound2;
  　    public AudioClip sound3;

  　    public AudioSource BGM1;
        public AudioSource BGM2;
        public AudioSource BGM3;
        public AudioSource BGM4;
        
        private float time = 0.5f;
        private float time2 = 3.0f;
        private float time3 = 3.0f;
        private float time4 = 1.0f;
        private float time5 = 3.0f;

        private float vecX; ///出現X座標
        private float vecY; ///出現Y座標

        private float vecX2; ///出現X座標
        private float vecY2; ///出現Y座標

        private float vecX3; ///出現X座標
        private float vecY3; ///出現Y座標


 
    // Use this for initialization
    void OnEnable () {
        remainTimeAdd = 0f;
        Image maincolor = main.GetComponent<Image>();
        if(PlayerPrefs.GetInt("ThisStageLevel") == 10 || PlayerPrefs.GetInt("ThisStageLevel") == 11
        || PlayerPrefs.GetInt("ThisStageLevel") == 12){
                maincolor.color = new Color (0.3f,0.5f,0.3f,1f);
        }else{maincolor.color = new Color (1f,1f,1f,1f);}
        if(PlayerPrefs.GetInt("ThisStageLevel")==100 || PlayerPrefs.GetInt("MugenLevelSave") < 1){
            PlayerPrefs.SetInt("MugenLevel",1);
        }
        
            
        Time.timeScale = 0;
        ready.SetActive(true);
        clearPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        goText.SetActive(false);
        tutorialPanel.SetActive(false);
        PlayerPrefs.SetInt("HereDisinfection",0);
        PlayerPrefs.SetInt("DisinfectionPoint" , 0); ///スコアをリセット
        PlayerPrefs.SetInt("AddPoint",0);
        PlayerPrefs.SetFloat("chain",0f);
        PlayerPrefs.SetInt("Ice",0);
        PlayerPrefs.SetInt("Mitikieru",0);
        PlayerPrefs.SetInt("Weakened",0);
        PlayerPrefs.SetInt("Spawner",0);
        PlayerPrefs.SetInt("NewVirusDestroy",0);
        StartCoroutine ("Coroutine");
        eventNow = 0;
        if(PlayerPrefs.GetInt("ThisStageLevel") == 100){
        if(PlayerPrefs.GetInt("MugenLevelSave") >= 1){
        PlayerPrefs.SetInt("MugenLevel",PlayerPrefs.GetInt("MugenLevelSave"));
        MugenLevelControl();
        remainTime = PlayerPrefs.GetFloat("MugenRemainTime");
        PlayerPrefs.SetInt("DisinfectionPoint",PlayerPrefs.GetInt("MugenDisinfectionPoint"));
        clearPoint = PlayerPrefs.GetInt("DisinfectionPoint") + PlayerPrefs.GetInt("MugenLevel") * 100 * mugenLevelControl;
        }else{
            clearPoint = 10;
            remaining = clearPoint;
            remainTime = 60f;}
        }else{
        remainTime = PlayerPrefs.GetFloat("TimeLimit");
        clearPoint = PlayerPrefs.GetInt("Clear");}
        if(PlayerPrefs.GetInt("StageLevel") > 4){
            itemUseButton.SetActive(true);
            }
    }

        IEnumerator Coroutine () {
  		yield return new WaitForSecondsRealtime(3.0f);
		Time.timeScale = 1;
        ready.SetActive(false);
        goText.SetActive(true);
        int x = 0;
        int y = 0;
        while(x < PlayerPrefs.GetInt("TotalVirus"))
        {
             VirusSpawn();
             x++;
        }
        if(PlayerPrefs.GetInt("ThisStageLevel") == 100){
            while(y < PlayerPrefs.GetInt("MugenNewVirus"))
        {
             NewVirusSpawn();
             y++;
             mugenFrag = 0;
        }
        }
        BGMControllerStart();
        if(PlayerPrefs.GetInt("StageLevel") >= 1 & PlayerPrefs.GetInt("StageLevel") <= 5){
        StartCoroutine("cococo");
                }
        StartCoroutine("GoCoroutine");}

        IEnumerator cococo()
        {
            yield return new WaitForSecondsRealtime(1.0f);
            TutorialControl();
        }

        IEnumerator GoCoroutine(){
            yield return new WaitForSeconds(1.0f);
            goText.SetActive(false);
            startEnd = true;
        }

    void Start()
    {
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        
        if(PlayerPrefs.GetInt("ThisStageLevel") == 3){
           ShitSpawn();
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 4){
            NewVirusSpawn();
            NewVirusSpawn();
            NewVirusSpawn();
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 5){
            NewVirusSpawn();NewVirusSpawn();NewVirusSpawn();
            NewVirusSpawn();NewVirusSpawn();NewVirusSpawn();
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 6){
           ShitSpawn();
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 8){
            mouseFrag = 1;
            MouseSpawn();MouseSpawn();MouseSpawn();
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 9){
            mush.SetActive(true);
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 10){
            birdFrag = 1;
            audioSource.PlayOneShot(sound1);
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 11){
            mouseFrag = 1;
            birdFrag = 1;
            audioSource.PlayOneShot(sound1);
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 12){
            mouseFrag = 1;
            birdFrag = 1;
            Level12Panel.SetActive(true);
            audioSource.PlayOneShot(sound1);
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 14 || PlayerPrefs.GetInt("ThisStageLevel") == 15){
            while(z < 10)
        {
             NewVirusSpawn();
             z++;
        }
        }if(PlayerPrefs.GetInt("MugenLevel") >= 50){
            mush.SetActive(true);
        }
    }
    

       void Update()
    {
        if(retryFrag == 1 & PlayerPrefs.GetInt("NewVirusDestroy") == 1){
            PlayerPrefs.SetInt("NewVirusDestroy",0);
        }

        remainTime -= Time.deltaTime;
        remaining = clearPoint - PlayerPrefs.GetInt("DisinfectionPoint");

        Text score_text = disinfectionPoint.GetComponent<Text> ();
        score_text.text = "Score:" + PlayerPrefs.GetInt("DisinfectionPoint");

        if(PlayerPrefs.GetInt("ThisStageLevel") < 100){
         if(remaining > 0)
          {  Text remaining_text = remainingPoint.GetComponent<Text> ();
            remaining_text.text = "残り" + remaining;}

            else if (remaining <= 0)
            { 
                Text remaining_text = remainingPoint.GetComponent<Text> ();
            remaining_text.text = "残り0";
                Clear();
            }

         if(remainTime > 0 & remaining > 0)
          {
            Text time_text = remainTimeText.GetComponent<Text> ();
         time_text.text = "残り時間" + remainTime.ToString("F2");
         }

          else if(remainTime <= 0 & remaining > 0)
          {
           Text time_text = remainTimeText.GetComponent<Text> ();
           time_text.text = "残り時間0";
           truePoint = PlayerPrefs.GetInt("AddPoint") + PlayerPrefs.GetInt("DisinfectionPoint");
           if(truePoint <= clearPoint & PlayerPrefs.GetFloat("chain") <= 0){
            GameOver();
            }}}


    if(PlayerPrefs.GetInt("ThisStageLevel") == 100){
        　if(remaining > 0)
          {  Text remaining_text = remainingPoint.GetComponent<Text> ();
            remaining_text.text = "残り" + remaining;}

            else if (remaining <= 0 & mugenFrag == 0 & startEnd == true)
            { 
                mugenFrag = 1;
                clearPoint = PlayerPrefs.GetInt("DisinfectionPoint");
                if(PlayerPrefs.GetInt("MugenHiScore") < PlayerPrefs.GetInt("DisinfectionPoint")){
                   PlayerPrefs.SetInt("MugenHiScore" , PlayerPrefs.GetInt("DisinfectionPoint"));
               }if(PlayerPrefs.GetInt("MugenHiLevel") < PlayerPrefs.GetInt("MugenLevel")){
                   PlayerPrefs.SetInt("MugenHiLevel" , PlayerPrefs.GetInt("MugenLevel"));
               }
                Text remaining_text = remainingPoint.GetComponent<Text> ();
                remaining_text.text = "残り0";
                Debug.Log("むげんれゔぇるあっぷ");
                   PlayerPrefs.SetInt("HereDisinfection",PlayerPrefs.GetInt("DisinfectionPoint") - PlayerPrefs.GetInt("HereDisinfection"));
                   PlayerPrefs.SetInt("MugenLevel" , PlayerPrefs.GetInt("MugenLevel") + 1);
                   PlayerPrefs.SetInt("MugenLevelSave",PlayerPrefs.GetInt("MugenLevel"));
                    MugenLevelControl();
                    remainTimeAdd = PlayerPrefs.GetInt("HereDisinfection") * 0.003f / mugenLevelControl　/ mugenLevelControl;  
                       StartCoroutine ("MugenCoroutine"); 
            }else if(remaining <= 0 & mugenFrag == 1){

            }
            

       　 if(remainTime > 0 & remaining > 0)
        {
            Text time_text = remainTimeText.GetComponent<Text> ();
        time_text.text = "残り時間" + remainTime.ToString("F2");
        }

        　else if(remainTime <= 0 & remaining > 0 & mugenFrag != 1)
        {
           Text time_text = remainTimeText.GetComponent<Text> ();
           time_text.text = "残り時間0";
           truePoint = PlayerPrefs.GetInt("AddPoint") + PlayerPrefs.GetInt("DisinfectionPoint");
           if(truePoint <= clearPoint & PlayerPrefs.GetFloat("chain") <= 0){
            GameOver();
            }
        }
        }
        




         if(PlayerPrefs.GetInt("AddPoint") >= 1)
        {   vecX3 = Random.Range(-2.0f,-1.8f);
            vecY3 = Random.Range(4f,3.5f);
            GameObject obj = Instantiate(addPointText, new Vector3(vecX3,vecY3,5f), Quaternion.identity);
            obj.transform.SetParent(parentTran2);
        }






        time -= Time.deltaTime;
 
        if(time <= 0.0f & PlayerPrefs.GetInt("TotalVirus") <= 200)
        {
            time = PlayerPrefs.GetFloat("SpawnLevel");
            VirusSpawn();
            PlayerPrefs.SetInt("TotalVirus", PlayerPrefs.GetInt("TotalVirus") + 1);
        }if(PlayerPrefs.GetInt("TotalVirus") > 200 & fullText == 0){
            VirusFull();
        }if(PlayerPrefs.GetInt("TotalVirus") > 200 & fullText == 1 & eventNow == 0){
            fullText = 0;
        }



        time2 -= Time.deltaTime;///ステージごとのやつは[time2]を使う

        if(time2 <= 0.0f & PlayerPrefs.GetInt("shit") > 0){
            time2 = PlayerPrefs.GetInt("shit");
            ShitSpawn();
        }


        time3 -= Time.deltaTime;

        if(time3 <= 0.0f & PlayerPrefs.GetFloat("NewVirus") > 0f){
            time3 = PlayerPrefs.GetFloat("NewVirus");
            NewVirusSpawn();
            if(PlayerPrefs.GetInt("ThisStageLevel") == 100){
            PlayerPrefs.SetInt("MugenNewVirus", PlayerPrefs.GetInt("MugenNewVirus") + 1);
            }
        }
        if(PlayerPrefs.GetInt("Mitikieru") == 1 & time3 <= 10f){
                time3 += 10f;
            }


        time4 -= Time.deltaTime;

        if(time4 <= 0.0f & mouseFrag > 0){
            time4 = 3f;
            MouseSpawn();
        }


        time5 -= Time.deltaTime;

        if(time5 <= 0.0f & birdFrag > 0){
            BirdSpawn();
            birdX = Random.Range(3f,20f);
            time5 = birdX;
        }

    }

    public void MugenLevelControl(){
        PlayerPrefs.SetInt("Money" ,PlayerPrefs.GetInt("Money") +PlayerPrefs.GetInt("HereDisinfection"));

        x = PlayerPrefs.GetInt("MugenLevel");
        R = 1f - x / 900 ; B = 1f - x / 300; G = 1f - x / 300;
        Image maincolor = main.GetComponent<Image>();
        maincolor.color = new Color (R,G,B,1f);
        if(PlayerPrefs.GetInt("MugenLevel") <= 5){ ///レベルコントロール
                       mugenLevelControl = 1;
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 10){
                       mugenLevelControl = 3;
                       time2 = 20f;
                       PlayerPrefs.SetInt("shit", 20 );
                       PlayerPrefs.SetFloat("SpawnLevel" , 0.8f);
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 15){
                       mugenLevelControl = 5;
                       time3 = 20f;
                       PlayerPrefs.SetFloat("NewVirus", 20f );
                       time4 = 3f;
                       mouseFrag = 1;
                       PlayerPrefs.SetFloat("SpawnLevel" , 0.6f);
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 20){
                        PlayerPrefs.SetFloat("NewVirus", 18f );
                       mugenLevelControl = 8;
                       mouseFrag = 0;
                       time5 = 10f;
                       birdFrag = 1;
                       PlayerPrefs.SetFloat("SpawnLevel" , 0.5f);
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 25){
                       mugenLevelControl = 10;
                       PlayerPrefs.SetInt("shit", 18 );
                       time4 = 3f;
                       mouseFrag = 1;
                       birdFrag = 0;
                       PlayerPrefs.SetFloat("NewVirus", 16f );
                       PlayerPrefs.SetFloat("SpawnLevel" , 0.4f);
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 30){
                       mugenLevelControl = 15;
                       mouseFrag = 0;
                       time5 = 10f;
                       birdFrag = 1;
                      
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 35){
                       mugenLevelControl = 20;
                       PlayerPrefs.SetInt("shit", 17 );
                       time4 = 3f;
                       mouseFrag = 1;
                       birdFrag = 0;
                       PlayerPrefs.SetFloat("NewVirus", 15f );
                       PlayerPrefs.SetFloat("SpawnLevel" , 0.3f);
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 40){
                       mugenLevelControl = 25;
                       mouseFrag = 0;
                       time5 = 10f;
                       birdFrag = 1;
                      
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 45){
                       mugenLevelControl = 30;
                       PlayerPrefs.SetInt("shit", 16 );
                       time4 = 3f;
                       mouseFrag = 1;
                       birdFrag = 0;
                       PlayerPrefs.SetFloat("NewVirus", 12f );
                       PlayerPrefs.SetFloat("SpawnLevel" , 0.2f);
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 50){
                       mugenLevelControl = 35;
                       mouseFrag = 0;
                       time5 = 10f;
                       birdFrag = 1;
                       mush.SetActive(true);
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 55){
                       mugenLevelControl = 40;
                       PlayerPrefs.SetInt("shit", 15 );
                       time4 = 3f;
                       mouseFrag = 1;
                       birdFrag = 0;
                       PlayerPrefs.SetFloat("NewVirus", 10f );
                       PlayerPrefs.SetFloat("SpawnLevel" , 0.1f);
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 60){
                       mugenLevelControl = 45;
                       mouseFrag = 0;
                       time5 = 10f;
                       birdFrag = 1;
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 65){
                       mugenLevelControl = 50;
                       PlayerPrefs.SetInt("shit", 14 );
                       time4 = 3f;
                       mouseFrag = 1;
                       birdFrag = 0;
                       PlayerPrefs.SetFloat("NewVirus", 8f );
                       PlayerPrefs.SetFloat("SpawnLevel" , 0.1f);
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 70){
                       mugenLevelControl = 55;
                       mouseFrag = 0;
                       time5 = 10f;
                       birdFrag = 1;
                       
                    }else if(PlayerPrefs.GetInt("MugenLevel") <= 75){
                       mugenLevelControl = 60;
                       PlayerPrefs.SetInt("shit", 13 );
                       time4 = 3f;
                       mouseFrag = 1;
                       birdFrag = 0;
                       PlayerPrefs.SetFloat("NewVirus", 5f );
                       
                    }else{mugenLevelControl = 60;
                    time5 = 10f;
                    birdFrag = 1;}
                   
                  
                   ///time2 newvirus time3 shit 使うときに０以上を代入
    }


    IEnumerator MugenCoroutine () {  
        CanvasGroup mugenLevelPanel = MugenLevelPanel.GetComponent<CanvasGroup>();
        Transform mugentran = MugenLevelPanel.GetComponent<Transform>();
        MugenLevelPanel.SetActive(true);
        mugenLevelPanel.blocksRaycasts = true;
    	yield return new WaitForSecondsRealtime(2.0f);
        Time.timeScale = 0;
        GameObject text = Instantiate(mugenLevelText, new Vector3(2.5f,2f,1f), Quaternion.identity);
        text.transform.SetParent(mugentran);
        clearPoint = clearPoint + PlayerPrefs.GetInt("MugenLevel") * 100 * mugenLevelControl;
        PlayerPrefs.SetInt("HereDisinfection",PlayerPrefs.GetInt("DisinfectionPoint"));
        PlayerPrefs.SetFloat("MugenRemainTime",remainTime + remainTimeAdd);
        remainTime += remainTimeAdd;
        yield return new WaitForSecondsRealtime(3.0f);
        Time.timeScale = 1;
        mugenLevelPanel.blocksRaycasts = false;
        MugenLevelPanel.SetActive(false);
        mugenFrag = 0;
        PlayerPrefs.SetInt("MugenDisinfectionPoint",PlayerPrefs.GetInt("DisinfectionPoint"));
        }



    public void VirusSpawn()
    {
        vecX = Random.Range(-2.3f,2.3f);
        vecY = Random.Range(4.3f,-1.3f);
        GameObject obj = Instantiate(prefab, new Vector3(vecX,vecY,1f), Quaternion.identity);
        obj.transform.SetParent(parentTran);
        // Cubeプレハブを元に、インスタンスを生成、        
    }


    public void ShitSpawn()
    {
       vecX2 = Random.Range(-2.3f,2.3f);
        vecY2 = Random.Range(4.3f,-1.3f);
        GameObject obt = Instantiate(shit, new Vector3(vecX2,vecY2,1f), Quaternion.identity);
        obt.transform.SetParent(disturbPanel);
    }

    public void NewVirusSpawn()
    {
        vecX = Random.Range(-2.3f,2.3f);
        vecY = Random.Range(4.3f,-1.3f);
        GameObject oc = Instantiate(newVirus, new Vector3(vecX,vecY,1f), Quaternion.identity);
        oc.transform.SetParent(parentTran);
        Debug.Log("沸いた！");
    }

    public void MouseSpawn()
    {
        vecX = Random.Range(-20.3f,-3.3f);
        vecY = Random.Range(3.3f,-0.3f);
        GameObject mou = Instantiate(mouse, new Vector3(vecX,vecY,1f), Quaternion.identity);
        mou.transform.SetParent(disturbPanel);
    }

    public void BirdSpawn(){
        birdY = Random.Range(0f,5f);
        if(birdY <= 2.5f){
        GameObject birdprefab = Instantiate(bird, new Vector3(-2f,2.3f,1f), Quaternion.identity);
        birdprefab.transform.SetParent(disturbPanel);}
        if(birdY > 2.5f){
        GameObject birdprefab2 = Instantiate(bird2, new Vector3(2f,2.3f,1f), Quaternion.identity);
        birdprefab2.transform.SetParent(disturbPanel);}
        StartCoroutine("BirdCoroutine");
      }

    IEnumerator BirdCoroutine () {
        yield return new WaitForSeconds(1f);
        ShitSpawn();
    } 


  ///BGMコントロール
　　 public void BGMControllerStart()
    {
        if(PlayerPrefs.GetInt("ThisStageLevel") >= 1 & PlayerPrefs.GetInt("ThisStageLevel") <= 4 
        || PlayerPrefs.GetInt("ThisStageLevel") >= 6 & PlayerPrefs.GetInt("ThisStageLevel") <= 9
        || PlayerPrefs.GetInt("ThisStageLevel") == 100
        || PlayerPrefs.GetInt("ThisStageLevel") == 11 || PlayerPrefs.GetInt("ThisStageLevel") == 13
        || PlayerPrefs.GetInt("ThisStageLevel") == 15){
        BGM1.Play();
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 5 
        || PlayerPrefs.GetInt("ThisStageLevel") == 10 ){
        BGM2.Play();
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 12){
            BGM3.Play();
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 12){
            BGM3.Play();
        }if(PlayerPrefs.GetInt("ThisStageLevel") == 14){
            BGM4.Play();
        }
    }

    public void BGMControllerStop()
    {
        
        BGM1.Stop();
        BGM2.Stop();
        BGM3.Stop();
        BGM4.Stop();
        
    }

    ///ここまで




    public void Retry()
    {
        TitleBuckButton.SetActive(false);
        BGMControllerStart();
        gameOverPanel.SetActive(false);
        CanvasGroup full_text = virusFull.GetComponent<CanvasGroup> ();
        eventNow = 0;
        remainTime = remainTime + 60f;
        retryFrag = 1;
        Time.timeScale = 1;
    }



    public void Clear()///クリア時の処理
    {
        　　　　if(PlayerPrefs.GetInt("StageLevel") == PlayerPrefs.GetInt("ThisStageLevel"))
               {
                   PlayerPrefs.SetInt("StageLevel" , PlayerPrefs.GetInt("StageLevel") + 1);
                   PlayerPrefs.SetInt("EventFlag" , 1);///1だとタイトル画面でEvent発生
               }if(PlayerPrefs.GetInt("HiScore") < PlayerPrefs.GetInt("DisinfectionPoint")){
                   PlayerPrefs.SetInt("HiScore" , PlayerPrefs.GetInt("DisinfectionPoint"));
               }
               BGMControllerStop();
               clearPanel.SetActive(true);
               CanvasGroup full_text = virusFull.GetComponent<CanvasGroup> ();
               full_text.DOFade(0,0);
               eventNow = 1;
               mouseFrag = 0;
               birdFrag = 0;
               StartCoroutine ("ClearCoroutine");
               
                   
               
    }
    IEnumerator ClearCoroutine () 
    {
  	 　　　yield return new WaitForSecondsRealtime(1.0f);
     　　　buttonTopPlease.SetActive(true);
    }





    public void GameOver()///ゲームオーバー時の処理
    {
        PlayerPrefs.SetInt("NewVirusDestroy",1);
        Time.timeScale = 0;
        if(retryFrag == 1){
            RetryButton.SetActive(false);
        }
        BGMControllerStop();
        PlayerPrefs.SetFloat("chain",0f);
        gameOverPanel.SetActive(true);
        TitleBuckButton.SetActive(true);
        if(PlayerPrefs.GetInt("ThisStageLevel")==100){
            Text score_text = ThisMugenScore.GetComponent<Text>();
            ThisMugenScore.SetActive(true);
            score_text.text =PlayerPrefs.GetInt("MugenLevel")+"Lv";
             PlayerPrefs.SetInt("MugenGameOver",1);
        }
        CanvasGroup full_text = virusFull.GetComponent<CanvasGroup> ();
        full_text.DOFade(0,0);
        eventNow = 1;
    }


    public void VirusFull()
    {
        CanvasGroup full_text = virusFull.GetComponent<CanvasGroup> ();
        full_text.DOFade(1,0);
    }

    
    public void TutorialControl()
    {
        Transform panel = tutorialPanel.GetComponent<Transform>();
        if(PlayerPrefs.GetInt("StageLevel") == 1 & PlayerPrefs.GetInt("ThisStageLevel") == 1){
            tutorial_image.sprite = tutorial1;
            tutorial_text.text = "ウイルスを消毒してみよう\n\n指でなぞると\nウイルスが消えるよ" ;
            panel.DOScale(new Vector2(0f,0f),0f);
        tutorialPanel.SetActive(true);
        panel.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　
        Time.timeScale = 0;
        }if(PlayerPrefs.GetInt("StageLevel") == 2 & PlayerPrefs.GetInt("ThisStageLevel") == 2){
            tutorial_image.sprite = tutorial2;
            tutorial_text.text = "ウイルスを連続で消してみよう\n\n連鎖がつながると\nポイントアップ！" ;
            panel.DOScale(new Vector2(0f,0f),0f);
        tutorialPanel.SetActive(true);
        panel.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　
        Time.timeScale = 0;
        }if(PlayerPrefs.GetInt("StageLevel") == 3 & PlayerPrefs.GetInt("ThisStageLevel") == 3){
            tutorial_image.sprite = tutorial3;
            panel.DOScale(new Vector2(0f,0f),0f);
        tutorialPanel.SetActive(true);
        panel.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　
        Time.timeScale = 0;
            tutorial_text.text = "お邪魔\n\nステージによって色々な\n仕掛けがある\n臨機応変に\n対応しよう！" ;
        }if(PlayerPrefs.GetInt("StageLevel") == 4 & PlayerPrefs.GetInt("ThisStageLevel") == 4){
            tutorial_image.sprite = tutorial4;
            tutorial_text.text = "未知のウイルス\n\n未知のウイルスは\n触っても消えない\n連鎖中に触ってしまうと\n連鎖が途切れてしまう" ;
            panel.DOScale(new Vector2(0f,0f),0f);
        tutorialPanel.SetActive(true);
        panel.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　
        Time.timeScale = 0;
        }if(PlayerPrefs.GetInt("StageLevel") == 5 & PlayerPrefs.GetInt("ThisStageLevel") == 5){
            tutorial_image.sprite = tutorial5;
            tutorial_text.text = "アイテム\n\nゲージが溜まると\n使うことができる\n効果はショップで確認\nすることができる" ;
            panel.DOScale(new Vector2(0f,0f),0f);
        tutorialPanel.SetActive(true);
        panel.DOScale (new Vector2(1f,1f),0.3f )
        .SetEase(Ease.InQuart);　　
        Time.timeScale = 0;
        }
        StartCoroutine ("TutorialCoroutine");
    }
    IEnumerator TutorialCoroutine () 
    {
  	 　　　yield return new WaitForSecondsRealtime(1.0f);
     　　　CanvasGroup can = tutorialPanel.GetComponent<CanvasGroup>();
          can.blocksRaycasts = (true);
    }

    public void TutorialClick(){
        Time.timeScale = 1;
        Transform panel = tutorialPanel.GetComponent<Transform>();
        CanvasGroup can = tutorialPanel.GetComponent<CanvasGroup>();
        can.blocksRaycasts = (false);
        panel.DOScale(new Vector2(0f,0f),0.3f);
        tutorialPanel.SetActive(false);
    }

 
}