using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private CardInfo cardInfo;
    
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI dmgText;
    [SerializeField] private TextMeshProUGUI manaText;
    [SerializeField] private Image artSprite;

    private void Start()
    {
      DisplayInfo();
      StartCoroutine(SetImage());
    }

    private IEnumerator SetImage()
    {
        yield return cardInfo.DownloadImage();
        artSprite.sprite = cardInfo.image;
    }

    public void DisplayInfo()
    {
        titleText.text = cardInfo.title;
        descriptionText.text = cardInfo.description;
        hpText.text = cardInfo.hp.ToString();
        dmgText.text = cardInfo.dmg.ToString();
        manaText.text = cardInfo.mana.ToString();
    }
}
