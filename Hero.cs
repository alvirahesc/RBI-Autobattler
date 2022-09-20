using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Characters
{
    //private Transform target;
    //private int heroSpeed = 3;

    //override untuk mengganti tag menjadi enemy
    protected override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
    }

    protected override void Move() //hero mengejar enemy
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy")) //mengecek kontak dengan Enemy
        {
            isColliding = true;
            damager = collision.gameObject.GetComponent<Characters>().atkDamage;
            //healthPoint -= collision.gameObject.GetComponent<Characters>().atkDamage; //perlu ambil data atkDamage dari yang ditabrak
            //Debug.Log(atkDamage + " nabrak hp sisa " + healthPoint);
        }
    }

    protected override void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            isColliding = false;
        }
        
        // jika musuh terakhir terbunuh, maka WIN
        if (GameObject.FindGameObjectWithTag("Enemy") == null) //mengecek kondisi musuh habis
        {
            Upgrade();
        }
    }

    void Upgrade() //menambah serangan hero setelah enemy habis
    {
        atkDamage += 1;
        Debug.Log("win " + atkDamage);
    }
  
}
