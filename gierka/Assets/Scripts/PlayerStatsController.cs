using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerStatsController : MonoBehaviour
    {
        public PlayerStats player;

        void Start()
        {
            UpdateSliders();
        }

        void Update()
        {
            UpdateSliders();
        }

        private void UpdateSliders()
        {
            Slider[] sliders = GetComponentsInChildren<Slider>();

            foreach(var slider in sliders)
            {
                switch(slider.name) {
                    case "RestSlider":
                        slider.value = 20 - player.PlTired;
                        break;
                    case "JoySlider":
                        slider.value = player.PlJoy;
                        break;
                    case "HungerSlider":
                        slider.value = player.PlHunger;
                        break;
                    case "KnowledgeSlider":
                        slider.value = player.PlKnow;
                        break;
                    default:
                        throw new Exception("woah");
                }
            }
        }
    }
}
