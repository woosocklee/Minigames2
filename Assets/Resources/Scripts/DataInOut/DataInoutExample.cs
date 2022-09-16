using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[System.Serializable]

public class SaveInformation
{
    public string name;
    public float posX;
    public float posY;
    public float posZ;
}


public class DataInoutExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(PlayerPrefs.HasKey("ID"))
            {
                string getID = PlayerPrefs.GetString("ID");
                Debug.Log(string.Format("ID:{0}", getID));
            }
            else
            {
                Debug.Log("저장된 아이디 없음");
            }
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            string setID = "PlayerID";
            PlayerPrefs.SetString("ID", setID);
            Debug.Log("저장된 ID : " + setID);
        }

        
        if(Input.GetKeyDown(KeyCode.C))
        {
            int getscore = PlayerPrefs.GetInt("Score", 100);
            float getExp = PlayerPrefs.GetFloat("Exp", 100.0f);
            string getName = PlayerPrefs.GetString("Name", "None");

            Debug.Log(getscore);
            Debug.Log(getExp);
            Debug.Log(getName);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerPrefs.DeleteKey("ID");
            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Exp");
            PlayerPrefs.DeleteAll();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveBinary();
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CSV_Load();
        }

    }

    void SaveBinary()
    {
        SaveInformation setInfo = new SaveInformation();
        setInfo.name = "Inha";
        setInfo.posX = 0.0f;
        setInfo.posY = 4.0f;
        setInfo.posZ = 8.0f;

        Debug.Log(setInfo.name);
        Debug.Log(setInfo.posX);
        Debug.Log(setInfo.posY);
        Debug.Log(setInfo.posZ);

        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memstream = new MemoryStream();
        formatter.Serialize(memstream, setInfo);
        byte[] bytes = memstream.GetBuffer();
        string memStr = Convert.ToBase64String(bytes);

        Debug.Log(memStr);

        PlayerPrefs.SetString("SaveInformation", memStr);


        //Load 파츠
        string getInfos = PlayerPrefs.GetString("SaveInformation", "None");
        Debug.Log("Load: " + getInfos);
        byte[] getBytes = Convert.FromBase64String(getInfos);
        MemoryStream getMemstream = new MemoryStream(getBytes);
        BinaryFormatter formatter2 = new BinaryFormatter();
        SaveInformation getInformation = (SaveInformation)formatter2.Deserialize(getMemstream);

        Debug.Log(getInformation.name);
        Debug.Log(getInformation.posX);
        Debug.Log(getInformation.posY);
        Debug.Log(getInformation.posZ);

    }

    void CSV_Load()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Scripts/DataInOut/ItemData");
        Debug.Log("LoadingStart");
        for (var i = 0; i < data.Count; i++)
        {
            print("ID : " + data[i]["ID"] + " ");
            print("Name : " + data[i]["Name"] + " ");
            print("Description : " + data[i]["Description"] + " ");
            print("AttackPower : " + data[i]["AttackPower"] + " ");
            print("DefensePower : " + data[i]["DefensePower"] + " ");
            print("Durability : " + data[i]["Durability"] + " ");
        }
    }
}
