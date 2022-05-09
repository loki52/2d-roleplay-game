using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAimSwing : MonoBehaviour
{
    [SerializeField] SpriteRenderer srMeleePoint1;
    [SerializeField] SpriteRenderer srMeleePoint2;
    [SerializeField] Animator playerAnimator;

    [Space][SerializeField] float rotationTime;
    [SerializeField] float swingDistance;

    float t1;
    float t2;
    float base_t1;
    float base_t2;

    float velocity1;
    float velocity2;

    Vector3 target1;
    Vector3 target2;

    bool swinging1;
    bool swinging2;

    int swing = 1;
    GameObject anchor;

    public bool swingFinished;
    public bool swingStarted;

    MeleeAnimPass animScript;

    public float cooldown = 0.25f;
    public float swingEndCooldown;
    private float lastAttack;
    private float lastSwingEndTime;

    bool firstSwing;

    bool fullFinish;

    private void Start()
    {
        anchor = transform.parent.gameObject;

        animScript = GameObject.Find("MeleeSlashPoint").GetComponent<MeleeAnimPass>();

        srMeleePoint1 = GetComponent<SpriteRenderer>();
        srMeleePoint2.sprite = srMeleePoint1.sprite;
        srMeleePoint2.enabled = false;
        srMeleePoint1.enabled = true;
        base_t1 = this.gameObject.transform.localEulerAngles.z;

        base_t2 = srMeleePoint2.transform.localEulerAngles.z;

        t1 = base_t1;
        t2 = base_t2;

        target1.z = base_t1;
        target2.z = base_t2;

        swingFinished = false;
        swingStarted = false;

        firstSwing = false;



    }

    private void Update()
    {
        if (srMeleePoint2.sprite != srMeleePoint1.sprite)
        {
            srMeleePoint2.sprite = srMeleePoint1.sprite;
        }

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        Vector2 mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(anchor.transform.position);

        if ((worldPosition - anchor.transform.position).x <= 0 && (Time.time - lastSwingEndTime > swingEndCooldown || firstSwing == false))
        {
            //flips the anchor when the mouse x reaches negative
            anchor.transform.localScale = new Vector3(-1, 1, 1);
            mousePos *= -1;
            playerAnimator.SetFloat("Horizontal", -1f);
            //mouse position is also flipped
        }
        else if ((worldPosition - anchor.transform.position).x >= 0 && (Time.time - lastSwingEndTime > swingEndCooldown || firstSwing == false))
        {
            anchor.transform.localScale = Vector3.one;
            playerAnimator.SetFloat("Horizontal", 1f);
        }
        if (Time.time - lastSwingEndTime > swingEndCooldown || firstSwing == false)
        {
            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            Vector3 rot = anchor.transform.eulerAngles;
            rot.z = angle;
            anchor.transform.eulerAngles = rot;
        }

        if (!swinging2)
        {
            target1.z = Mathf.SmoothDamp(target1.z, base_t1, ref velocity1, rotationTime);
            if (Mathf.Abs(base_t1 - target1.z) < 1) swinging1 = false; swingFinished = true;
            {
                transform.localRotation = Quaternion.Euler(target1);
                // swordPoint2.transform.localRotation = Quaternion.Euler(target1 * -1);
            }
        }
        else if (!swinging1)
        {
            target2.z = Mathf.SmoothDamp(target2.z, base_t2, ref velocity2, rotationTime);
            if (Mathf.Abs(base_t2 - target2.z) < 1) swinging2 = false; swingFinished = true;
            {
                srMeleePoint2.transform.localRotation = Quaternion.Euler(target2);
                // transform.localRotation = Quaternion.Euler(target2 * -1);
            }
        }

        if (swingFinished && swingStarted)
        {
            lastSwingEndTime = Time.time;
            swingFinished = false;
            swingStarted = false;
        }

        if (Input.GetMouseButton(0) && Time.time - lastAttack > cooldown)
        {
            animScript.StartCoroutine(animScript.AttackAnim());
            swingSword();
            lastAttack = Time.time;
        }
    }

    public void swingSword()
    {
        firstSwing = true;
        fullFinish = false;
        if (swinging1) return;
        if (swinging2) return;


        swing *= -1;
        swingStarted = true;

        if (swing == 1)
        {

            t1 = base_t1 - swingDistance;
            target1.z = t1;
            srMeleePoint1.enabled = true;
            srMeleePoint2.enabled = false;
            swinging1 = true;
        }
        else if (swing == -1)
        {
            t2 = base_t2 + swingDistance;
            target2.z = t2;
            srMeleePoint1.enabled = false;
            srMeleePoint2.enabled = true;
            swinging2 = true;
        }

    }
    public void resetSword()
    {
        if (swinging1) return;

        swing *= -1;

        if (swing == -1)
        {
            t2 = base_t2 + swingDistance;
            target2.z = t2;
            srMeleePoint1.enabled = false;
            srMeleePoint2.enabled = true;
            swinging2 = true;
        }
    }
}
