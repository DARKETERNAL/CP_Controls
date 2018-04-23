using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10F;

    private float timeToAutoDestroy = 1F;

    private Rigidbody rb;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        timeToAutoDestroy = Random.Range(1F, 5F);
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(timeToAutoDestroy);
        Destroy(gameObject);
    }
}