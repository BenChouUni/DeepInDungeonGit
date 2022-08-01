using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public int id;
    public string name;
    public string cardDescription;
    
    

    public Card(int _id, string _name,string _description)
    {
        this.id = _id;
        this.name = _name;
        this.cardDescription = _description;
      
        
    }
}


