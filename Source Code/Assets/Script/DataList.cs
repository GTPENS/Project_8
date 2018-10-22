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

    [Header("Background List")]
    public Sprite[] BG;

    [Header("Character Random")]
    public CharacterRandom[] cosplayer;
    public int DropChance;
}

[System.Serializable]
public class LevelData
{
    public int MaxKill;
}

[System.Serializable]
public class CharacterRandom
{
    public Sprite Char;
    public int DropRarity;
}