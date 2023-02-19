using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
 
public class GameScript : MonoBehaviour {

    public Result1 res1;
    public QuestionList[] questions;
    public Text[] answersText;
    public Text qText;
    public GameObject headPanel;
    public Button[] answerBttns = new Button[3];
    public Sprite[] TFIcons = new Sprite[2];
    public Image TFIcon;
    public Text TFText;
    public GameObject myObject;
 
    List<object> qList;
    QuestionList crntQ;
    int randQ;
 
    public void OnClickPlay()
    {
        res1.result11 = 0;
        qList = new List<object>(questions);
        questionGenerate();
        if (!headPanel.GetComponent<Animator>().enabled) headPanel.GetComponent<Animator>().enabled = true;
        else headPanel.GetComponent<Animator>().SetTrigger("In");
    }
    void questionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0,qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.answers);
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
            StartCoroutine(animBttns());
        }
        else
        {
            print("Вы прошли игру");
            TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out");
            headPanel.GetComponent<Animator>().SetTrigger("Out");
        }
    }
    IEnumerator animBttns()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = false;
        int a = 0;
        while (a < answerBttns.Length)
        {
            if (!answerBttns[a].gameObject.activeSelf) answerBttns[a].gameObject.SetActive(true);
            else answerBttns[a].gameObject.GetComponent<Animator>().SetTrigger("In");
            a++;
            yield return new WaitForSeconds(1);
        }
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = true;
        yield break;
    }
    IEnumerator trueOrFalse(bool check)
    {
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = false;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].gameObject.GetComponent<Animator>().SetTrigger("Out");
        qText.gameObject.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(0.5f);
        if (!TFIcon.gameObject.activeSelf) TFIcon.gameObject.SetActive(true);
        else TFIcon.gameObject.GetComponent<Animator>().SetTrigger("In");
        if (check)
        {
            TFIcon.sprite = TFIcons[0];
            TFText.text = "Правильный ответ";
            res1.result11 +=1;
            yield return new WaitForSeconds(1);
            TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out");
            qList.RemoveAt(randQ);

            questionGenerate();
            myObject.SetActive(false);
            yield break;
        }
        else
        {
            TFIcon.sprite = TFIcons[1];
            TFText.text = "Неправильный ответ";
            yield return new WaitForSeconds(1);
            qList.RemoveAt(randQ);

            questionGenerate();
            myObject.SetActive(false);
            yield break;
        }
    }
    public void AnswerBttns(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) StartCoroutine(trueOrFalse(true));
        else StartCoroutine(trueOrFalse(false));
    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[3];
}