using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Image ItemImage;
    public GameObject InfoText = null;
    public Text InfoTextPurchase = null;
    public GameObject NameText = null;
    public GameObject LevelText = null;
    public Text effectTime_text;
    public Text coolTime_text;
    public GameObject Leveling;
    public int cost;
    public Text cost_text;
    public GameObject PurchaseButton;
    public GameObject PurchasePanel;
    public GameObject LevelUpButton;
    public GameObject DontHave;
    public GameObject SetButton;
    public GameObject SetText;
    public Text price_text;
    public Text moneyPossession;
    public Image purchaseImage;
    public GameObject NoMoney;
    public int price;

    public AudioClip sound1;
    public AudioClip set;
    public AudioClip purchaseSE;
    public AudioClip LevelUpSE;

    public string whatChoice = null;
    public GameObject IceBox;
    public GameObject SpawnBox;
    public GameObject MitikieruBox;
    public GameObject WeakenedBox;
    public GameObject MagnifyingGlassBox;
    public GameObject SpawnerRock;
    public GameObject MitikieruRock;
    public GameObject WeakenedRock;
    public GameObject MagnifyingGlass;
    public GameObject MagnifyingGlassRock;
    public Sprite iceSprite;
    public Sprite spawnerSprite;
    public Sprite mitikieruSprite;
    public Sprite magnifyingGlassSprite;
    public Sprite weakenedSprite;

    void Start(){
        if(PlayerPrefs.GetInt("IceLevel") == 1){
        PlayerPrefs.SetFloat("IceEffectTime" , 5f);
        PlayerPrefs.SetFloat("IceCoolTime" , 15f);
        }if(PlayerPrefs.GetInt("SpawnerLevel") <= 1){
            PlayerPrefs.SetFloat("SpawnerEffectTime" , 0.8f);
            PlayerPrefs.SetFloat("SpawnerCoolTime" , 10f);
        }if(PlayerPrefs.GetInt("MagnifyingGlassLevel") <= 1){
            PlayerPrefs.SetFloat("MagnifyingGlassEffectTime" , 10f);
            PlayerPrefs.SetFloat("MagnifyingGlassCoolTime" , 10f);
        }if(PlayerPrefs.GetInt("MitikieruLevel") <= 1){
            PlayerPrefs.SetFloat("MitikieruEffectTime" , 0.7f);
            PlayerPrefs.SetFloat("MitikieruCoolTime" , 12f);
        }if(PlayerPrefs.GetInt("WeakenedLevel") <= 1){
            PlayerPrefs.SetFloat("WeakenedEffectTime" , 1f);
            PlayerPrefs.SetFloat("WeakenedCoolTime" , 10f);
        }
    }


    public void Update(){
        
        if(PlayerPrefs.GetInt("ShopOpen") == 1){
            Reset();
            PlayerPrefs.SetInt("ShopOpen",0);
        }   
            }

    public void IceChoice()
    {
        AnyChoice();
      Image iceBox = IceBox.GetComponent<Image>();
      iceBox.color = new Color32(0,0,0,100);
      whatChoice = "ice";
      ItemBoxControll();
    }

    public void SpawnChoice()
    {
        AnyChoice();
      Image spawnBox = SpawnBox.GetComponent<Image>();
      spawnBox.color = new Color32(0,0,0,100);
      whatChoice = "spawner";
      ItemBoxControll();
    }

    public void WeakenedChoice()
    {
        AnyChoice();
      Image weakenedBox = WeakenedBox.GetComponent<Image>();
      weakenedBox.color = new Color32(0,0,0,100);
      whatChoice = "weakened";
      ItemBoxControll();
    }

    public void MagnifyingGlassChoice()
    {
        AnyChoice();
      Image magnifyingGlassBox = MagnifyingGlassBox.GetComponent<Image>();
      magnifyingGlassBox.color = new Color32(0,0,0,100);
      whatChoice = "magnifyingGlass";
      ItemBoxControll();
    }

    public void MitikieruChoice()
    {
        AnyChoice();
      Image mitikieruBox = MitikieruBox.GetComponent<Image>();
      mitikieruBox.color = new Color32(0,0,0,100);
      whatChoice = "mitikieru";
      ItemBoxControll();
    }

    public void AnyChoice()
    {
      ItemImage.color = new Color32(255,255,255,255);
      Image iceBox = IceBox.GetComponent<Image>();
      iceBox.color = new Color32(0,0,0,0);
      Image spawnBox = SpawnBox.GetComponent<Image>();
      spawnBox.color = new Color32(0,0,0,0);
      Image magnifyingGlassBox = MagnifyingGlassBox.GetComponent<Image>();
      magnifyingGlassBox.color = new Color32(0,0,0,0);
      Image mitikieruBox = MitikieruBox.GetComponent<Image>();
      mitikieruBox.color = new Color32(0,0,0,0);
      Image weakenedBox = WeakenedBox.GetComponent<Image>();
      weakenedBox.color = new Color32(0,0,0,0);
    }

    public void ItemBoxControll()
    {
        Text name_text = NameText.GetComponent<Text>();
        Text info_text = InfoText.GetComponent<Text>();
        Text level_text = LevelText.GetComponent<Text>();

        if(whatChoice == "ice"){
            name_text.text = "アイスノーゼ";
            info_text.text = "[ウイルス]を非活性化\nさせる。たまに前回の\n連鎖を引き継ぐ。";
            ItemImage.sprite = iceSprite;
            level_text.text = "" + PlayerPrefs.GetInt("IceLevel");
            effectTime_text.text = "" + PlayerPrefs.GetFloat("IceEffectTime").ToString("f1") + "秒";
            coolTime_text.text = "" +PlayerPrefs.GetFloat("IceCoolTime").ToString("f1") + "秒";
            cost = 10000 * PlayerPrefs.GetInt("IceLevel")*PlayerPrefs.GetInt("IceLevel");
            SetButton.SetActive(true);
             if(PlayerPrefs.GetInt("IceLevel") == 9){
                level_text.color = new Color(1.0f,0.0f,0.0f,1.0f);
                cost_text.text = "";
            }else{level_text.color = new Color(0f,0f,0f,255f);
            cost_text.text = cost + "G";;
            }if(PlayerPrefs.GetInt("IceLevel")==0){
                DontHave.SetActive(true);
                PurchaseButton.SetActive(true);
                LevelUpButton.SetActive(false);
                Leveling.SetActive(false);
                SetButton.SetActive(false);
            }else{
                DontHave.SetActive(false);
                PurchaseButton.SetActive(false);
                LevelUpButton.SetActive(true);
                Leveling.SetActive(true);
                }
            ItemImage.sprite = iceSprite;
            if(PlayerPrefs.GetString("Set") == "ice"){
                SetText.SetActive(true);
            }else{SetText.SetActive(false);}
        }else if(whatChoice == "spawner"){
            name_text.text = "フエルーノ";
            info_text.text = "ナゾった部分に隠れて\nいる[ウイルス]を炙り\n出す。";
            InfoTextPurchase.text = "ナゾった部分に隠れて\nいる[ウイルス]を炙り\n出す。";
            ItemImage.sprite = spawnerSprite;
            level_text.text = "" + PlayerPrefs.GetInt("SpawnerLevel");
            effectTime_text.text = "" + PlayerPrefs.GetFloat("SpawnerEffectTime").ToString("f1") + "秒";
            coolTime_text.text = "" + PlayerPrefs.GetFloat("SpawnerCoolTime").ToString("f1") + "秒" ;
            cost = 10000 * PlayerPrefs.GetInt("SpawnerLevel") * PlayerPrefs.GetInt("SpawnerLevel");
            SetButton.SetActive(true);
            if(PlayerPrefs.GetInt("SpawnerLevel") == 9){
                level_text.color = new Color(1.0f,0.0f,0.0f,1.0f);
                cost_text.text = "";
            }else{level_text.color = new Color(0f,0f,0f,255f);
                 cost_text.text = cost + "G";
            }if(PlayerPrefs.GetInt("SpawnerLevel")==0){
                DontHave.SetActive(true);
                PurchaseButton.SetActive(true);
                LevelUpButton.SetActive(false);
                Leveling.SetActive(false);
                SpawnerRock.SetActive(true);
                SetButton.SetActive(false);
            }else{
                DontHave.SetActive(false);
                PurchaseButton.SetActive(false);
                LevelUpButton.SetActive(true);
                Leveling.SetActive(true);
                SpawnerRock.SetActive(false);
                }
                if(PlayerPrefs.GetString("Set") == "spawner"){
                SetText.SetActive(true);
                }else{SetText.SetActive(false);}
        }else if(whatChoice == "weakened"){
            name_text.text = "ジャクタイガー";
            info_text.text = "ナゾった[ウイルス]を\n弱体化させて消毒ポイ\nントを上げる。";
            InfoTextPurchase.text = "ナゾった[ウイルス]を\n弱体化させて消毒ポイ\nントを上げる。";
            ItemImage.sprite = weakenedSprite;
            level_text.text = "" + PlayerPrefs.GetInt("WeakenedLevel");
            effectTime_text.text = "" + PlayerPrefs.GetFloat("WeakenedEffectTime").ToString("f1") + "秒";
            coolTime_text.text = "" + PlayerPrefs.GetFloat("WeakenedCoolTime").ToString("f1") + "秒" ;
            cost = 10000 * PlayerPrefs.GetInt("WeakenedLevel") * PlayerPrefs.GetInt("WeakenedLevel");
            SetButton.SetActive(true);
            if(PlayerPrefs.GetInt("WeakenedLevel") == 9){
                level_text.color = new Color(1.0f,0.0f,0.0f,1.0f);
                cost_text.text = "";
            }else{level_text.color = new Color(0f,0f,0f,255f);
                 cost_text.text = cost + "G";
            }if(PlayerPrefs.GetInt("WeakenedLevel")==0){
                DontHave.SetActive(true);
                PurchaseButton.SetActive(true);
                LevelUpButton.SetActive(false);
                Leveling.SetActive(false);
                WeakenedRock.SetActive(true);
                SetButton.SetActive(false);
            }else{
                DontHave.SetActive(false);
                PurchaseButton.SetActive(false);
                LevelUpButton.SetActive(true);
                Leveling.SetActive(true);
                WeakenedRock.SetActive(false);
                }
                if(PlayerPrefs.GetString("Set") == "weakened"){
                SetText.SetActive(true);
                }else{SetText.SetActive(false);}
        }else if(whatChoice == "magnifyingGlass"){
            name_text.text = "ムシメガネ";
            info_text.text = "画面をよく見て、邪魔\nな障害物を無効化する";
            InfoTextPurchase.text = "画面をよく見て、邪魔\nな障害物を無効化する";
            ItemImage.sprite = magnifyingGlassSprite;
            level_text.text = "" + PlayerPrefs.GetInt("MagnifyingGlassLevel");
            effectTime_text.text = "" + PlayerPrefs.GetFloat("MagnifyingGlassEffectTime").ToString("f1") + "秒";
            coolTime_text.text = "" + PlayerPrefs.GetFloat("MagnifyingGlassCoolTime").ToString("f1") + "秒" ;
            cost = 15000 * PlayerPrefs.GetInt("MagnifyingGlassLevel") * PlayerPrefs.GetInt("MagnifyingGlassLevel");
            cost_text.text = cost + "G";
            SetButton.SetActive(true);
            if(PlayerPrefs.GetInt("MagnifyingGlassLevel") == 9){
                level_text.color = new Color(1.0f,0.0f,0.0f,1.0f);
                cost_text.text = "";
            }else{level_text.color = new Color(0f,0f,0f,255f);
            cost_text.text = cost + "G";
            }if(PlayerPrefs.GetInt("MagnifyingGlassLevel")==0){
                DontHave.SetActive(true);
                PurchaseButton.SetActive(true);
                LevelUpButton.SetActive(false);
                Leveling.SetActive(false);
                MagnifyingGlassRock.SetActive(true);
                SetButton.SetActive(false);
            }else{
                DontHave.SetActive(false);
                PurchaseButton.SetActive(false);
                LevelUpButton.SetActive(true);
                Leveling.SetActive(true);
                MagnifyingGlassRock.SetActive(false);
                }
                if(PlayerPrefs.GetString("Set") == "magnifyingGlass"){
                SetText.SetActive(true);
                }else{SetText.SetActive(false);}
                }else if(whatChoice == "mitikieru"){
            name_text.text = "ミチキエル";
            info_text.text = "ナゾった[未知のウイル\nス]を見えなくし、し\nばらく沸かなくする。";
            InfoTextPurchase.text = "ナゾったところの[未知\nのウイルス]を見えなく\nする。";
            ItemImage.sprite = mitikieruSprite;
            level_text.text = "" + PlayerPrefs.GetInt("MitikieruLevel");
            effectTime_text.text = "" + PlayerPrefs.GetFloat("MitikieruEffectTime").ToString("f1") + "秒";
            coolTime_text.text = "" + PlayerPrefs.GetFloat("MitikieruCoolTime").ToString("f1") + "秒" ;
            cost = 100000 * PlayerPrefs.GetInt("MitikieruLevel") * PlayerPrefs.GetInt("MitikieruLevel");
            cost_text.text = cost + "G";
            SetButton.SetActive(true);
            if(PlayerPrefs.GetInt("MitikieruLevel") == 9){
                level_text.color = new Color(1.0f,0.0f,0.0f,1.0f);
                cost_text.text = "";
            }else{level_text.color = new Color(0f,0f,0f,255f);
            cost_text.text = cost + "G";
            }if(PlayerPrefs.GetInt("MitikieruLevel")==0){
                DontHave.SetActive(true);
                PurchaseButton.SetActive(false);
                LevelUpButton.SetActive(false);
                Leveling.SetActive(false);
                MitikieruRock.SetActive(true);
                SetButton.SetActive(false);
                name_text.text = "?????";
                info_text.text = "?????";
                effectTime_text.text = "?????";
                coolTime_text.text = "?????";
            }else{
                DontHave.SetActive(false);
                PurchaseButton.SetActive(false);
                LevelUpButton.SetActive(true);
                Leveling.SetActive(true);
                MagnifyingGlassRock.SetActive(false);
                }
                if(PlayerPrefs.GetString("Set") == "mitikieru"){
                SetText.SetActive(true);
                }else{SetText.SetActive(false);}
                }
                
                
    }

    
    public void Reset(){
            whatChoice = null;
            Text name_text = NameText.GetComponent<Text>();
            Text info_text = InfoText.GetComponent<Text>();
            Text level_text = LevelText.GetComponent<Text>();
            name_text.text = "";
            info_text.text = "";
            level_text.text = "";
            effectTime_text.text = "";
            coolTime_text.text = "";
            cost_text.text = "";
              AnyChoice();
            ItemImage.color = new Color32(0,0,0,0);
            DontHave.SetActive(false);
            PurchaseButton.SetActive(false);
            LevelUpButton.SetActive(false);
            PurchasePanel.SetActive(false);
            SetText.SetActive(false);
            SetButton.SetActive(false);
            if(PlayerPrefs.GetInt("SpawnerLevel")==0){
                SpawnerRock.SetActive(true);
            }else{SpawnerRock.SetActive(false);}
            if(PlayerPrefs.GetInt("MagnifyingGlassLevel")==0){
                MagnifyingGlassRock.SetActive(true);
            }else{MagnifyingGlassRock.SetActive(false);}
            if(PlayerPrefs.GetInt("MitikieruLevel")==0){
                MitikieruRock.SetActive(true);
            }else{MitikieruRock.SetActive(false);}
            if(PlayerPrefs.GetInt("WeakenedLevel")==0){
                WeakenedRock.SetActive(true);
            }else{WeakenedRock.SetActive(false);}
    }





    public void PurchaeseButton()
    {
        PurchasePanel.SetActive(true);
        NoMoney.SetActive(false);
        moneyPossession.text = PlayerPrefs.GetInt("Money") + "G";
        if(whatChoice == "spawner"){
        price = 30000;
        price_text.text = price + "G";
        purchaseImage.sprite = spawnerSprite;
        }if(whatChoice == "magnifyingGlass"){
        price = 100000;
        price_text.text = price + "G";
        purchaseImage.sprite = magnifyingGlassSprite;
        }if(whatChoice == "weakened"){
        price = 200000;
        price_text.text = price + "G";
        purchaseImage.sprite = weakenedSprite;
        }
    }

    public void YesPurchase()
    {
        if(whatChoice == "spawner"){
            if(PlayerPrefs.GetInt("Money") >= price){
               PlayerPrefs.SetInt("Money" , PlayerPrefs.GetInt("Money") - price);
               PlayerPrefs.SetInt("ItemInPossession" , PlayerPrefs.GetInt("ItemInPossession") + 1);
               PlayerPrefs.SetInt("SpawnerLevel" , 1);
               PurchasePanel.SetActive(false);
               NoMoney.SetActive(false);
               ItemBoxControll();
               AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(purchaseSE);
            }else{
                NoMoney.SetActive(true);
                StartCoroutine("Coroutine");
            }
        }if(whatChoice == "magnifyingGlass"){
            if(PlayerPrefs.GetInt("Money") >= price){
               PlayerPrefs.SetInt("Money" , PlayerPrefs.GetInt("Money") - price);
               PlayerPrefs.SetInt("ItemInPossession" , PlayerPrefs.GetInt("ItemInPossession") + 1);
               PlayerPrefs.SetInt("MagnifyingGlassLevel" , 1);
               PurchasePanel.SetActive(false);
               NoMoney.SetActive(false);
               ItemBoxControll();
               AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(purchaseSE);
            }else{
                NoMoney.SetActive(true);
                StartCoroutine("Coroutine");
            }
        }if(whatChoice == "weakened"){
            if(PlayerPrefs.GetInt("Money") >= price){
               PlayerPrefs.SetInt("Money" , PlayerPrefs.GetInt("Money") - price);
               PlayerPrefs.SetInt("ItemInPossession" , PlayerPrefs.GetInt("ItemInPossession") + 1);
               PlayerPrefs.SetInt("WeakenedLevel" , 1);
               PurchasePanel.SetActive(false);
               NoMoney.SetActive(false);
               ItemBoxControll();
               AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(purchaseSE);
            }else{
                NoMoney.SetActive(true);
                StartCoroutine("Coroutine");
            }
        }
    }

     IEnumerator Coroutine () {    
    	yield return new WaitForSeconds(1.0f);
        PurchasePanel.SetActive(false);
        NoMoney.SetActive(false);
           }


    public void NoPurchase()
    {
        PurchasePanel.SetActive(false);
    }

///虫眼鏡ここから
    public void LevelUp(){
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
           if(whatChoice == "ice" & PlayerPrefs.GetInt("IceLevel") <=  8 & PlayerPrefs.GetInt("Money") > cost){
               PlayerPrefs.SetInt("Money" , PlayerPrefs.GetInt("Money") - cost);
               PlayerPrefs.SetInt("IceLevel" , PlayerPrefs.GetInt("IceLevel") + 1);
               PlayerPrefs.SetFloat("IceEffectTime" , PlayerPrefs.GetFloat("IceEffectTime") + 0.3f);
               PlayerPrefs.SetFloat("IceCoolTime" , PlayerPrefs.GetFloat("IceCoolTime") - 0.5f);
               ItemBoxControll();
               audioSource.PlayOneShot(LevelUpSE);
               }else if(whatChoice == "spawner" & PlayerPrefs.GetInt("SpawnerLevel") <= 8 & PlayerPrefs.GetInt("Money") > cost){
               PlayerPrefs.SetInt("Money" , PlayerPrefs.GetInt("Money") - cost);
               PlayerPrefs.SetInt("SpawnerLevel" , PlayerPrefs.GetInt("SpawnerLevel") + 1);
               PlayerPrefs.SetFloat("SpawnerEffectTime" , PlayerPrefs.GetFloat("SpawnerEffectTime") + 0.3f);
               PlayerPrefs.SetFloat("SpawnerCoolTime" , PlayerPrefs.GetFloat("SpawnerCoolTime") - 0.5f);
               ItemBoxControll();
               audioSource.PlayOneShot(LevelUpSE);
               }else if(whatChoice == "magnifyingGlass" & PlayerPrefs.GetInt("MagnifyingGlassLevel") <= 8 & PlayerPrefs.GetInt("Money") > cost){
               PlayerPrefs.SetInt("Money" , PlayerPrefs.GetInt("Money") - cost);
               PlayerPrefs.SetInt("MagnifyingGlassLevel" , PlayerPrefs.GetInt("MagnifyingGlassLevel") + 1);
               PlayerPrefs.SetFloat("MagnifyingGlassEffectTime" , PlayerPrefs.GetFloat("MagnifyingGlassEffectTime") + 0.5f);
               PlayerPrefs.SetFloat("MagnifyingGlassCoolTime" , PlayerPrefs.GetFloat("MagnifyingGlassCoolTime") - 0.5f);
               ItemBoxControll();
               audioSource.PlayOneShot(LevelUpSE);
               }else if(whatChoice == "mitikieru" & PlayerPrefs.GetInt("MitikieruLevel") <= 8 & PlayerPrefs.GetInt("Money") > cost){
               PlayerPrefs.SetInt("Money" , PlayerPrefs.GetInt("Money") - cost);
               PlayerPrefs.SetInt("MitikieruLevel" , PlayerPrefs.GetInt("MitikieruLevel") + 1);
               PlayerPrefs.SetFloat("MitikieruEffectTime" , PlayerPrefs.GetFloat("MitikieruEffectTime") + 0.2f);
               PlayerPrefs.SetFloat("MitikieruCoolTime" , PlayerPrefs.GetFloat("MitikieruCoolTime") - 0.4f);
               ItemBoxControll();
               audioSource.PlayOneShot(LevelUpSE);
               }else if(whatChoice == "weakened" & PlayerPrefs.GetInt("WeakenedLevel") <= 8 & PlayerPrefs.GetInt("Money") > cost){
               PlayerPrefs.SetInt("Money" , PlayerPrefs.GetInt("Money") - cost);
               PlayerPrefs.SetInt("WeakenedLevel" , PlayerPrefs.GetInt("WeakenedLevel") + 1);
               PlayerPrefs.SetFloat("WeakenedEffectTime" , PlayerPrefs.GetFloat("WeakenedEffectTime") + 0.5f);
               PlayerPrefs.SetFloat("WeakenedCoolTime" , PlayerPrefs.GetFloat("WeakenedCoolTime") - 0.5f);
               ItemBoxControll();
               audioSource.PlayOneShot(LevelUpSE);
               }else{
                audioSource.PlayOneShot(sound1);}
            }
        

        public void SetClick()
        {
            
            if(whatChoice == "ice"){
                PlayerPrefs.SetString("Set" , "ice");
            }else if(whatChoice == "spawner"){
                PlayerPrefs.SetString("Set" , "spawner");
            }else if(whatChoice == "magnifyingGlass"){
                PlayerPrefs.SetString("Set" , "magnifyingGlass");
            }else if(whatChoice == "mitikieru"){
                PlayerPrefs.SetString("Set" , "mitikieru");
            }else if(whatChoice == "weakened"){
                PlayerPrefs.SetString("Set" , "weakened");
            }
            ItemBoxControll();
             AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(set);
        }

}
    

    
