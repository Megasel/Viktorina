using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestionsAndAnswers : MonoBehaviour
{
    public QuestionList[] questions;
    public Text qText;
    public Text[] answersText;
    List<object> qList;
    QuestionList crntQ;
    int randQ;
    public GameObject WinPanel;
    public GameObject audTrue;
    public GameObject audFalse;
    public GameObject player;
    public Image timeImage;
    float fill = 1f;
    public Text countText;
    int countQuestions = 0;
    bool isWin = false;
    public GameObject music;
    public Text scoreText;
    private void Start()
    {
        qList = new List<object>(questions);
        questionGenerate();
    }
    private void Update()
    {
        if(player.GetComponent<PlayerScript>().health > 0 & isWin == false)
        {
            fill -= Time.deltaTime * 0.07f;
            timeImage.fillAmount = fill;
            if (fill <= 0)
            {
                FalseAnswer();
                fill = 1;
            }
        }
        else
        {
            
            timeImage.fillAmount = 1;
        }
    }
    void questionGenerate()
    {
        if(qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
        else
        {
            scoreText.text = "Î×ÊÈ: " + player.GetComponent<PlayerScript>().score.ToString();
            music.GetComponent<AudioSource>().enabled = false;
            gameObject.GetComponent<AudioSource>().Play();
            isWin = true;
            WinPanel.SetActive(true);
            Debug.Log("Èãðà ïðîéäåíà");
        }       
    }
    public void AnswersButton(int index)
    {
        if(answersText[index].text.ToString() == crntQ.answers[0])
        {
            countQuestions++;
            countText.text = countQuestions.ToString() + "/100";
            fill = 1;
            player.GetComponent<PlayerScript>().score += 3;
            player.GetComponent<PlayerScript>().textScore.text = "Î×ÊÈ: " + player.GetComponent<PlayerScript>().score;
            player.GetComponent<PlayerScript>().anim.SetTrigger("isTrue");
            audTrue.GetComponent<AudioSource>().Play();
            qList.RemoveAt(randQ);
            questionGenerate();
            Debug.Log("true");
        }
        else
        {
            FalseAnswer();
        }
    }
    public void FalseAnswer()
    {
        countQuestions++;
        countText.text = countQuestions.ToString() + "/100";
        player.GetComponent<PlayerScript>().TakeDamage();
        audFalse.GetComponent<AudioSource>().Play();
        qList.RemoveAt(randQ);
        questionGenerate();
        Debug.Log("false");
    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];
}
