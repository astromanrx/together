using UnityEngine;

public class IsoAnimationController : BB{
    private Animator mAnimator;    
    private float mSpeed =0;

    public enum Animation{
        Melee,
        Idle,
    }


    public float Speed{
        get{
            return mSpeed;
        }

        set{
            mSpeed = value;
            UpdateSpeed(value);
        }
    }

    public void Play(Animation animation){
        switch(animation){
            case Animation.Melee:
                mAnimator.Play("Melee");
                break;
            case Animation.Idle:
                mAnimator.Play("Movement");
                Speed = 0;
                break;
        }
    }

    private void Awake(){
        mAnimator = GetComponent<Animator>();
    }

    private void UpdateSpeed (float value){
        mAnimator.SetFloat("Speed",value);
    }
}
