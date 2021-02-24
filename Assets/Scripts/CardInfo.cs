using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class CardInfo : MonoBehaviour
{
    public string title;
    public string description;
    public int hp;
    public int dmg;
    public int mana;
    public Sprite image;
    
    private const string URL = "https://picsum.photos/320/280";

    private void Awake()
    {
        hp = Random.Range(1, 20);
        dmg = Random.Range(1, 20);
        mana = Random.Range(1, 20);
    }

    public IEnumerator DownloadImage() 
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(URL);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            image = Sprite.Create(texture, new Rect(0.0f, 0.0f, 320, 280), new Vector2(0.5f, 0.5f));
        }
    }
}
