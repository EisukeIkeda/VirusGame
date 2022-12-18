using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class NewVirusSpawn : MonoBehaviour
{
    
    public static int chainPoint = 0; ///チェーンポイント
    public GameObject comboBreak = null; // Textオブジェクト
    private int point;
    public static int addPoint;
    public int iceOff;
    public AudioSource sound1;
    public bool destroy = false;
    public AudioClip sound2;

    

    ///virusの出現アニメーション
    void Start()
    {
        Transform tran = this.gameObject.GetComponent<Transform>();
        
        tran.DOScale (
    　　　new Vector2(1f,1f),　　//終了時点のScale
    　　　3.0f )        
         .SetLink( gameObject );　　　　　//時間
         tran.DORotate(
        new Vector3(0f,50,0f), 0.5f)
        .SetLoops(-1, LoopType.Restart)
        .SetEase(Ease.Linear)
        .SetLink( gameObject );
    }

    // Update is called once per frame
    void Update()
    {
         if(PlayerPrefs.GetInt("Ice") == 1)
        {
            NewVirusIce();
        }if(PlayerPrefs.GetInt("Ice") == 0 & iceOff > 0){
            IceOff();
        }
        if(PlayerPrefs.GetInt("NewVirusDestroy") >= 1 & destroy == false){
         NewVirusDeath();
         destroy = true;
        }
    }

        public void NewVirusIce()
    {
        Transform tran = this.gameObject.GetComponent<Transform>();
        CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
        tran.DORotate(
        new Vector3(0f,0f,0f), 0f)
        .SetLink( gameObject );
        can.blocksRaycasts = false;
        iceOff = 1;
    }

    public void IceOff()
    {
        Transform tran = this.gameObject.GetComponent<Transform>();
        CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
        tran.DORotate(
        new Vector3(0,50f,0f), 0.1f)///触ったときの挙動
        .SetLoops(3, LoopType.Yoyo)
        .SetEase(Ease.Linear)
        .SetLink( gameObject );
        can.blocksRaycasts = true;
        iceOff = 0;
    }

    public void ChainBreak()
    {
        if(PlayerPrefs.GetInt("Ice") == 0 || PlayerPrefs.GetInt("Mitikieru") == 0){
        Transform tran = this.gameObject.GetComponent<Transform>();

        tran.DORotate(
        new Vector3(0,50f,0f), 0.1f)///触ったときの挙動
        .SetLoops(3, LoopType.Yoyo)
        .SetEase(Ease.Linear)
        .SetLink( gameObject );
        if(PlayerPrefs.GetFloat("chain") > 0){
        CanvasGroup can = comboBreak.GetComponent<CanvasGroup>();
        Transform tr = comboBreak.GetComponent<Transform>();
        can.DOFade(1,0);
        comboBreak.SetActive(true);
         tr.DOLocalMove(new Vector2(0, 200), 0.5f)
         .SetLink( gameObject );　
         tr.DOScale(new Vector2(2f,2f),0.5f).SetLink( gameObject );
         Text break_text = comboBreak.GetComponent<Text> ();
         break_text.text = "コンボ破壊";
             sound1.Play();
         StartCoroutine ("Coroutine");
        }
        
         PlayerPrefs.SetFloat("chain",0f);///チェーン受付時間の設定
        }else{}
    }

    public void MitikieruTouch(){
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        if(PlayerPrefs.GetInt("Mitikieru") == 1){
            NewVirusDeath();
            audioSource.PlayOneShot(sound2);
        }
    }

    IEnumerator Coroutine () 
    {
        for(int i=0;i<1;++i)
	　　　{
		   yield return coSub();
	　　　}yield return new WaitForSeconds(0.5f);///元の位置に戻してる
          Transform tr = comboBreak.GetComponent<Transform>();
          tr.DOLocalMove(new Vector2(0, -200), 0f);
          tr.DOScale(new Vector2(0f,0f),0f);
     　　　comboBreak.SetActive(false);
    }

    　　　IEnumerator coSub()
　　　{
	     yield return new WaitForSeconds(0.5f);
         CanvasGroup can = comboBreak.GetComponent<CanvasGroup>();
         can.DOFade(0,0.5f);
　　　}






    public void NewVirusDeath()
    {

        this.gameObject.GetComponent<Image>().raycastTarget = false;
        DG.Tweening.DOTween.SetTweensCapacity(tweenersCapacity:800, sequencesCapacity:200);
        Transform tran = this.gameObject.GetComponent<Transform>();
        tran.DOScale (
    　　　new Vector2(0f,0f),2.0f )        
         .SetLink( gameObject , LinkBehaviour.KillOnDisable);　　///消えるアニメーション

        StartCoroutine("Death");
        }

        IEnumerator Death(){
            //CanvasGroup can = this.gameObject.GetComponent<CanvasGroup>();
            yield return new WaitForSeconds(2.0f);
            //can.DOFade(0f,1);
            //can.blocksRaycasts = false;
             this.gameObject.SetActive(false);
            }

    }

