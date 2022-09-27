using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using static Form_UI;

public class APIHelper:MonoBehaviour 
{
    private string _formDataJson;

    public void SendData(string email, QuestionAnswer[] qa)
    {
        string[] responses = new String[] { "5", "Los contenidos de tarjeta de credito son raris" };
        FormData dataObject = new FormData(email, "SURVEY_1", qa);

        var jsonDataToSend = JsonConvert.SerializeObject(dataObject);
        Debug.Log(jsonDataToSend);
        _formDataJson = jsonDataToSend;
        StartCoroutine("SendFormToServer");
    }
   public IEnumerator SendFormToServer()
    {
       
        string uriToSendData = "https://prkp5zrp2g.execute-api.sa-east-1.amazonaws.com/prod/surveys";
        UnityWebRequest www = new UnityWebRequest(uriToSendData, "POST");
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("x-api-key", "NhHdy3sj7G1yxEjKsdiXD6Wqakyb8QzV8BI1XFhq");
        byte[] rawFightData = Encoding.UTF8.GetBytes(_formDataJson);
        www.uploadHandler = new UploadHandlerRaw(rawFightData);
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();
                 
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    //contiene algunas variables que luego seran convertidas en json para enviar al servidor
    [Serializable]
    public class FormData
    {
        public String id;
        public String formId;
        public QuestionAnswer[] answers;

        public FormData(String id, String formID, QuestionAnswer[] ans)
        {
            this.id = id;
            this.formId = formID;
            this.answers = ans;

        }
    }

}
