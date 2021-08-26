using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] private AnimationCurve JumpAnim;
    [SerializeField] private float JumpTimeDuration;
    [SerializeField] private float JumpHeight;


    private float StartY;
    private bool IsGrounded = true;
    private Coroutine JumpCor = null;


    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {

        if (JumpCor == null)
        {
            JumpCor = StartCoroutine(JumpCoroutine());
        }
        else
        {
            Debug.LogError("[Character] ERROR JumpCor not null. type of JumpCor:" + JumpCor);
        }

    }
    private IEnumerator JumpCoroutine()
    {
        float jumpTimeDuration = JumpTimeDuration;
        StartY = transform.position.y;
        while (jumpTimeDuration > 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
            float delta = Time.fixedDeltaTime;
            float currentAnimationValue = JumpAnim.Evaluate((JumpTimeDuration - jumpTimeDuration) / JumpTimeDuration).RoundTo(3);
            
            transform.position = new Vector3(transform.position.x, StartY + (JumpHeight * currentAnimationValue), transform.position.z);
            jumpTimeDuration -= delta;
            yield return new WaitForSeconds(delta);
        }
        GetComponent<Rigidbody>().velocity = new Vector2(0, -1);
        transform.position = new Vector3(transform.position.x, StartY, transform.position.z);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        OnStayEnter();
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        OnStayEnter();
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        IsGrounded = false;
    }
    private void OnStayEnter()
    {

        if (JumpCor != null)
        {
            if (IsGrounded == false)
            {
                StopCoroutine(JumpCor);
                JumpCor = null;
            }

        }
        IsGrounded = true;
    }
}
