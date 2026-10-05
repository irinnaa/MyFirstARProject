using UnityEngine;
using Vuforia;

public class CactiAttack : MonoBehaviour
{
    public Transform firstCactus;
    public Transform secondCactus;
    public Animator firstAnimation;
    public Animator secondAnimation;

    public ObserverBehaviour firstImageTarget;
    public ObserverBehaviour secondImageTarget;

    public float attackDistance = 0.25f;

    void Update()
    {
        if (firstCactus != null && secondCactus != null && firstImageTarget != null && secondImageTarget != null)
        {
            bool isFirstTargetFound = firstImageTarget.TargetStatus.Status == Status.TRACKED || firstImageTarget.TargetStatus.Status == Status.EXTENDED_TRACKED;
            bool isSecondTargetFound = secondImageTarget.TargetStatus.Status == Status.TRACKED || secondImageTarget.TargetStatus.Status == Status.EXTENDED_TRACKED;

            if (isFirstTargetFound && isSecondTargetFound)
            {
                float distance = Vector3.Distance(firstCactus.position, secondCactus.position);

                if (distance < attackDistance)
                {
                    firstAnimation.SetBool("isAttacking", true);
                    secondAnimation.SetBool("isAttacking", true);
                }
                else
                {
                    firstAnimation.SetBool("isAttacking", false);
                    secondAnimation.SetBool("isAttacking", false);
                }
            }
            else
            {
                firstAnimation.SetBool("isAttacking", false);
                secondAnimation.SetBool("isAttacking", false);
            }
        }
    }
}