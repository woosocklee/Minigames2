using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using LitJson;

public class PlayerInfo
{
    public int Number;
    public string Name;
    public double Gold;

    public PlayerInfo(int num, string name, double gold)
    {
        this.Number = num;
        this.Name = name;
        this.Gold = gold;
    }

    

};


public class JSON_Test : MonoBehaviour
{
    // Start is called before the first frame update

    public List<PlayerInfo> playerInfoList;
    void Start()
    {
        playerInfoList = new List<PlayerInfo>();
        playerInfoList.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SavePlayerInfo();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            LoadPlayerInfo();
        }
    }

    public void SavePlayerInfo()
    {
        Debug.Log("Save PlayerInfo");

        playerInfoList.Add(new PlayerInfo(1, "이름1", 1001));
        playerInfoList.Add(new PlayerInfo(1, "이름2", 2001));
        playerInfoList.Add(new PlayerInfo(1, "이름3", 4001));
        playerInfoList.Add(new PlayerInfo(1, "이름4", 8001));
        playerInfoList.Add(new PlayerInfo(1, "이름5", 16001));
        playerInfoList.Add(new PlayerInfo(1, "이름6", 32001));
        playerInfoList.Add(new PlayerInfo(1, "이름7", 64001));


        JsonData infoJson = JsonMapper.ToJson(playerInfoList);
        File.WriteAllText(Application.dataPath + "/Resources/JsonData/PlayerInfoData.json", infoJson.ToString());

    }

    public void LoadPlayerInfo()
    {
        Debug.Log("LoadPlayerInfo");
        if(File.Exists(Application.dataPath + "/Resources/JsonData/PlayerInfoData.json"))
        {
            string jsonString = File.ReadAllText(Application.dataPath + "/Resources/JsonData/PlayerInfoData.json");

            Debug.Log(jsonString);
            JsonData playerData = JsonMapper.ToObject(jsonString);
            ParsingJsonPlayerInfo(playerData);
            
        }
    }

    private void ParsingJsonPlayerInfo(JsonData playerData)
    {
        Debug.Log("ParsingJsonPlayerInfo()");
        for(int i = 0; i < playerData.Count; i++)
        {
            Debug.Log(playerData[i]["Number"]);
            Debug.Log(playerData[i]["Name"]);
            Debug.Log(playerData[i]["Gold"]);

        }
    }
}
