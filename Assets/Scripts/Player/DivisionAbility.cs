using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionAbility : MonoBehaviour
{
    private Vector2 mousePos;
    private Ray mouseRay;
    private RaycastHit mouseHit;

    GameObject obj;
    Vector3 divisionDir;

    [SerializeField] private Player player;

    [SerializeField] private GameObject divisionProjectile;
    [SerializeField] private float divisionCooldownTime;
    private bool isOnCooldown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mouseRay, out mouseHit);


        if (Input.GetMouseButtonDown(0) && !isOnCooldown)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        player.LoseSize(player.GetSize() / 3);

        StartCoroutine(nameof(DivideCooldown));
        divisionDir = -(transform.position - mouseHit.point);
        divisionDir.y = 0;
        obj = Instantiate(divisionProjectile, transform.position, Quaternion.identity);
        DivisionProjectile projectile = obj.GetComponent<DivisionProjectile>();
        projectile.SetProjectileSize(player.GetSize() / 3);
        projectile.SetProjectileDirection(divisionDir);
    }

    IEnumerator DivideCooldown()
    {
       isOnCooldown = true;
       yield return new WaitForSeconds(divisionCooldownTime);
       isOnCooldown = false;
    }
}
