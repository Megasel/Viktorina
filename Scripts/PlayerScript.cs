using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public int score;
    public int health;
    public GameObject[] hearts;
    public Text textScore;
    public Animator anim;
    public GameObject gameOverPanel;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage()
    {
        
        anim.SetTrigger("isFalse");
        health--;
        textScore.text = "ОЧКИ: " + score.ToString();
        if (health == 0)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("проиграл");
        }
        hearts[health].SetActive(false);

    }
}
