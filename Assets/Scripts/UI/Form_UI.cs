using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Form_UI : MonoBehaviour
{
    public GameObject[] questionGroupArr;
    public TMP_InputField inputEmail;
    public QuestionAnswer[] qaArr;
    public GameObject APIHelper;
    private string email = "generic";

    // Start is called before the first frame update
    void Start()
    {
        qaArr = new QuestionAnswer[questionGroupArr.Length];
    }

    public void SubmitAnswer()
    {
        for(int i=0; i < qaArr.Length; i++)
        {
            qaArr[i] = ReadQuestionAnswer(questionGroupArr[i]);
        }

        APIHelper.GetComponent<APIHelper>().SendData(email, qaArr);
    }

    QuestionAnswer ReadQuestionAnswer(GameObject questionGroup)
    {
        QuestionAnswer result = new QuestionAnswer();
        GameObject q = questionGroup.transform.Find("Question").gameObject;
        GameObject a = questionGroup.transform.Find("Answer").gameObject;
        email = inputEmail.text;
        result.Question = q.GetComponent<TextMeshProUGUI>().text;
        result.Answer = a.GetComponent<TMP_InputField>().text;
        return result;
    }

    [System.Serializable]
    public class QuestionAnswer
    {
        public string Question = "";
        public string Answer = "";
    }
}
