using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class LegacyLauncher : MonoBehaviour
{
    public WeaponSO weapon;

    string sendURL = "http://zdayscott.pythonanywhere.com/SendWeapon/GametoServer";
    string getURL = "http://zdayscott.pythonanywhere.com/PrintData";

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
        using (UnityWebRequest www = UnityWebRequest.Get(getURL))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public void GetDataS()
    {
        StartCoroutine(GetData());
    }
}
