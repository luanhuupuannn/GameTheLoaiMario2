using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

public class Login : MonoBehaviour
{
    public InputField i_username, i_password;
    private string apiUrl = "http://localhost:3000/api/checklogin";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void checkLogin()
    {
        var u = i_username.text;
        var p = i_password.text;
        string jsonData = "{\"username\":\"" + u + "\",\"password\":\"" + p + "\"}";
        StartCoroutine(PostRequest(jsonData));


    }
    IEnumerator GetDataFromAPI()
    {
        // Tạo request để gọi API
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);

        // Gửi request và đợi phản hồi
        yield return request.SendWebRequest();

        // Kiểm tra xem có lỗi không
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi khi gọi API: " + request.error);
        }
        else
        {
            // Lấy dữ liệu từ phản hồi của API
            string responseData = request.downloadHandler.text;

            // Xử lý dữ liệu ở đây
            Debug.Log("Dữ liệu từ API: " + responseData);
        }
    }
    IEnumerator PostRequest(string jsonData)
    {
        // Tạo request
        using (UnityWebRequest request = new UnityWebRequest(apiUrl, "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            // Gửi dữ liệu JSON
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            // Đợi phản hồi từ server
            yield return request.SendWebRequest();

            // Kiểm tra lỗi
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                // Xử lý phản hồi thành công

              //  Debug.Log("Response: " + request.downloadHandler.text);
                string responseJson = request.downloadHandler.text;
                Debug.Log("Response: " + responseJson);
                try
                {
                    var responseObject = JsonUtility.FromJson<ResponseObject>(responseJson);

                    if (responseObject.status == 200)
                    {
                        // Load Scene 1 (assuming you have a scene named "Scene_1")
                        SceneManager.LoadScene(1);
                    }
                    else
                    {
                        Debug.LogWarning("API response status is not 200: " + responseObject.status);
                    }
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Error parsing JSON response: " + e.Message);
                }



            }
            request.Dispose();
        }
    }

    public class ResponseObject
    {
        public int status; // Replace with the actual property name in your response
        // Add other relevant properties if needed
    }
   
}

class userData
{

}
