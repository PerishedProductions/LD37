using LD37.GameLevels;
using LD37.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;

namespace LD37.UI
{
    class MainGameCanvas : UICanvas
    {

        UIButton openMenu;
        UIPanel mainPanel;
        UIPanel machinePanel;

        UIButton[] machines = new UIButton[3];

        UIButton imp;
        UIButton res;

        int windowWidth = 1280;
        int windowHeight = 720;
        int padding = 5;

        int menuBtnW = 100;
        int menuBtnH = 50;

        int impW = 200;
        int impH = 50;

        int resW = 155;
        int resH = 50;

        int machinePanelW = 650;
        int machinePanelH = 45;

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            openMenu = (UIButton)CreateUIElement(new UIButton("Menu", new Rectangle(windowWidth - menuBtnW, windowHeight - menuBtnH, menuBtnW, menuBtnH), new Vector2(10, 5)));
            mainPanel = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(0, windowHeight - menuBtnH, windowWidth - menuBtnW, menuBtnH)));
            mainPanel.visible = false;

            imp = (UIButton)mainPanel.CreateUIElement(new UIButton("Import Elf", new Rectangle(0 + padding, windowHeight - impH, impW, impH), new Vector2(10, 5), WindowTheme.Light));
            res = (UIButton)mainPanel.CreateUIElement(new UIButton("Research", new Rectangle(impW + padding * 2, windowHeight - resH, resW, resH), new Vector2(10, 5), WindowTheme.Light));

            machinePanel = (UIPanel)mainPanel.CreateUIElement(new UIPanel(new Rectangle(windowWidth - machinePanelW - menuBtnW - padding, windowHeight - machinePanelH, machinePanelW, machinePanelH), WindowTheme.Light));
        }

        public override void Update(GameTime gameTime)
        {
            if (openMenu.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("ButtonPressed");
                mainPanel.visible = !mainPanel.visible;
            }

            base.Update(gameTime);
        }
    }
}
