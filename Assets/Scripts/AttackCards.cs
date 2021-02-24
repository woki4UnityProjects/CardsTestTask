using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCards : MonoBehaviour
{
  [SerializeField] private Transform hand;
  private List<CardInfo> _children = new List<CardInfo>();
  
  public void Attack()
  {
    _children.Clear();
    int childCount = hand.childCount;
    
    for (int i = 0; i < childCount; i++)
    {
      CardInfo cardInfo = hand.GetChild(i).GetComponent<CardInfo>();
      _children.Add(cardInfo);
    }
    StartCoroutine(DoAttack());
  }

  private IEnumerator DoAttack()
  {
    foreach (CardInfo cardInfo in _children)
    {
      int rnd = Random.Range(0, 3);

      switch (rnd)
      {
        case 0:
          MinusDamage(cardInfo);
          break;
        case 1:
          MinusHealth(cardInfo);
          break;
        case 2:
          MinusMana(cardInfo);
          break;
      }
      
      cardInfo.GetComponent<CardDisplay>().DisplayInfo();
      
      if (cardInfo.hp <= 0)
      {
        Destroy(cardInfo.gameObject);
      }
      
      yield return new WaitForSeconds(0.25f);
    }
  }

  private void MinusDamage(CardInfo cardInfo)
  {
    cardInfo.dmg = Random.Range(2, 9);
  }

  private void MinusHealth(CardInfo cardInfo)
  {
    cardInfo.hp -= Random.Range(2, 9);
  }

  private void MinusMana(CardInfo cardInfo)
  {
    cardInfo.mana -= Random.Range(2, 9);
  }
}
