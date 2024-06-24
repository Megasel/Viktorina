using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuButton : MonoBehaviour
{
    public AudioSource audSource;
    public AudioClip audClip;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject plScr;
    public void PlaySound()
    {
        audSource.Play();
        Image1.SetActive(true);
        Image2.SetActive(true);
        StartCoroutine(GoToScene());
    }
    IEnumerator GoToScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
    public void rewardedShow(GameObject panel)
    {
        plScr.GetComponent<PlayerScript>().health = 5;
        panel.SetActive(false);
        for(int i = 0;i< plScr.GetComponent<PlayerScript>().hearts.Length; i++)
        {
           plScr.GetComponent<PlayerScript>().hearts[i].SetActive(true);
        }
    }
}
