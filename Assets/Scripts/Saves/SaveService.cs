using System.Collections;
using UnityEngine;
using YG;

public class SaveData
{
    public int level = 1;
    public float target = 1000;
    public float capital = 100;
    public float deposit = 100;
    public float divident = 0;

    public bool[] lockedDividents = new bool[25];
    public bool[] openRealtyAndBusiness = new bool[25];
    public float[] sumRealtyAndBusiness = new float[25];

    public SaveData()
    {
        for (int i = 0; i < lockedDividents.Length; i++)
        {
            lockedDividents[i] = false;
        }
        for (int i = 0; i < openRealtyAndBusiness.Length; i++)
        {
            openRealtyAndBusiness[i] = false;
        }
        for (int i = 0; i < sumRealtyAndBusiness.Length; i++)
        {
            sumRealtyAndBusiness[i] = 0;
        }
    }

    public static explicit operator SaveData(SavesYG savesYG)
    {
        SaveData data=new SaveData()
        {
            level = savesYG.level,
            target = savesYG.target,
            capital = savesYG.capital,
            deposit = savesYG.deposit,
            divident = savesYG.divident,
        };
        for (int i = 0; i < savesYG.lockedDividents.Length; i++)
        {
            data.lockedDividents[i] = savesYG.lockedDividents[i];
        }
        for (int i = 0; i < savesYG.openRealtyAndBusiness.Length; i++)
        {
            data.openRealtyAndBusiness[i] = savesYG.openRealtyAndBusiness[i];
        }
        for (int i = 0; i < savesYG.sumRealtyAndBusiness.Length; i++)
        {
            data.sumRealtyAndBusiness[i] = savesYG.sumRealtyAndBusiness[i];
        }
        return data;
    }
}

public class SaveService:MonoBehaviour
{
    private const float AutoSaveInterval = 60f;
    private ISaveSystem saveSystem;
    public SaveData Data;

    private void Awake()
    {
        Data = new SaveData();
        saveSystem=new YGSaveSystem();
        if(YandexGame.SDKEnabled==true)
        {
            Load();
            StartCoroutine("AutoSave");
        }
    }

    public void Save()
    {
        saveSystem.Save(Data);
    }

    public void ResetProcess()
    {
        var emptyData = new SaveData();
        saveSystem.Save(emptyData);
        Load();
    }

    private void Load()
    {
        Data=saveSystem.Load();
    }

    private IEnumerator AutoSave()
    {
        while (true)
        {
            Save();
            yield return new WaitForSeconds(AutoSaveInterval);
        }        
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += Load;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= Load;
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
