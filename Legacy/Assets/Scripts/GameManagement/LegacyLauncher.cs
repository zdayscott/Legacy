using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class LegacyLauncher : MonoBehaviour
{
    public WeaponSO weapon;

    string sendURL = "http://127.0.0.1:5000/SendWeapon/GametoServer";
    string getURL = "http://127.0.0.1:5000/PrintData";

    IEnumerator SendData()
    {
        WWWForm form = new WWWForm();
        string jsonStr = JsonUtility.ToJson(weapon, true);
        //form.AddField("x", jsonStr);

        var uwr = new UnityWebRequest(sendURL, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonStr);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.chunkedTransfer = false;

        yield return uwr.SendWebRequest();

       // using (UnityWebRequest www = UnityWebRequest.Post(sendURL, form))
      //  {
       //     www.chunkedTransfer = false;
        //    yield return www.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                Debug.Log("Form upload complete! Recieved: " + uwr.downloadHandler.text);
            }
       // }
    }

    public void SendWeapon()
    {
        StartCoroutine(SendData());
    }

    IEnumerator GetData()
    {
        WWW www = new WWW(getURL);
        yield return www;
    }
}
