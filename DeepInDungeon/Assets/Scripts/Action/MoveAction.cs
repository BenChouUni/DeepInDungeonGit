using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class MoveAction
{
    [Serializable]
    public class BaseAction
    {
        public int id;
        public int parameter;
    }
    [Serializable]
    public class ApplyAction
    {
        public int stateID;
        public int layer;
    }
    [Serializable]
    public class GainAction
    {
        public int stateID;
        public int layer;
    }
    /*
    public List<BaseAction> baseActions;
    public List<ApplyAction> applyActions;
    public List<GainAction> gainActions;
    */
}
