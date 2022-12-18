using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class VirusSpawn : MonoBehaviour
{
    
    public static int chainPoint = 0; ///チェーンポイント
    public GameObject combo = null; // Textオブジェクト
    private int point;
    private int weakened;
    public static int addPoint;
    public int iceNow;
    public int death;
    public int virusIceDeath;
    public Sprite weakenedSprite;
    public AudioClip soundSpawner;
    public AudioClip soundWeak;
    public GameObject Virus;
    public bool virusTouch = false;


    ///virusの出現アニメーション
    void Start()
    {
        if(PlayerPrefs.GetInt("Spawner") == 1){
            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
             audioSource.PlayOneShot(soundSpawner);
        }
        Transform tran = this.gameObject.GetComponent<Transform>();
        
        Tweener tweenerStart = tran.DOScale (
    　　　new Vector2(1f,1f),　　//終了時点のScale
    　　　3.0f )        
         .SetLink( gameObject );　　　　　//時間
        Tweener tweenerNormal = tran.DORotate(
        new Vector3(0f,50,0f), 0.5f)
        .SetLoops(-1, LoopType.Restart)
        .SetEase(Ease.Linear)
        .SetLink( gameObject , LinkBehaviour.KillOnDisable);
        
    }

    // Update is called once per frame
    void Update()
    {
        CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
        if(PlayerPrefs.GetInt("Ice") == 1)
        {
            VirusIce();
        }if(PlayerPrefs.GetInt("Ice") == 0 & virusIceDeath > 0){
            IceDeathMove();
        }

        if(PlayerPrefs.GetFloat("chain") <= 0 & addPoint >0)
        {   
            PlayerPrefs.SetInt("AddPoint", addPoint);
            PlayerPrefs.SetInt("DisinfectionPoint", PlayerPrefs.GetInt("DisinfectionPoint") + addPoint);
            addPoint = 0;
        }

        if(PlayerPrefs.GetInt("Weakened")==1 & weakened ==1){
            can.blocksRaycasts = false;
        }else if(death ==0){can.blocksRaycasts = true;}

        if(can.blocksRaycasts == true & PlayerPrefs.GetInt("Mitikieru") == 1){
            can.blocksRaycasts = false;
        }else if(can.blocksRaycasts == false){can.blocksRaycasts = true;}
    }

    public void VirusIce()
    {
        Transform tran = this.gameObject.GetComponent<Transform>();
        tran.DORotate(
        new Vector3(0f,0f,0f), 0f)
        .SetLink( gameObject , LinkBehaviour.KillOnDisable);
    }


    public void VirusDeath()
    {
      if(PlayerPrefs.GetInt("Weakened") == 0){
          death = 1;
        if(PlayerPrefs.GetInt("Ice") == 1){
            virusIceDeath = 1;
            CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
            can.blocksRaycasts = false;
        }
        

        if(PlayerPrefs.GetFloat("chain") <= 0)
        {
            chainPoint = 0;
        }
        else
        {
            chainPoint = chainPoint + 1;
        }       

        point = 1 + chainPoint;
        
        if(virusTouch == false){
        if(chainPoint == 2)
        {
           combo.SetActive(true);
         Text combo_text = combo.GetComponent<Text> ();
         combo_text.text = "2";
        
        }
         else if(chainPoint >= 2)
         {
             combo.SetActive(true);
         Text combo_text = combo.GetComponent<Text> ();
         combo_text.text = chainPoint + "";
         }}

         
         if(PlayerPrefs.GetInt("Ice") == 0){
         DeathMove();
         }

        PlayerPrefs.SetInt("TotalVirus",PlayerPrefs.GetInt("TotalVirus") - 1);

        if(weakened == 0){
        addPoint = addPoint + 1 + chainPoint;
        }if(weakened >= 1){
        addPoint = addPoint + (10 * chainPoint);
        }

        virusTouch = true;
      }
    }




        public void DeathMove()
        {
        this.gameObject.GetComponent<Image>().raycastTarget = false;
        Transform tran = this.gameObject.GetComponent<Transform>();
        Tweener tweenerDeath = tran.DOScale (
    　　　new Vector2(0f,0f),2.0f )        
         .SetLink( gameObject , LinkBehaviour.KillOnDisable);
        ///Destroy(gameObject,2f);
        StartCoroutine("Death");

        PlayerPrefs.SetFloat("chain",0.5f);///チェーン受付時間の設定

        virusIceDeath = 0;
        }

        public void IceDeathMove()
        {
        this.gameObject.GetComponent<Image>().raycastTarget = false;
        Transform tran = this.gameObject.GetComponent<Transform>();
        Tweener tweenerIceDeath = tran.DOScale (
    　　　new Vector2(0f,0f),2.0f )        
         .SetLink( gameObject , LinkBehaviour.KillOnDisable);　　///消えるアニメーション
        ///Destroy(gameObject,2f);
         tran.DORotate(
        new Vector3(0f,50,0f), 0.2f)
        .SetLoops(-1, LoopType.Restart)
        .SetEase(Ease.Linear)
        .SetLink( gameObject , LinkBehaviour.KillOnDisable);
        StartCoroutine("Death");

        virusIceDeath = 0;
        }

        IEnumerator Death(){
            //CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
            yield return new WaitForSeconds(2.0f);
            //can.DOFade(0f,1);
            //can.blocksRaycasts = false;
             Virus.SetActive(false);
            }

        public void WeakenedChange(){
            if(PlayerPrefs.GetInt("Weakened") == 1){
            Image img = this.gameObject.GetComponent<Image>();
            img.sprite = weakenedSprite;
            weakened = 1;
            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
             audioSource.PlayOneShot(soundWeak);
            }
        }
        




    
}
