using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    // Puntos de vida actuales del soldado, si llega a 0 o menos, el soldado muere
    public float life = 100;

    // Puntería del soldado, entre 0 y 1
    public float accuracy = 0.5f;

    // Probabilidad de crítico entre 0 y 1
    // [System.NonSerialized] --> Pública solo para scripts, no aparece en el inspector
    public float criticalChance = 0.05f;

    // Referencia al arma del soldado
    // [SerializeField] --> Muestra el campo en el inspector, incluso si es privado
    public Weapon weapon;

    // Soldado objetivo
    public Soldier target;

    // Nombre del soldado enemigo
    public string targetName;

    // El soldado está vivo
    public bool isAlive = true;



    // Use this for initialization
    void Start()
    {
        Soldier target = GameObject.Find(targetName).GetComponent<Soldier>();
        AimAtTarget(target);

        //while(life > 0 && target.life > 0)
        //{
        //    ShootAtTarget(target);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive && target.isAlive)
        {
            // Si aún tenemos munición
            if (weapon.currentAmmo > 0)
            {
                // Disparamos al objetivo
                ShootAtTarget(target);
            }
            else
            {
                // Si no, recargamos el arma
                ReloadWeapon();
            }
        }
    }

    private void AimAtTarget(Soldier target)
    {
        // Miramos al objetivo
        transform.LookAt(target.transform);
    }

    private void ShootAtTarget(Soldier target)
    {
        // Se dispara al objetivo teniendo en cuenta las tiradas de puntería y crítico
        weapon.ShootAtTarget(this.name, target, accuracy, criticalChance);
    }

    private void ReloadWeapon()
    {
        // Llamamos al método Reload del arma para que recargue
        weapon.Reload();
    }

    public void GetDamage(float damage)
    {
        // Restamos vida según el golpe que hemos recibido
        life = life - damage;

        if (life <= 0)
        {
            isAlive = false;
        }
    }
}
