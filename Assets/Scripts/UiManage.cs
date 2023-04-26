using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManage : MonoBehaviour
{
    [SerializeField] private Text Money;
    public void ChangeMoneyTxt(int MOneyValue)
    {
        Money.text = MOneyValue.ToString();
    }
}
