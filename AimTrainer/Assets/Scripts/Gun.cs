using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    private Animator animator;
    private Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cam = Camera.main.transform;
    }

    public void Fire()
    {
        // Start fire animation
        animator.SetTrigger("Fire");

        // ----- Use Raycast to check if the player has hit the target ------ //

        // If nothing has been hit
        RaycastHit hit;
        if (!Physics.Raycast(cam.position, cam.forward, out hit, 250f))
        {
            gameManager.TargetMissed();
            return;
        }

        // If something has been hit but it's not a target
        GameObject hitGo = hit.transform.gameObject;
        if (hitGo.tag != "Target")
        {
            gameManager.TargetMissed();
            return;
        }

        // A target has been hit
        float targetSize = hitGo.GetComponent<Target>().Size;
        gameManager.TargetHit(targetSize);

        Destroy(hitGo);
    }
}
