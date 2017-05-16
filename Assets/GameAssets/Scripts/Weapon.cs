using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    // Daño del arma por disparo
    public float damage = 1;

    // Daño que hace el arma por disparo crítico
    public float criticalDamage = 2;

    // Munición total del arma
    // public int maxAmmo;
    // Munición actual del arma
    [System.NonSerialized]
    public int currentAmmo;
    // Munición máxima por cargador
    public int maxClipAmmo;

    // Cadencia del arma
    // Tiempo por cada disparo
    public float firerate = 0.4f;

    // Tiempo que el soldado tarda en recargar el arma
    public float reloadTime = 0.5f;



    // Use this for initialization
    void Start()
    {
        currentAmmo = maxClipAmmo;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootAtTarget(string soldierName, Soldier target, float accuracy, float criticalChance)
    {
        currentAmmo--;

        if (Random.value <= accuracy)
        {
            if (Random.value <= criticalChance)
            {
                target.GetDamage(criticalDamage);
                Debug.Log("¡Golpe crítico!: " + target.name + " se queda con " + target.life + " puntos de vida");
            }
            else
            {
                target.GetDamage(damage);
                Debug.Log("Golpe normal: " + target.name + " se queda con " + target.life + " puntos de vida");
            }

            if (target.life <= 0)
            {
                Debug.Log(soldierName + " ha matado a " + target.name);
            }
        }
        else
        {
            Debug.Log(soldierName + " ha fallado el disparo");
        }
    }

    public void Reload()
    {
        Debug.Log("Recargando " + this.name + "...");
        currentAmmo = maxClipAmmo;
    }
}
