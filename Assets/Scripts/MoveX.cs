using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveX : MonoBehaviour
{
    public SpriteRenderer projectileSprite;
    [SerializeField] private float speed = 100f;
    [SerializeField] private Rigidbody2D body;


    public void AddVelocity(bool isLeft, Vector3 force) 
    {
        if(isLeft)
        {
            body?.AddForce(-force * speed, ForceMode2D.Impulse);
        }
        else body?.AddForce(force * speed, ForceMode2D.Impulse);
    }

    public void FadeProjectile() => projectileSprite?.DOFade(0.0f, 0.2f).SetEase(Ease.OutQuad).OnComplete(() => DestroyProjectile());
    private void DestroyProjectile() => Destroy(this.gameObject);

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.transform.tag != "Sticky") 
        {
            FadeProjectile();
            body.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
