/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this Code Monkey project
    I hope you find it useful in your own projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */
 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour {
    
    public event EventHandler OnAnimationLoopedFirstTime;
    public event EventHandler OnAnimationLooped;

    [SerializeField] private Sprite[] frameArray;
    [SerializeField] private float framerate = .1f; // How much time per frame; Default: .1f == 100ms per frame == 10 frames per second

    private int currentFrame;
    private float timer;
    private SpriteRenderer spriteRenderer;
    private bool loop;
    private bool isPlaying;
    private int loopCounter;

    private void Awake() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (frameArray != null) {
            PlayAnimation(frameArray, framerate);
        } else {
            isPlaying = false;
        }
    }

    private void Update() {
        if (!isPlaying) {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= framerate) {
            timer -= framerate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            if (!loop && currentFrame == 0) {
                StopPlaying();
            } else {
                spriteRenderer.sprite = frameArray[currentFrame];
            }

            if (currentFrame == 0) {
                loopCounter++;
                if (loopCounter == 1) {
                    if (OnAnimationLoopedFirstTime != null) OnAnimationLoopedFirstTime(this, EventArgs.Empty);
                }
                if (OnAnimationLooped != null) OnAnimationLooped(this, EventArgs.Empty);
            }
        }
    }

    public void StopPlaying() {
        isPlaying = false;
    }

    public void PlayAnimation(Sprite[] frameArray, float framerate, bool loop = true) {
        this.frameArray = frameArray;
        this.framerate = framerate;
        this.loop = loop;
        isPlaying = true;
        currentFrame = 0;
        timer = 0f;
        loopCounter = 0;
        spriteRenderer.sprite = frameArray[currentFrame];
    }

}
