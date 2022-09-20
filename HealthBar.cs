using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //Ambil value health dari Character
    Vector3 localScale;
    public GameObject Characters;
    private Characters character;

    void Start()
    {
        character = Characters.GetComponent<Characters>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //ukuran disesuaikan dengan kebutuhan
        localScale.x = character.healthPoint/100;
        transform.localScale = localScale;
    }
}
