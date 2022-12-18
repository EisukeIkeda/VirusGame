using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

  public class ItemBox : MonoBehaviour {
  public float countTimer;
  public float x;
  public float x2;
  public float stop;///効果発動時間
  private float time;
  private float time2;
  private int itemUsedFlag;
  public GameObject switchButton;

  public string item;///なんのアイテムを選択しているかを格納

  public GameObject ice;
  public GameObject icePanel;
  public float iceCool = 0f;
  public float iceCoolCount = 0f;
  public GameObject spawner;
  public GameObject spawnerPanel;
  public float spawnerCool = 0f;
  public float spawnerCoolCount = 0f;
  public GameObject weakened;
  public GameObject weakenedPanel;
  public float weakenedCool = 0f;
  public float weakenedCoolCount = 0f;
  public GameObject mitikieru;
  public GameObject mitikieruPanel;
  public float mitikieruCool = 0f;
  public float mitikieruCoolCount = 0f;
  public GameObject magnifyingGlass;
  public float magnifyingGlassCool = 0f;
  public float magnifyingGlassCoolCount = 0f;
  public GameObject disturbPanel;

  public AudioClip sound1;
  public AudioClip sound2;
  public AudioClip sound3;
  public AudioClip soundWeakened;   
  public AudioClip soundMagnifying;  
  public AudioClip mitikieruSE;

  void Start()
  {
    CanvasGroup icecan = ice.GetComponent<CanvasGroup>();
    CanvasGroup spawnercan = spawner.GetComponent<CanvasGroup>();
    CanvasGroup weakenedcan = weakened.GetComponent<CanvasGroup>();
    CanvasGroup mitikierucan = mitikieru.GetComponent<CanvasGroup>();
    CanvasGroup magnifyingGlasscan = magnifyingGlass.GetComponent<CanvasGroup>();
    icecan.DOFade(0,0);
    spawnercan.DOFade(0,0);
    weakenedcan.DOFade(0,0);
    mitikierucan.DOFade(0,0);
    magnifyingGlasscan.DOFade(0,0);
    item = PlayerPrefs.GetString("Set");
    if(item == "ice")
       {IceSet();
       icecan.DOFade(0.5f,0);
       }else if(item == "spawner")
       {SpawnerSet();
       spawnercan.DOFade(0.5f,0);
       }else if(item == "mitikieru")
       {MitikieruSet();
       mitikierucan.DOFade(0.5f,0);
       }else if(item == "magnifyingGlass")
       {MagnifyingGlassSet();
       magnifyingGlasscan.DOFade(0.5f,0);
       }else if(item == "weakened")
       {WeakenedSet();
       weakenedcan.DOFade(0.5f,0);
       }else{IceSet();}
    itemUsedFlag = 0;
  }

  // Update is called once per frame
  void Update (){
    if(itemUsedFlag == 0){
    time += Time.deltaTime;
     CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
     CanvasGroup icecan = ice.GetComponent<CanvasGroup>();
     CanvasGroup spawnercan = spawner.GetComponent<CanvasGroup>();
     CanvasGroup weakenedcan = weakened.GetComponent<CanvasGroup>();
     CanvasGroup mitikierucan = mitikieru.GetComponent<CanvasGroup>();
     CanvasGroup magnifyingGlasscan = magnifyingGlass.GetComponent<CanvasGroup>();
     Image img = this.gameObject.GetComponent<Image>();
     if(item == "ice"){
     iceCoolCount += 1.0f / countTimer * Time.deltaTime;
     img.fillAmount = iceCoolCount;
     can.DOFade(0.5f,0);
     }if(item == "spawner"){
       spawnerCoolCount += 1.0f / countTimer * Time.deltaTime;
       img.fillAmount = spawnerCoolCount;
       can.DOFade(0.5f,0);
     }if(item == "weakened"){
       weakenedCoolCount += 1.0f / countTimer * Time.deltaTime;
       img.fillAmount = weakenedCoolCount;
       can.DOFade(0.5f,0);
     }if(item == "mitikieru"){
       mitikieruCoolCount += 1.0f / countTimer * Time.deltaTime;
       img.fillAmount = mitikieruCoolCount;
       can.DOFade(0.5f,0);
     }if(item == "magnifyingGlass"){
       magnifyingGlassCoolCount += 1.0f / countTimer * Time.deltaTime;
       img.fillAmount = magnifyingGlassCoolCount;
       can.DOFade(0.5f,0);
     }
     if(img.fillAmount == 1f)
     {
       x = 1;
     }
     if(x == 1){
       can.DOFade(1,0);
       if(item == "ice"){
        icecan.DOFade(1,0);
       }else if(item == "spawner"){
        spawnercan.DOFade(1,0);
       }else if(item == "weakened"){
        weakenedcan.DOFade(1,0);
       }else if(item == "mitikieru"){
        mitikierucan.DOFade(1,0);
       }else if(item == "magnifyngGlass"){
        magnifyingGlasscan.DOFade(1,0);
       }
     }
    }if(itemUsedFlag == 1){
      CanvasGroup sbutton = switchButton.GetComponent<CanvasGroup>();
      sbutton.blocksRaycasts = false;
     time2 += Time.deltaTime;
     Image img = this.gameObject.GetComponent<Image>();
     CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
     CanvasGroup icecan = ice.GetComponent<CanvasGroup>();
     CanvasGroup spawnercan = spawner.GetComponent<CanvasGroup>();
     CanvasGroup weakenedcan = weakened.GetComponent<CanvasGroup>();
     CanvasGroup mitikierucan = mitikieru.GetComponent<CanvasGroup>();
     CanvasGroup magnifyingGlasscan = magnifyingGlass.GetComponent<CanvasGroup>();
     if(item == "ice"){
     img.fillAmount -= 1.0f / stop * Time.deltaTime;
     iceCoolCount = 0;
     }if(item == "spawner"){
       img.fillAmount -= 1.0f / stop * Time.deltaTime;
       spawnerCoolCount = 0;
     }if(item == "weakened"){
       img.fillAmount -= 1.0f / stop * Time.deltaTime;
       weakenedCoolCount = 0;
     }if(item == "mitikieru"){
       img.fillAmount -= 1.0f / stop * Time.deltaTime;
       mitikieruCoolCount = 0;
     }if(item == "magnifyingGlass"){
       img.fillAmount -= 1.0f / stop * Time.deltaTime;
       magnifyingGlassCoolCount = 0;
     }
      if(time2 >= stop)
     {
       x2 = 1;
     }if(x2 == 1){
       can.DOFade(0.5f,0);
       if(item == "ice"){
       icecan.DOFade(0.5f,0);
       }if(item == "spawner"){
         spawnercan.DOFade(0.5f,0);
       }if(item == "weakened"){
         weakenedcan.DOFade(0.5f,0);
       }if(item == "mitikieru"){
         mitikierucan.DOFade(0.5f,0);
       }if(item == "magnifyingGlass"){
         magnifyingGlasscan.DOFade(0.5f,0);
       }itemUsedFlag = 0;
       sbutton.blocksRaycasts = true;
     }}
     }
    


    public void ItemSwitch(){
    AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
    Image img = this.gameObject.GetComponent<Image>();
       if(PlayerPrefs.GetInt("ItemInPossession") >= 2)///２つ以上アイテムを買っておるかの確認
       {
       ///ここまでリセット
       if(item == "ice")
       {SwitchIce();
       }else if(item == "spawner")
       {SwitchSpawner();
       }else if(item == "weakened")
       {SwitchWeakened();
       }else if(item == "mitikieru")
       {SwitchMitikieru();
       }else if(item == "magnifyingGlass")
       {SwitchMagnifyingGlass();
       }
       if(itemUsedFlag != 1){
         img.fillAmount = 0f;///アイテムのゲージの初期化
       x=0; time=0;///時間のリセット
       }audioSource.PlayOneShot(sound3);
       }else{
        audioSource.PlayOneShot(sound1);}
        
      }



    public void ItemUse()
    {
          AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
      if(x == 1 & item == "ice")///アイスを使う
      {
        Ice();
        ItemUsed();///アイテムを使ったら必ず呼ぶ
        audioSource.PlayOneShot(sound2);
      }else if(x == 1 & item == "spawner" & PlayerPrefs.GetInt("TotalVirus") <= 200)///スポナーを使う
      {
        Spawner();
        ItemUsed();///アイテムを使ったら必ず呼ぶ
        ///audioSource.PlayOneShot(sound3);
      }else if(x == 1 & item == "weakened")///スポナーを使う
      {
        Weakened();
        ItemUsed();
      }else if(x == 1 & item == "mitikieru")///スポナーを使う
      {
        Mitikieru();
        ItemUsed();
      }else if(x == 1 & item == "magnifyingGlass")///スポナーを使う
      {
        MagnifyingGlass();
        ItemUsed();
      }else{
        audioSource.PlayOneShot(sound1);
      }
    }



     

     ///Switch〇〇ここから

     public void SwitchIce()
     {
       CanvasGroup icecan = ice.GetComponent<CanvasGroup>();
       CanvasGroup spawnercan = spawner.GetComponent<CanvasGroup>();
       CanvasGroup weakenedcan = weakened.GetComponent<CanvasGroup>();
       CanvasGroup mitikierucan = mitikieru.GetComponent<CanvasGroup>();
       CanvasGroup magnifyingGlasscan = magnifyingGlass.GetComponent<CanvasGroup>();
       icecan.DOFade(0,0);
       Image img = this.gameObject.GetComponent<Image>();
       iceCool = img.fillAmount;
       if(PlayerPrefs.GetInt("SpawnerLevel") >= 1)///何を持っておるかで条件わけ
       {
         spawnercan.DOFade(0.5f,0);
         SpawnerSet();///○○Set()はアイテムの情報を代入
       }else if(PlayerPrefs.GetInt("WeakenedLevel") >= 1){
         weakenedcan.DOFade(0.5f,0);
         WeakenedSet();///○○Set()はアイテムの情報を代入
       }else if(PlayerPrefs.GetInt("MitikieruLevel") >= 1){
         mitikierucan.DOFade(0.5f,0);
         MitikieruSet();///○○Set()はアイテムの情報を代入
       }else if(PlayerPrefs.GetInt("MagnifyingGlassLevel") >= 1){
         magnifyingGlasscan.DOFade(0.5f,0);
         MagnifyingGlassSet();///○○Set()はアイテムの情報を代入
       }
     }

     public void SwitchSpawner()
     {
       CanvasGroup icecan = ice.GetComponent<CanvasGroup>();
       CanvasGroup spawnercan = spawner.GetComponent<CanvasGroup>();
       CanvasGroup weakenedcan = weakened.GetComponent<CanvasGroup>();
       CanvasGroup mitikierucan = mitikieru.GetComponent<CanvasGroup>();
       CanvasGroup magnifyingGlasscan = magnifyingGlass.GetComponent<CanvasGroup>();
       Image img = this.gameObject.GetComponent<Image>();
       spawnerCool = img.fillAmount;
       spawnercan.DOFade(0,0);
       if(PlayerPrefs.GetInt("WeakenedLevel") >= 1){
         weakenedcan.DOFade(0.5f,0);
         WeakenedSet();///○○Set()はアイテムの情報を代入
       }else if(PlayerPrefs.GetInt("MitikieruLevel") >= 1){
         mitikierucan.DOFade(0.5f,0);
         MitikieruSet();///○○Set()はアイテムの情報を代入
       }else if(PlayerPrefs.GetInt("MagnifyingGlassLevel") >= 1){
         magnifyingGlasscan.DOFade(0.5f,0);
         MagnifyingGlassSet();///○○Set()はアイテムの情報を代入
       }else{icecan.DOFade(0.5f,0);
      IceSet();///○○Set()はアイテムの情報を代入
      }
     }

     public void SwitchWeakened()
     {
       CanvasGroup icecan = ice.GetComponent<CanvasGroup>();
       CanvasGroup spawnercan = spawner.GetComponent<CanvasGroup>();
       CanvasGroup weakenedcan = weakened.GetComponent<CanvasGroup>();
       CanvasGroup mitikierucan = mitikieru.GetComponent<CanvasGroup>();
       CanvasGroup magnifyingGlasscan = magnifyingGlass.GetComponent<CanvasGroup>();
       Image img = this.gameObject.GetComponent<Image>();
       weakenedCool = img.fillAmount;
       weakenedcan.DOFade(0,0);
       if(PlayerPrefs.GetInt("MitikieruLevel") >= 1){
         mitikierucan.DOFade(0.5f,0);
         MitikieruSet();///○○Set()はアイテムの情報を代入
       }else if(PlayerPrefs.GetInt("MagnifyingGlassLevel") >= 1){
         magnifyingGlasscan.DOFade(0.5f,0);
         MagnifyingGlassSet();///○○Set()はアイテムの情報を代入
       }else{icecan.DOFade(0.5f,0);
      IceSet();///○○Set()はアイテムの情報を代入
      }
     }


     public void SwitchMitikieru(){
       CanvasGroup icecan = ice.GetComponent<CanvasGroup>();
       CanvasGroup spawnercan = spawner.GetComponent<CanvasGroup>();
       CanvasGroup mitikierucan = mitikieru.GetComponent<CanvasGroup>();
       CanvasGroup weakenedcan = weakened.GetComponent<CanvasGroup>();
       CanvasGroup magnifyingGlasscan = magnifyingGlass.GetComponent<CanvasGroup>();
       Image img = this.gameObject.GetComponent<Image>();
       mitikieruCool = img.fillAmount;
       mitikierucan.DOFade(0,0);
       if(PlayerPrefs.GetInt("MagnifyingGlassLevel") >= 1){
         magnifyingGlasscan.DOFade(0.5f,0);
         MagnifyingGlassSet();///○○Set()はアイテムの情報を代入
       }else{icecan.DOFade(0.5f,0);
      IceSet();///○○Set()はアイテムの情報を代入
      }
      }


     public void SwitchMagnifyingGlass(){
       CanvasGroup icecan = ice.GetComponent<CanvasGroup>();
       CanvasGroup spawnercan = spawner.GetComponent<CanvasGroup>();
       CanvasGroup mitikierucan = mitikieru.GetComponent<CanvasGroup>();
       CanvasGroup weakenedcan = weakened.GetComponent<CanvasGroup>();
       CanvasGroup magnifyingGlasscan = magnifyingGlass.GetComponent<CanvasGroup>();
       Image img = this.gameObject.GetComponent<Image>();
       magnifyingGlassCool = img.fillAmount;
       magnifyingGlasscan.DOFade(0,0);
       //if
       icecan.DOFade(0.5f,0);
      IceSet();///○○Set()はアイテムの情報を代入
      }
     


     ///Switch〇〇ここまで

     

     public void ItemUsed()///アイテムを使ったら必ず呼ぶ
     {
       x = 0;
       x2 = 0;
       time = 0;
       time2 = 0;
       itemUsedFlag = 1;
     }




       public void Weakened(){ 
         AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundWeakened);
        weakenedPanel.SetActive(true);
        CanvasGroup weakenedPanelcan = weakenedPanel.GetComponent<CanvasGroup>();
      weakenedPanelcan.DOFade(1,0);
      weakenedPanelcan.blocksRaycasts = false;
      PlayerPrefs.SetInt("Weakened",1);
      StartCoroutine("WeakenedCoroutine");
      }

      IEnumerator WeakenedCoroutine () {
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("WeakenedEffectTime"));
        CanvasGroup weakenedPanelcan = weakenedPanel.GetComponent<CanvasGroup>();
        weakenedPanelcan.DOFade(0,0.5f);
        PlayerPrefs.SetInt("Weakened",0);
        for(int i=0;i<1;++i)
	　　　{
		   yield return coWeakenedSub();
	　　　}
      }
　　　　　
      IEnumerator coWeakenedSub () {
        yield return new WaitForSeconds(0.5f);
        CanvasGroup weakenedPanelcan = weakenedPanel.GetComponent<CanvasGroup>();
        weakenedPanel.SetActive(false);
      }

      public void WeakenedSet()
      {
        weakenedCoolCount = weakenedCool;
        countTimer = PlayerPrefs.GetFloat("WeakenedCoolTime");
        stop = PlayerPrefs.GetFloat("WeakenedEffectTime");
        item = "weakened";
      }



     public void Mitikieru()///ミチキエルを使った処理
     {
       AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
      mitikieruPanel.SetActive(true);
       CanvasGroup mitikieruPanelcan = mitikieruPanel.GetComponent<CanvasGroup>();
      mitikieruPanelcan.DOFade(1,0);
      audioSource.PlayOneShot(mitikieruSE);
       PlayerPrefs.SetInt("Mitikieru",1);
       StartCoroutine ("MitikieruCoroutine");  
    }

    IEnumerator MitikieruCoroutine () {
    	yield return new WaitForSeconds(PlayerPrefs.GetFloat("MitikieruEffectTime"));
      CanvasGroup mitikieruPanelcan = mitikieruPanel.GetComponent<CanvasGroup>();
      mitikieruPanelcan.DOFade(0,1);
        for(int i=0;i<1;++i)
	　　　{
		   yield return coMitikieruSub();
	　　　}
      }
　　　　　
      IEnumerator coMitikieruSub () {
        yield return new WaitForSeconds(1.0f);
        mitikieruPanel.SetActive(false);
        PlayerPrefs.SetInt("Mitikieru",0);
      }

      ///ここまで

      public void MitikieruSet()
      {
        mitikieruCoolCount = mitikieruCool;
        countTimer = PlayerPrefs.GetFloat("MitikieruCoolTime");
        item = "mitikieru";
        stop = PlayerPrefs.GetFloat("MitikieruEffectTime");
      }




　　　public void MagnifyingGlass(){
 　　　 AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundMagnifying);
       CanvasGroup disturbcan = disturbPanel.GetComponent<CanvasGroup>();
       disturbcan.DOFade(0.5f,0.5f);
       disturbcan.blocksRaycasts = false;
       StartCoroutine("MagnifyingGlassCoroutine");
      }

      IEnumerator MagnifyingGlassCoroutine () {
        CanvasGroup disturbcan = disturbPanel.GetComponent<CanvasGroup>();
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("MagnifyingGlassEffectTime"));
        disturbcan.DOFade(1f,0.5f);
        disturbcan.blocksRaycasts = true;
      }

      public void MagnifyingGlassSet(){
        magnifyingGlassCoolCount = magnifyingGlassCool;
        countTimer = PlayerPrefs.GetFloat("MagnifyingGlassCoolTime");
        item = "magnifyingGlass";
        stop = 1f;
      }
      




　　　public void Spawner(){
        spawnerPanel.SetActive(true);
        CanvasGroup spawnerPanelcan = spawnerPanel.GetComponent<CanvasGroup>();
      spawnerPanelcan.DOFade(1,0);
      spawnerPanelcan.blocksRaycasts = true;
      StartCoroutine("SpawnerCoroutine");
      PlayerPrefs.SetInt("Spawner",1);
      }

      IEnumerator SpawnerCoroutine () {
        yield return new WaitForSeconds(PlayerPrefs.GetFloat("SpawnerEffectTime"));
        CanvasGroup spawnerPanelcan = spawnerPanel.GetComponent<CanvasGroup>();
        spawnerPanelcan.DOFade(0,0.5f);
        PlayerPrefs.SetInt("Spawner",0);
        for(int i=0;i<1;++i)
	　　　{
		   yield return coSpawnerSub();
	　　　}
      }
　　　　　
      IEnumerator coSpawnerSub () {
        yield return new WaitForSeconds(0.5f);
        CanvasGroup spawnerPanelcan = spawnerPanel.GetComponent<CanvasGroup>();
        spawnerPanel.SetActive(false);
        spawnerPanelcan.blocksRaycasts = false;
      }



      public void SpawnerSet()
      {
        spawnerCoolCount = spawnerCool;
        countTimer = PlayerPrefs.GetFloat("SpawnerCoolTime");
        stop = PlayerPrefs.GetFloat("SpawnerEffectTime");
        item = "spawner";
      }




     public void Ice()///アイスを使った処理
     {
      icePanel.SetActive(true);
       CanvasGroup icePanelcan = icePanel.GetComponent<CanvasGroup>();
      icePanelcan.DOFade(1,0);
       PlayerPrefs.SetInt("Ice",1);
       PlayerPrefs.SetFloat("chain",PlayerPrefs.GetFloat("IceEffectTime"));///チェーン受付時間の設定
       StartCoroutine ("IceCoroutine");  
    }

    IEnumerator IceCoroutine () {
    	yield return new WaitForSeconds(PlayerPrefs.GetFloat("IceEffectTime") - 1f);
      CanvasGroup icePanelcan = icePanel.GetComponent<CanvasGroup>();
      icePanelcan.DOFade(0,1);
        for(int i=0;i<1;++i)
	　　　{
		   yield return coIceSub();
	　　　}
      }
　　　　　
      IEnumerator coIceSub () {
        yield return new WaitForSeconds(1.0f);
        icePanel.SetActive(false);
        PlayerPrefs.SetInt("Ice",0);
      }

      ///ここまで

      public void IceSet()
      {
        iceCoolCount = iceCool;
        countTimer = PlayerPrefs.GetFloat("IceCoolTime");
        item = "ice";
        stop = PlayerPrefs.GetFloat("IceEffectTime");
      }

  }
