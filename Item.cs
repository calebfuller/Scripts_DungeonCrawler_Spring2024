using System.Collections;
using UnityEngine;
using UnityEngine.Networking;  // Required for UnityWebRequest
using UnityEngine.UI;         // Required for UI elements like Text

public class pokemonAPI : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetRequest("https://pokeapi.co/api/v2/ability/?offset=0&limit=2000"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
     
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                // Show results as text
                print(webRequest.downloadHandler.text);
                // Or retrieve results as binary data
                //byte[] results = webRequest.downloadHandler.data;
            }
        }
    }
}
