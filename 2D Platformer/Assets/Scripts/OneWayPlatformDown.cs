using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatformDown : MonoBehaviour
{
    private GameObject currentPlatform;
    [SerializeField] private BoxCollider2D playerCollider;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("SemiSolidPlatform"))
        {
            currentPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.CompareTag("SemiSolidPlatform"))
        {
            currentPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }


}
