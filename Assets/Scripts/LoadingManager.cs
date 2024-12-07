using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LoadingManager : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int count = 1;
    private int countMax = 10;
    private float time;

    void Awake()
    {
        text =  this.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
        time = Random.Range(8f, 18f);
        StartCoroutine("Load");
        StartCoroutine("ChangeScene");
    }
    
    private IEnumerator Load(){
        yield return new WaitForSeconds(1);
        string a = "";
        count++;
        if (count > countMax){
            count = 1;
        }
        for (int i=0; i < count; i++){
            a += ".";
        }
        text.text = "Loading"+a;
        StartCoroutine("Load");
    }

        private IEnumerator ChangeScene(){
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Game");
    }
}
