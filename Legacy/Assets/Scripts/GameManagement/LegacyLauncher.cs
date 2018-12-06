using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class LegacyLauncher : MonoBehaviour
{
    public WeaponSO weapon;

    string sendURL = "http://zdayscott.pythonanywhere.com/SendWeapon/GametoServer";
    string getURL = "http://zdayscott.pythonanywhere.com/GetChain";
    string getWeaponURL = "http://zdayscott.pythonanywhere.com/GetWeapon";

    IEnumerator SendData(LegacyWeaponSO wep)
    {

        string jsonStr = JsonUtility.ToJson(wep, true);

        var uwr = new UnityWebRequest(sendURL, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonStr);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        uwr.chunkedTransfer = false;

        yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                Debug.Log("Form upload complete! Recieved: " + uwr.downloadHandler.text);
            }
    }

    public void SendWeapon(LegacyWeaponSO wep)
    {
        if(wep != null)
        {
            StartCoroutine(SendData(wep));
        }
    }

    IEnumerator GetData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(getURL))
        {
            yield return www.SendWebRequest();

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

    IEnumerator GetWeapon()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(getURL))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                yield return null;
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
                yield return JsonUtility.FromJson<LegacyWeaponSO>(System.Text.Encoding.UTF8.GetString(results));
            }
        }
    }



    public class CoroutineWithData
    {
        public Coroutine coroutine { get; private set; }
        public LegacyWeaponSO result;
        private IEnumerator target;

        public CoroutineWithData(MonoBehaviour owner, IEnumerator target)
        {
            this.target = target;
            this.coroutine = owner.StartCoroutine(Run());
        }

        private IEnumerator Run()
        {
            while(target.MoveNext())
            {
                result = (LegacyWeaponSO)target.Current;
                yield return result;
            }
        }
    }
}
