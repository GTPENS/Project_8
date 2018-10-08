using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamselHeart : MonoBehaviour {

    public GenerateEnemy GE;

    void Start()
    {
        GE = FindObjectOfType<GenerateEnemy>();
    }

    public void OnMouseDown()
    {
        if (GE.worldState == GenerateEnemy.WorldState.run)
        {
            if (GE.bullet > 0)
            {
                GE.bullet--;
               // GE.song.Firebullet();
                GE.Damsel_Kills++;
                GE.song.DamselGetHurt();
                Destroy(this.gameObject);
            }
           // else GE.song.EmptyBullet();
        }
    }
}
