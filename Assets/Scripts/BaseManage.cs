using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using DG.Tweening;
using Unity.Mathematics;
using Zenject;

public class BaseManage : MonoBehaviour
{
    #region Fields

    private MakeMoneyCompany _makeMoneyCompany;
    [SerializeField] private UiManage _uiManage;
    [SerializeField] private List<bool> AllCabin;
    [SerializeField] private List<Vector2> AllCabinVector2;
    [SerializeField] private List<CabinScript> allCabinScripts;
    [SerializeField] private GameObject CabinPrefab;
    [SerializeField] private GameObject ParentRef;
    [SerializeField] private const int TimeUpDelay = 6;
    [Inject] private _ImergeService _imergeService;
    [Inject] private IAddService _IAddService;

    #endregion

    // Start is called before the first frame update
    void OnEnable()
    {
        if (_imergeService != null)
        {
            _imergeService.MergeValuei_j += ActionMerge;
            _IAddService.AddAction += ActionAdd;
        }


        GameObject Ref =
            ObjectPooler.Generate(CabinPrefab, CabinPrefab.transform.position, CabinPrefab.transform.rotation);
        //      = ObjectPool.SharedInstance.PoolObjectIns(1);
        Ref.transform.parent = ParentRef.transform;
        Ref.transform.localPosition = AllCabinVector2[0];
        Ref.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
        Ref.transform.localRotation = quaternion.identity;
        Ref.gameObject.SetActive(true);
        allCabinScripts[0] = Ref.GetComponent<CabinScript>();
        AllCabin[0] = true;


        _makeMoneyCompany = new MakeMoneyCompany();
        StartCoroutine("TimeMoneyUp");
    }

    private void OnDisable()
    {
        if (_imergeService != null)
        {
            _imergeService.MergeValuei_j -= ActionMerge;
            _IAddService.AddAction -= ActionAdd;
        }
    }

    public void ActionMerge(int i, int j)
    {
        allCabinScripts[j]._spriteRenderer.DOFade(0, 0.3f);
        allCabinScripts[j].transform.DOMove(allCabinScripts[i].transform.position, 0.3f);
        ObjectPooler.Destroy(allCabinScripts[j].gameObject);
        AllCabin[j] = false;
        allCabinScripts[j] = null;
        allCabinScripts[i].LevelUpMerging();
    }

    public void ActionAdd(int i)
    {
        if (_makeMoneyCompany.Money >= 10)
        {
            GameObject Ref = ObjectPooler.Generate(CabinPrefab, CabinPrefab.transform.position,
                CabinPrefab.transform.rotation);
            Ref.transform.parent = ParentRef.transform;
            Ref.transform.localPosition = AllCabinVector2[i];
            Ref.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            Ref.transform.localRotation = quaternion.identity;
            Ref.gameObject.SetActive(true);
            _makeMoneyCompany.MoneyDown();
            _uiManage.ChangeMoneyTxt(_makeMoneyCompany.Money);
            allCabinScripts[i] = Ref.GetComponent<CabinScript>();
            AllCabin[i] = true;
        }
    }

    IEnumerator TimeMoneyUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeUpDelay);
            _makeMoneyCompany.MoneyUp();
            _uiManage.ChangeMoneyTxt(_makeMoneyCompany.Money);
        }
    }

    public void MergeElemet()
    {
        if (_makeMoneyCompany.Money >= 10)
        {
            _imergeService.MergeElemet(allCabinScripts);
        }
    }


    public void AddElement()
    {
        
        for (int i = 0; i < AllCabin.Count; i++)
        {
            if (!AllCabin[i])
            {
                _IAddService.AddListFunc(AllCabin);
                return;
            }
        }
    }

    // Update is called once per frame
}