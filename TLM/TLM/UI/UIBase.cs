using ColossalFramework.UI;
using TrafficManager.TrafficLight;
using UnityEngine;

namespace TrafficManager.UI
{
    public class UIBase : UICustomControl
    {
        private bool _uiShown;

        public UIBase()
        {
            // Get the UIView object. This seems to be the top-level object for most
            // of the UI.
            var uiView = UIView.GetAView();

            // Add a new button to the view.
            var button = (UIButton)uiView.AddUIComponent(typeof(UIButton));

            // Set the text to show on the button.
            button.text = "Traffic Manager Plus";

            // Set the button dimensions.
            button.width = 150;
            button.height = 30;

            // Style the button to look like a menu button.
            button.normalBgSprite = "ButtonMenu";
            button.disabledBgSprite = "ButtonMenuDisabled";
            button.hoveredBgSprite = "ButtonMenuHovered";
            button.focusedBgSprite = "ButtonMenuFocused";
            button.pressedBgSprite = "ButtonMenuPressed";
            button.textColor = new Color32(255, 255, 255, 255);
            button.disabledTextColor = new Color32(7, 7, 7, 255);
            button.hoveredTextColor = new Color32(7, 132, 255, 255);
            button.focusedTextColor = new Color32(255, 255, 255, 255);
            button.pressedTextColor = new Color32(30, 30, 44, 255);

            // Enable button sounds.
            button.playAudioEvents = true;

            // Place the button.
            button.relativePosition = new Vector3(180f, 20f);

            // Respond to button click.
            button.eventClick += ButtonClick;
        }

        private void ButtonClick(UIComponent uiComponent, UIMouseEventParameter eventParam)
        {
            if (!_uiShown)
            {
                Show();
            }
            else
            {
                Close();
            }
        }

        public bool IsVisible()
        {
            return _uiShown;
        }

        public void Show()
        {
            var uiView = UIView.GetAView();

            uiView.AddUIComponent(typeof(UITrafficManager));

            LoadingExtension.Instance.SetToolMode(TrafficManagerMode.TrafficLight);

            _uiShown = true;
        }

        public void Close()
        {
            var uiView = UIView.GetAView();

            var trafficManager = uiView.FindUIComponent("UITrafficManager");

            if (trafficManager != null)
            {
                Destroy(trafficManager);
            }

            UITrafficManager.UIState = UIState.None;
            TrafficLightTool.SetToolMode(ToolMode.None);
            LoadingExtension.Instance.SetToolMode(TrafficManagerMode.None);

            _uiShown = false;
        }
    }
}
