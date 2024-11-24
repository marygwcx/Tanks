using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isPlayer1 = true;
    [Header("Movement")]

    public float speed = 10;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    private object other;

    private void Start()
    {
        InvokeRepeating("Shoot", 0, fireRate);
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
    }

    void Update()
    {

        var input = new Vector3();

        if (isPlayer1)
        {
            input.x = Input.GetAxis("HorizontalKeys");
            input.z = Input.GetAxis("VerticalKeys");
        }
        else
        {
            input.x = Input.GetAxis("HorizontalArrows");
            input.z = Input.GetAxis("VerticalArrows");
        }

        transform.position += input * speed * Time.deltaTime;

        if (input != Vector3.zero)
        {
            transform.forward = input;
        }

    }
    private void ChangeScene()
    {
        var health = gameObject.GetComponent<Health>();
        if (isPlayer1 && Convert.ToInt32(health) == 0)
        {
            SceneManager.LoadScene("EndGame");
        }
        else if (!isPlayer1 && Convert.ToInt32(health) == 0)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
