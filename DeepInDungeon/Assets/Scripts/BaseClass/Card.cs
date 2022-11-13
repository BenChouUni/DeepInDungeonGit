using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public int id;
    public string cardName;
    public string cardDescription;
    
    

    public Card(int _id, string _name,string _description)
    {
        this.id = _id;
        this.cardName = _name;
        this.cardDescription = _description;
      
        
    }
}


