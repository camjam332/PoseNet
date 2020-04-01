using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class jsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    public string newValue;

    [System.Obsolete]
    void Start()
    {
        // A correct website page.
        if(newValue == "")
        {
            StartCoroutine(GetRequest("http://127.0.0.1:8000/languages/?format=json"));
        }

        else
        {
            //StartCoroutine(SendRequest("http://127.0.0.1:8000/languages/?format=json"));
        }
    }


    [System.Obsolete]
    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.Send();


        Languages languagesInJson = JsonUtility.FromJson<Languages>("{" + "\"" + "languages" + "\"" + ":" + request.downloadHandler.text + "}");

           foreach (Language language in languagesInJson.languages)
           {
               Debug.Log("Found language: " + language.name + " " + language.paradigm);
           }
    }
}
