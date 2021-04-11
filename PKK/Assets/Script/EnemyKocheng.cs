using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKocheng : MonoBehaviour
{
    public float speed;
    public bool harusGerak;
    public Transform groundCheckPos;
    private bool harusBalik;
    public LayerMask groundLayer;
    public Rigidbody2D rb;
    public Collider2D bodyCollider;

    // Start is called before the first frame update
    void Start()
    {
        harusGerak = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(harusGerak){
            Gerak();
        }
    }


    private void FixedUpdate(){
        if (harusGerak){
            harusBalik = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Gerak(){
        if (harusBalik || bodyCollider.IsTouchingLayers(groundLayer)){
            balik();
        }
        rb.velocity = new Vector2(-speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void balik(){
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
    }

}
