using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MenuManager : MonoBehaviour
{
    #region BG
    [SerializeField]
    private Sprite[] images = new Sprite[12];
    [SerializeField]
    private Image Bg1;
    [SerializeField]
    private Image Bg2;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI text2;
    [SerializeField]
    private UISwitcher.UISwitcher switcher;

    [SerializeField]
    private GameObject InputsChangeBG;

    private int num=0;
    private float amount=1;
    private int speed=2;
    private int time=30;
    private int OLDspeed;
    private int OLDtime;
    private bool start=false;
    private bool startCoroutine;
    private bool Startl=false;

    private void numPlus(){
        num++;
        if (num == 12)
            num = 0;
        Bg1.sprite = images[num];
        Bg2.sprite = images[num+1];
    }

    private void Awake() {
        OLDspeed = speed;
        OLDtime = time;
        num = Random.Range(0, 10);
        //Bg1 = transform.Find("BackGround1").gameObject.GetComponent<Image>();
        //Bg2 = transform.Find("BackGround2").gameObject.GetComponent<Image>();
        //text = transform.Find("InputField (TMP)").gameObject.GetComponent<TextMeshProUGUI>(); // speed
        //text2 = transform.Find("InputField (TMP) (1)").gameObject.GetComponent<TextMeshProUGUI>(); // time
        Bg1.sprite = images[num];
        Bg2.sprite = images[num+1];
        StartCoroutine("BG1");
    }

    private IEnumerator BG1(){
        yield return new WaitForSeconds(time);
        start = true;
    }

    private void Update() {
        if (switcher.isOn == false){
            StopCoroutine("BG1");
            startCoroutine = false;
            InputsChangeBG.SetActive(switcher.isOn);
            return;
        }else{
            if (startCoroutine==false){
                InputsChangeBG.SetActive(switcher.isOn);
                startCoroutine=true;
                StartCoroutine("BG1");
            }
        }
        
        int value;
        if(int.TryParse(text.text, out value)){
            speed = value;
        }
        value = 0;
        if(int.TryParse(text2.text, out value)){
            time = value;
        }
        if (speed != OLDspeed || time != OLDtime){
            StopCoroutine("BG1");
            StartCoroutine("BG1");
        }
        OLDspeed = speed;
        OLDtime = time;

        if (start == true){
            if (amount > 0){
                amount = amount - 0.0001f*speed;
            }else{
                start = false;
                amount = 1;
                numPlus();
                StartCoroutine("BG1");
            }
            Bg1.fillAmount = amount;
        }
        
    }
    #endregion

    public void Exit(){
        Application.Quit();
    }
    public void Start(){
        if (Startl){
            SceneManager.LoadScene("Loading");
        }else{
            Startl = true;
        }
    }
}
