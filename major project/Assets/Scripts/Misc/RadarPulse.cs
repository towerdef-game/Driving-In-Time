using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarPulse : MonoBehaviour
{
    private Transform pulseTransform;
    private float range;
    public float maxRange = 300f;
    public float rangeSpeed = 150f;
    private List<Collider2D> alreadyPingedCollider;
    // Start is called before the first frame update
    void Start()
    {
        pulseTransform = transform.Find("Pulse");
        alreadyPingedCollider = new List<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        range += rangeSpeed * Time.deltaTime;
        if(range > maxRange)
        {
            range = 0f;
            alreadyPingedCollider.Clear();
        }

        pulseTransform.localScale = new Vector3(range, range);

        RaycastHit2D[] raycastHit = Physics2D.CircleCastAll(transform.position, range / 2f, Vector2.zero);
        foreach (RaycastHit2D hit2D in raycastHit)
        {
            if (hit2D.collider != null)
            {

                if (!alreadyPingedCollider.Contains(hit2D.collider))
                {
                    alreadyPingedCollider.Add(hit2D.collider);
                    Debug.Log("Hit");
                }
            }
        }
    }
}
