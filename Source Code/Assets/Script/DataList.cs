using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DataListed",menuName ="DataList", order =1)]

public class DataList : ScriptableObject {

    [Header("Sprite List")]
    public Sprite[] sprite;


    [Header("Audio List")]
    public AudioClip[] sfx;


    [Header("Data Level List")]
    public LevelData[] levelData;
}

[System.Serializable]
public class LevelData
{
    public int MaxKill;
}
