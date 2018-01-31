using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour {

    public enum Instruments
    {
        Keyboard, 
        Ukelele, 
        Triangel, 
        Drum, 
        Vleugel,
        Trumpet,
    }

    public Instruments instruments;

    public UIManager uiManager;

    public bool entered;
    public AudioClip[] instrumentsAudio;
    public AudioSource instrumentAudioSource;

    private void Awake()
    {
        instrumentAudioSource = transform.gameObject.AddComponent<AudioSource>();

       uiManager = GameObject.Find("Managers").GetComponent<UIManager>();
    }

    public void PlayInstrument(AudioClip instrumentsound)
    {
        instrumentAudioSource.clip = instrumentsound;
        instrumentAudioSource.Play();
        StartCoroutine("InstrumentPlaying", instrumentAudioSource.clip);
    }


    private void OnTriggerEnter(Collider other)
    {
        print("boe");
        entered = true;

        uiManager.ShowInstrumentPanel(("Press E to play instrument"), true);
    }

   

    public void Update()
    {
        if (entered == true)
        {
            if (Input.GetButtonDown("ActionButton"))
            {
                switch (instruments)
                {
                    case Instruments.Keyboard:
                        PlayInstrument(instrumentsAudio[0]);
                        break;
                    case Instruments.Ukelele:
                        PlayInstrument(instrumentsAudio[1]);
                        break;
                    case Instruments.Triangel:
                        PlayInstrument(instrumentsAudio[2]);
                        break;
                    case Instruments.Drum:
                        PlayInstrument(instrumentsAudio[3]);
                        break;
                    case Instruments.Vleugel:
                        PlayInstrument(instrumentsAudio[4]);
                        break;
                    case Instruments.Trumpet:
                        PlayInstrument(instrumentsAudio[5]);
                        break;
                }

                
            }
        }
    }

    public IEnumerator InstrumentPlaying(AudioClip a)
    {
        entered = false;
        yield return new WaitForSeconds(a.length);
        entered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        entered = false;

        instrumentAudioSource.Stop();
        uiManager.ShowInstrumentPanel(null, false);
    }
}
