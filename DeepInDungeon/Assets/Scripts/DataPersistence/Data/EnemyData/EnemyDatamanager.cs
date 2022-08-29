using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyDatamanager : MonoBehaviour
{
    //各種對應csv，敵人列表，敵人種族對應部位列表，跟該種族全部位列表
    #region
    //全敵人列表
    public TextAsset EnemyList;
    //透過種族以及種族編號尋找部位表
    public TextAsset FindSpeciesParts;
    //各種族的部位表
    public TextAsset TreesPartsList;
    #endregion

    //敵人狀態管理器
    public EnemyStatusManager enemyStatusManager;

    [SerializeField]
    public Enemy enemy;

    // Start is called before the first frame update
    void Awake()
    {
        LoadCertainEnemy(0);
    }

    private TextAsset FindSpeciesPartsList(Species _species)
    {
        switch (_species)
        {
            case Species.Trees:
                return TreesPartsList;

            default:
                return null;
        }

    }


    private List<Part> FindParts(Species _species,int speciesID)
    {
        List<Part> returnParts = new List<Part>();
        //找到對應種族的表
        TextAsset speciesParts = FindSpeciesPartsList(_species);
        //表中需要找到的部位ID
        List<int> partsIDs = new List<int>();
       
        string[] dataRow = FindSpeciesParts.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0].Trim() == _species.ToString())
            {
                if (rowArray[1].Trim() == speciesID.ToString())
                {
                    for (int i = 2; i < rowArray.Length; i++)
                    {
                        partsIDs.Add(int.Parse(rowArray[i]));
                        
                    }
                }
                
            }

        }
        //由小排到大
        partsIDs.Sort();

        //找到所對應部位
        string[] partsRow = speciesParts.text.Split('\n');
        foreach (var row in partsRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[1].Trim() == "id")
            {
                continue;
            }
            if (rowArray[1].Trim() == partsIDs[0].ToString())
            {
                string _name = rowArray[2];
                int _maxHp = int.Parse(rowArray[3]);
                PartType _partType = Part.FindPartTypeByText(rowArray[4].Trim());

                Part part = new Part(_name,_maxHp,_partType);
                //將部位加入部位列表
                Debug.Log(part.name + "加入");
                returnParts.Add(part);
                //刪掉partID第一個，才能往下檢索
                partsIDs.RemoveAt(0);
                

            }
            //如果partID找完了可以提前退出
            if (partsIDs.Count == 0)
            {
                return returnParts;
            }

        }

        return returnParts;
    }

    public void LoadCertainEnemy(int id)
    {
        string[] dataRow = EnemyList.text.Split('\n');
        

        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0].Trim() != id.ToString())
            {
                continue;
            }

            string name = rowArray[1];
            Species species = Enemy.FindSpeciesByText(rowArray[2].Trim());
            int speciesID = int.Parse(rowArray[3]);
            int maxHp = int.Parse(rowArray[4]);
            int atk = int.Parse(rowArray[5]);

            List<Part> parts = FindParts(species, speciesID);

            enemy = new Enemy(id, name, maxHp, atk,species,speciesID,parts); 

        }
        if (enemy.name == null)
        {
            Debug.LogError("找不到敵人");
        }
        else
        {
            enemyStatusManager.enemyStatus = enemy;
        }
        
    }


}
