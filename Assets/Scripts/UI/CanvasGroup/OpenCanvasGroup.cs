using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class OpenCanvasGroup : MonoBehaviour
{
    

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeSpeed = 2f;
    [SerializeField] private bool ToOpenCanvas;
    private float targetAlpha;


    void Start()
    {
        targetAlpha = 1f * (ToOpenCanvas ? 1f : 0f);
    }


    public void OpenCanvasFunc() {
        if(canvasGroup.alpha == 1f || canvasGroup.alpha == 0f) {
           StartCoroutine("OpenCanvas");
        }
        
    }

    public IEnumerator OpenCanvas()
    {
        
        
        
        
        while (!Mathf.Approximately(canvasGroup.alpha, targetAlpha))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, targetAlpha, fadeSpeed * Time.deltaTime);
            
            yield return null; // Wait for the next frame
        }
        ConfigCanvasGroup();
        
    }

    void ConfigCanvasGroup() {
        canvasGroup.alpha = targetAlpha; 
        canvasGroup.interactable = ToOpenCanvas;
        canvasGroup.blocksRaycasts = ToOpenCanvas;
    }
}
