using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Beat : MonoBehaviour
{
    private float startBeat;
    private float anticipationBeats;

    private Animator animator;

    private Conductor conductor;

    public void Init(float startBeat, float anticipationBeats)
    {
        this.startBeat = startBeat;
        this.anticipationBeats = anticipationBeats;
    }

    // Start is called before the first frame update
    void Start()
    {

        conductor = GameObject.FindWithTag("Music Player").GetComponent<Conductor>();
        
        //Load the animator attached to this object
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (conductor.getSongPositionInBeats() >= startBeat - anticipationBeats && conductor.getSongPositionInBeats() <= startBeat)
        {
            float percentLeft = 1 - (startBeat - conductor.getSongPositionInBeats())/anticipationBeats;
            
            //Start playing the current animation from wherever the current conductor loop is
            animator.Play("Launch", -1, percentLeft);
            //Set the speed to 0 so it will only change frames when you next update it
            animator.speed = 0;
        }

        if (conductor.getSongPositionInBeats() > startBeat)
        {
            animator.Play("Drop");
            
            animator.speed = 1;
        }
    }
}