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
    [SerializeField] private List<bool> AllCabin;//naming issue _allCabin
    [SerializeField] private List<Vector2> AllCabinVector2;//naming issue _allCabinVector2
    [SerializeField] private List<CabinScript> allCabinScripts;//naming issue _allCabinScripts
    [SerializeField] private GameObject CabinPrefab;//naming issue _cabinPrefab
    [SerializeField] private GameObject ParentRef;//naming issue _parentRef
    [SerializeField] private const int TimeUpDelay = 6;//naming issue _timeUpDelay
    [Inject] private _ImergeService _imergeService;//nterface name issue -> why name starts with _ ?!?!
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
        
        //cache Ref.transform in var refTransform=Ref.transform; and use it 
        
        Ref.transform.parent = ParentRef.transform;// use SetParent Func.
        Ref.transform.localPosition = AllCabinVector2[0];
        Ref.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
        Ref.transform.localRotation = quaternion.identity;
        Ref.gameObject.SetActive(true);//ref is a gameobject don't need to .gameObject
        allCabinScripts[0] = Ref.GetComponent<CabinScript>();
        AllCabin[0] = true;


        _makeMoneyCompany = new MakeMoneyCompany();
        StartCoroutine("TimeMoneyUp");//use nameOf() function nstead of use string explicitly
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
        if (_makeMoneyCompany.Money >= 10)//never use magic number => always create const variable with miningfull name for this type of values
        {
            GameObject Ref = ObjectPooler.Generate(CabinPrefab, CabinPrefab.transform.position,
                CabinPrefab.transform.rotation);
            Ref.transform.parent = ParentRef.transform;
            Ref.transform.localPosition = AllCabinVector2[i];
            Ref.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);// same as previous comment
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
            _uiManage.ChangeMoneyTxt(_makeMoneyCompany.Money);// it's better to change ui values with events for exp OnCoinChange - update ui in loop such as update or coroutine will kill performance especialyy with text mesh pro - it renders again every frame you change value
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
