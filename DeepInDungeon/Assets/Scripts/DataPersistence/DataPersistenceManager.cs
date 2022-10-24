using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/// <summary>
///此為singleton
/// </summary>

public class DataPersistenceManager : MonoSingleton<DataPersistenceManager>
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName = "GameData";



    private GameData gameData;

    private List<IDataPersistence> dataPersistencesObjects;

    private FileDataHandler dataHandler;
    
    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogError("Data Persistence Manager More Than One");
        }
        instance = this;

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistencesObjects = FindAllDataPersistencesObject();
        LoadGame();//沒有loaddata會無法載入東西
        //NewGame();//測試用新檔
    }

    private void Start()
    {
        

        //NewGame();//測試用每次都新檔
        
    }

    public void NewGame()
    {
        Debug.Log("start new game");
        this.gameData = new GameData();
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.LoadData(this.gameData);
        }
    }

    public void Savegame()
    {
        
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.SaveData(ref this.gameData);
            Debug.Log("調用到"+dataPersistenceObj.ToString()); 
            
        }

        if (this.gameData.playerWeapon.mainWeapon == null)
        {
            Debug.Log("沒有武器");
        }

      
        //Debug.Log(this.gameData.playerMovesDeck.Count.ToString());
        

        //將資料存成Json
        dataHandler.Save(gameData);
        Debug.Log("遊戲儲存到"+ Application.persistentDataPath);
        
    }


    public void LoadGame()
    {
        Debug.Log("load game");
        //利用data handler讀取資料
        this.gameData = dataHandler.Load();
        //如果沒有東西能夠讀取，則初始化
        if (this.gameData == null)
        {
            Debug.Log("沒有可讀取資料，開始新遊戲");
            NewGame();
        }
        /*
        if (this.gameData.playerStatus == null)
        {
            Debug.Log("生成初始玩家資料");
            this.gameData.playerStatus = new PlayerStatus();
        }
        */
        foreach (IDataPersistence dataPersistenceObj in dataPersistencesObjects)
        {
            dataPersistenceObj.LoadData(this.gameData);
        }
    }


    private List<IDataPersistence> FindAllDataPersistencesObject()
    {
        IEnumerable<IDataPersistence> dataPersistencesObjec = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();//記得object有s

        return new List<IDataPersistence>(dataPersistencesObjec);
    }
}
