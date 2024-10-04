using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.Events;

public class ServerManager : MonoBehaviour
{
    public string apiUrl = "https://maphis-server.onrender.com/generate_dialog";
    public Dialog dialog;
    public UnityEvent generatingDialogue;
    public UnityEvent dialogueGenerated;
    public UnityEvent answerRight;
    public UnityEvent answerWrong;

    [TextArea]
    public string chatlog = "";

    [System.Serializable]
    public class Dialog
    {
        public string dialog;
        public string[] chatOptions;
    }

    [System.Serializable]
    public class PromptRequest
    {
        public string persona;
        public string chatlog;

        public PromptRequest(string persona, string chatlog)
        {
            this.persona = persona;
            this.chatlog = chatlog;
        }
    }
    private static ServerManager _instance;
    public static ServerManager Instance {
        get {
            return _instance;
        }
    }

    public void GenerateDialog(string persona)
    {
        StartCoroutine(PostRequest(persona));
    }

    private IEnumerator PostRequest(string persona)
    {
        generatingDialogue.Invoke();

        // Create the request body
        PromptRequest promptRequest = new PromptRequest(persona, chatlog);
        string jsonData = JsonConvert.SerializeObject(promptRequest);

        // Create a UnityWebRequest and set it up as a POST request
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Send the request and wait for the response
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Parse the response
            string jsonResponse = request.downloadHandler.text;
            dialog = JsonConvert.DeserializeObject<Dialog>(jsonResponse);

            chatlog += "\n";
            chatlog += "YOU: " + dialog.dialog;

            dialogueGenerated.Invoke();
        }
        else
        {
            // Log the error if the request failed
            Debug.LogError("Request Error: " + request.error);
        }
    }
}
