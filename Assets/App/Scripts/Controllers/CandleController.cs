using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CandleController : MonoBehaviour
{
    public float fadeTime = 0.2f;
    public IEnumerator LitCandle() //Litting the candle
    {
        GetComponent<AudioSource>().Play();
        // gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().DOFade(1,fadeTime);
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().DOFade(0,fadeTime);
        // gameObject.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }
    
}
