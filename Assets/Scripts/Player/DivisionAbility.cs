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

        if (obj != null)
        {
            print("to sim");
            obj.transform.Translate(divisionDir * 2 * Time.deltaTime);
        }
    }
    private void Shoot()
    {
        StartCoroutine(nameof(DivideCooldown));
        divisionDir = -(transform.position - mouseHit.point);
        divisionDir.y = 0;
        obj = Instantiate(divisionProjectile, transform.position, Quaternion.identity);
    }

    IEnumerator DivideCooldown()
    {
       isOnCooldown = true;
       yield return new WaitForSeconds(divisionCooldownTime);
       isOnCooldown = false;
    }
}
