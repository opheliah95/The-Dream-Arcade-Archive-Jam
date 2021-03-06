﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : GameplayEvent
{
    [Tooltip("Dialogue sequence played on interaction")]
    public List<Dialogue> dialogues;

    [Tooltip("Examine sound")]
    public SoundData soundData;

    bool hasPlayedOneExamineSound; // make sure only one examine sound is played

    protected override void Execute()
    {
        // play sound if there is any
        if (soundData != null && !hasPlayedOneExamineSound)
        {
            SoundManager.Instance.startPlaySound(soundData);
            hasPlayedOneExamineSound = true;
        }
            
        // register callback on dialogue end so we can notify this event as ended
        DialogueManager.onDialogueEnded += OnDialogueEnded;
        
        DialogueManager.Instance.StartDialogue(dialogues);
    }

    private void OnDialogueEnded()
    {
        // unsubscribe now to avoid duplicate End signal on next dialogue (one-time event)
        DialogueManager.onDialogueEnded -= OnDialogueEnded;
        hasPlayedOneExamineSound = false; // can play the sound again when examine next time
        End();
    }
}
