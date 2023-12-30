using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterShooting : MonoBehaviour
{
    public float shootingTerm;
    public float shootingDelay;

    Animator anim;
    public GameObject bulletObj;
    GameObject bullet;

    void Awake()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(ShootPrepare());
    }

    void Update()
    {
        
    }

    IEnumerator ShootPrepare()
    {
        while (true)
        {
            anim.SetTrigger("isAttack");
            Invoke("Shooting", shootingDelay);

            yield return new WaitForSeconds(shootingTerm);
        }
    }
    
    void Shooting()
    {
        bullet = Instantiate(bulletObj, this.transform.position, this.transform.rotation);
    }
}
