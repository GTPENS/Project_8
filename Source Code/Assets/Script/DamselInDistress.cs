using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamselInDistress : MonoBehaviour {

    public GameObject damsel, start, end, TheDamsels;
    public float speed = 6f;
    public bool status;

	// Use this for initialization
	void Start () {
        InvokeRepeating("GenerateDamsel", 1f, 5f);
	}

    void Update()
    {
        GameObject e;
        if(TheDamsels.transform.childCount > 0)
        {
            for (int i = 0; i < TheDamsels.transform.childCount; i++)
            {
                e = TheDamsels.transform.GetChild(i).gameObject;
                MoveTheDamsel(e);
                if(e.transform.position.x >= 15)Destroy(e);
            }
        }
    }

    void MoveTheDamsel(GameObject e)
    {
        if (status)e.transform.position += Vector3.right * (Time.deltaTime * speed);
    }

    void GenerateDamsel()
    {
        GameObject the_damsel = Instantiate(damsel, start.transform.position, Quaternion.identity);
        the_damsel.transform.parent = TheDamsels.transform;
        the_damsel.transform.position.Set(the_damsel.transform.position.x, the_damsel.transform.position.y,-30f);
    }

}
