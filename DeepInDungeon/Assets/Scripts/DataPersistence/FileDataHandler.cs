using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{


    private string dataDirPath = "";

    private string dataFileName = "";

    public FileDataHandler(string _dataDirPath,string _dataFileName)
    {
        this.dataDirPath = _dataDirPath;
        this.dataFileName = _dataFileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                // 讀取被序列化資料
                string dataLoad = "";
                using(FileStream stream = new FileStream(fullPath,FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataLoad = reader.ReadToEnd();
                    }
                }
                //把序列化資料變回C# object
                loadedData = JsonUtility.FromJson<GameData>(dataLoad);

            }
            catch (Exception ex)
            {
                Debug.LogError("Error occureed when trying to save data to file" + fullPath + "\n" + ex);
            }
        }

        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath,dataFileName);
        try
        {
            //創建檔案要寫到的目錄，如果目錄不存在
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            
            //序列化成為JSON格式
            string dataToStore = JsonUtility.ToJson(data,true);
            
            //將JSON格式存入
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    
                    writer.Write(dataToStore);
                }
            }
            
        }
        catch (Exception ex)
        {
            Debug.LogError("Error occureed when trying to save data to file" + fullPath + "\n" + ex);
        }
    }
}
