using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerStatsController : MonoBehaviour
    {
        private Slider[] sliders;
        public PlayerController player;

        void Start()
        {
            sliders = GetComponentsInChildren<Slider>();
            UpdateSliders();
        }

        void Update()
        {
            UpdateSliders();
        }

        private void UpdateSliders()
        {
            foreach(var slider in sliders)
            {
                switch(slider.name) {
                    case "RestSlider":
                        slider.value = 20 - player.PlayerStats.PlTired;
                        break;
                    case "JoySlider":
                        slider.value = player.PlayerStats.PlJoy;
                        break;
                    case "HungerSlider":
                        slider.value = player.PlayerStats.PlHunger;
                        break;
                    case "KnowledgeSlider":
                        slider.value = player.PlayerStats.PlKnow;
                        break;
                    default:
                        throw new Exception("woah");
                }
            }
        }
    }
}
